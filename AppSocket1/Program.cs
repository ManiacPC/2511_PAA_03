using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSocket1
{
    class Program
    {
        static void Main(string[] args)
        {
            string puertoTxt = ConfigurationManager.AppSettings["puerto"];
            int puerto = Convert.ToInt32(puertoTxt);

            string ip = ConfigurationManager.AppSettings["ip"];
        }
    }
}
