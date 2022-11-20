using Newtonsoft.Json;

namespace InfinBank.Domain.Entities.UserEntities;

public class UserDto : User
{
    [JsonIgnore]
    public override string PasswordHash { get; set; }
}