using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class RoleDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

           public List<Role> GetAllRoles()
            {
                return context.Roles.ToList();
            }
    
            public Role GetRoleById(int id)
            {
                return context.Roles.FirstOrDefault(r => r.RoleId == id);
            }
    
            public bool AddRole(Role role)
            {
                context.Roles.Add(role);
                return context.SaveChanges() > 0;
            }
    
            public bool DeleteRole(Role role)
            {
                context.Roles.Remove(role);
                return context.SaveChanges() > 0;
            }
    
            public bool UpdateRole(Role role)
            {
                context.Roles.Update(role);
                return context.SaveChanges() > 0;
        }
    }
}
