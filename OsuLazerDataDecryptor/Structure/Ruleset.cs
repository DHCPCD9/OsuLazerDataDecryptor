using Realms;

namespace OsuLazerDataDecryptor.Structure;

public class Ruleset : RealmObject
{
    [PrimaryKey]
    public string ShortName { get; set; }
    
    public int OnlineID { get; set; }
    
    public string Name { get; set; }
    
    public string InstantiationInfo { get; set; }
    
    public bool Available { get; set; }
    
}