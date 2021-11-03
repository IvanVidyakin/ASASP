using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Service
    {
        protected MySqlConnection conn;
        protected string joindata;
        protected int period;
        public Service(string jd, int per, MySqlConnection cn)
        {
            joindata = jd;
            period = per;
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

        public MySqlConnection getconn()
        { 
            return conn;
        }
        public void QuerryBoxSwap(RichTextBox Rtbx1, RichTextBox Rtbx2, string NewQuerry)
        {
            Rtbx2.Text = Rtbx1.Text;
            Rtbx1.Text = NewQuerry;
        }
        public void DataReader(string sqlcommand, MySqlConnection connect)
        {
            MySqlCommand comm = new MySqlCommand(sqlcommand, this.getconn());
            MySqlDataReader reader = comm.ExecuteReader();
            reader.Close();
        }

        public void Addtolist(List<string> list, string[] adds)
        {
            foreach (string str in adds)
            {
               list.Add(str);
            }
        }
    }
}
