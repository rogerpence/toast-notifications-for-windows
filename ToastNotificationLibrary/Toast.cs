using FormFader;

namespace ToastNotification
{
    public partial class Toast : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private Form parentForm;

        public enum ToastStatus
        {
            SUCCESS,
            INFO,
            ERROR
        }
        string[] statusColors = { "#408C3A", "#0F4CF1", "#FF1B00" };

        public enum ToastDuration
        {
            SHORT,
            MEDIUM,
            LONG,
            EXTRA_LONG,
            FOREVER
        }
        int[] durations = { 3000, 6000, 9000, 12000 };

        public enum ToastPosition
        {
            UPPER_LEFT,
            LOWER_LEFT,
            UPPER_RIGHT,
            LOWER_RIGHT,
            CENTER
        }

        public ToastStatus Status { get; set; } = ToastStatus.SUCCESS;
        public ToastDuration Duration { get; set; } = ToastDuration.SHORT;
        public ToastPosition Position { get; set; } = ToastPosition.LOWER_LEFT;
        public string HeaderText { get; set; } = "Congratulations!";
        public string MessageText { get; set; } = "Yay! You did it! World's greatest cup of coffee!";
        public bool HideHeaderMessage { get; set; } = false;
        public bool HideAccentAndIcon { get; set; } = false;
        public bool HideUserCloseButton { get; set; } = false;
        public Color BackgroundColor { get; set; }
        public Color BorderColor { get; set; }

        public Toast(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

            BorderColor = this.BackColor;
            BackgroundColor = this.panelToast.BackColor;
            this.TopMost = true;
        }

        public void ChangeDefaultDurationSeconds(int slowDuration,
                                                 int mediumDuration,
                                                 int longDuration,
                                                 int extraLongDuration)
        {
            durations[0] = slowDuration * 1000;
            durations[1] = mediumDuration * 1000;
            durations[2] = longDuration * 1000;
            durations[3] = extraLongDuration * 1000;
        }

        private void Toast_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;

            assignText();
            arrangeIcons();
            setActiveIcon(Status);
            setToastScreenPosition();
            setColors();
        }

        public void SetMessageText(string message)
        {
            labelToastMessageText.Text = message;
        }

        private void setColors()
        {
            if (BorderColor.Name != "Control") this.BackColor = BorderColor;
            if (BackgroundColor.Name != "Control") panelToast.BackColor = BackgroundColor;
        }

        private void assignText()
        {
            labelToastHeaderText.Text = HeaderText;
            labelToastMessageText.Text = MessageText;

            if (HideAccentAndIcon)
            {
                labelToastHeaderText.Left = labelToastHeaderText.Left - 65;
                labelToastMessageText.Left = labelToastMessageText.Left - 65;
            }

            if (HideHeaderMessage)
            {
                labelToastHeaderText.Visible = false;
                labelToastMessageText.Top = labelToastMessageText.Top - 15;
            }
        }

        private void displayAndHideToast()
        {
            Fader.FadeIn(this, Fader.FadeSpeed.Slow);

            if (Duration == ToastDuration.FOREVER) return;

            timer.Tick += (arg1, arg2) =>
            {
                this.Opacity = 1;
                Fader.FadeOutAndClose(this, Fader.FadeSpeed.Slow);
                timer.Stop();
            };
            timer.Interval = durations[EnumToInt<ToastDuration>(Duration)];
            timer.Start();
        }

        private void setActiveIcon(ToastStatus status)
        {
            if (HideAccentAndIcon)
            {
                pictureboxInfo.Visible = false;
                pictureboxSuccess.Visible = false;
                pictureboxError.Visible = false;
                panelAccent.Visible = false;
                return;
            }

            PictureBox pb;

            int index = EnumToInt<ToastStatus>(status);
            string[] statusValue = EnumToNames<ToastStatus>();
            foreach (string itemStatus in statusValue)
            {
                pb = this.Controls.Find($"picturebox{itemStatus}", true).FirstOrDefault() as PictureBox;
                pb.Visible = false;
            }
            pb = this.Controls.Find($"picturebox{statusValue[index]}", true).FirstOrDefault() as PictureBox;
            pb.Visible = true;

            string statusColor = getToastStatusColor(status);
            panelAccent.BackColor = ColorTranslator.FromHtml(statusColor);
        }

        private void arrangeIcons()
        {
            pictureboxClose.Visible = !HideUserCloseButton;
            pictureboxInfo.Location = pictureboxSuccess.Location;
            pictureboxError.Location = pictureboxSuccess.Location;
        }

        private string getToastStatusColor(ToastStatus ts)
        {
            return statusColors[EnumToInt(ts)];
        }

        private void setToastScreenPosition()
        {
            if (Position == ToastPosition.UPPER_LEFT)
            {
                this.Left = this.parentForm.Left + 20;
                this.Top = this.parentForm.Top + 10;
            }
            else if (Position == ToastPosition.UPPER_RIGHT)
            {
                this.Left = this.parentForm.Left + this.parentForm.Width - this.Width - 20;
                this.Top = this.parentForm.Top + 10;
            }
            else if (Position == ToastPosition.LOWER_RIGHT)
            {
                this.Left = this.parentForm.Left + this.parentForm.Width - this.Width - 20;
                this.Top = this.parentForm.Top + this.parentForm.Height - this.Height - 20;
            }
            else if (Position == ToastPosition.CENTER)
            {
                this.Left = ((parentForm.Width / 2) - (this.Width / 2)) + parentForm.Left;
                this.Top = ((parentForm.Height / 2) - (this.Height / 2)) + parentForm.Top;
            }
            else
            {
                this.Left = this.parentForm.Left + 20;
                this.Top = this.parentForm.Top + this.parentForm.Height - this.Height - 20;
            }
        }

        public void ShowToast()
        {
            displayAndHideToast();
        }

        public void CloseToast()
        {
            try
            {
                timer.Stop();
                this.Opacity = 1;
                Fader.FadeOutAndClose(this, Fader.FadeSpeed.Slow);
            }
            catch
            {

            }
        }

        private void pictureboxClose_Click(object sender, EventArgs e)
        {
            CloseToast();
        }

        /*
         *  Generic members
         */

        /*
         *  Get enum member by name
         *  https://stackoverflow.com/questions/10685794/how-to-use-generic-tryparse-with-enum
         */
        public static TEnum EnumFromName<TEnum>(string name) where TEnum : struct
        {
            string userInputString = string.Empty;
            TEnum resultInputType = default(TEnum);

            Enum.TryParse(name, true, out resultInputType);

            return resultInputType;
        }

        /*
         *  Get array of enum names
         */
        public static string[] EnumToNames<T>()
        {
            List<string> result = new();

            foreach (string s in Enum.GetNames(typeof(T)))
            {
                result.Add(s);
            }

            return result.ToArray();
        }

        /*
         *  Get enum member ordinal position
         */
        public static int EnumToInt<T>(T enumValue) where T : Enum
        {
            int index = Convert.ToInt32(enumValue);
            return index;
        }

        /*
         *  Get enum value as string
         */
        public static string EnumGetName<T>(object value)
        {{
            return Enum.GetName(typeof(T), value);}
        }
    }
}

