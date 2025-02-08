using System;
using System.Data;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SQL Connection 
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NCOL2RG\SQLEXPRESS;Initial Catalog=My2025;Integrated Security=True");


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); //close the form window method
        }

        private void txtUsername_MouseClick(object sender, MouseEventArgs e)
        {
            //clear the username text
            if (txtUserName.Text == "User Name")
            {
                txtUserName.Clear();
            }
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            //clear the password text
            if (txtPassword.Text == "Password")
            {
                txtPassword.Clear();
                // hide the password text
                txtPassword.PasswordChar = '*';
            }
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            //add link to image
            System.Diagnostics.Process.Start("https:/www.facebook.com");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        // loging button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username, user_password;
            username = txtUserName.Text;
            user_password = txtPassword.Text;

            try
            {
                string querry = "SELECT * FROM login_1 WHERE username = '"+txtUserName.Text+"' AND password = '"+txtPassword.Text+"' ";
                SqlDataAdapter sdq = new SqlDataAdapter(querry, conn);

                DataTable data_table = new DataTable();
                sdq.Fill(data_table);

                if(data_table.Rows.Count > 0)
                {
                    username = txtUserName.Text;
                    user_password = txtPassword.Text;

                    //connection to new page
                    Menu form2 = new Menu();
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Login datails","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtUserName.Clear();
                    txtPassword.Clear();

                    //to focus username
                    txtUserName.Focus();
                }
            }   
            catch
            {
                MessageBox.Show("Error");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
