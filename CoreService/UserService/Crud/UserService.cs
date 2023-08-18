using Azure;
using CommonService;
using CoreService.CommonResponseMaker.dto;
using DataService.Entities;
using DataService.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.UserService.Crud
{
    public class UserService : IUserService
    {
        private IRepository<UserDataTable> _users;
        private TwilioAppContext _appContext;
        public UserService(IRepository<UserDataTable> users, TwilioAppContext appContext)
        {
            _users = users;
            _appContext = appContext;
        }
        public async Task<ResponseModel<UserDataTable>> AddAsync(UserDataTable userDataTable)
        {
            try
            {
                var Data = await _users.AddAsync(userDataTable);
                return CommonResponseMaker.Response<UserDataTable>.Success("Success", Data);
            }
            catch(Exception ex)
            {
                return CommonResponseMaker.Response<UserDataTable>.InternalServerError(ex.Message);
            }
        }

        public async Task<ResponseModel<List<UserDataTable>>> GetAllAsync(Expression<Func<UserDataTable, bool>> predicate = null)
        {
            try
            {
                var Data = await _users.GetAllAsync(predicate);
                return CommonResponseMaker.Response<List<UserDataTable>>.Success("Success", Data);
            }
            catch (Exception ex)
            {
                return CommonResponseMaker.Response<List<UserDataTable>>.InternalServerError(ex.Message);
            }
        }

        public async Task<ResponseModel<UserDataTable>> GetByIdAsync(int id)
        {
            try
            {
                var Data = await _users.GetByIdAsync(id);
                return CommonResponseMaker.Response<UserDataTable>.Success("Success", Data);
            }
            catch (Exception ex)
            {
                return CommonResponseMaker.Response<UserDataTable>.InternalServerError(ex.Message);
            }
        }

        public async Task<ResponseModel<UserDataTable>> GetUserByNumber(string number)
        {
            try
            {
                var response = await _appContext.UserDataTables.FirstOrDefaultAsync(x => x.Phone == number);
                return CommonResponseMaker.Response<UserDataTable>.Success("Success!", response);
            }
            catch(Exception ex)
            {
                return CommonResponseMaker.Response<UserDataTable>.InternalServerError(ex.Message);
            }
        }

        public async Task<ResponseModel<UserDataTable>> UpdateAsync(UserDataTable userDataTable)
        {
            try
            {
                await _users.UpdateAsync(userDataTable);
                return CommonResponseMaker.Response<UserDataTable>.Success("Success");
            }
            catch (Exception ex)
            {
                return CommonResponseMaker.Response<UserDataTable>.InternalServerError(ex.Message);
            }
        }
    }
}
