using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Interfaces;
using UniversitySystem.Models;

namespace UniversitySystem.Helpers;

public class RoleHelper:IRoleHelper
{
    public Boolean AddRole(string name)
    {
        try
        {
            InmindContext context = new InmindContext();

            var role = new Role
            {
                Name = name
            };

            context.Roles.Add(role);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
    }

    public bool DeleteRole(int id)
    {
        try
        {
            InmindContext context = new InmindContext();
            Role role = context.Roles.First(r => r.Id == id);
            context.Roles.Remove(role);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;
        
    }

    public bool UpdateRole(int id, string name)
    {
        try
        {
            InmindContext context = new InmindContext();
            Role role = context.Roles.First(r => r.Id == id);
            role.Name = name;
            context.Roles.Update(role);
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return true;

    }

    public List<Role> GetRoles()
    {
        try
        {
            InmindContext context = new InmindContext();

            List<Role> roles = context.Roles.ToList();
            return roles;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}