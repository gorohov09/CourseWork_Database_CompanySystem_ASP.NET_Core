using Company.DAL.Context;
using Company.DAL.Interfaces;
using Company.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.DAL.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CompanyContext _context;

        public RoleRepository(CompanyContext context)
        {
            _context = context;
        }

        public async Task<RoleEntity> GetRoleByName(string roleName)
        {
            var roleEntity = await _context.Roles
                .FirstOrDefaultAsync(r => r.Name == roleName);
            return roleEntity;
        }
    }
}
