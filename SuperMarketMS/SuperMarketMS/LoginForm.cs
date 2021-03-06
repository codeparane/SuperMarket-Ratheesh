﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarketMS
{
    public partial class LoginForm : Form
    {
        public static string loggedUser= "Null User";
        DbConn dbconn = new DbConn();
        public LoginForm()
        {
            InitializeComponent();
            txtUserName.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (loggedUser == "" || loggedUser == null)
            {
                loggedUser = "Null User";
                    };
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            dbconn.CloseConnection();
            dbconn.OpenConnection();
            bool isExecute = true;
            if (txtUserName.Text.Equals("") || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("User name or password can't be Empty !!!");
                isExecute = false;
            }
            if (dbconn.OpenConnection() == false)
            {
                MessageBox.Show("Cant connect to the database contact system Administrator.");
                isExecute = false;
            }

            if (isExecute == true)
            {
                string qr_getUserDetails = "SELECT * FROM users WHERE BINARY username = '" + txtUserName.Text + "' && userpw ='"
                    + txtPassword.Text + "';";
                MySqlCommand cm_getUserDetails = new MySqlCommand(qr_getUserDetails, dbconn.connection);
                MySqlDataReader dr_getUserDetails = cm_getUserDetails.ExecuteReader();

                if (dr_getUserDetails.HasRows)
                {
                    //MessageBox.Show("Success!!");
                    loggedUser = txtUserName.Text;

                    this.Hide();
                    DashBoard mainForm = new DashBoard();
                    mainForm.Show();

                }
                else
                {
                    MessageBox.Show("Username and Password are not Matched !!!");
                    txtUserName.Clear();
                    txtPassword.Clear();
                    txtUserName.Focus();
                }

                dbconn.CloseConnection();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
        
        }
    }
}
