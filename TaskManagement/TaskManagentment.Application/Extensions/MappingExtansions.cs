using TaskManagentment.Application.Enums;
using TaskManagentment.Application.Request;
using TaskManagetment.Domain.Entities;

namespace TaskManagentment.Application.Extensions
{
    public static class MappingExtensions
    {
        public static AppUser ToMap(this RegistarRequest request)
        {
            return new AppUser
            {
                AppRoleID = (int)RoleType.Member,
                Name = request.Name,
                Surname = request.Surname,
                Password = request.Password,
                UserName = request.Username,
            };
        }

        public static Priority ToMap(this PriorityCreateRequest request)
        {
            return new Priority
            {
                Definition = request.Definition,
            };
        }
    }
}
