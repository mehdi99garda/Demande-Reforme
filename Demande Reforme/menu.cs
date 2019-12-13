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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }
        ConnectionDB cdb = new ConnectionDB();

        private void btn_new_Click(object sender, EventArgs e)
        {
            panel_aff.Visible = true;
            panel_maj.Visible = false;
        }

        private void btn_maj_Click(object sender, EventArgs e)
        {
            panel_aff.Visible = false;
            panel_maj.Visible = true;
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (txt_pass1.Text != txt_pass2.Text)
            {
                MessageBox.Show("la confirmation de mot passe est incorrect");
            }
            else
            {
                if (txt_user.Text != "" && txt_pass1.Text != "" && txt_pass2.Text != "")
                {
                    cdb.con.Open();
                    string req2 = "insert into loggin values('" + txt_user.Text + "','" + txt_pass1.Text + "')";
                    cdb.cmd = new SqlCommand(req2, cdb.con);
                    cdb.cmd.ExecuteNonQuery();
                    cdb.con.Close();
                    MessageBox.Show("**ajout effectue avec succees**");
                }
                else
                {
                    MessageBox.Show("**Remplir tous les champs**");
                }
            }
        }

        private void btn_fermer_Click(object sender, EventArgs e)
        {
            panel_aff.Visible = false;
        }

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (txt2_pass1.Text != txt2_pass2.Text)
            {
                MessageBox.Show("la confirmation de mot passe est incorrect");
            }
            else
            {
                if (txt2_user1.Text != "" && txt2_user2.Text != "" && txt2_pass1.Text != "" && txt2_pass2.Text != "")
                {
                    cdb.con.Open();
                    string req2 = "update loggin set username='" + txt2_user2.Text + "',pass='" + txt2_pass1.Text + "' where username='" + txt2_user1.Text + "'";
                    cdb.cmd = new SqlCommand(req2, cdb.con);
                    cdb.cmd.ExecuteNonQuery();
                    int i;
                    i = cdb.cmd.ExecuteNonQuery();
                    cdb.con.Close();
                    if (i == 0)
                    {
                        MessageBox.Show("**username non existe**");
                    }
                    else
                    {
                        MessageBox.Show("**modification effectue avec succees**");
                    }
                }
                else
                {
                    MessageBox.Show("**Remplir tous les champs**");
                }
            }
        }

        private void button3btn_supp_Click(object sender, EventArgs e)
        {
            if (txt2_user1.Text != "")
            {
                cdb.con.Open();
                string req2 = "delete from loggin where username='" + txt2_user1.Text + "'";
                cdb.cmd = new SqlCommand(req2, cdb.con);
                int i;
                i = cdb.cmd.ExecuteNonQuery();
                cdb.con.Close();
                if (i == 0)
                {
                    MessageBox.Show("**username non existe**");
                }
                else
                {
                    MessageBox.Show("**suppression effectue avec succees**");
                }

            }
            else
            {
                MessageBox.Show("**entrer username que vous voulez supprimer**");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            panel_maj.Visible = false;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            panel_aff.Visible = false;
            panel_maj.Visible = false;
            txt_pass1.PasswordChar = '*';
            txt_pass2.PasswordChar = '*';
            txt2_pass1.PasswordChar = '*';
            txt2_pass2.PasswordChar = '*';
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            principale p = new principale();
            p.Show();
        }

        private void btn_demande_Click(object sender, EventArgs e)
        {
            this.Hide();
            demande d = new demande();
            d.Show();
        }

        private void btn_fiche_Click(object sender, EventArgs e)
        {
            this.Hide();
            fiche_expertise ff = new fiche_expertise();
            ff.Show();
        }

        private void btn_PV_Click(object sender, EventArgs e)
        {
            this.Hide();
            pv_mise p = new pv_mise();
            p.Show();
        }
    }
}
