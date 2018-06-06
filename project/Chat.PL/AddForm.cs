using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat.PL
{
    public partial class AddForm : Form
    {
        public string ReturnValue1;
        public string ReturnValue2;
        public string ReturnValue3;
        public string ReturnValue4;
        public string ReturnValue5;
        public string ReturnValue6;

        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                this.ReturnValue1 = textBox6.Text;
                this.ReturnValue2 = textBox1.Text;
                this.ReturnValue3 = textBox2.Text;
                this.ReturnValue4 = textBox3.Text;
                this.ReturnValue5 = textBox4.Text;
                this.ReturnValue6 = textBox5.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
