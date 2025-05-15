using TaskManagentment.Application.Enums;

namespace TaskManagentment.Application.DTOs
{
    public record LoginResponseDto(string Name, string Surname, RoleType Role, int Id);
}
