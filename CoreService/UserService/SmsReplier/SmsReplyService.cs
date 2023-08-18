using CommonService;
using CoreService.UserService.Crud;
using CoreService.UserService.dto;
using CoreService.UserService.ResponseMaker;
using DataService.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CoreService.UserService.SmsReplier
{
    public class SmsReplyService : ISmsReplyService
    {
        private IUserService _users;
        public SmsReplyService(IUserService users)
        {
            _users = users;
        }
        public async Task<SessionModel> GetReply(Dictionary<string,StringValues> formData,int menuType)
        {
            SessionModel res = new SessionModel();
            try
            {
                UserDataTable user = await GetUserByPhoneNumber(formData);
                if (user == null)
                {
                    res.Response = $"Please register on our platform.";
                    res.currentSession = menuType;
                    return res;
                }
                int.TryParse(formData["Body"].ToString(), out int body);
                if ((int)UserRequests.MenuTypes.Language == menuType && body == (int)UserRequests.LanguageMenuOptions.English)
                {
                    res.Response = TemplateHelper.GetDetailsMenu();
                    res.currentSession = menuType + 1;
                    return res;
                }
                else if ((int)UserRequests.MenuTypes.Language == menuType && body == (int)UserRequests.LanguageMenuOptions.Hindi)
                {
                    res.Response = "Currently working on hindi.";
                    res.currentSession = menuType + 1;
                    return res;
                }
                else if ((int)UserRequests.MenuTypes.Language == menuType && body == (int)UserRequests.LanguageMenuOptions.Punjabi)
                {
                    res.Response = $"Currently working on Punjabi.";
                    res.currentSession = menuType + 1;
                    return res;
                }
                else
                {
                    res.Response = $"Hi {user.Name}!\nChoose language:\n1.English\n 2.Hindi\n 3.Punjabi";
                    res.currentSession = menuType + 1;
                    return res;
                }

            }
            catch(Exception ex)
            {
                res.Response = $"Some Error Occured!";
                res.currentSession = menuType;
                return res;
            }
           
        }

        private async Task<UserDataTable> GetUserByPhoneNumber(Dictionary<string, StringValues> formData)
        {
            try
            {
                string number = formData["FormattedNumber"].ToString();
                var user = await _users.GetUserByNumber(number);
                return user.entity;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
