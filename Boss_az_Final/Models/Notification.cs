using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Boss_az_Final.Models
{
    public class Notificaiton
    {
        public string content { get; set; }
        public string time { get; set; }
        public Notificaiton(string _cont)
        {

            content = _cont;
            time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

     
        public override string ToString()
        {
            string? txt = content + "\tTime:" + time;
            return txt;


        }
    }
}
