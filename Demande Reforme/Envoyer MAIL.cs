using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demande_Reforme
{
    public partial class Envoyer_MAIL : Form
    {
        public Envoyer_MAIL()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            panel_msg.Visible = false;
            txt_msg.Visible = true;
        }

        private void btn_annuler_Click(object sender, EventArgs e)
        {
            txt_mail.Text = "";
            txt_pass.Text = "";
            txt_a_mail.Text = "";
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (Form1.a == 1)
            {
                this.Hide();
                Form1 ff = new Form1();
                ff.Show();
            }
            if (demande.b == 1)
            {
                this.Hide();
                demande ff = new demande();
                ff.Show();
            }
        }

        private void btn_envoyer_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage(txt_mail.Text, txt_a_mail.Text, txt_sujet.Text, txt_msg.Text);
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.Credentials = new NetworkCredential(txt_mail.Text, txt_pass.Text);
                client.EnableSsl = true;
                client.Send(mail);
                MessageBox.Show("Mail Envoyer", "Success", MessageBoxButtons.OK);
            }
            catch
            {
                try
                {
                    MailMessage mail = new MailMessage(txt_mail.Text, txt_a_mail.Text, txt_sujet.Text, txt_msg.Text);
                    SmtpClient client = new SmtpClient("smtp.outlook.com");
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(txt_mail.Text, txt_pass.Text);
                    client.EnableSsl = true;
                    client.Send(mail);
                    MessageBox.Show("Mail Envoyer", "Success", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Mail Non Envoyer", "erreur", MessageBoxButtons.OK);
                }
            }
        }

        private void Envoyer_MAIL_Load(object sender, EventArgs e)
        {
            txt_pass.PasswordChar = '*';
            //panel1.Visible = false;
            txt_msg.Visible = false;

            if(Form1.a == 1)
            {
                txt_msg.Text = Form1.msg;
                txt_sujet.Text = Form1.sujet;
            }
            else
            {
                if (demande.b == 1)
                {
                    txt_sujet.Text = demande.suje;
                }
            }
            
        }
    }
}
