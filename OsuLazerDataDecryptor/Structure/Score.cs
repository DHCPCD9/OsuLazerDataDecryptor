using OsuLazerDataDecryptor.Structure.Files;
using OsuLazerDataDecryptor.Structure.Users;
using Realms;
using Realms.Sync;

namespace OsuLazerDataDecryptor.Structure;

public class Score : RealmObject
{
    [PrimaryKey]
    public Guid ID { get; set; }
    
    public Beatmap? BeatmapInfo { get; set; }
    public Ruleset Ruleset { get; set; }
    public IList<RealmNamedFileUsage> Files { get; }
    public string? Hash { get; set; }
    public bool DeletePending { get; set; }
    public int TotalScore { get; set; }
    public int MaxCombo { get; set; }
    public bool HasReplay { get; set; }
    public DateTimeOffset Date { get; set; }
    public double? PP { get; set; }
    public int OnlineID { get; set; }
    public RealmUser User { get; set; }
    public string Mods { get; set; }
    public string Statistics { get; set; }
    public int Rank { get; set; }
    public int Combo { get; set; }
    public double Accuracy { get; set; }
}