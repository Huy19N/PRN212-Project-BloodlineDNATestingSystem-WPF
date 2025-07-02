using BusinessObjects;
using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public class RoleDAO
{
    public List<Role> GetAllRoles()
    {
        using var context = new GeneCareContext();
        return context.Roles.ToList();
    }

    public bool CreateRole(Role role)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (role == null)
            {
                return false;
            }

            context.Roles.Add(new Role
            {
                RoleName = role.RoleName,
            });

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool UpdateRole(Role role)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            if (role == null)
            {
                return false;
            }
            var existingRole = context.Roles.Find(role.RoleId);
            if (existingRole == null)
            {
                return false;
            }

            existingRole.RoleName = role.RoleName;

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool DeleteRoleById(int id)
    {
        using var context = new GeneCareContext();
        using var transaction = context.Database.BeginTransaction();
        try
        {
            var role = context.Roles.Find(id);
            if (role == null) return false;

            context.Roles.Remove(role);

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
