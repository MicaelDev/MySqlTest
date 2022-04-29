using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlTest
{
    public partial class Form1 : Form
    {

        private MySqlConnection bdConn; //MySQL
        private MySqlDataAdapter bdAdapter;
        private DataSet bdDataSet; //MySQL

        public Form1()
        {
            InitializeComponent();
        }

        private void MySqlConnection(string query)
        {
            //Definição do dataset
            bdDataSet = new DataSet();

            //Define string de conexão
            bdConn = new MySqlConnection("            server=localhost;" +
                "                                       database=teste;" +
                "                                             uid=xxxxx;" +
                "                                     pwd=xxxxxxxxxxxxx");

            //Abre conexão
            try
            {
                bdConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossível estabelecer conexão" + ex.Message);
            }
            //Verifica se a conexão está aberta
            if (bdConn.State == ConnectionState.Open)
            {
                //Se estiver aberta insere os dados na BD
                MySqlCommand commS = new MySqlCommand(query, bdConn);
                commS.ExecuteNonQuery();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string query = $"INSERT INTO TESTEE (NOME, SOBRENOME) VALUES ('{txtNome.Text}','{txtSobrenome.Text}')";

            //Executa a query 
            MySqlConnection(query);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = $"UPDATE TESTEE SET SOBRENOME = '{txtSobrenome.Text}' WHERE NOME = '{txtNome.Text}'";

            //Executa a query 
            MySqlConnection(query);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string query = $"DELETE FROM TESTEE WHERE NOME ='{txtNome.Text}' AND SOBRENOME = '{txtSobrenome.Text}'";

            //Executa a query 
            MySqlConnection(query);
        }
    }
}
