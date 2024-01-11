using Common.DTOs;

namespace Logic.Interfaces
{
    public interface IUser
    {
        public Task<OperationResult<List<UserDto>>> GetUsers();
        public Task<OperationResult<bool>> AddUser(UserDto user);
        public Task<OperationResult<bool>> UpdateUser(UserDto user);
        public Task<OperationResult<UserDto>> GetUserInfo(int id);
        public Task<OperationResult<bool>> DeleteUser(int id);
    }
}
