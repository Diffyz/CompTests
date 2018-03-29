using System;
using System.IO;

namespace TurnBasedRPG
{
    public class FileReader: IDisposable
    {
        private StreamReader stream;

        public void Open(string path)
        {
            FileInfo file = new FileInfo(path);
            stream = file.OpenText();
        }

        public void Close()
        {
            stream.Close();
        }

        public string ReadLine()
        {
            return stream.ReadLine();
        }

        public string ReadAll()
        {
            return stream.ReadToEnd();
        }
        
        public void Dispose()
        {
            Close();
        }
    }
}