using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TJQ
{
    public partial class Setup : Form
    {
        //For menu border style
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public Setup()
        {
            InitializeComponent();

            Success("Ready");

            //Get Stored Logins
            txtBoxUsername210M.Text = Properties.Settings.Default.Username210M;

            txtBoxPassword210M.Text = Properties.Settings.Default.Password210M;

            txtBoxUsername3501.Text = Properties.Settings.Default.Username3501;

            txtBoxPassword3501.Text = Properties.Settings.Default.Password3501;

            txtBoxUsername3502.Text = Properties.Settings.Default.Username3502;

            txtBoxPassword3502.Text = Properties.Settings.Default.Password3502;

            if (Properties.Settings.Default.DefaultOID == "MNLPH210M")
                radBtnDefault210M.Checked = true;
            else if (Properties.Settings.Default.DefaultOID == "MNLPH3501")
                radBtnDefault3501.Checked = true;
            else if (Properties.Settings.Default.DefaultOID == "MNLPH3502")
                radBtnDefault3502.Checked = true;
        }

        private void MenuMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Error(string _errorMessage)
        {
            lblMessage.Text = _errorMessage;

            panelBottom.BackColor = Color.Red;
        }

        private void Success(string successMessage)
        {
            lblMessage.Text = successMessage;

            panelBottom.BackColor = Color.FromArgb(104, 33, 122);

            lblMessage.Refresh();

            panelBottom.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Save login for 210M
            if(txtBoxUsername210M.Text != "" && txtBoxPassword210M.Text != "")
            {
                Properties.Settings.Default.Username210M = txtBoxUsername210M.Text;

                Properties.Settings.Default.Password210M = txtBoxPassword210M.Text;
            }
            else if(txtBoxPassword210M.Text != "" || txtBoxPassword210M.Text != "")
            {
                Error("Please complete login info for MNLPH210M");

                return;
            }

            //Save login for 3501
            if (txtBoxUsername3501.Text != "" && txtBoxPassword3501.Text != "")
            {
                Properties.Settings.Default.Username3501 = txtBoxUsername3501.Text;

                Properties.Settings.Default.Password3501 = txtBoxPassword3501.Text;
            }
            else if (txtBoxPassword3501.Text != "" || txtBoxPassword3501.Text != "")
            {
                Error("Please complete login info for MNLPH3501");

                return;
            }

            //Save login for 3502
            if (txtBoxUsername3502.Text != "" && txtBoxPassword3502.Text != "")
            {
                Properties.Settings.Default.Username3502 = txtBoxUsername3502.Text;

                Properties.Settings.Default.Password3502 = txtBoxPassword3502.Text;
            }
            else if (txtBoxPassword3502.Text != "" || txtBoxPassword3502.Text != "")
            {
                Error("Please complete login info for MNLPH3502");

                return;
            }

            if (radBtnDefault210M.Checked)
                Properties.Settings.Default.DefaultOID = "MNLPH210M";
            else if (radBtnDefault3501.Checked)
                Properties.Settings.Default.DefaultOID = "MNLPH3501";
            else if (radBtnDefault3502.Checked)
                Properties.Settings.Default.DefaultOID = "MNLPH3502";
            else
            {
                Error("Please select default office ID");

                return;
            }

            Properties.Settings.Default.Save();

            Success("Office ID login successfully saved");

            Close();
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MenuMove(e);
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            MenuMove(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnShowPassword210M_MouseDown(object sender, MouseEventArgs e)
        {
            txtBoxPassword210M.UseSystemPasswordChar = false;
        }

        private void btnShowPassword210M_MouseUp(object sender, MouseEventArgs e)
        {
            txtBoxPassword210M.UseSystemPasswordChar = true;
        }

        private void btnShowPassword3501_MouseDown(object sender, MouseEventArgs e)
        {
            txtBoxPassword3501.UseSystemPasswordChar = false;
        }

        private void btnShowPassword3501_MouseUp(object sender, MouseEventArgs e)
        {
            txtBoxPassword3501.UseSystemPasswordChar = true;
        }

        private void btnShowPassword3502_MouseDown(object sender, MouseEventArgs e)
        {
            txtBoxPassword3502.UseSystemPasswordChar = false;
        }

        private void btnShowPassword3502_MouseUp(object sender, MouseEventArgs e)
        {
            txtBoxPassword3502.UseSystemPasswordChar = true;
        }

        private void radBtnDefault210M_MouseDown(object sender, MouseEventArgs e)
        {
            radBtnDefault3501.Checked = radBtnDefault3502.Checked = false;
        }

        private void radBtnDefault3501_MouseDown(object sender, MouseEventArgs e)
        {
            radBtnDefault210M.Checked = radBtnDefault3502.Checked = false;
        }

        private void radBtnDefault3502_MouseDown(object sender, MouseEventArgs e)
        {
            radBtnDefault210M.Checked = radBtnDefault3501.Checked = false;
        }

        private void Setup_Load(object sender, EventArgs e)
        {

        }
    }
}
