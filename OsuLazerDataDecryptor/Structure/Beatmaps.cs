using OsuLazerDataDecryptor.Structure.Beatmaps;
using Realms;

namespace OsuLazerDataDecryptor.Structure;

public class Beatmap : RealmObject
{
    [PrimaryKey]
    public Guid ID { get; set; }
    public string DifficultyName { get; set; }
    public Ruleset Ruleset { get; set; }
    public BeatmapDifficulty? Difficulty { get; set; }
    public BeatmapMetadata? Metadata { get; set; }
    public BeatmapUserSettings UserSettings { get; set; }
    public int Status { get; set; }
    public int OnlineID { get; set; }
    public double Length { get; set; }
    public double BPM { get; set; }
    public string? MD5Hash { get; set; }
    public string? Hash { get; set; }
    public bool Hidden { get; set; }
    public double AudioLeadIn { get; set; }
    public float StackLeniency { get; set; }
    public bool SpecialStyle { get; set; }
    public bool LetterboxInBreaks { get; set; }
    public bool WidescreenStoryboard { get; set; }
    public bool EpilepsyWarning { get; set; }
    public bool SamplesMatchPlaybackRate { get; set; }
    public double DistanceSpacing { get; set; }
    public int BeatDivisor { get; set; }
    public int GridSize { get; set; }
    public double TimelineZoom { get; set; }
    public int CountdownOffset { get; set; }
    public double StarRating { get; set; }
    public BeatmapSet? BeatmapSet { get; set; }
}