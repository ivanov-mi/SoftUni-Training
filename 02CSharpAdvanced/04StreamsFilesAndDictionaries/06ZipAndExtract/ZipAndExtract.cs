using System;
using System.IO;
using System.IO.Compression;

class ZipAndExtract
{
    static void Main()
    {
        var sourcePath = @"../../../Recources/randomPicture.png";
        var zipPath = @"../../../result.zip";
        Directory.CreateDirectory(@"../../../Extract");
        var extractPath = @"../../../Extract";

        using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
        {
            archive.CreateEntryFromFile(sourcePath, Path.GetFileName(sourcePath));
            archive.ExtractToDirectory(extractPath);
        }
    }
}
