using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public class Globalium
    {
        protected string joindata;
        protected int period;
        public Globalium(string jd, int per)
        {
            joindata = jd;
            period = per;
        }
    }
    public class Globalum : Globalium
    {
        public MySqlConnection conn;
        public Globalum(string jd, int per, MySqlConnection cn) : base(jd, per) 
        {
            conn = cn;
        }
        public string getjoin()
        {
            return joindata;
        }

        public int getper()
        {
            return period;
        }
    }
}
