// See https://aka.ms/new-console-template for more information

using System.IO.Compression;
using MongoDB.Bson;
using OsuLazerDataDecryptor.Structure;
using OsuLazerDataDecryptor.Utils;
using Realms;

if (args.Length < 2)
{
    Console.WriteLine("Usage: <input-directory> <output-directory>");
    return;
}

var lazerPath = args[0];
var outputPath = args[1];

if (!Directory.Exists(lazerPath))
{
    Console.WriteLine($"Input directory '{lazerPath}' does not exist.");
    return;
}

if (!Directory.Exists(outputPath))
{
    Directory.CreateDirectory(outputPath);
}


var realm = Realm.GetInstance(new RealmConfiguration(Path.Join(lazerPath, "client.realm"))
{
    SchemaVersion = 14
});

Console.WriteLine($"Opened realm file: {realm.Config.DatabasePath}");

Console.WriteLine("Exporting replays...");
if (!Directory.Exists(Path.Join(outputPath, "replays")))
{
    Directory.CreateDirectory(Path.Join(outputPath, "replays"));
}

var replay = realm.All<Score>();

foreach (var score in replay.ToList())
{
    
    Console.WriteLine($"Exporting replay: {score.BeatmapInfo?.Metadata?.ArtistUnicode??"Unknown Artist"} - {score?.BeatmapInfo?.Metadata?.TitleUnicode??"Unknown Beatmap"}[{score?.BeatmapInfo?.DifficultyName??"Unknown difficulty"}]");

    var replayFile = score.Files.FirstOrDefault(c => c.Filename == "replay.osr");
    
    if (replayFile is null)
        continue;

    var data = FileUtils.GetEncryptedFilePath(lazerPath, replayFile.File.Hash);
    try
    {
        File.Copy(data, Path.Join(Path.Join(outputPath, "replays"), $"{score.User.Username} - {score.BeatmapInfo?.Metadata?.ArtistUnicode??"Unknown Artist"} - {score?.BeatmapInfo?.Metadata?.TitleUnicode??"Unknown Beatmap"}[{score?.BeatmapInfo?.DifficultyName??"Unknown difficulty"}].osr"), true);
    }catch
    {
        Console.WriteLine("Failed to export.");
    }
}
Console.WriteLine("Exporting skins...");
if (!Directory.Exists(Path.Join(outputPath, "skins")))
{
    Directory.CreateDirectory(Path.Join(outputPath, "skins"));
}

var skins = realm.All<Skin>();

foreach (var skin in skins.ToList())
{
    if (skin.Protected)
        continue;
    
    Console.WriteLine($"Exporting skin: {skin.Name}");
    if (!Directory.Exists(Path.Join(outputPath, "skins", skin.Name)))
    {
        Directory.CreateDirectory(Path.Join(outputPath, "skins", skin.Name));
    }
    
    var files = skin.Files.ToList();

    foreach (var file in files)
    {
        var fileData = FileUtils.GetEncryptedFilePath(lazerPath, file.File.Hash);
        
        if (!Directory.Exists(Path.Join(outputPath, "skins", skin.Name, Path.GetDirectoryName(file.Filename))))
        {
            Directory.CreateDirectory(Path.Join(outputPath, "skins", skin.Name, Path.GetDirectoryName(file.Filename)));
        }
        
        File.Copy(fileData, Path.Join(outputPath, "skins", skin.Name, file.Filename), true);
    }
    Console.WriteLine("Creating .osk file...");
    ZipFile.CreateFromDirectory(Path.Join(outputPath, "skins", skin.Name), Path.Join(outputPath, "skins", $"{skin.Name}.osk"));
    Console.WriteLine("Skin exported.");
}
