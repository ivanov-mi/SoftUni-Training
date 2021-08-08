using System;
using System.IO;

class CopyBinaryFile
{
    static void Main()
    {
        string resourcePath = @"../../../Resources/randomPicture.png";
        Directory.CreateDirectory(@"../../../Output");
        string destinationPath = @"../../../Output/copiedPicture.png";

        using (FileStream streamReader = new FileStream(resourcePath, FileMode.Open))
        {
            using (FileStream streamWriter = new FileStream(destinationPath, FileMode.Create))
            {
                byte[] buffer = new byte[4096];

                while (true)
                {
                    int readSize = (readSize = streamReader.Read(buffer, 0, buffer.Length));

                    if (readSize == 0)
                    {
                        break;
                    }

                    streamWriter.Write(buffer, 0, readSize);
                }
            }
        }
    }
}