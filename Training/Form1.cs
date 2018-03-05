using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Training
{
    public partial class Form1 : Form
    {
        int count = 1;
        string inpRus;
        string inpEng;
        public static Dictionary<string, string> dictionary;
        bool check = false;
        public static string name = Environment.UserName;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Enter eng word";
            dictionary = new Dictionary<string, string>(1);
        }
        //Заполнение словаря
        private void Save_To_Dict(string eng, string rus)
        {
            dictionary.Add(eng, rus);
        }
        //Тупо вывод в листбоксы
        private void Save_To_ListBoxes()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox1.Items.AddRange(dictionary.Keys.ToArray<string>());
            listBox2.Items.AddRange(dictionary.Values.ToArray<string>());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            check = false;
            label1.Text = "Enter eng word";
            Save_To_Dict(inpEng, inpRus);
            Save_To_ListBoxes();
            textBox1.Focus();
            //SelectNextControl(textBox1, true, true, false, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new TrainingForm().Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                if (!check)
                {
                    inpEng = textBox1.Text;
                    textBox1.Text = String.Empty;
                    label1.Text = "Enter rus definition";
                    check = true;
                }
                else
                {
                    inpRus = textBox1.Text;
                    textBox1.Text = String.Empty;
                    label1.Text = "Press add btn";
                    button1.Focus();
                }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            //{
            //    this.SelectNextControl((Control)sender, true, true, true, true);
            //}
        }
    }
}
