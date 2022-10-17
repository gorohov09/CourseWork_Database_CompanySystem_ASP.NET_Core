using Company.Domain.Entities;

namespace Company.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleEntity> GetRoleByName(string roleName);
    }
}
