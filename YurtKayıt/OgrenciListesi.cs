using MySql.Data.MySqlClient;
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
    public partial class OgrenciListesi : Form
    {
        public OgrenciListesi()
        {
            InitializeComponent();
        }

        MySqlConnection baglanti = new MySqlConnection(@"Server=localhost;Port=3306;Uid=root;Pwd=ayarlama@#@#141414;Database=yurtotomasyondb");

        private void OgrenciListesi_Load(object sender, EventArgs e)
        {
            OgrencileriListele();
        }

        void OgrencileriListele()
        {
            listView1.Items.Clear();

            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                MySqlCommand komut = new MySqlCommand("Select * From ogrenciler", baglanti);
                MySqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem urun = new ListViewItem(new string[]
                    {
                        oku["id"].ToString(  ),
                        oku["ad"].ToString(  ),
                        oku["soyad"].ToString(  ),
                        oku["telefon"].ToString(  ),
                        oku["kat"].ToString(  ),
                        oku["odano"].ToString(  ),
                        oku["yatakno"].ToString(  )
                    }
                         );
                    listView1.Items.Add(urun);
                }
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                return;
            }

            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                ListViewItem listViewItem = listView1.SelectedItems[0];
                MySqlCommand komut = new MySqlCommand("Select * From ogrenciler where id=" + listViewItem.SubItems[0].Text, baglanti);
                MySqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    textBox4.Text = oku["Id"].ToString();
                    textBox1.Text = oku["ad"].ToString();
                    textBox2.Text = oku["soyad"].ToString();
                    textBox3.Text = oku["telefon"].ToString();
                    comboBox1.Text = oku["kat"].ToString();
                    comboBox2.Text = oku["odano"].ToString();
                    comboBox3.Text = oku["yatakno"].ToString();
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                MySqlCommand komut = new MySqlCommand("Update ogrenciler Set ad='" + textBox1.Text + "', soyad='" + textBox2.Text + "', telefon='" + textBox3.Text + "',kat=" + comboBox1.Text + ",odano=" + comboBox2.Text + ", yatakno=" + comboBox3.Text + " Where Id='" + textBox4.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Öğrenci Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
            finally
            {
                baglanti.Close();

                OgrencileriListele();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                MySqlCommand komut = new MySqlCommand("Delete From ogrenciler Where Id='" + textBox4.Text + "'", baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("Öğrenci Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
            finally
            {
                baglanti.Close();

                OgrencileriListele();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {
                if (baglanti.State != ConnectionState.Open)
                    baglanti.Open();

                MySqlCommand komut = new MySqlCommand("Select * From ogrenciler where kat=" + comboBox6.Text + " and odano=" + comboBox5.Text + " and yatakno=" + comboBox4.Text, baglanti);
                MySqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    ListViewItem urun = new ListViewItem(new string[]
                    {
                        oku["id"].ToString(  ),
                        oku["ad"].ToString(  ),
                        oku["soyad"].ToString(  ),
                        oku["telefon"].ToString(  ),
                        oku["kat"].ToString(  ),
                        oku["odano"].ToString(  ),
                        oku["yatakno"].ToString(  )
                    }
                         );
                    listView1.Items.Add(urun);
                }
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

        private void button4_Click(object sender, EventArgs e)
        {
            OgrencileriListele();
        }
    }
}
