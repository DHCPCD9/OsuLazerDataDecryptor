using Realms;

namespace OsuLazerDataDecryptor.Structure.Files;
[MapTo("File")]
public class FileObject : RealmObject
{
    [PrimaryKey]
    public string? Hash { get; set; }
}