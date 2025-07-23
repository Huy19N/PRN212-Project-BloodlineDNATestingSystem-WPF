using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Interface
{
    public interface IRoleService
    {
        public List<Role> GetAllRoles();
        public Role GetRoleById(int id);
        public bool AddRole(Role role);
        public bool DeleteRole(Role role);
        public bool UpdateRole(Role role);
    }
}
