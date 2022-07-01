using MediatR;
using UniversitySystem.Models;

namespace UniversitySystem.Persistences.Entities.Roles.Queries.GetRoles;

public class GetRolesHandler : IRequestHandler<GetRolesQuery,List<Role>>
{
    private InmindContext _context;

    public GetRolesHandler(InmindContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        return _context.Roles.ToList();
    }
}