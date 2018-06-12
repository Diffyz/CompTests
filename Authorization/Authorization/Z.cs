using System;
using System.IO;

namespace Authorization.Controllers
{
    internal class Z
    {
        internal static void Write(string v)
        {
            using(StreamWriter sw = new StreamWriter("D:\\Game.txt"))
            {
                sw.Write(v);
            }
        }
    }
}