namespace OsuLazerDataDecryptor.Utils;

public class FileUtils
{
    public  static string GetEncryptedFilePath(string root, string fileName)
    {
        var firstSubfolder = fileName.Substring(0, 1);
        var secondSubfolder = fileName.Substring(0, 2);

        return Path.Join(root, "files", firstSubfolder, secondSubfolder, fileName);
    } 
}