using Common.DTOs;
using Dotin.DAL.Context;
using Dotin.DAL.Entities;
using Logic.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class UserService : IUser
    {
        private readonly DatabaseContext _db;

        public UserService(DatabaseContext db)
        {
            _db = db;
        }

        //To Get all user details
        public async Task<OperationResult<List<UserDto>>> GetUsers()
        {
            OperationResult<List<UserDto>> result = new();
            try
            {
                result.Data = await _db.Users.Select(x => new UserDto()
                {
                    UserID = x.UserID,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MobileNumber = x.MobileNumber,
                    Email = x.Email
                }).ToListAsync();
                result.Message = "اطلاعات با موفقیت دریافت شد";
                result.ResponseCode = ResponseCode.Successful;
            }
            catch
            {
                result.Data = new();
                result.Message = "خطا در واکشی اطلاعات";
                result.ResponseCode = ResponseCode.OperationFailed;
            }
            return result;
        }

        //To Add new user record
        public async Task<OperationResult<bool>> AddUser(UserDto model)
        {
            OperationResult<bool> result = new();
            try
            {
                User user = new()
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MobileNumber = model.MobileNumber
                };
                await _db.Users.AddAsync(user);
                if (await _db.SaveChangesAsync() > 0)
                {
                    result.Data = true;
                    result.Message = "کاربر با موفقیت ذخیره شد";
                    result.ResponseCode = ResponseCode.Successful;
                }
                else
                {
                    result.Data = false;
                    result.Message = "ثبت اطلاعات با خطا مواجه شد";
                    result.ResponseCode = ResponseCode.InvalidRequest;
                }
                return result;
            }
            catch
            {
                result.Data = false;
                result.Message = "ثبت اطلاعات با خطا مواجه شد";
                result.ResponseCode = ResponseCode.OperationFailed;
            }
            return result;
        }

        //To Update the records of a particluar user
        public async Task<OperationResult<bool>> UpdateUser(UserDto model)
        {
            OperationResult<bool> result = new();
            try
            {
                User? user = await _db.Users.FindAsync(model.UserID);
                if (user is not null)
                {
                    user.MobileNumber = model.MobileNumber;
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    _db.Users.Update(user);
                }
                else
                {
                    result.Data = false;
                    result.Message = "کاربر یافت نشد";
                    result.ResponseCode = ResponseCode.NoAvailableData;
                    return result;
                }
                if (await _db.SaveChangesAsync() > 0)
                {
                    result.Data = true;
                    result.Message = "کاربر با موفقیت به روز شد";
                    result.ResponseCode = ResponseCode.Successful;
                }
                else
                {
                    result.Data = false;
                    result.Message = "اطلاعاتی از کاربر تغییر پیدا نکرد";
                    result.ResponseCode = ResponseCode.InvalidRequest;
                }
            }
            catch
            {
                result.Data = false;
                result.Message = "ثبت اطلاعات با خطا مواجه شد";
                result.ResponseCode = ResponseCode.OperationFailed;
            }
            return result;
        }

        //Get the details of a particular user
        public async Task<OperationResult<UserDto>> GetUserInfo(int userID)
        {
            OperationResult<UserDto> result = new();
            try
            {
                User? user = await _db.Users.FindAsync(userID);
                if (user is not null)
                {
                    result.Data = new()
                    {
                        UserID = user.UserID,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        MobileNumber = user.MobileNumber,
                        Email = user.Email
                    };
                    result.Message = "کاربر یافت شد";
                    result.ResponseCode = ResponseCode.Successful;
                }
                else
                {
                    result.Message = "کاربر یافت نشد";
                    result.ResponseCode = ResponseCode.NoAvailableData;
                }
            }
            catch
            {
                result.Message = "دریافت اطلاعات با خطا مواجه شد";
                result.ResponseCode = ResponseCode.OperationFailed;
            }
            return result;
        }

        //To Delete the record of a particular user
        public async Task<OperationResult<bool>> DeleteUser(int userID)
        {
            OperationResult<bool> result = new();
            try
            {
                User? user = await _db.Users.FindAsync(userID);
                if (user is not null)
                {
                    _db.Users.Remove(user);
                }
                else
                {
                    result.Data = false;
                    result.Message = "کاربر یافت نشد";
                    result.ResponseCode = ResponseCode.NoAvailableData;
                    return result;
                }
                if (await _db.SaveChangesAsync() > 0)
                {
                    result.Data = true;
                    result.Message = "کاربر با موفقیت حذف شد";
                    result.ResponseCode = ResponseCode.Successful;
                }
                else
                {
                    result.Data = false;
                    result.Message = "اطلاعاتی از کاربر تغییر پیدا نکرد";
                    result.ResponseCode = ResponseCode.InvalidRequest;
                }
            }
            catch
            {
                result.Data = false;
                result.Message = "ثبت اطلاعات با خطا مواجه شد";
                result.ResponseCode = ResponseCode.OperationFailed;
            }
            return result;
        }

    }
}
