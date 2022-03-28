using Realms;

namespace OsuLazerDataDecryptor.Structure.Users;

public class RealmUser : EmbeddedObject
{
    public int OnlineID { get; set; }
    
    public string? Username { get; set; }
}