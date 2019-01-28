using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeLib;

namespace Stoper
{
    public partial class Form1 : Form
    {

        TimePeriod tp = new TimePeriod(0, 0, 0);
        int indexer = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tp += new TimePeriod(0, 0, 1);
            label1.Text = tp.ToString();
           

        }

        private void Stop_Click(object sender, EventArgs e)
        {
           
            
            timer1.Stop();
            ListViewItem lvI = new ListViewItem(indexer.ToString());
            lvI.SubItems.Add(tp.ToString());
            listView1.Items.Add(lvI);
            indexer++;
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            tp = new TimePeriod(0, 0, 0);

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListViewItem lvI = new ListViewItem(indexer.ToString());
            lvI.SubItems.Add(tp.ToString());
            listView1.Items.Add(lvI);
            indexer++;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }
    }
}
