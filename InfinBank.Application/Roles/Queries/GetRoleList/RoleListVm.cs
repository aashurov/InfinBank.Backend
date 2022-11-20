using System.Collections.Generic;

namespace InfinBank.Application.Roles.Queries.GetRoleList;

public class RoleListVm
{
    public IList<RoleListLookupDto> Roles { get; set; }
}