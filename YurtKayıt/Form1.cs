using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "muhammet" 
                && textBox2.Text.Trim() == "1234")
            {
                this.Hide();
                AnaForm anaForm = new AnaForm();
                anaForm.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre yanlış.", "Hata bilgilendirmesi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
