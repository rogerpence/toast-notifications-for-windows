namespace ToastNotification
{
    partial class Toast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Toast));
            pictureboxSuccess = new PictureBox();
            pictureboxInfo = new PictureBox();
            pictureboxError = new PictureBox();
            panelToast = new Panel();
            pictureboxClose = new PictureBox();
            labelToastMessageText = new Label();
            labelToastHeaderText = new Label();
            panelAccent = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureboxSuccess).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureboxInfo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureboxError).BeginInit();
            panelToast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureboxClose).BeginInit();
            SuspendLayout();
            // 
            // pictureboxSuccess
            // 
            pictureboxSuccess.Image = (Image)resources.GetObject("pictureboxSuccess.Image");
            pictureboxSuccess.Location = new Point(17, 78);
            pictureboxSuccess.Margin = new Padding(4);
            pictureboxSuccess.Name = "pictureboxSuccess";
            pictureboxSuccess.Size = new Size(62, 61);
            pictureboxSuccess.TabIndex = 1;
            pictureboxSuccess.TabStop = false;
            // 
            // pictureboxInfo
            // 
            pictureboxInfo.Image = (Image)resources.GetObject("pictureboxInfo.Image");
            pictureboxInfo.Location = new Point(17, 147);
            pictureboxInfo.Margin = new Padding(4);
            pictureboxInfo.Name = "pictureboxInfo";
            pictureboxInfo.Size = new Size(62, 61);
            pictureboxInfo.TabIndex = 2;
            pictureboxInfo.TabStop = false;
            // 
            // pictureboxError
            // 
            pictureboxError.Image = (Image)resources.GetObject("pictureboxError.Image");
            pictureboxError.Location = new Point(17, 9);
            pictureboxError.Margin = new Padding(4);
            pictureboxError.Name = "pictureboxError";
            pictureboxError.Size = new Size(62, 61);
            pictureboxError.TabIndex = 3;
            pictureboxError.TabStop = false;
            // 
            // panelToast
            // 
            panelToast.BackColor = Color.WhiteSmoke;
            panelToast.Controls.Add(pictureboxClose);
            panelToast.Controls.Add(labelToastMessageText);
            panelToast.Controls.Add(labelToastHeaderText);
            panelToast.Controls.Add(pictureboxError);
            panelToast.Controls.Add(pictureboxSuccess);
            panelToast.Controls.Add(pictureboxInfo);
            panelToast.Location = new Point(20, 12);
            panelToast.Margin = new Padding(4);
            panelToast.Name = "panelToast";
            panelToast.Size = new Size(1060, 230);
            panelToast.TabIndex = 5;
            // 
            // pictureboxClose
            // 
            pictureboxClose.Image = (Image)resources.GetObject("pictureboxClose.Image");
            pictureboxClose.Location = new Point(996, 8);
            pictureboxClose.Margin = new Padding(4);
            pictureboxClose.Name = "pictureboxClose";
            pictureboxClose.Size = new Size(53, 44);
            pictureboxClose.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureboxClose.TabIndex = 6;
            pictureboxClose.TabStop = false;
            pictureboxClose.Click += pictureboxClose_Click;
            // 
            // labelToastMessageText
            // 
            labelToastMessageText.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            labelToastMessageText.Location = new Point(108, 95);
            labelToastMessageText.Margin = new Padding(4, 0, 4, 0);
            labelToastMessageText.Name = "labelToastMessageText";
            labelToastMessageText.Size = new Size(926, 131);
            labelToastMessageText.TabIndex = 5;
            labelToastMessageText.Text = "label2";
            // 
            // labelToastHeaderText
            // 
            labelToastHeaderText.AutoSize = true;
            labelToastHeaderText.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelToastHeaderText.Location = new Point(108, 34);
            labelToastHeaderText.Margin = new Padding(4, 0, 4, 0);
            labelToastHeaderText.Name = "labelToastHeaderText";
            labelToastHeaderText.Size = new Size(131, 51);
            labelToastHeaderText.TabIndex = 4;
            labelToastHeaderText.Text = "label1";
            // 
            // panelAccent
            // 
            panelAccent.Location = new Point(0, 0);
            panelAccent.Margin = new Padding(4);
            panelAccent.Name = "panelAccent";
            panelAccent.Size = new Size(21, 320);
            panelAccent.TabIndex = 6;
            // 
            // Toast
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1098, 255);
            Controls.Add(panelAccent);
            Controls.Add(panelToast);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Toast";
            Text = "Toast";
            Load += Toast_Load;
            ((System.ComponentModel.ISupportInitialize)pictureboxSuccess).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureboxInfo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureboxError).EndInit();
            panelToast.ResumeLayout(false);
            panelToast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureboxClose).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pictureboxSuccess;
        private PictureBox pictureboxInfo;
        private PictureBox pictureboxError;
        private Panel panelToast;
        private Panel panelAccent;
        private Label labelToastMessageText;
        private Label labelToastHeaderText;
        private PictureBox pictureboxClose;
    }
}