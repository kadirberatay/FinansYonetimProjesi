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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinansYonetimProjesi.GelirGider
{
    public partial class DELETED : Form
    {
        public DELETED()
        {
            InitializeComponent();
        }
        public static int id1 = 0;
        public static int id2 = 0;
        sqlbaglantisi bgl = new sqlbaglantisi();
        public void gelir()
        {


            string sorgu = "select Income.Id,Income.Amount as IncomeAmount,Income.Description, Income.Date,Income.IsStatus as Status from Income where IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, bgl.baglanti());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView1.DataSource = dt;
            

            bgl.baglanti().Close();
        }
        public void gider()
        {


            string sorgu = "select Expense.Id,Expense.Amount as ExpenseAmount,Expense.Description, Expense.Date,Expense.IsStatus as Status from Expense where IsDelete=0";

            SqlDataAdapter sqlData = new SqlDataAdapter(sorgu, bgl.baglanti());

            DataTable dt = new DataTable();
            sqlData.Fill(dt);

            dataGridView2.DataSource = dt;
            

            bgl.baglanti().Close();
        }
        private void DELETED_Load(object sender, EventArgs e)
        {
            gelir();
            gider();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            



            
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();


         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult deleteDialog = new DialogResult();

            deleteDialog = MessageBox.Show("Delete Income?",
                                        "Delete Income",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (deleteDialog == DialogResult.Yes)
            {
                
                SqlCommand deleteControl = new SqlCommand("deleteIncome", bgl.baglanti());
                deleteControl.CommandType = CommandType.StoredProcedure;
                deleteControl.Parameters.Add("Id", SqlDbType.Int).Value = textBox1.Text;

                var returnValue = deleteControl.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                deleteControl.ExecuteNonQuery();

                int result = Convert.ToInt32(returnValue.Value);


                bgl.baglanti().Close();

                if (result == 1)
                {
                    MessageBox.Show("Income Deletion Successful",
                               "Delete Income",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                    gelir();
                }
                else
                {
                    MessageBox.Show("Income Not Found",
                               "Delete Income",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Income Deletion Canceled",
                                "Delete Income",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult deleteDialog = new DialogResult();

            deleteDialog = MessageBox.Show("Delete Expense?",
                                        "Delete Expense",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (deleteDialog == DialogResult.Yes)
            {
               

                SqlCommand deleteControl = new SqlCommand("deleteExpense", bgl.baglanti());
                deleteControl.CommandType = CommandType.StoredProcedure;
                deleteControl.Parameters.Add("Id", SqlDbType.Int).Value = textBox2.Text;

                var returnValue = deleteControl.Parameters.Add("@ReturnVal", SqlDbType.Int);
                returnValue.Direction = ParameterDirection.ReturnValue;

                deleteControl.ExecuteNonQuery();

                int result = Convert.ToInt32(returnValue.Value);


                bgl.baglanti().Close();

                if (result == 1)
                {
                    MessageBox.Show("Expense Deletion Successful",
                               "Delete Expense",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);

                    gider();
                }
                else
                {
                    MessageBox.Show("Expense Not Found",
                               "Delete Expense",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Expense Deletion Canceled",
                                "Delete Expense",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            }
        }
    }
}
