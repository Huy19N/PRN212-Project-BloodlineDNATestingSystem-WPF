using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class RoleRepository : Interface.IRoleRepository
    {
        RoleDAO roleDAO = new RoleDAO();
        public bool AddRole(Role role)
        {
            return roleDAO.AddRole(role);
        }

        public bool DeleteRole(Role role)
        {
            return roleDAO.DeleteRole(role);
        }

        public List<Role> GetAllRoles()
        {
            return roleDAO.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return roleDAO.GetRoleById(id);
        }

        public bool UpdateRole(Role role)
        {
            return roleDAO.UpdateRole(role);
        }
    }
}
