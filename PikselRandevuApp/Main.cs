using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facade;
using Entity;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;

namespace PikselRandevuApp
{
    public partial class Main : Form
    {
        private SerialPort myport;
        public Main()
        {
            InitializeComponent();
            init();
        }
        private void init()

        {

            try
            {
                myport = new SerialPort();
                myport.BaudRate = 9600;
                string port=File.ReadAllText(Application.StartupPath + "\\portinfo.txt");
                myport.PortName = port;
                myport.Open();

                //btn13_btn.Enabled = true;
                //btn14_btn.Enabled = false;
            }

            catch (Exception)
            {
                MessageBox.Show("Error");

            }

        }

        private int userID = 0;
        private int logoutct = 0;
        int resid, pid;
        string[] rescgfs;
        private void Main_Load(object sender, EventArgs e)
        {
            List<resources> reslst;
            rescgfs = File.ReadAllLines(Application.StartupPath + "\\rescfg.txt");
            reslst = Facade.Resources.ResNameByRids(rescgfs[0]);
            for (int i = 0; i < 8; i++)
            {
                if (i <= reslst.Count - 1)
                {
                    string buttonName = "lblr" + (i + 1);
                    Control getcont = grpResources.Controls[buttonName];
                    getcont.Text = reslst[i]._resource_name;
                    getcont.Tag = reslst[i]._resource_id;
                    if (Resources.ResourceStatuCheck(reslst[i]._resource_id) == false)
                    {
                        getcont.ForeColor = Color.Red;
                    }
                    else
                    {
                        getcont.ForeColor = Color.Green;
                    }
                }
            }
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            users users = new users();
            Entity.user usermdl = new Entity.user();
            Sifre sifre = new Sifre();
            usermdl._username = txtUserName.Text;
            usermdl._password = sifre.TextSifrele(txtPassword.Text);

            DataRow dr = users.Kullanici_Sorgula(usermdl);

            if (dr != null)
            {
                userID = Convert.ToInt32(dr["uid"].ToString());
                DataRow curusage = Facade.Kullanim.ArayGetCurrentUsage(userID, rescgfs[0]);
                if (curusage != null)
                {
                    lblSessionStart.Text = Convert.ToDateTime(curusage["basla"].ToString()).ToString("dd.MM.yyyy hh:mm:ss");
                    lblSessionEnd.Text = "-";
                    lblSessionSpent.Text = curusage["curmin"].ToString();
                    lblSessionSpent.Tag = curusage["kullanim_id"].ToString();
                }
                else
                {
                    DataRow datr = Facade.Reservation.AraYazilimReservationGETOneByUid(userID);
                    if (datr != null)
                    {
                        lblProject.Text = datr["project_title"].ToString();
                        lblPi.Text = datr["user_fullname"].ToString();
                        lblResource.Text = datr["resource_name"].ToString();
                        lblDate.Text = Convert.ToDateTime(datr["reservation_start"].ToString()).ToShortDateString() + " - " + Convert.ToDateTime(datr["reservation_end"].ToString()).ToShortDateString();
                        lblTime.Text = Convert.ToDateTime(datr["reservation_start"].ToString()).ToShortTimeString() + " - " + Convert.ToDateTime(datr["reservation_end"].ToString()).ToShortTimeString();
                        btnStartSession.Tag = datr["rid"].ToString();
                        pid = Convert.ToInt32(datr["rid"].ToString());
                        resid = Convert.ToInt32(datr["resid"].ToString());
                        btnLogin.Enabled = false;
                        txtUserName.Enabled = false;
                        txtPassword.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("You don't have any reservation, please try again correct time!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong password or username !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tmrLogout_Tick(object sender, EventArgs e)
        {
            logoutct++;
            if (logoutct == 20)
            {
                btnLogin.Enabled = true;
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                lblProject.Text = string.Empty;
                lblDate.Text = string.Empty;
                lblPi.Text = string.Empty;
                lblResource.Text = string.Empty;
                lblSessionEnd.Text = string.Empty;
                lblSessionSpent.Text = string.Empty;
                lblSessionStart.Text = string.Empty;
                lblTime.Text = string.Empty;
            }
        }

        private void btnStartSession_Click(object sender, EventArgs e)
        {
            tmrLogout.Start();
            foreach (Control item in grpResources.Controls)
            {
                if (item.Tag != null && btnStartSession.Tag != null && btnStartSession.Tag.ToString() == item.Tag.ToString())
                {
                    int rid = Convert.ToInt32(btnStartSession.Tag.ToString());
                    bool sonuc = Facade.Kullanim.ArayYeniKullanimEkle(pid, userID, rid, resid);
                    DataRow curusage = Facade.Kullanim.ArayGetCurrentUsage(userID, rescgfs[0]);
                    if (curusage != null)
                    {
                        lblSessionStart.Text = Convert.ToDateTime(curusage["basla"].ToString()).ToString("dd.MM.yyyy hh:mm:ss");
                        lblSessionEnd.Text = "-";
                        lblSessionSpent.Text = curusage["curmin"].ToString();
                        lblSessionSpent.Tag = curusage["kullanim_id"].ToString();
                        //serialRoleAcKapa role = new serialRoleAcKapa();
                        //string[] portlar = role.acikPortlariGetir();
                        //SerialPort portum = new SerialPort("COM37");
                        //role.serialPort = portum;
                        //if (!role.serialPortAcikMi(role.serialPort))
                        //{
                        //    role.serialPortAc("COM37");
                            
                        //}
                        //else
                        //{
                        //    role.roleHepsiKapan();
                        //}
                        for (int i = 0, m = 0; i < rescgfs[0].Length; i++)
                        {
                            char ch = rescgfs[0][i];
                            if (ch != ',')
                            {
                                if (Convert.ToInt32(ch.ToString()) == rid)
                                {
                                    m = m + 1;
                                    //myport.WriteLine(m.ToString());
                                    btnEndSession.Tag = m.ToString();
                                    return;
                                }
                                else
                                {
                                    m++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnEndSession_Click(object sender, EventArgs e)
        {
            int kulid = Convert.ToInt32(lblSessionSpent.Tag.ToString());
            bool sonuc = Facade.Kullanim.ArayKullanimBitir(userID, kulid);
            if (sonuc)
            {
                MessageBox.Show("Usage completed !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try
                {
                    int roleid = Convert.ToInt32(btnEndSession.Tag.ToString());
                    if (roleid != 0)
                    {
                        //serialRoleAcKapa role = new serialRoleAcKapa();
                        //string[] portlar = role.acikPortlariGetir();
                        //SerialPort portum = new SerialPort("COM37");
                        //role.serialPort = portum;
                        //if (!role.serialPortAcikMi(role.serialPort))
                        //{
                        //    role.serialPortAc("COM37");

                        //}
                        //else
                        //{
                        //    role.roleHepsiKapan();
                        //}
                        string rolec = "";
                        switch (roleid)
                        {
                            case 1:rolec = "a";break;
                            case 2: rolec = "b"; break;
                            case 3: rolec = "c"; break;
                            case 4: rolec = "d"; break;
                            case 5: rolec = "e"; break;
                            case 6: rolec = "f"; break;
                            case 7: rolec = "g"; break;
                            case 8: rolec = "h"; break;
                            default:rolec = "";
                                break;
                        }
                        myport.WriteLine(rolec);
                    }
                }
                catch (Exception ex)
                {
                    
                }

                
                btnLogin.Enabled = true;
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                lblProject.Text = string.Empty;
                lblDate.Text = string.Empty;
                lblPi.Text = string.Empty;
                lblResource.Text = string.Empty;
                lblSessionEnd.Text = string.Empty;
                lblSessionSpent.Text = string.Empty;
                lblSessionStart.Text = string.Empty;
                lblTime.Text = string.Empty;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = true;
            txtUserName.Enabled = true;
            txtPassword.Enabled = true;
            lblProject.Text = string.Empty;
            lblDate.Text = string.Empty;
            lblPi.Text = string.Empty;
            lblResource.Text = string.Empty;
            lblSessionEnd.Text = string.Empty;
            lblSessionSpent.Text = string.Empty;
            lblSessionStart.Text = string.Empty;
            lblTime.Text = string.Empty;
        }
    }
}
