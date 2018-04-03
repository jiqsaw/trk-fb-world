using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB
{
    public class FileHelper
    {
        public static string Read(string Path) {
            StreamReader sr = new StreamReader(Path, Encoding.GetEncoding("windows-1254"));
            string Output = sr.ReadToEnd();
            sr.Close();
            return Output;
        }
    }
}
