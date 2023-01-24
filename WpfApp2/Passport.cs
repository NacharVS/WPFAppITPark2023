using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    internal class Passport
    {
        public Passport(string serial, string number)
        {
            Serial = serial;
            Number = number;
        }

        public string Serial { get; set; }
        public string Number { get; set; }
    }
}
