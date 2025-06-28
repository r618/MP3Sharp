using MP3Sharp;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileName =
                "stream_bug00.mp3"
                ;

            var rawSamples = new List<byte>();

            // open the mp3 file.
            MP3Stream stream = new MP3Stream(fileName);
            // Create the buffer.
            byte[] buffer = new byte[4096];
            // read the entire mp3 file.
            int bytesReturned = 1;
            int totalBytesRead = 0;
            while (bytesReturned > 0)
            {
                bytesReturned = stream.Read(buffer, 0, buffer.Length);
                if (bytesReturned > 0)
                {
                    var bytes = new byte[bytesReturned];
                    Array.Copy(buffer, 0, bytes, 0, bytesReturned);
                    rawSamples.AddRange(bytes);
                }

                totalBytesRead += bytesReturned;
            }

            // close the stream after we're done with it.
            stream.Close();

            File.WriteAllBytes(Path.GetFileNameWithoutExtension(fileName) + ".raw", rawSamples.ToArray());

        }
    }
}
