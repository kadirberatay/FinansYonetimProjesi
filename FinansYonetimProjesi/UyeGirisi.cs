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

namespace FinansYonetimProjesi
{
    public partial class UyeGirisi : Form
    {
        public UyeGirisi()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtkAd.Text) && !String.IsNullOrEmpty(txtPassword.Text) && !String.IsNullOrEmpty(txtAd.Text) && !String.IsNullOrEmpty(txtSoyad.Text) && !String.IsNullOrEmpty(txtAge.Text) && !String.IsNullOrEmpty(maskedtxtNo.Text) && !String.IsNullOrEmpty(txtMail.Text))
            {
                SqlCommand komut = new SqlCommand("insert into tbl_uye (UserName,Password,Name,Surname,Age,NumberPhone,Mail) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkAd.Text);
                komut.Parameters.AddWithValue("@p2", txtPassword.Text);
                komut.Parameters.AddWithValue("@p3", txtAd.Text);
                komut.Parameters.AddWithValue("@p4", txtSoyad.Text);
                komut.Parameters.AddWithValue("@p5", txtAge.Text);
                komut.Parameters.AddWithValue("@p6", maskedtxtNo.Text);
                komut.Parameters.AddWithValue("@p7", txtMail.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kaydınız Gerçekleşmiştir");
                txtAd.Clear();
                txtkAd.Clear();
                txtPassword.Clear();
                txtSoyad.Clear();
                txtAge.Clear();
                maskedtxtNo.Clear();
                txtMail.Clear();
                txtAd.Focus();
            }
            else
            {
                MessageBox.Show("Değerler Boş Geçilemez");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
