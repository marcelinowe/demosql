using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLInjection
{
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String instance = ConfigurationManager.AppSettings["instance"].ToString();
            String dbname = ConfigurationManager.AppSettings["dbname"].ToString();
            String tableLogin = ConfigurationManager.AppSettings["tableLogin"].ToString();
            String user = ConfigurationManager.AppSettings["user"].ToString();
            String pass = ConfigurationManager.AppSettings["pass"].ToString();

            String conn = "Data Source=" + instance.ToString() + ";Initial Catalog=" + dbname.ToString() + ";User ID=" + user.ToString() + ";Password=" + pass.ToString() + ";";
            try
            {
                SqlConnection sqlConn = new SqlConnection(conn);
                sqlConn.Open();
                String cmd = "select * from "+ tableLogin + " where Login = '" + txtLogin.Text + "' and Senha = '" + txtSenha.Text + "'";
                
                SqlCommand sqlCmd = new SqlCommand(cmd, sqlConn);
                SqlDataReader dr = sqlCmd.ExecuteReader();
                if (dr.HasRows) {
                    while (dr.Read())
                    {
                        MessageBox.Show("Login executado com sucesso: " + dr.GetString(1));
                    }
                }
                else {
                    MessageBox.Show("Falha no login");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
            }
        }
    }
}
