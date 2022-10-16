using Company.Domain.Base;

namespace Company.Domain.Entities
{
    public class RoleEntity : Entity
    {
        public string Name { get; set; }

        public IEnumerable<EmployeeEntity> Users { get; set; } = new List<EmployeeEntity>();
    }
}
