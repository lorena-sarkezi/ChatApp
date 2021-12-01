using ChatApp.Common.ViewModels;
using ChatApp.Data.Entities;

namespace ChatApp.Core.Data
{
    public static class ModelMapper
    {
        public static UserDTO GetUserViewModel(this User user) {
            return new UserDTO
            {
                Id = user.Id,
                DisplayName = user.Username,
                FirstName = user.Person?.FirstName,
                LastName = user.Person?.LastName,
            };
        }
    }
}
