using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModerateValidation
{
    public partial class SignupForm : Form
    {
        private const String placeholder_firstname = "FIRST NAME";
        private const String placeholder_lastname = "LAST NAME";
        private const String placeholder_username = "USER NAME";
        private const String placeholder_phone = "PHONE NUNBER";
        private const String placeholder_email = "EMAIL";
        private const String placeholder_workfield = "WORK FIELD";
        private const String placeholder_pass = "PASSWORD";
        private const String placeholder_passconfirm = "RETYPE PASSWORD";

        private bool mouseDown;
        private Point lastLocation;


        public SignupForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SignupForm_Load(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void SignupForm_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void SignupForm_MouseMove(object sender, MouseEventArgs e)
        {

            

        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void SignupForm_MouseUp(object sender, MouseEventArgs e)
        {
          
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(string.Equals(txtFirstName.Text, placeholder_firstname, StringComparison.OrdinalIgnoreCase))
            {
                txtFirstName.Text = "";
                txtFirstName.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = placeholder_firstname;
                txtFirstName.ForeColor = Color.Silver;
            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtLastName.Text, placeholder_lastname, StringComparison.OrdinalIgnoreCase))
            {
                txtLastName.Text = "";
                txtLastName.ForeColor = Color.White;
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = placeholder_lastname;
                txtLastName.ForeColor = Color.Silver;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = placeholder_username;
                txtUsername.ForeColor = Color.Silver;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtUsername.Text, placeholder_username, StringComparison.OrdinalIgnoreCase))
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.White;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtEmail.Text, placeholder_email, StringComparison.OrdinalIgnoreCase))
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.White;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                txtEmail.Text = placeholder_email;
                txtEmail.ForeColor = Color.Silver;
            }
        }

        private void txtPhone_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtPhone.Text, placeholder_phone, StringComparison.OrdinalIgnoreCase))
            {
                txtPhone.Text = "";
                txtPhone.ForeColor = Color.White;
            }
        }

        private void txtPhone_Leave(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                txtPhone.Text = placeholder_phone;
                txtPhone.ForeColor = Color.Silver;
            }

        }

        private void txtWorkField_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtWorkField.Text, placeholder_workfield, StringComparison.OrdinalIgnoreCase))
            {
                txtWorkField.Text = "";
                txtWorkField.ForeColor = Color.White;
            }
        }

        private void txtWorkField_Leave(object sender, EventArgs e)
        {
            if (txtWorkField.Text == "")
            {
                txtWorkField.Text = placeholder_workfield;
                txtWorkField.ForeColor = Color.Silver;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtPass.Text, placeholder_pass, StringComparison.OrdinalIgnoreCase))
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = placeholder_pass;
                txtPass.ForeColor = Color.Silver;
            }
        }

        private void txtPassConfirm_Enter(object sender, EventArgs e)
        {
            if (string.Equals(txtPassConfirm.Text, placeholder_passconfirm, StringComparison.OrdinalIgnoreCase))
            {
                txtPassConfirm.Text = "";
                txtPassConfirm.ForeColor = Color.White;
            }
        }

        private void txtPassConfirm_Leave(object sender, EventArgs e)
        {
            if (txtPassConfirm.Text == "")
            {
                txtPassConfirm.Text = placeholder_passconfirm;
                txtPassConfirm.ForeColor = Color.Silver;
            }
        }
    }
}
