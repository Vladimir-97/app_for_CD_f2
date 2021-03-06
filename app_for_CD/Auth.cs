using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace app_for_CD
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
            SetConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.exit = true;
            string name = textBox1.Text;
            string pass = textBox2.Text;
            OracleCommand cmd = con.CreateCommand();
            cmd.Parameters.Add(new OracleParameter("LOGIN", name));
            cmd.Parameters.Add(new OracleParameter("PASSW", pass));
            cmd.CommandText = "select * from users_cd where login = :LOGIN and PASSWORD = :PASSW";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();

            while (dr.Read() == true)
            {
                fill_data(dr);
            }
            

            CloseConnection();
            this.Close();
        }
        private void fill_data(OracleDataReader dr)
        {
            Data.login = 1;
            string tmp_str;
            tmp_str = dr[3].ToString();    

            Data.role = Int32.Parse(tmp_str);
        }



        OracleConnection con = null;
        private void SetConnection()
        {
            string ConnectionString = "USER ID=GGUZDR_APP;PASSWORD=gguzdr_app;DATA SOURCE=10.1.50.12:1521/GDBDRCT1";
            con = new OracleConnection(ConnectionString);
            try
            {
                con.Open();
            }

            catch (Exception e)
            {
                string errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, e.Message);
            }
        }
        private void CloseConnection()
        {
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.exit = false;
            this.Close();
        }
    }
}
