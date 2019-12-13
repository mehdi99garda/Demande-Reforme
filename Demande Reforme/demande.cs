using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demande_Reforme
{
    public partial class demande : Form
    {
        public demande()
        {
            InitializeComponent();
        }
        ConnectionDB cdb = new ConnectionDB();
        public int num_demande;
        private void demande_Load(object sender, EventArgs e)
        {
            cdb.con.Open();
            String req = "select Num_DEMANDE from DEMANDE";
            cdb.cmd = new SqlCommand(req, cdb.con);
            SqlDataReader dr = cdb.cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_num.Items.Add(dr[0]);
            }
            cdb.con.Close();
            cdb.con.Open();
            cdb.cmd = new SqlCommand("select count(Num_DEMANDE)  from DEMANDE", cdb.con);
            SqlDataReader drr = cdb.cmd.ExecuteReader();
            drr.Read();
            num_demande = (Convert.ToInt16(drr[0]) + 1);
            affiche_num.Text = "" + num_demande;
            cdb.con.Close();
            btn_modifier.Enabled = false;
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu mm = new menu();
            mm.Show();
        }

        private void cmb_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            num_demande = Convert.ToUInt16(cmb_num.SelectedItem);
            cdb.con.Open();
            string q = "select * from identification where num=" + num_demande;
            cdb.cmd = new SqlCommand(q, cdb.con);
            SqlDataReader d = cdb.cmd.ExecuteReader();
            while (d.Read())
            {

                txt_description.Text = d[1].ToString();
                txt_quantite.Text = d[2].ToString();
                comboBox1.Text = d[3].ToString();
                txt_principale.Text = d[4].ToString();
                txt_secondaire.Text = d[5].ToString();
                txt_usage.Text = d[6].ToString();
                txt_nature.Text = d[7].ToString();
                txt_num_inventaire.Text = d[8].ToString();
                txt_num_serie.Text = d[9].ToString();
                txt_num_parent.Text = d[10].ToString();
                txt_sa.Text = d[11].ToString();
                txt_commune.Text = d[12].ToString();
                txt_nz.Text = d[13].ToString();
                txt_ste.Text = d[14].ToString();
                txt_produit.Text = d[15].ToString();
                txt_sa_cliente.Text = d[16].ToString();
                txt_matricule.Text = d[17].ToString();
                txt_nom.Text = d[18].ToString();

            }
            cdb.con.Close();
            //part2
            cdb.con.Open();
            string req = "select * from DEMANDE where Num_DEMANDE=" + num_demande;
            SqlCommand cd = new SqlCommand(req, cdb.con);
            SqlDataReader dr = cd.ExecuteReader();
            while (dr.Read())
            {
                affiche_num.Text = dr[0].ToString();
                txt_code.Text = dr[1].ToString();
                txt_num_immo.Text = dr[2].ToString();
                txt_service.Text = dr[3].ToString();
            }
            cdb.con.Close();
            btn_modifier.Enabled = true;
        }

        private void btn_rechercher_Click(object sender, EventArgs e)
        {
            try
            {
                num_demande = Convert.ToUInt16(cmb_num.Text);
                cdb.con.Open();
                string q = "select * from identification where num=" + num_demande;
                cdb.cmd = new SqlCommand(q, cdb.con);
                SqlDataReader d = cdb.cmd.ExecuteReader();
                while (d.Read())
                {

                    txt_description.Text = d[1].ToString();
                    txt_quantite.Text = d[2].ToString();
                    comboBox1.Text = d[3].ToString();
                    txt_principale.Text = d[4].ToString();
                    txt_secondaire.Text = d[5].ToString();
                    txt_usage.Text = d[6].ToString();
                    txt_nature.Text = d[7].ToString();
                    txt_num_inventaire.Text = d[8].ToString();
                    txt_num_serie.Text = d[9].ToString();
                    txt_num_parent.Text = d[10].ToString();
                    txt_sa.Text = d[11].ToString();
                    txt_commune.Text = d[12].ToString();
                    txt_nz.Text = d[13].ToString();
                    txt_ste.Text = d[14].ToString();
                    txt_produit.Text = d[15].ToString();
                    txt_sa_cliente.Text = d[16].ToString();
                    txt_matricule.Text = d[17].ToString();
                    txt_nom.Text = d[18].ToString();
                }
            }
            catch
            {
                MessageBox.Show("Non existe !!");
            }
            cdb.con.Close();
            //2
            cdb.con.Open();
            string req = "select * from DEMANDE where Num_DEMANDE=" + num_demande;
            SqlCommand cd = new SqlCommand(req, cdb.con);
            SqlDataReader dr = cd.ExecuteReader();
            while (dr.Read())
            {
                affiche_num.Text = dr[0].ToString();
                txt_code.Text = dr[1].ToString();
                txt_num_immo.Text = dr[2].ToString();
                txt_service.Text = dr[3].ToString();
            }
            cdb.con.Close();
            btn_modifier.Enabled = true;
        }
        public static string suje= "Répondre validation";
        public static int b = 0;
        private void btn_env_Click(object sender, EventArgs e)
        {
            b = 1;
            this.Hide();
            Envoyer_MAIL em = new Envoyer_MAIL();
            em.Show();
        }

        public string unite = "";
        public string achete = "";
        public string r1 = "";
        public string r2 = "";
        public string r3 = "";
        public string r4 = "";
        public string r5 = "";
        public string r6 = "";
        public string r7 = "";
        public string piece = "";

        private void btn_modifier_Click(object sender, EventArgs e)
        {
            if (rd1_oui.Checked == true)
            {
                r1 = rd1_oui.Text;
            }
            else
            {
                r1 = rd1_non.Text;
            }
            if (rd2_oui.Checked == true)
            {
                r2 = rd2_oui.Text;
            }
            else
            {
                r2 = rd2_non.Text;
            }

            if (rd3_oui.Checked == true)
            {
                r3 = rd3_oui.Text;
            }
            else
            {
                r3 = rd3_non.Text;
            }
            if (rd4_oui.Checked == true)
            {
                r4 = rd4_oui.Text;
            }
            else
            {
                r4 = rd4_non.Text;
            }
            if (rd5_oui.Checked == true)
            {
                r5 = rd5_oui.Text;
            }
            else
            {
                r5 = rd5_non.Text;
            }
            if (rd6_oui.Checked == true)
            {
                r6 = rd6_oui.Text;
            }
            else
            {
                r6 = rd6_non.Text;
            }
            if (rd7_oui.Checked == true)
            {
                r7 = rd7_oui.Text;
            }
            else
            {
                r7 = rd7_non.Text;
            }

            if (rd1_piece.Checked == true)
            {
                piece = rd1_piece.Text;
            }
            else
            {
                if (rd2_piece.Checked == true)
                {
                    piece = rd2_piece.Text;
                }
                else
                {
                    if (rd3_piece.Checked == true)
                    {
                        piece = rd3_piece.Text;
                    }
                    else
                    {
                        if (rd4_piece.Checked == true)
                        {
                            piece = rd4_piece.Text;
                        }
                        else
                        {
                            if (rd5_piece.Checked == true)
                            {
                                piece = rd5_piece.Text;
                            }
                            else
                            {
                                if (rd6_piece.Checked == true)
                                {
                                    piece = rd6_piece.Text;
                                }
                            }
                        }
                    }
                }
            }
            cdb.con.Open();
            //update identification set
            string str = "update identification set ";
            //descri = '1', quantite = '2', code_unite = '3',
            str += "descri = '" + txt_description.Text + "', quantite = '" + txt_quantite.Text + "', code_unite = '" + comboBox1.SelectedItem + "',";
            //cat_principale = '1', cat_secondaire = '2', cle_usage = '3', cle_nature = '4',
            str += "cat_principale = '" + txt_principale.Text + "', cat_secondaire = '" + txt_secondaire.Text + "', cle_usage = '" + txt_usage.Text + "', cle_nature = '" + txt_nature.Text + "',";
            //Numero_inv = '1', Numero_serie = '2', N_immo_parent = '3',
            str += "Numero_inv = '" + txt_num_inventaire.Text + "', Numero_serie = '" + txt_num_serie.Text + "', N_immo_parent = '" + txt_num_parent.Text + "',";
            //SA = '1', Commune = '2', NZ = '3',
            str += "SA = '" + txt_sa.Text + "', Commune = '" + txt_commune.Text + "', NZ = '" + txt_nz.Text + "',";
            //ste_cc = '1', produit = '2', SA_client = '3',
            str += "ste_cc = '" + txt_ste.Text + "', produit = '" + txt_produit.Text + "', SA_client = '" + txt_sa_cliente.Text + "',";
            //mat_agent = '1', nom = '2' where num = 1
            str += "mat_agent = '" + txt_matricule.Text + "', nom = '" + txt_nom.Text + "' where num = " + num_demande;
            SqlCommand cmm = new SqlCommand(str, cdb.con);
            cmm.ExecuteNonQuery();
            cdb.con.Close();
            try
            {
                cdb.con.Open();
                //table caracteristique
                //insert into caracteristique values(
                string rec = "insert into caracteristique values(" + num_demande + ",";
                //'moha', 'hada', 'nouveau',
                rec += "'" + txt_fournisseur.Text + "', '" + txt_fabricant.Text + "', '" + achete + "',";
                //'1', '2', 3, 4, 5,
                rec += "'" + txt_cout.Text + "', '" + txt_mise_service.Text + "', " + Convert.ToInt16(num_fiscale.Text) + ", " + Convert.ToInt16(num_technique.Text) + ", " + Convert.ToInt16(num_garantie.Text) + ",";
                //'1', '2', '3', '4', '5', '6', '7',
                rec += "'" + txt_puissance.Text + "', '" + txt_debit.Text + "', '" + txt_vitesse.Text + "', '" + txt_intensite.Text + "', '" + txt_pression.Text + "', '" + txt_tension.Text + "', '" + txt_rapport.Text + "',";
                //'1', '2', '3')
                rec += "'" + marque.Text + "', '" + txt_immatri.Text + "', '" + txt_autres.Text + "')";
                SqlCommand c3 = new SqlCommand(rec, cdb.con);
                c3.ExecuteNonQuery();
                //table situation..
                //insert into situation values(
                string rq = "insert into situation values(" + num_demande + ",";
                //'1', '2', '3', '4', '5', '6', '7',
                rq += "'" + r1 + "', '" + r2 + "', '" + r3 + "', '" + r4 + "', '" + r5 + "', '" + r6 + "', '" + r7 + "',";
                //'1','1')
                rq += "'" + piece + "','" + txt_comment.Text + "')";
                SqlCommand kk = new SqlCommand(rq, cdb.con);
                kk.ExecuteNonQuery();
                cdb.con.Close();
                MessageBox.Show("** Modification effectue **");
            }
            catch
            {
                MessageBox.Show("identification de l'immobilisation est modifie \n les autres non modifie ");
            }
        }

        Bitmap bmp;
        PrintPreviewDialog ppd = new PrintPreviewDialog();
        PrintDocument pd = new PrintDocument();

        private void imprimer_Click(object sender, EventArgs e)
        {
            ////table 1
            //txt_code.BorderStyle = BorderStyle.None;
            //txt_num_immo.BorderStyle = BorderStyle.None;
            //txt_service.BorderStyle = BorderStyle.None;
            ////table 2
            //txt_description.BorderStyle = BorderStyle.None;
            //txt_quantite.BorderStyle = BorderStyle.None;
            //txt_principale.BorderStyle = BorderStyle.None;
            //txt_secondaire.BorderStyle = BorderStyle.None;
            //txt_usage.BorderStyle = BorderStyle.None;
            //txt_nature.BorderStyle = BorderStyle.None;
            //txt_num_inventaire.BorderStyle = BorderStyle.None;
            //txt_num_serie.BorderStyle = BorderStyle.None;
            //txt_num_parent.BorderStyle = BorderStyle.None;
            //txt_sa.BorderStyle = BorderStyle.None;
            //txt_commune.BorderStyle = BorderStyle.None;
            //txt_nz.BorderStyle = BorderStyle.None;
            //txt_ste.BorderStyle = BorderStyle.None;
            //txt_produit.BorderStyle = BorderStyle.None;
            //txt_sa_cliente.BorderStyle = BorderStyle.None;
            //txt_matricule.BorderStyle = BorderStyle.None;
            //txt_nom.BorderStyle = BorderStyle.None;
            ////table 3
            //txt_fournisseur.BorderStyle = BorderStyle.None;
            //txt_fabricant.BorderStyle = BorderStyle.None;
            //txt_cout.BorderStyle = BorderStyle.None;
            //txt_mise_service.BorderStyle = BorderStyle.None;
            //num_fiscale.BorderStyle = BorderStyle.None;
            //num_technique.BorderStyle = BorderStyle.None;
            //num_garantie.BorderStyle = BorderStyle.None;
            //txt_puissance.BorderStyle = BorderStyle.None;
            //txt_debit.BorderStyle = BorderStyle.None;
            //txt_debit.BorderStyle = BorderStyle.None;
            //txt_intensite.BorderStyle = BorderStyle.None;
            //txt_pression.BorderStyle = BorderStyle.None;
            //txt_tension.BorderStyle = BorderStyle.None;
            //txt_rapport.BorderStyle = BorderStyle.None;
            //marque.BorderStyle = BorderStyle.None;
            //txt_immatri.BorderStyle = BorderStyle.None;
            //txt_autres.BorderStyle = BorderStyle.None;
            //txt_comment.BorderStyle = BorderStyle.None;
            //txt_vitesse.BorderStyle = BorderStyle.None;
            ////fin
            //imprimer
            Print(panel_general);
            ////debut
            ////table 1
            //txt_code.BorderStyle = BorderStyle.Fixed3D;
            //txt_num_immo.BorderStyle = BorderStyle.Fixed3D;
            //txt_service.BorderStyle = BorderStyle.Fixed3D;
            ////table 2
            //txt_description.BorderStyle = BorderStyle.Fixed3D;
            //txt_quantite.BorderStyle = BorderStyle.Fixed3D;
            //txt_principale.BorderStyle = BorderStyle.Fixed3D;
            //txt_secondaire.BorderStyle = BorderStyle.Fixed3D;
            //txt_usage.BorderStyle = BorderStyle.Fixed3D;
            //txt_nature.BorderStyle = BorderStyle.Fixed3D;
            //txt_num_inventaire.BorderStyle = BorderStyle.Fixed3D;
            //txt_num_serie.BorderStyle = BorderStyle.Fixed3D;
            //txt_num_parent.BorderStyle = BorderStyle.Fixed3D;
            //txt_sa.BorderStyle = BorderStyle.Fixed3D;
            //txt_commune.BorderStyle = BorderStyle.Fixed3D;
            //txt_nz.BorderStyle = BorderStyle.Fixed3D;
            //txt_ste.BorderStyle = BorderStyle.Fixed3D;
            //txt_produit.BorderStyle = BorderStyle.Fixed3D;
            //txt_sa_cliente.BorderStyle = BorderStyle.Fixed3D;
            //txt_matricule.BorderStyle = BorderStyle.Fixed3D;
            //txt_nom.BorderStyle = BorderStyle.Fixed3D;
            ////table 3
            //txt_fournisseur.BorderStyle = BorderStyle.Fixed3D;
            //txt_fabricant.BorderStyle = BorderStyle.Fixed3D;
            //txt_cout.BorderStyle = BorderStyle.Fixed3D;
            //txt_mise_service.BorderStyle = BorderStyle.Fixed3D;
            //num_fiscale.BorderStyle = BorderStyle.Fixed3D;
            //num_technique.BorderStyle = BorderStyle.Fixed3D;
            //num_garantie.BorderStyle = BorderStyle.Fixed3D;
            //txt_puissance.BorderStyle = BorderStyle.Fixed3D;
            //txt_debit.BorderStyle = BorderStyle.Fixed3D;
            //txt_debit.BorderStyle = BorderStyle.Fixed3D;
            //txt_intensite.BorderStyle = BorderStyle.Fixed3D;
            //txt_pression.BorderStyle = BorderStyle.Fixed3D;
            //txt_tension.BorderStyle = BorderStyle.Fixed3D;
            //txt_rapport.BorderStyle = BorderStyle.Fixed3D;
            //marque.BorderStyle = BorderStyle.Fixed3D;
            //txt_immatri.BorderStyle = BorderStyle.Fixed3D;
            //txt_autres.BorderStyle = BorderStyle.Fixed3D;
            //txt_comment.BorderStyle = BorderStyle.Fixed3D;
            //txt_vitesse.BorderStyle = BorderStyle.Fixed3D;
        }
        public void Print(Panel pnl)
        {
            PrinterSettings ps = new PrinterSettings();
            panel_general = pnl;
            getprintarea(pnl);
            ppd.Document = pd;
            pd.PrintPage += new PrintPageEventHandler(pd_pp);
            ppd.ShowDialog();
        }
        public void pd_pp(object sender, PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(bmp, (pagearea.Width / 22) - (this.panel_general.Width / 22), this.Location.Y);
        }
        public void getprintarea(Panel pnl)
        {
            bmp = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bmp, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
