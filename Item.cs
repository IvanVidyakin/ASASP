using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
  public class Item
  {
    public string Sqlcomm;
    public int Num;
    public string[] Addlist;
    public Item(string sqlcomm, int num, string[] addlists)
    {
      Sqlcomm = sqlcomm;
      Num = num;
      Addlist = addlists;
    }
  }
}
