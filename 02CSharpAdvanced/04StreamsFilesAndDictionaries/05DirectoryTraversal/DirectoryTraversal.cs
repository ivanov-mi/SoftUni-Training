using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
        string givenDirectory = Environment.CurrentDirectory;



        var directoryInfo = new DirectoryInfo(givenDirectory);

        var filesInfo = directoryInfo.GetFiles();

        var directoryData = new Dictionary<string, Dictionary<string, long>>();

        foreach (var file in filesInfo)
        {
            if (!directoryData.ContainsKey(file.Extension))
            {
                directoryData.Add(file.Extension, new Dictionary<string, long>());
            }

            directoryData[file.Extension].Add(file.Name, file.Length);
        }

        var outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

        using (StreamWriter sw = new StreamWriter(outputPath))
        {

            foreach (var extension in directoryData.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                sw.WriteLine(extension.Key);

                foreach (var file in extension.Value.OrderBy(x => x.Value))
                {
                    sw.WriteLine($"--{file.Key} - {(file.Value / 1024.0):F3}kb");
                }
            }
        }

    }
}

