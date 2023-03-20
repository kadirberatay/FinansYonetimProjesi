using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinansYonetimProjesi
{
    public partial class ISTATISTIK : Form
    {
        public ISTATISTIK()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public void getir()
        {
            

            string sorgu = "select Income.Id,Income.Amount as IncomeAmount,Income.Description, Income.Date,Income.IsStatus as Status from Income where IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, bgl.baglanti());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;

            bgl.baglanti().Close();
        }
        private void ISTATISTIK_Load(object sender, EventArgs e)
        {
            getir();

        }
    }
}
