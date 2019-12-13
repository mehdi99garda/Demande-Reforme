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

namespace Demande_Reforme
{
    public partial class principale : Form
    {
        ConnectionDB cdb = new ConnectionDB();
        public principale()
        {
            InitializeComponent();
        }
        public static int num;
        private void btn_client_Click(object sender, EventArgs e)
        {
            num = 1;
            this.Hide();
            Form1 dd = new Form1();
            dd.Show();
        }

        private void btn_fermer_Click(object sender, EventArgs e)
        {
            panel_aff.Visible = false;
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            panel_aff.Visible = true;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            cdb.con.Open();
            string str = "Select count(username) from Loggin where username='" + txt_user.Text + "' AND pass='" + txt_pass.Text + "'";
            cdb.cmd = new SqlCommand(str, cdb.con);
            SqlDataReader dr = cdb.cmd.ExecuteReader();
            cdb.dt.Load(dr);
            cdb.con.Close();
            if (cdb.dt.Rows[0][0].ToString() == "1")
            {
                Form1.sujet = "";
                Form1.msg = "";
                num = 2;
                this.Hide();
                menu f = new menu();
                f.Show();
            }
            else
            {
                MessageBox.Show("User_name ou password est incorrect");
                cdb.dt.Clear();
            }
        }

        private void principale_Load(object sender, EventArgs e)
        {
            panel_aff.Visible = false;
            txt_pass.PasswordChar = '*';
        }
    }
}
