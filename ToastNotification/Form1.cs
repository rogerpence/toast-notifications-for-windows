using FormFader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ToastNotification
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            //frm = new Toast(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Toast frm;

            frm = new Toast(this);

            frm.Opacity = 0;

            if (radiobuttonUpperLeft.Checked) frm.Position = Toast.ToastPosition.UPPER_LEFT;
            else if (radiobuttonUpperRight.Checked) frm.Position = Toast.ToastPosition.UPPER_RIGHT;
            else if (radiobuttonLowerLeft.Checked) frm.Position = Toast.ToastPosition.LOWER_LEFT;
            else if (radiobuttonLowerRight.Checked) frm.Position = Toast.ToastPosition.LOWER_RIGHT;
            else frm.Position = Toast.ToastPosition.CENTER;

            if (radiobuttonShort.Checked) frm.Duration = Toast.ToastDuration.SHORT;
            else if (radiobuttonMedium.Checked) frm.Duration = Toast.ToastDuration.MEDIUM;
            else if (radiobuttonLong.Checked) frm.Duration = Toast.ToastDuration.LONG;
            else if (radiobuttonExtraLong.Checked) frm.Duration = Toast.ToastDuration.EXTRALONG;
            else if (radiobuttonUserClose.Checked) frm.Duration = Toast.ToastDuration.USER_CLOSE;

            if (radiobuttonSuccess.Checked) frm.Status = Toast.ToastStatus.Success;
            else if (radiobuttonInfo.Checked) frm.Status = Toast.ToastStatus.Info;
            else if (radiobuttonError.Checked) frm.Status = Toast.ToastStatus.Error;

            frm.ChangeDefaultDurationSeconds(3, 6, 9, 12);

            frm.UserClose = checkboxAllowUserClose.Checked;
            frm.HideHeaderMessage = checkboxHideHeaderMessage.Checked;

            frm.BorderColor = panelBorderColor.BackColor;
            frm.BackgroundColor = panelBackgroundColor.BackColor;

            frm.HideAccentAndIcon = checkboxHideAccentAndIcon.Checked;

            if (!String.IsNullOrEmpty(this.textboxHeaderMessageText.Text)) frm.HeaderText = this.textboxHeaderMessageText.Text;
            if (!String.IsNullOrEmpty(this.textboxMessageText.Text)) frm.MessageText = this.textboxMessageText.Text;

            buttonCloseToast.Enabled = !(checkboxAllowUserClose.Checked);

            /*
             * 
             * This stuff lets you assign a handler to a button to close 
             * a user-closed toast without the toast form being declared 
             * globally.
             * 
             */

            EventHandler handler = null;
            handler = (s, e) =>
            {
                frm.CloseToast();
                buttonCloseToast.Click -= handler;
            };
            buttonCloseToast.Click += handler;

            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * 
             * Instance the form so you can snag some of its 
             * properties to populate some of the test 
             * form controls.
             * 
             */
            Toast frm;
            frm = new Toast(this);
            textboxHeaderMessageText.Text = frm.HeaderText;
            textboxMessageText.Text = frm.MessageText;

            panelBorderColor.BackColor = frm.BorderColor;
            panelBackgroundColor.BackColor = frm.BackgroundColor;
        }

        private void linklabelSetBorderColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            colorDialog1.ShowDialog();
            panelBorderColor.BackColor = colorDialog1.Color;
        }

        private void linklabelBackgroundColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            colorDialog1.ShowDialog();
            panelBackgroundColor.BackColor = colorDialog1.Color;
        }
    }
}
