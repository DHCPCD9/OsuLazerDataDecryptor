using OsuLazerDataDecryptor.Structure.Files;
using Realms;

namespace OsuLazerDataDecryptor.Structure.Beatmaps;

public class BeatmapSet : RealmObject
{
    [PrimaryKey]
    public Guid ID { get; set; }
    public int OnlineID { get; set; }
    public DateTimeOffset DateAdded { get; set; }
    public IList<Beatmap> Beatmaps { get; }
    public IList<RealmNamedFileUsage> Files { get; }
    public int Status { get; set; }
    public bool DeletePending { get; set; }
    public string? Hash { get; set; }
    public bool Protected { get; set; }
}