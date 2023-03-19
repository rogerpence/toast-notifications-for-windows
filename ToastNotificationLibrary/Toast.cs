using System.Windows.Forms;
using FormFader;


namespace ToastNotification
{
    public partial class Toast : Form
    {
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private Form parentForm;

        public enum ToastStatus
        {
            Success,
            Info,
            Error
        }
        string[] statusColors = { "#408C3A", "#0F4CF1", "#FF1B00" };

        public enum ToastDuration
        {
            SHORT,
            MEDIUM,
            LONG,
            EXTRALONG,
            USER_CLOSE
        }
        int[] durations = { 2500, 3500, 5000, 7500 };

        public enum ToastPosition
        {
            UPPER_LEFT,
            LOWER_LEFT,
            UPPER_RIGHT,
            LOWER_RIGHT,
            CENTER
        }

        public ToastStatus Status { get; set; } = ToastStatus.Success;
        public ToastDuration Duration { get; set; } = ToastDuration.SHORT;
        public ToastPosition Position { get; set; } = ToastPosition.LOWER_LEFT;
        public string HeaderText { get; set; } = "Congratulations!";
        public string MessageText { get; set; } = "Yay! You did it! World's greatest cup of coffee!";
        public bool UserClose { get; set; } = false;
        public bool HideHeaderMessage { get; set; } = false;
        public Color BorderColor { get; set; }
        public Color BackgroundColor { get; set; }
        public bool HideAccentAndIcon { get; set; } = false;

        public Toast(Form parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;

            BorderColor = this.BackColor;
            BackgroundColor = this.panelToast.BackColor;
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
            pictureboxClose.Visible = UserClose;

            assignText();
            arrangeIcons();
            setActiveIcon(Status);
            setToastScreenPosition();
            setColors();
            displayAndHideToast();
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

            if (Duration == ToastDuration.USER_CLOSE) return;

            timer.Tick += (arg1, arg2) =>
            {
                this.Opacity = 1;
                Fader.FadeOutAndClose(this, Fader.FadeSpeed.Slow);
                timer.Stop();
            };
            timer.Interval = durations[EnumToInt<ToastDuration>(Duration)];
            timer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Opacity = 1;
            Fader.FadeOutAndClose(this, Fader.FadeSpeed.Slow);
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

        public void CloseToast()
        {
            this.Opacity = 1;
            Fader.FadeOutAndClose(this, Fader.FadeSpeed.Slow);
            timer.Stop();
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
        private TEnum EnumFromName<TEnum>(string name) where TEnum : struct
        {
            string userInputString = string.Empty;
            //TEnum resultInputType = default(TEnum);
            TEnum resultInputType = default;

            Enum.TryParse(name, true, out resultInputType);

            return resultInputType;
        }

        /*
         *  Get array of enum names
         */
        private string[] EnumToNames<T>()
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
        public int EnumToInt<T>(T enumValue) where T : Enum
        {
            int index = Convert.ToInt32(enumValue);
            return index;
        }
    }
}

