using OsuLazerDataDecryptor.Structure.Users;
using Realms;

namespace OsuLazerDataDecryptor.Structure.Beatmaps;

public class BeatmapMetadata : RealmObject
{
    public string Title { get; set; }
    public string TitleUnicode { get; set; }
    public string Artist { get; set; }
    public string ArtistUnicode { get; set; }
    public RealmUser Author { get; set; }
    public string Source { get; set; }
    public string Tags { get; set; }
    public string AudioFile { get; set; }
    public string BackgroundFile { get; set; }
    public int PreviewTime { get; set; }
    
    
}