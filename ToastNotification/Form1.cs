using System.Text;

namespace ToastNotification
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Test()
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Toast toast  = new Toast(this);

            if (radiobuttonUpperLeft.Checked) toast.Position = Toast.ToastPosition.UPPER_LEFT;
            else if (radiobuttonUpperRight.Checked) toast.Position = Toast.ToastPosition.UPPER_RIGHT;
            else if (radiobuttonLowerLeft.Checked) toast.Position = Toast.ToastPosition.LOWER_LEFT;
            else if (radiobuttonLowerRight.Checked) toast.Position = Toast.ToastPosition.LOWER_RIGHT;
            else toast.Position = Toast.ToastPosition.CENTER;

            if (radiobuttonShort.Checked) toast.Duration = Toast.ToastDuration.SHORT;
            else if (radiobuttonMedium.Checked) toast.Duration = Toast.ToastDuration.MEDIUM;
            else if (radiobuttonLong.Checked) toast.Duration = Toast.ToastDuration.LONG;
            else if (radiobuttonExtraLong.Checked) toast.Duration = Toast.ToastDuration.EXTRA_LONG;
            else if (radiobuttonForever.Checked) toast.Duration = Toast.ToastDuration.FOREVER;

            if (radiobuttonSuccess.Checked) toast.Status = Toast.ToastStatus.SUCCESS;
            else if (radiobuttonInfo.Checked) toast.Status = Toast.ToastStatus.INFO;
            else if (radiobuttonError.Checked) toast.Status = Toast.ToastStatus.ERROR;

            toast.HideUserCloseButton = checkboxHideUserControlButton.Checked;
            toast.HideHeaderMessage = checkboxHideHeaderMessage.Checked;
            toast.HideAccentAndIcon = checkboxHideAccentAndIcon.Checked;

            toast.BorderColor = panelBorderColor.BackColor;
            toast.BackgroundColor = panelBackgroundColor.BackColor;

            if (!String.IsNullOrEmpty(this.textboxHeaderMessageText.Text)) toast.HeaderText = this.textboxHeaderMessageText.Text;
            if (!String.IsNullOrEmpty(this.textboxMessageText.Text)) toast.MessageText = this.textboxMessageText.Text;

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
                toast.CloseToast();
                buttonCloseToast.Click -= handler;
            };
            buttonCloseToast.Click += handler;

            generateToastCode(toast);

            buttonCloseToast.Enabled = radiobuttonForever.Checked;
            toast.ShowToast();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * 
             * Instance an intermediate toast just so you can snag some of its 
             * properties to populate some of the test form controls.
             * 
             */
            Toast frm;
            frm = new Toast(this);
            textboxHeaderMessageText.Text = frm.HeaderText;
            textboxMessageText.Text = frm.MessageText;
            panelBorderColor.BackColor = frm.BorderColor;
            labelBorderColorHex.Text = HexConverter(panelBorderColor.BackColor);
            panelBackgroundColor.BackColor = frm.BackgroundColor;
            labelBackgroundColorHex.Text = HexConverter(panelBackgroundColor.BackColor);
        }

        private void linklabelSetBorderColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            colorDialog1.ShowDialog();
            panelBorderColor.BackColor = colorDialog1.Color;
            labelBorderColorHex.Text = HexConverter(panelBorderColor.BackColor);
        }

        private void linklabelBackgroundColor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            colorDialog1.ShowDialog();
            panelBackgroundColor.BackColor = colorDialog1.Color;
            labelBackgroundColorHex.Text = HexConverter(panelBackgroundColor.BackColor);
        }

        private static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        private void generateToastCode(Toast toast)
        {
            string indent = new string(' ', 12);

            StringBuilder code = new();
            code.AppendLine($"{indent}Toast toast = new Toast(this);");
            code.AppendLine("");
            string position = Toast.EnumGetName<Toast.ToastPosition>(toast.Position);
            code.AppendLine($"{indent}toast.Position = Toast.ToastPosition.{position};") ;
            string duration = Toast.EnumGetName<Toast.ToastDuration>(toast.Duration);
            code.AppendLine($"{indent}toast.Duration = Toast.ToastDuration.{duration};");
            string status = Toast.EnumGetName<Toast.ToastStatus>(toast.Status);
            code.AppendLine($"{indent}toast.Status = Toast.ToastStatus.{status};");
            code.AppendLine("");
            code.AppendLine($"{indent}toast.HideUserCloseButton = {checkboxHideUserControlButton.Checked.ToString().ToLower()};");
            code.AppendLine($"{indent}toast.HideHeaderMessage = {checkboxHideHeaderMessage.Checked.ToString().ToLower()};");
            code.AppendLine($"{indent}toast.HideAccentAndIcon = {checkboxHideAccentAndIcon.Checked.ToString().ToLower()};");
            code.AppendLine("");
            code.AppendLine($@"{indent}toast.BorderColor = System.Drawing.ColorTranslator.FromHtml(""{HexConverter(panelBorderColor.BackColor)}"");");
            code.AppendLine($@"{indent}toast.BackgroundColor = System.Drawing.ColorTranslator.FromHtml(""{HexConverter(panelBackgroundColor.BackColor)}"");");
            code.AppendLine("");
            code.AppendLine($@"{indent}toast.HeaderText = ""{toast.HeaderText}"";");
            code.AppendLine($@"{indent}toast.MessageText = ""{toast.MessageText}"";");

            code.AppendLine("");
            code.AppendLine($@"// {indent}If you want to change the default duration values:");
            code.AppendLine($@"// {indent}toast.ChangeDefaultDurationSeconds(slowDuration: 5,"); 
            code.AppendLine($@"// {indent}                                   mediumDuration: 10"); 
            code.AppendLine($@"// {indent}                                   longDuration: 15,"); 
            code.AppendLine($@"// {indent}                                   extraLongDuration: 20)");

            if (toast.Duration == Toast.ToastDuration.FOREVER)
            {
                code.AppendLine("");
                code.AppendLine($"//{indent} ----------------------------------------");
                code.AppendLine($"//{indent} This toast is configured to run forever.");
                code.AppendLine($"//{indent} ----------------------------------------");
                code.AppendLine("");
                code.AppendLine($"//{indent} You should call the toast's CloseToast() method ");
                code.AppendLine($"//{indent} before showing another toast.");
                code.AppendLine("");
                code.AppendLine($"//{indent} You probably don't need the event handler code");
                code.AppendLine($"//{indent} below--because you'll most likely call CloseToast()");
                code.AppendLine($"//{indent} programatically. But, if you do want users to click");
                code.AppendLine($"//{indent} a button to close the toast, the code below lets ");
                code.AppendLine($"//{indent} you do that without needing to declare the toast globally.");
                code.AppendLine("");
                code.AppendLine($"//{indent} EventHandler handler = null;");
                code.AppendLine($"//{indent} handler = (s, e) =>");
                code.AppendLine($"//{indent} {{");
                code.AppendLine($"//{indent}    toast.CloseToast();");
                code.AppendLine($"//{indent}    [your-button-control].Click -= handler;");
                code.AppendLine($"//{indent} }};");
                code.AppendLine($"//{indent} [your-button-control].Click += handler;");
            };

            code.AppendLine($"{indent}toast.ShowToast();");

            TextCopy.ClipboardService.SetText(code.ToString());
        }
    }
}
