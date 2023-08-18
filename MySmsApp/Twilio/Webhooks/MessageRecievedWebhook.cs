using CoreService.UserService.Crud;
using CoreService.UserService.ResponseMaker;
using DataService.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.SqlServer.Server;
using MySmsApp.Twilio.HelperMethods;
using System.Linq;
using System.Text.Json;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Lookups.V2;
using Twilio.TwiML;

namespace MySmsApp.Twilio.Webhooks
{
    public class MessageRecievedWebhook : TwilioController
    {
        private IUserService _users;
        private ISmsReplyService _sms;

        public MessageRecievedWebhook(IUserService users, ISmsReplyService sms)
        {
            TwilioClient.Init("ACf13f42145864bd3aa5d64bf6d77b3e8d", "512b62db20e30f017c7ee3e1d940ecfb");
            _users = users;
            _sms = sms;
        }


        [HttpPost]
        [Route("/MySmsApp/Response")]
        public async Task<TwiMLResult> Index()
        {
            try
            {
                var menuType = HttpContext.Session.GetString("MenuType")??"0";
                Dictionary<string, StringValues> Data = new Dictionary<string, StringValues>(HttpContext.Request.Form); 
                Data["FormattedNumber"] = new StringValues(await PhoneNumberHelper.GetNumberWithoutCode(Data["From"].ToString()));
                var messagingResponse = new MessagingResponse();
                var response = await _sms.GetReply(Data,String.IsNullOrEmpty(menuType)?0:int.Parse(menuType));
                messagingResponse.Message(response.Response);
                HttpContext.Session.SetString("MenuType", response.currentSession.ToString());
                return TwiML(messagingResponse);
            }
            catch (Exception ex)
            {
                return TwiML(new MessagingResponse().Message("Something Went Wrong We Will Contact You Shortly!"));
            }
        }
    }
}
