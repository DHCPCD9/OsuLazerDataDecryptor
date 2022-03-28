using OsuLazerDataDecryptor.Structure.Files;
using Realms;

namespace OsuLazerDataDecryptor.Structure;

public class Skin : RealmObject
{
    [PrimaryKey]
    public Guid ID { get; set; }
    public string Name { get; set; }
    public string Creator { get; set; }
    public string InstantiationInfo { get; set; }
    public string Hash { get; set; }
    public bool Protected { get; set; }
    public IList<RealmNamedFileUsage> Files { get; }
    public bool DeletePending { get; set; }
}