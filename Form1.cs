using System;
using System.Collections.Generic;
using System.ComponentModel;
using SD=System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DB mydb;
        public Form1()
        {
            InitializeComponent();
            mydb = new DB(this);
            mydb.DBConnection();
            mydb.expired();
        }
        public DataGridView getdgv()
        {
            return dataGridView1;
        }
        public Label getlbl()
        {
            return label1;
        }
        public CheckBox getcbx()
        {
            return checkBox1;
        }
        public RichTextBox getrbx1()
        {
            return rtbxquerry;
        }
        public RichTextBox getrbx2()
        {
            return rtbxelem;
        }
        public RichTextBox getrbx3()
        {
            return rtbxoldquerry;
        }
        public TextBox gettbx1()
        {
            return tbxFind;
        }
        public TextBox gettbx2()
        {
            return tbxmove;
        }

        public Panel getpnl()
        {
            return pnltabs;
        }
        private void ВыбратьтаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnltabs.Visible = true;
        }
        private void btntabs_Click(object sender, EventArgs e)
        {
            mydb.SelectQuerry(cbxtabs.Text);
        }
        private void добавитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mydb.INSERTDB();
        }
        private void изменитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mydb.UPDATEDB(dataGridView1.CurrentCell.Value.ToString());
        }
        private void удалитьЗаписьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mydb.DELETEDB();
        }
        private void btnex_Click(object sender, EventArgs e)
        {
            mydb.EXPORTDB();
        }
        private void btnsort_Click(object sender, EventArgs e)
        {
            mydb.SORTDB();
        }
        private void btnfind_Click(object sender, EventArgs e)
        {
            mydb.FIND();
        }
        private void обновитьСписокНаИсключениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mydb.expired();
        }
        private void закончитьКурсToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlmove.Visible = true;
        }
        private void btnmove_Click(object sender, EventArgs e)
        {
            pnlmove.Visible = false;
            mydb.Moving(tbxmove.Text);
        }
        private void запросыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rtbxquerry.Visible==false)
            {
                rtbxquerry.Visible = true;
                rtbxoldquerry.Visible = true;
            }
            else
            {
                rtbxquerry.Visible = false;
                rtbxoldquerry.Visible = false;
            }
        }
        private void вставляемыеДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rtbxelem.Visible==false)
            {
                rtbxelem.Visible = true;
            }
            else
            {
                rtbxelem.Visible = false;
            }
        }
    }
}
