namespace TJQ
{
    partial class ConfirmationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.topPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDialogYes = new System.Windows.Forms.Button();
            this.btnDialogNo = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(90)))), ((int)(((byte)(125)))));
            this.topPanel.Controls.Add(this.pictureBox1);
            this.topPanel.Controls.Add(this.lblTitle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(444, 29);
            this.topPanel.TabIndex = 1;
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.topPanel_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TJQ.Properties.Resources._1478705166_sign_info;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(82, 16);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Confirmation";
            // 
            // btnDialogYes
            // 
            this.btnDialogYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDialogYes.BackColor = System.Drawing.SystemColors.Control;
            this.btnDialogYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnDialogYes.FlatAppearance.BorderSize = 0;
            this.btnDialogYes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnDialogYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDialogYes.ForeColor = System.Drawing.Color.Black;
            this.btnDialogYes.Location = new System.Drawing.Point(12, 150);
            this.btnDialogYes.Name = "btnDialogYes";
            this.btnDialogYes.Size = new System.Drawing.Size(103, 23);
            this.btnDialogYes.TabIndex = 6;
            this.btnDialogYes.Text = "Yes";
            this.btnDialogYes.UseVisualStyleBackColor = false;
            // 
            // btnDialogNo
            // 
            this.btnDialogNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDialogNo.BackColor = System.Drawing.SystemColors.Control;
            this.btnDialogNo.FlatAppearance.BorderSize = 0;
            this.btnDialogNo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnDialogNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDialogNo.ForeColor = System.Drawing.Color.Black;
            this.btnDialogNo.Location = new System.Drawing.Point(329, 150);
            this.btnDialogNo.Name = "btnDialogNo";
            this.btnDialogNo.Size = new System.Drawing.Size(103, 23);
            this.btnDialogNo.TabIndex = 7;
            this.btnDialogNo.Text = "No";
            this.btnDialogNo.UseVisualStyleBackColor = false;
            this.btnDialogNo.Click += new System.EventHandler(this.btnDialogNo_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(12, 43);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(420, 92);
            this.lblMessage.TabIndex = 8;
            this.lblMessage.Text = "Confirmation Message";
            // 
            // ConfirmationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(444, 185);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnDialogNo);
            this.Controls.Add(this.btnDialogYes);
            this.Controls.Add(this.topPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConfirmationWindow";
            this.Load += new System.EventHandler(this.ConfirmationWindow_Load);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDialogYes;
        private System.Windows.Forms.Button btnDialogNo;
        private System.Windows.Forms.Label lblMessage;
    }
}