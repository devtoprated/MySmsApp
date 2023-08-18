using CoreService.CommonResponseMaker.dto;
using DataService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.UserService.Crud
{
    public interface IUserService
    {
        Task<ResponseModel<UserDataTable>> AddAsync(UserDataTable userDataTable);
        Task<ResponseModel<UserDataTable>> UpdateAsync(UserDataTable userDataTable);
        Task<ResponseModel<UserDataTable>> GetByIdAsync(int id);
        Task<ResponseModel<List<UserDataTable>>> GetAllAsync(Expression<Func<UserDataTable, bool>> predicate = null);
        Task<ResponseModel<UserDataTable>> GetUserByNumber(string number);
    }
}
