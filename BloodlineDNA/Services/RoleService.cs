using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;

namespace Services
{
    public class RoleService : Interface.IRoleService
    {
        IRoleRepository roleRepository;

        public RoleService()
        {
            roleRepository = new RoleRepository();
        }
        public bool AddRole(Role role)
        {
            return roleRepository.AddRole(role);
        }

        public bool DeleteRole(Role role)
        {
            return roleRepository.DeleteRole(role);
        }

        public List<Role> GetAllRoles()
        {
            return roleRepository.GetAllRoles();
        }

        public Role GetRoleById(int id)
        {
            return roleRepository.GetRoleById(id);
        }

        public bool UpdateRole(Role role)
        {
            return roleRepository.UpdateRole(role);
        }
    }
}
