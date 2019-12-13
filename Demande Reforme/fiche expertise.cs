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
    public partial class fiche_expertise : Form
    {
        public fiche_expertise()
        {
            InitializeComponent();
        }
        ConnectionDB cdb = new ConnectionDB();

        private void cmb_num_SelectedIndexChanged(object sender, EventArgs e)
        {
            cdb.con.Open();
            cdb.cmd = new SqlCommand("select SA  from identification where num=" + cmb_num.SelectedItem, cdb.con);
            SqlDataReader dr = cdb.cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_sa.Text = dr[0].ToString();
            }
            cdb.con.Close();

            cdb.con.Open();
            cdb.cmd = new SqlCommand("select Servicee  from DEMANDE where Num_DEMANDE=" + cmb_num.SelectedItem, cdb.con);
            SqlDataReader drR = cdb.cmd.ExecuteReader();
            while (drR.Read())
            {
                TXT_SERVICE.Text = drR[0].ToString();
            }
            cdb.con.Close();
        }

        private void fermer_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void imprimer_Click(object sender, EventArgs e)
        {
            Print(panel_general);
        }
        Bitmap bmp;
        PrintPreviewDialog ppd = new PrintPreviewDialog();
        PrintDocument pd = new PrintDocument();
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
            e.Graphics.DrawImage(bmp, (pagearea.Width / 4) - (this.panel_general.Width / 4), this.Location.Y);
        }
        public void getprintarea(Panel pnl)
        {
            bmp = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(bmp, new Rectangle(0, 0, pnl.Width, pnl.Height));
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu m = new menu();
            m.Show();
        }

        private void fiche_expertise_Load(object sender, EventArgs e)
        {
            label_date.Text += DateTime.Now.Day + " / " + DateTime.Now.Month + " / " + DateTime.Now.Year;
            cdb.con.Open();
            String req = "select Num_DEMANDE from DEMANDE";
            cdb.cmd = new SqlCommand(req, cdb.con);
            SqlDataReader dr = cdb.cmd.ExecuteReader();
            while (dr.Read())
            {
                cmb_num.Items.Add(dr[0]);
            }
            cdb.con.Close();
        }
    }
}
