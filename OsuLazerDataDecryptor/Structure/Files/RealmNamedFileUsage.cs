using Realms;

namespace OsuLazerDataDecryptor.Structure.Files;

public class RealmNamedFileUsage : EmbeddedObject
{
    public string Filename { get; set; }
    public FileObject File { get; set; }
}