using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Training
{
    public partial class TrainingForm : Form
    {
        private List<string> list;
        private int count;
        private string[] keys = Form1.dictionary.Keys.ToArray<string>();


        public TrainingForm()
        {
            InitializeComponent();
            label1.TextAlign = ContentAlignment.MiddleCenter;

            list = new List<string> { "Hello there, voyager!", $"or better call you {Form1.name}",
                "There is no way out...", "...until you have finish...", "... this awesome challenge!", "First question:"};
            count = list.Count;
        }

        //private void Introdution(object count)
        //{
        //    for (int i = 0; i < (int)count; i++)
        //    {
        //        label1.Invoke(label1.Text = list[i];
        //        Thread.Sleep(3000);
        //    }
        //}

        private void Introdution()
        {
            for (int i = 0; i < count; i++)
            { 
                Invoke(new Action(() => { label1.Text = list[i]; }));
                Thread.Sleep(2000);
            }
        }
        // Допилить логику цикла
        private void Challenge()
        {
            int numQuesions = keys.Length;

            for (int i = 0; i < numQuesions; i++)
            {
                if (textBox1.Text == keys[i])
                    label1.Text = "Well done";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && textBox1.Text == keys[0])
            {
                MessageBox.Show("Well done");
            }
            else
                MessageBox.Show("Nope");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(Introdution);
            //th.Start();
            label1.Text = $"What is {keys[0].ToString()}?";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
