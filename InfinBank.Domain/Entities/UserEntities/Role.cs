using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
//using System.Text.Json.Serialization;



namespace InfinBank.Domain.Entities.UserEntities;

public class Role : IdentityRole
{
    [JsonIgnore]
    public virtual ICollection<UserRole> UserRoles { get; set; }

    [JsonIgnore]
    public override string NormalizedName { get; set; }

    [JsonIgnore]
    public override string ConcurrencyStamp { get; set; }
}