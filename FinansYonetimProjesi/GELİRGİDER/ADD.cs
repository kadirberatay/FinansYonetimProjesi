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
    public partial class ADD : Form
    {
        public ADD()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox1.Text) && !String.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                SqlCommand sqlCommand = new SqlCommand("AddIncome", bgl.baglanti());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("Amount", SqlDbType.Float).Value = Convert.ToInt32(textBox1.Text);
                sqlCommand.Parameters.Add("Date", SqlDbType.Date).Value = dateTimePicker1.Value;
                sqlCommand.Parameters.Add("Description", SqlDbType.Text).Value = richTextBox1.Text;



                var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                int result = Convert.ToInt32(ReturnValue.Value);

                bgl.baglanti().Close();

                if (result == 1)
                {
                    MessageBox.Show("Income Added Successfull", "Income Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("An error occurred while adding!", "Income Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Değerler Boş Geçilemez");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBox2.Text) && !String.IsNullOrWhiteSpace(richTextBox2.Text))
            {
                SqlCommand sqlCommand = new SqlCommand("AddExpense", bgl.baglanti());
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Add("Amount", SqlDbType.Float).Value = Convert.ToInt32(textBox2.Text);
                sqlCommand.Parameters.Add("Date", SqlDbType.Date).Value = dateTimePicker2.Value;
                sqlCommand.Parameters.Add("Description", SqlDbType.Text).Value = richTextBox2.Text;


                var ReturnValue = sqlCommand.Parameters.Add("@ReturnVal", SqlDbType.Int);
                ReturnValue.Direction = ParameterDirection.ReturnValue;
                sqlCommand.ExecuteNonQuery();
                int result = Convert.ToInt32(ReturnValue.Value);

                bgl.baglanti().Close();

                if (result == 1)
                {
                    MessageBox.Show("Expense Added Successfull", "Expense Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("An error occurred while adding!", "Expense Add", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Değerler Boş Geçilemez");
            }

           
        }
    }
}
