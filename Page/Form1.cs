using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Page
{
    public partial class Form1 : Form
    {

        private Pages page = new Pages();
        private Index index = new Index();

        const int firstPage = 1;

        public Form1()
        {
            InitializeComponent();
            InitializePage();
        }

        private void InitializePage()
        {
            page.numPerPage = 10; // number of item per page
            numericUpDown1.Maximum = page.count(page.numPerPage);//limit the num index max value
            label1.Text = page.rows().ToString() + " items";
            label2.Text = "Items per page: " + page.numPerPage.ToString();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CurrentPage(firstPage);
            //button7.BackColor = Color.White;
        }


        private void CurrentPage(int i)
        {
            page.fromPage = index.fromItem(i, page.numPerPage);
            page.toPage = page.numPerPage * i;
            label3.Text = page.getText(page.count(page.numPerPage));
            numericUpDown1.Value = i;

            page.load(listView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
                comboBox1.Text = comboBox1.SelectedItem.ToString() + "aaa";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            CurrentPage(Int32.Parse(button7.Text));
            //button7.BackColor = Color.White;
            //button5.BackColor = SystemColors.Control;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CurrentPage(Int32.Parse(button5.Text));
            //button5.BackColor = Color.White;
            //button7.BackColor = SystemColors.Control;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int pages = page.count(page.numPerPage);
            int currentPage = Int32.Parse(this.numericUpDown1.Value.ToString());
            if (currentPage<pages)
            {
                //parameter 1 is increment the page
                NavigatePage(1);
            }
        }

        private void NavigatePage(int i)
        {
            //CurrentPage(Int32.Parse(button5.Text) + i);
            CurrentPage(Int32.Parse(this.numericUpDown1.Value.ToString()) + i);

            button5.Text = (Int32.Parse(button5.Text) + i).ToString();
            button7.Text = (Int32.Parse(button7.Text) + i).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button7.Text == "1")
            {
                CurrentPage(firstPage);
            }
            else
            {
                //parameter -1 is decrement the page
                NavigatePage(-1);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CurrentPage(firstPage);

            button7.Text = "1";
            button5.Text = "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int pages = page.count(page.numPerPage);

            CurrentPage(pages);

            button7.Text = (pages - 1).ToString();
            button5.Text = (pages).ToString();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int target = Int32.Parse(this.numericUpDown1.Value.ToString());
            int pages = page.count(page.numPerPage);

            if (0 < target && target < pages)
            {
                button7.Text = (target - 1).ToString();
                button5.Text = (target).ToString();
            }
        }
    }
}
