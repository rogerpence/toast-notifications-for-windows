namespace ToastNotification
{
    partial class Form1
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
            buttonShowToast = new Button();
            groupboxPosition = new GroupBox();
            radiobuttonCenter = new RadioButton();
            radiobuttonLowerRight = new RadioButton();
            radiobuttonLowerLeft = new RadioButton();
            radiobuttonUpperRight = new RadioButton();
            radiobuttonUpperLeft = new RadioButton();
            groupboxDuration = new GroupBox();
            radiobuttonForever = new RadioButton();
            radiobuttonExtraLong = new RadioButton();
            radiobuttonLong = new RadioButton();
            radiobuttonMedium = new RadioButton();
            radiobuttonShort = new RadioButton();
            groupboxStatus = new GroupBox();
            radiobuttonError = new RadioButton();
            radiobuttonInfo = new RadioButton();
            radiobuttonSuccess = new RadioButton();
            textboxHeaderMessageText = new TextBox();
            textboxMessageText = new TextBox();
            label1 = new Label();
            label4 = new Label();
            buttonCloseToast = new Button();
            checkboxHideHeaderMessage = new CheckBox();
            colorDialog1 = new ColorDialog();
            linklabelSetBorderColor = new LinkLabel();
            panelBorderColor = new Panel();
            linklabelBackgroundColor = new LinkLabel();
            panelBackgroundColor = new Panel();
            checkboxHideAccentAndIcon = new CheckBox();
            checkboxHideUserControlButton = new CheckBox();
            labelBorderColorHex = new Label();
            labelBackgroundColorHex = new Label();
            checkboxStayOnTop = new CheckBox();
            groupboxPosition.SuspendLayout();
            groupboxDuration.SuspendLayout();
            groupboxStatus.SuspendLayout();
            SuspendLayout();
            // 
            // buttonShowToast
            // 
            buttonShowToast.Location = new Point(202, 990);
            buttonShowToast.Name = "buttonShowToast";
            buttonShowToast.Size = new Size(328, 68);
            buttonShowToast.TabIndex = 0;
            buttonShowToast.Text = "Show toast";
            buttonShowToast.UseVisualStyleBackColor = true;
            buttonShowToast.Click += button1_Click;
            // 
            // groupboxPosition
            // 
            groupboxPosition.Controls.Add(radiobuttonCenter);
            groupboxPosition.Controls.Add(radiobuttonLowerRight);
            groupboxPosition.Controls.Add(radiobuttonLowerLeft);
            groupboxPosition.Controls.Add(radiobuttonUpperRight);
            groupboxPosition.Controls.Add(radiobuttonUpperLeft);
            groupboxPosition.Location = new Point(187, 638);
            groupboxPosition.Name = "groupboxPosition";
            groupboxPosition.Size = new Size(278, 270);
            groupboxPosition.TabIndex = 1;
            groupboxPosition.TabStop = false;
            groupboxPosition.Text = "Toast position";
            // 
            // radiobuttonCenter
            // 
            radiobuttonCenter.AutoSize = true;
            radiobuttonCenter.Location = new Point(21, 214);
            radiobuttonCenter.Name = "radiobuttonCenter";
            radiobuttonCenter.Size = new Size(110, 36);
            radiobuttonCenter.TabIndex = 4;
            radiobuttonCenter.TabStop = true;
            radiobuttonCenter.Text = "Center";
            radiobuttonCenter.UseVisualStyleBackColor = true;
            // 
            // radiobuttonLowerRight
            // 
            radiobuttonLowerRight.AutoSize = true;
            radiobuttonLowerRight.Location = new Point(21, 172);
            radiobuttonLowerRight.Name = "radiobuttonLowerRight";
            radiobuttonLowerRight.Size = new Size(159, 36);
            radiobuttonLowerRight.TabIndex = 3;
            radiobuttonLowerRight.Text = "Lower right";
            radiobuttonLowerRight.UseVisualStyleBackColor = true;
            // 
            // radiobuttonLowerLeft
            // 
            radiobuttonLowerLeft.AutoSize = true;
            radiobuttonLowerLeft.Checked = true;
            radiobuttonLowerLeft.Location = new Point(21, 130);
            radiobuttonLowerLeft.Name = "radiobuttonLowerLeft";
            radiobuttonLowerLeft.Size = new Size(144, 36);
            radiobuttonLowerLeft.TabIndex = 2;
            radiobuttonLowerLeft.TabStop = true;
            radiobuttonLowerLeft.Text = "Lower left";
            radiobuttonLowerLeft.UseVisualStyleBackColor = true;
            // 
            // radiobuttonUpperRight
            // 
            radiobuttonUpperRight.AutoSize = true;
            radiobuttonUpperRight.Location = new Point(21, 88);
            radiobuttonUpperRight.Name = "radiobuttonUpperRight";
            radiobuttonUpperRight.Size = new Size(161, 36);
            radiobuttonUpperRight.TabIndex = 1;
            radiobuttonUpperRight.Text = "Upper right";
            radiobuttonUpperRight.UseVisualStyleBackColor = true;
            // 
            // radiobuttonUpperLeft
            // 
            radiobuttonUpperLeft.AutoSize = true;
            radiobuttonUpperLeft.Location = new Point(21, 46);
            radiobuttonUpperLeft.Name = "radiobuttonUpperLeft";
            radiobuttonUpperLeft.Size = new Size(146, 36);
            radiobuttonUpperLeft.TabIndex = 0;
            radiobuttonUpperLeft.Text = "Upper left";
            radiobuttonUpperLeft.UseVisualStyleBackColor = true;
            // 
            // groupboxDuration
            // 
            groupboxDuration.Controls.Add(radiobuttonForever);
            groupboxDuration.Controls.Add(radiobuttonExtraLong);
            groupboxDuration.Controls.Add(radiobuttonLong);
            groupboxDuration.Controls.Add(radiobuttonMedium);
            groupboxDuration.Controls.Add(radiobuttonShort);
            groupboxDuration.Location = new Point(490, 641);
            groupboxDuration.Name = "groupboxDuration";
            groupboxDuration.Size = new Size(300, 267);
            groupboxDuration.TabIndex = 2;
            groupboxDuration.TabStop = false;
            groupboxDuration.Text = "Toast duration";
            // 
            // radiobuttonForever
            // 
            radiobuttonForever.AutoSize = true;
            radiobuttonForever.Location = new Point(26, 216);
            radiobuttonForever.Name = "radiobuttonForever";
            radiobuttonForever.Size = new Size(119, 36);
            radiobuttonForever.TabIndex = 4;
            radiobuttonForever.TabStop = true;
            radiobuttonForever.Text = "Forever";
            radiobuttonForever.UseVisualStyleBackColor = true;
            // 
            // radiobuttonExtraLong
            // 
            radiobuttonExtraLong.AutoSize = true;
            radiobuttonExtraLong.Location = new Point(26, 175);
            radiobuttonExtraLong.Name = "radiobuttonExtraLong";
            radiobuttonExtraLong.Size = new Size(145, 36);
            radiobuttonExtraLong.TabIndex = 3;
            radiobuttonExtraLong.Text = "Extra long";
            radiobuttonExtraLong.UseVisualStyleBackColor = true;
            // 
            // radiobuttonLong
            // 
            radiobuttonLong.AutoSize = true;
            radiobuttonLong.Location = new Point(28, 133);
            radiobuttonLong.Name = "radiobuttonLong";
            radiobuttonLong.Size = new Size(92, 36);
            radiobuttonLong.TabIndex = 2;
            radiobuttonLong.Text = "Long";
            radiobuttonLong.UseVisualStyleBackColor = true;
            // 
            // radiobuttonMedium
            // 
            radiobuttonMedium.AutoSize = true;
            radiobuttonMedium.Location = new Point(26, 90);
            radiobuttonMedium.Name = "radiobuttonMedium";
            radiobuttonMedium.Size = new Size(129, 36);
            radiobuttonMedium.TabIndex = 1;
            radiobuttonMedium.Text = "Medium";
            radiobuttonMedium.UseVisualStyleBackColor = true;
            // 
            // radiobuttonShort
            // 
            radiobuttonShort.AutoSize = true;
            radiobuttonShort.Checked = true;
            radiobuttonShort.Location = new Point(28, 48);
            radiobuttonShort.Name = "radiobuttonShort";
            radiobuttonShort.Size = new Size(96, 36);
            radiobuttonShort.TabIndex = 0;
            radiobuttonShort.TabStop = true;
            radiobuttonShort.Text = "Short";
            radiobuttonShort.UseVisualStyleBackColor = true;
            // 
            // groupboxStatus
            // 
            groupboxStatus.Controls.Add(radiobuttonError);
            groupboxStatus.Controls.Add(radiobuttonInfo);
            groupboxStatus.Controls.Add(radiobuttonSuccess);
            groupboxStatus.Location = new Point(815, 641);
            groupboxStatus.Name = "groupboxStatus";
            groupboxStatus.Size = new Size(300, 181);
            groupboxStatus.TabIndex = 3;
            groupboxStatus.TabStop = false;
            groupboxStatus.Text = "Toast status";
            // 
            // radiobuttonError
            // 
            radiobuttonError.AutoSize = true;
            radiobuttonError.Location = new Point(20, 130);
            radiobuttonError.Name = "radiobuttonError";
            radiobuttonError.Size = new Size(89, 36);
            radiobuttonError.TabIndex = 2;
            radiobuttonError.Text = "Error";
            radiobuttonError.UseVisualStyleBackColor = true;
            // 
            // radiobuttonInfo
            // 
            radiobuttonInfo.AutoSize = true;
            radiobuttonInfo.Location = new Point(20, 88);
            radiobuttonInfo.Name = "radiobuttonInfo";
            radiobuttonInfo.Size = new Size(81, 36);
            radiobuttonInfo.TabIndex = 1;
            radiobuttonInfo.Text = "Info";
            radiobuttonInfo.UseVisualStyleBackColor = true;
            // 
            // radiobuttonSuccess
            // 
            radiobuttonSuccess.AutoSize = true;
            radiobuttonSuccess.Checked = true;
            radiobuttonSuccess.Location = new Point(20, 46);
            radiobuttonSuccess.Name = "radiobuttonSuccess";
            radiobuttonSuccess.Size = new Size(121, 36);
            radiobuttonSuccess.TabIndex = 0;
            radiobuttonSuccess.TabStop = true;
            radiobuttonSuccess.Text = "Success";
            radiobuttonSuccess.UseVisualStyleBackColor = true;
            // 
            // textboxHeaderMessageText
            // 
            textboxHeaderMessageText.Location = new Point(187, 109);
            textboxHeaderMessageText.Name = "textboxHeaderMessageText";
            textboxHeaderMessageText.Size = new Size(771, 39);
            textboxHeaderMessageText.TabIndex = 4;
            // 
            // textboxMessageText
            // 
            textboxMessageText.Location = new Point(187, 227);
            textboxMessageText.Multiline = true;
            textboxMessageText.Name = "textboxMessageText";
            textboxMessageText.Size = new Size(918, 127);
            textboxMessageText.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(187, 60);
            label1.Name = "label1";
            label1.Size = new Size(238, 32);
            label1.TabIndex = 7;
            label1.Text = "Header message text";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(187, 171);
            label4.Name = "label4";
            label4.Size = new Size(155, 32);
            label4.TabIndex = 10;
            label4.Text = "Message text";
            // 
            // buttonCloseToast
            // 
            buttonCloseToast.Enabled = false;
            buttonCloseToast.Location = new Point(563, 990);
            buttonCloseToast.Name = "buttonCloseToast";
            buttonCloseToast.Size = new Size(279, 68);
            buttonCloseToast.TabIndex = 12;
            buttonCloseToast.Text = "Close toast";
            buttonCloseToast.UseVisualStyleBackColor = true;
            // 
            // checkboxHideHeaderMessage
            // 
            checkboxHideHeaderMessage.AutoSize = true;
            checkboxHideHeaderMessage.Location = new Point(196, 403);
            checkboxHideHeaderMessage.Name = "checkboxHideHeaderMessage";
            checkboxHideHeaderMessage.Size = new Size(271, 36);
            checkboxHideHeaderMessage.TabIndex = 13;
            checkboxHideHeaderMessage.Tag = "";
            checkboxHideHeaderMessage.Text = "Hide header message";
            checkboxHideHeaderMessage.UseVisualStyleBackColor = true;
            // 
            // linklabelSetBorderColor
            // 
            linklabelSetBorderColor.AutoSize = true;
            linklabelSetBorderColor.LinkColor = Color.Black;
            linklabelSetBorderColor.Location = new Point(748, 401);
            linklabelSetBorderColor.Name = "linklabelSetBorderColor";
            linklabelSetBorderColor.Size = new Size(186, 32);
            linklabelSetBorderColor.TabIndex = 14;
            linklabelSetBorderColor.TabStop = true;
            linklabelSetBorderColor.Text = "Set border color";
            linklabelSetBorderColor.LinkClicked += linklabelSetBorderColor_LinkClicked;
            // 
            // panelBorderColor
            // 
            panelBorderColor.BorderStyle = BorderStyle.FixedSingle;
            panelBorderColor.Location = new Point(951, 390);
            panelBorderColor.Name = "panelBorderColor";
            panelBorderColor.Size = new Size(52, 43);
            panelBorderColor.TabIndex = 15;
            // 
            // linklabelBackgroundColor
            // 
            linklabelBackgroundColor.AutoSize = true;
            linklabelBackgroundColor.LinkColor = Color.Black;
            linklabelBackgroundColor.Location = new Point(703, 461);
            linklabelBackgroundColor.Name = "linklabelBackgroundColor";
            linklabelBackgroundColor.Size = new Size(242, 32);
            linklabelBackgroundColor.TabIndex = 16;
            linklabelBackgroundColor.TabStop = true;
            linklabelBackgroundColor.Text = "Set background color";
            linklabelBackgroundColor.LinkClicked += linklabelBackgroundColor_LinkClicked;
            // 
            // panelBackgroundColor
            // 
            panelBackgroundColor.BorderStyle = BorderStyle.FixedSingle;
            panelBackgroundColor.Location = new Point(951, 450);
            panelBackgroundColor.Name = "panelBackgroundColor";
            panelBackgroundColor.Size = new Size(52, 43);
            panelBackgroundColor.TabIndex = 17;
            // 
            // checkboxHideAccentAndIcon
            // 
            checkboxHideAccentAndIcon.AutoSize = true;
            checkboxHideAccentAndIcon.Location = new Point(196, 458);
            checkboxHideAccentAndIcon.Name = "checkboxHideAccentAndIcon";
            checkboxHideAccentAndIcon.Size = new Size(306, 36);
            checkboxHideAccentAndIcon.TabIndex = 18;
            checkboxHideAccentAndIcon.Text = "Hide accent bar and icon";
            checkboxHideAccentAndIcon.UseVisualStyleBackColor = true;
            // 
            // checkboxHideUserControlButton
            // 
            checkboxHideUserControlButton.AutoSize = true;
            checkboxHideUserControlButton.Location = new Point(196, 513);
            checkboxHideUserControlButton.Name = "checkboxHideUserControlButton";
            checkboxHideUserControlButton.Size = new Size(282, 36);
            checkboxHideUserControlButton.TabIndex = 19;
            checkboxHideUserControlButton.Text = "Hide user close button";
            checkboxHideUserControlButton.UseVisualStyleBackColor = true;
            // 
            // labelBorderColorHex
            // 
            labelBorderColorHex.AutoSize = true;
            labelBorderColorHex.Location = new Point(1024, 401);
            labelBorderColorHex.Name = "labelBorderColorHex";
            labelBorderColorHex.Size = new Size(55, 32);
            labelBorderColorHex.TabIndex = 20;
            labelBorderColorHex.Text = "Hex";
            // 
            // labelBackgroundColorHex
            // 
            labelBackgroundColorHex.AutoSize = true;
            labelBackgroundColorHex.Location = new Point(1024, 461);
            labelBackgroundColorHex.Name = "labelBackgroundColorHex";
            labelBackgroundColorHex.Size = new Size(55, 32);
            labelBackgroundColorHex.TabIndex = 21;
            labelBackgroundColorHex.Text = "Hex";
            // 
            // checkboxStayOnTop
            // 
            checkboxStayOnTop.AutoSize = true;
            checkboxStayOnTop.Location = new Point(196, 565);
            checkboxStayOnTop.Name = "checkboxStayOnTop";
            checkboxStayOnTop.Size = new Size(296, 36);
            checkboxStayOnTop.TabIndex = 22;
            checkboxStayOnTop.Text = "Toast topmost to parent";
            checkboxStayOnTop.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1392, 1093);
            Controls.Add(checkboxStayOnTop);
            Controls.Add(labelBackgroundColorHex);
            Controls.Add(labelBorderColorHex);
            Controls.Add(checkboxHideUserControlButton);
            Controls.Add(checkboxHideAccentAndIcon);
            Controls.Add(panelBackgroundColor);
            Controls.Add(linklabelBackgroundColor);
            Controls.Add(panelBorderColor);
            Controls.Add(linklabelSetBorderColor);
            Controls.Add(checkboxHideHeaderMessage);
            Controls.Add(buttonCloseToast);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(textboxMessageText);
            Controls.Add(textboxHeaderMessageText);
            Controls.Add(groupboxStatus);
            Controls.Add(groupboxDuration);
            Controls.Add(groupboxPosition);
            Controls.Add(buttonShowToast);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Form1";
            Text = "Test Toasts";
            Load += Form1_Load;
            groupboxPosition.ResumeLayout(false);
            groupboxPosition.PerformLayout();
            groupboxDuration.ResumeLayout(false);
            groupboxDuration.PerformLayout();
            groupboxStatus.ResumeLayout(false);
            groupboxStatus.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonShowToast;
        private GroupBox groupboxPosition;
        private RadioButton radiobuttonLowerRight;
        private RadioButton radiobuttonLowerLeft;
        private RadioButton radiobuttonUpperRight;
        private RadioButton radiobuttonUpperLeft;
        private RadioButton radiobuttonCenter;
        private GroupBox groupboxDuration;
        private RadioButton radiobuttonExtraLong;
        private RadioButton radiobuttonLong;
        private RadioButton radiobuttonMedium;
        private RadioButton radiobuttonShort;
        private GroupBox groupboxStatus;
        private RadioButton radiobuttonError;
        private RadioButton radiobuttonInfo;
        private RadioButton radiobuttonSuccess;
        private TextBox textboxHeaderMessageText;
        private TextBox textboxMessageText;
        private Label label1;
        private Label label4;
        private RadioButton radiobuttonForever;
        private Button buttonCloseToast;
        private CheckBox checkboxHideHeaderMessage;
        private ColorDialog colorDialog1;
        private LinkLabel linklabelSetBorderColor;
        private Panel panelBorderColor;
        private LinkLabel linklabelBackgroundColor;
        private Panel panelBackgroundColor;
        private CheckBox checkboxHideAccentAndIcon;
        private CheckBox checkboxHideUserControlButton;
        private Label labelBorderColorHex;
        private Label labelBackgroundColorHex;
        private CheckBox checkboxStayOnTop;
    }
}