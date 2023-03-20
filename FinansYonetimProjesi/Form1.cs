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
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();
        private void btngirisYap_Click(object sender, EventArgs e)
        {
            var query = "Select * From dbo.Users Where userName=@p1 and Password=@p2";
            SqlCommand komut = new SqlCommand(query, bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtkAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {

                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
