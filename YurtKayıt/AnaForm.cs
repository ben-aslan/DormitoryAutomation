using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayıt
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection(@"Server=localhost;Port=3306;Uid=root;Pwd=ayarlama@#@#141414;Database=yurtotomasyondb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                MySqlCommand komut = new MySqlCommand("Insert Into ogrenciler ( ad, soyad, telefon, kat, odano, yatakno ) Values( '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "','" + comboBox3.Text + "' )", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Öğrenci Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciListesi ogrenciListesi = new OgrenciListesi();
            ogrenciListesi.Show();
        }
    }
}
