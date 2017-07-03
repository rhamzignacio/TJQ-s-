using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TJQ
{
    public partial class MainWindow : Form
    {
        //For menu border style
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        //===============Global Variables===============
        List<TJQModel> list210M = new List<TJQModel>();
        List<TJQModel> list3501 = new List<TJQModel>();
        List<TJQModel> list3502 = new List<TJQModel>();

        private void MenuMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Normal();

            lblMode.Text = "";

            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void topPanel_MouseDown(object sender, MouseEventArgs e)
        {
            MenuMove(e);
        }

        private void label8_MouseDown(object sender, MouseEventArgs e)
        {
            MenuMove(e);
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;

                btnMaximize.BackgroundImage = Properties.Resources.rsz_tick_blank;
            }
            else
            {
                WindowState = FormWindowState.Maximized;

                btnMaximize.Image = null;

                btnMaximize.BackgroundImage = Properties.Resources.rsz_duplicate;
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Maximized;

                btnMaximize.BackgroundImage = Properties.Resources.rsz_duplicate;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Normal;

                btnMaximize.BackgroundImage = Properties.Resources.rsz_tick_blank;
            }
        }

        private void cmbBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBoxType.Text == "AS OF")
            {
                dateTimeStart.Enabled = true;
                dateTimeEnd.Enabled = false;
            }
            else if(cmbBoxType.Text == "BETWEEN")
            {
                dateTimeStart.Enabled = true;
                dateTimeEnd.Enabled = true;
            }
            else
            {
                dateTimeStart.Enabled = false;
                dateTimeEnd.Enabled = false;
            }
        }

        private void Error(string _errorMessage)
        {
            lblMessage.Text = _errorMessage;

            panelBottom.BackColor = Color.Red;
        }

        private void Normal(string message = "Ready")
        {
            lblMessage.Text = message;

            panelBottom.BackColor = Color.FromArgb(104,33,122);

            lblMessage.Refresh();

            panelBottom.Refresh();
        }

        private void Success(string successMessage)
        {
            lblMessage.Text = successMessage;

            panelBottom.BackColor = Color.FromArgb(1,167,227);

            lblMessage.Refresh();

            panelBottom.Refresh();
        }

        private void Clear()
        {
            listView210M.Items.Clear();

            listView3501.Items.Clear();

            listView3502.Items.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Normal();

            string errorMessage = "", currency = "";

                if (lblMode.Text == "Amadeus Selling Platform")
                {
                if (Properties.Settings.Default.Username210M == "" && Properties.Settings.Default.Username3501 == ""
               && Properties.Settings.Default.Username3502 == "")
                {
                    Error("Please save login credentials for Amadeus Selling Platform");
                }
                else
                {
                    if (cmbBoxType.Text == "")
                        errorMessage += "|Type is required";

                    if (!radBtnPHP.Checked && !radBtnUSD.Checked)
                        errorMessage += " | Currency is required";
                    else
                    {
                        if (radBtnPHP.Checked == true)
                            currency = "PHP";
                        else
                            currency = "USD";
                    }

                    if (errorMessage != "")
                    {
                        Error(errorMessage);
                    }
                    else
                    {
                        AmadeusSellingPlatform A1 = new AmadeusSellingPlatform();

                        string endDate = "";

                        int colorCtr = 1;

                        if (cmbBoxType.Text == "BETWEEN")
                        {
                            endDate = dateTimeEnd.Text;
                        }

                        if (checkBoxMNLPH210M.Checked)
                        {
                            //=====================MNLPH210M=========================

                            listView210M.Items.Clear();

                            Normal("Retrieving data from Amadeus Selling Platform - MNLPH210M");

                            list210M = A1.GetMNLPH210M(dateTimeStart.Text, endDate, currency);

                            list210M.ForEach(item =>
                            {
                                ListViewItem lvi = new ListViewItem(item.SEQNO);

                                lvi.SubItems.Add(item.AL);

                                lvi.SubItems.Add(item.DOCNO);

                                lvi.SubItems.Add(item.AMOUNT);

                                lvi.SubItems.Add(item.TAX);

                                lvi.SubItems.Add(item.FEE);

                                lvi.SubItems.Add(item.COMM);

                                lvi.SubItems.Add(item.FP);

                                lvi.SubItems.Add(item.PAXNAME);

                                lvi.SubItems.Add(item.AS);

                                lvi.SubItems.Add(item.RELOC);

                                lvi.SubItems.Add(item.TRNC);

                                if (colorCtr % 2 == 0)
                                    lvi.BackColor = Color.White;

                                colorCtr++;

                                listView210M.Items.Add(lvi);
                            });
                        }

                        if (checkBoxMNLPH3501.Checked)
                        {
                            //=====================MNLPH3501=========================
                            listView3501.Items.Clear();

                            Normal("Retrieving data from Amadeus Selling Platform - MNLPH3501");

                            list3501 = A1.GetMNLPH3501(dateTimeStart.Text, endDate, currency);

                            colorCtr = 1;

                            list3501.ForEach(item =>
                            {
                                ListViewItem lvi = new ListViewItem(item.SEQNO);

                                lvi.SubItems.Add(item.AL);

                                lvi.SubItems.Add(item.DOCNO);

                                lvi.SubItems.Add(item.AMOUNT);

                                lvi.SubItems.Add(item.TAX);

                                lvi.SubItems.Add(item.FEE);

                                lvi.SubItems.Add(item.COMM);

                                lvi.SubItems.Add(item.FP);

                                lvi.SubItems.Add(item.PAXNAME);

                                lvi.SubItems.Add(item.AS);

                                lvi.SubItems.Add(item.RELOC);

                                lvi.SubItems.Add(item.TRNC);

                                if (colorCtr % 2 == 0)
                                    lvi.BackColor = Color.White;

                                colorCtr++;

                                listView3501.Items.Add(lvi);
                            });
                        }

                        if (checkBoxMNLPH3502.Checked)
                        {
                            //=====================MNLPH3502=========================
                            listView3502.Items.Clear();

                            Normal("Retrieving data from Amadeus Selling Platform - MNLPH3502");

                            list3502 = A1.GetMNLPH3502(dateTimeStart.Text, endDate, currency);

                            colorCtr = 1;

                            list3502.ForEach(item =>
                            {
                                ListViewItem lvi = new ListViewItem(item.SEQNO);

                                lvi.SubItems.Add(item.AL);

                                lvi.SubItems.Add(item.DOCNO);

                                lvi.SubItems.Add(item.AMOUNT);

                                lvi.SubItems.Add(item.TAX);

                                lvi.SubItems.Add(item.FEE);

                                lvi.SubItems.Add(item.COMM);

                                lvi.SubItems.Add(item.FP);

                                lvi.SubItems.Add(item.PAXNAME);

                                lvi.SubItems.Add(item.AS);

                                lvi.SubItems.Add(item.RELOC);

                                lvi.SubItems.Add(item.TRNC);

                                if (colorCtr % 2 == 0)
                                    lvi.BackColor = Color.White;

                                colorCtr++;

                                listView3502.Items.Add(lvi);
                            });
                        }
                        Success("Done extracting TJQ data in " + lblMode.Text);
                    }                  
                }
            }
            else if(lblMode.Text != "")
            {
                Error("Database mode is not yet available");
            }
            else
            {
                Error("Please select data source [Amadeus | Database]");
            }
        }

        private void ExportToExcel()
        {
            Normal();

            if (listView210M.Items.Count > 0 || listView3501.Items.Count > 0 || listView3502.Items.Count > 0)
            {
                Normal("Exporting to excel");

                SaveFileDialog saveDialog = new SaveFileDialog();

                saveDialog.Filter = "Excel File |*.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    MSExcel excel = new MSExcel();

                    string temp = "";

                    if (cmbBoxType.Text == "AS OF")
                        temp = cmbBoxType.Text + " " + dateTimeStart.Text;
                    else if (cmbBoxType.Text == "BETWEEN")
                        temp = cmbBoxType.Text + " " + dateTimeStart.Text + " - " + dateTimeEnd.Text;

                    if (excel.Export(list210M, list3501, list3502, temp, saveDialog.FileName))
                    {
                        Success("Done exporting to excel");
                    }
                    else
                    {
                        Error("Error on exporting to excel file");
                    }
                }
            }
            else
            {
                Error("No data to be exported");
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void btnAmadeusMode_Click(object sender, EventArgs e)
        {
            lblMode.Text = "Amadeus Selling Platform";

            btnAmadeusMode.Enabled = false;

            btnDatabaseMode.Enabled = true;

            Normal();
        }

        private void btnDatabaseMode_Click(object sender, EventArgs e)
        {
            //lblMode.Text = "Database";

            btnDatabaseMode.Enabled = false;

            btnAmadeusMode.Enabled = true;

            Error("Database mode is not yet available");
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            Setup form = new Setup();

            form.ShowDialog();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Normal();
            btnAmadeusMode.PerformClick();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Normal();

            ConfirmationWindow dialog = new ConfirmationWindow("Confirmation","Are you sure you want to clear all data?");

            if(dialog.ShowDialog() == DialogResult.Yes)
                Clear();
        }

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            Normal();
        }

        private void btnBrowseExcel_Click(object sender, EventArgs e)
        {
            Normal();        
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Normal();
        }

        private void listView210M_MouseDown(object sender, MouseEventArgs e)
        {
            Normal();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            Normal();
        }

        private void pictureBoxExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }

        private void DownloadManual()
        {
            Process.Start("https://drive.google.com/file/d/0BybWuaFKq9dEVnkyQ3huZU5ONjQ/view?usp=sharing");
        }

        private void btnDownloadManual_Click(object sender, EventArgs e)
        {
            DownloadManual();
        }

        private void pictureBoxDownloadManual_Click(object sender, EventArgs e)
        {
            DownloadManual();
        }

        private void lblMode_Click(object sender, EventArgs e)
        {

        }

        private void lblVersion_Click(object sender, EventArgs e)
        {
       
        }
    }
}
