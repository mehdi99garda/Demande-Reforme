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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string sujet;
        public static string msg;
        public static string num;
        public static string nom;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fermer_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez vous quitter ?", "Confirmer", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //cdb.con.Close();
                this.Close();
                Application.Exit();
            }
        }
        ConnectionDB cdb = new ConnectionDB();
        public static int a = 0;
        private void save_Click(object sender, EventArgs e)
        {

            if ((txt_num_immo.Text != "" || txt_nom.Text != "" || txt_num_serie.Text != "") && txt_service.Text != "" && txt_description.Text != "" && txt_sa.Text != "")
            {
                try
                {
                    //insert into DEMANDE values(3,'',123456,'')
                    cdb.con.Open();
                    string str = "insert into DEMANDE values(" + Convert.ToInt32(affiche_num.Text) + ",'" + txt_code.Text + "'," + Convert.ToInt64(txt_num_immo.Text) + ",'" + txt_service.Text + "')";
                    cdb.cmd = new SqlCommand(str, cdb.con);
                    cdb.cmd.ExecuteNonQuery();
                    //table 2
                    //insert into identification values(
                    string req = "insert into identification values(" + num_demande + ",";
                    //'1', '2', '3',
                    req += "'" + txt_description.Text + "', '" + txt_quantite.Text + "','" + comboBox1.SelectedItem + "',";
                    //'1', '2', '3', '4',
                    req += "'" + txt_principale.Text + "', '" + txt_secondaire.Text + "', '" + txt_usage.Text + "', '" + txt_nature.Text + "',";
                    //'1', '2', '3',
                    req += "'" + txt_num_inventaire.Text + "', '" + txt_num_serie.Text + "', '" + txt_num_parent.Text + "',";
                    //'1', '2', '3',
                    req += "'" + txt_sa.Text + "', '" + txt_commune.Text + "', '" + txt_nz.Text + "',";
                    //'1', '2', '3',
                    req += "'" + txt_ste.Text + "', '" + txt_produit.Text + "', '" + txt_sa_cliente.Text + "',";
                    //'1', '2')
                    req += "'" + txt_matricule.Text + "', '" + txt_nom.Text + "')";
                    SqlCommand cc = new SqlCommand(req, cdb.con);
                    cc.ExecuteNonQuery();
                    MessageBox.Show("**  effectue  avec succee**");
                    cdb.con.Close();
                    num = affiche_num.Text;
                    nom = txt_nom.Text;
                    sujet = "ATTENTE DE VALIDATION";
                    msg = "DEMANDE DE REFORME DES IMMOBILISATIONS en attente de validation \n **** Mr(Mme) : " + nom + "\n **** Numero de demande : " + num;

                    a = 1;
                    //envoyer mail
                    this.Hide();
                    Envoyer_MAIL em = new Envoyer_MAIL();
                    em.Show();
                }
                catch
                {
                    MessageBox.Show("******Erreur*****");
                }
            }
            else
            {
                MessageBox.Show("******Remplir les champs obligatoires*****");
            }
        }
        public static int num_demande;
        private void Form1_Load(object sender, EventArgs e)
        {
            cdb.con.Open();
            cdb.cmd = new SqlCommand("select count(Num_DEMANDE)  from DEMANDE", cdb.con);
            SqlDataReader drr = cdb.cmd.ExecuteReader();
            drr.Read();
            num_demande = (Convert.ToInt16(drr[0]) + 1);
            affiche_num.Text = "" + num_demande;
            //num_d = (Convert.ToInt16(drr[0]) + 1);
            cdb.con.Close();
        }

        private void back2_Click(object sender, EventArgs e)
        {
            this.Hide();
            principale p = new principale();
            p.Show();
        }
    }
}
