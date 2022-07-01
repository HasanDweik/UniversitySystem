using UniversitySystem.Models;

namespace UniversitySystem.Interfaces;

public interface IRoleHelper
{
    public Boolean AddRole(string name);
    bool DeleteRole(int id);
    bool UpdateRole(int id,string name);
    List<Role> GetRoles();
}