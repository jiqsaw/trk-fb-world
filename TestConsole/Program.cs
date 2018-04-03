using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB.ExtentionMethods;
using TurkcellFacebookDunyasi.Com.General;
using System.Collections.Specialized;
using System.Net;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            NameValueCollection a = null;

            Console.WriteLine(a.ToString());
            /*
            using (var wc = new WebClient())
            {
                var b = wc.UploadData("www.asda.com", Encoding.ASCII.GetBytes(str));
                Console.WriteLine(Encoding.UTF8.GetString(b));
            }*/


            

            Console.Read();

        }

    }
}