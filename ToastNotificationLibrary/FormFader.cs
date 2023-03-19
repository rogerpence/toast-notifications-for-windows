namespace FormFader
{
    /// <summary>
    /// An object used to control fading forms in and out.
    /// </summary>
    class Fader
    {
        // This delegate is later used as a call back for
        // when the form has completed fading.
        public delegate void FadeCompleted();

        // Class properties
        private readonly Form form;                                           // The form to modify the opacity of.
        private readonly Form parentForm;                                     // The parent form if being displayed as a dialog.
        private FadeDirection fadeDirection;                                  // The direction in which to fade.
        private float fadeSpeed;                                              // The speed at which to fade.
        private FadeCompleted fadeFinished;                                   // The delegate to call when a fade has completed.
        private bool shouldClose;                                             // If set to true, the form will close after fading out.
        private readonly TaskCompletionSource<DialogResult> showDialogResult  // The Async Task Completion Source for displaying as a dialog.
            = new TaskCompletionSource<DialogResult>();

        // Enum for controlling the fade direction.
        private enum FadeDirection
        {
            In,
            Out
        }

        // Constants for setting the fade speed. 
        // (You can alternately use a custom float value)
        public static class FadeSpeed
        {
            public static readonly float Slowest = 1;
            public static readonly float Slower = 10;
            public static readonly float Slow = 25;
            public static readonly float Normal = 50;
            public static readonly float Fast = 60;
            public static readonly float Faster = 75;
            public static readonly float Fastest = 100;
        }

        /// <summary>
        /// Construct the Fader object with a form.
        /// </summary>
        private Fader(Form form)
        {
            this.form = form;
        }

        /// <summary>
        /// Construct a Fader object with a form and a parent form.
        /// </summary>
        private Fader(Form form, Form parent) : this(form)
        {
            this.parentForm = parent;
        }

        /// <summary>
        /// Begin fading the form.
        /// </summary>
        private void BeginFade()
        {
            UpdateOpacity();
            fadeFinished?.Invoke();
        }

        /// <summary>
        /// Update the opacity of the form using the timer.
        /// </summary>
        private async void UpdateOpacity()
        {
            if (form.IsDisposed)
            {
                return;
            }

            switch (fadeDirection)
            {
                // Fade in
                case FadeDirection.In:
                    if (form.Opacity < 1.0)
                        form.Opacity += (fadeSpeed / 1000.0);
                    else
                        return;

                    break;

                // Fade out
                case FadeDirection.Out:
                    if (form.Opacity > 0.1)
                    {
                        form.Opacity -= (fadeSpeed / 1000.0);
                    }
                    else
                    {
                        if (!shouldClose)
                            form.Hide();
                        else
                            form.Close();

                        return;
                    }
                    break;
            }

            await Task.Delay(10);
            UpdateOpacity();
        }

        /// <summary>
        /// Fade the form in at the defined speed as a dialog
        /// based on parent form.
        /// </summary>
        private async Task<DialogResult> ShowDialog(float fadeSpeed, FadeCompleted finished)
        {
            parentForm.BeginInvoke(new Action(() => showDialogResult.SetResult(form.ShowDialog(parentForm))));
            
            fadeFinished = finished;
            form.Opacity = 0;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.In;
            BeginFade();

            return await showDialogResult.Task;
        }

        /// <summary>
        /// Fade the form in at the defined speed.
        /// </summary>
        private void FadeIn(float fadeSpeed, FadeCompleted finished)
        {
            form.Opacity = 0;
            form.Show();

            fadeFinished = finished;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.In;

            BeginFade();
        }

        /// <summary>
        /// Fade the form out at the defined speed.
        /// </summary>
        private void FadeOut(float fadeSpeed, FadeCompleted finished)
        {
            if (form.Opacity < 0.1)
            {
                finished?.Invoke();
                return;
            }

            fadeFinished = finished;
            form.Opacity = 100;
            this.fadeSpeed = fadeSpeed;
            fadeDirection = FadeDirection.Out;

            BeginFade();
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed.
        /// </summary>
        public async static Task<DialogResult> ShowDialog(Form form, Form parent, float fadeSpeed)
        {
            Fader fader = new Fader(form, parent);
            return await fader.ShowDialog(fadeSpeed, null);
        }

        /// <summary>
        /// Fades a dialog in using parent form and defined fade speed
        /// and call the finished delegate.)
        /// </summary>
        public async static Task<DialogResult> ShowDialog(Form form, Form parent, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form, parent);
            return await fader.ShowDialog(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(Form form, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form);
            fader.FadeIn(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(Form form, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form);
            fader.FadeOut(fadeSpeed, finished);
        }

        /// <summary>
        /// Fade a form in at the defined speed.
        /// </summary>
        public static void FadeIn(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form);
            fader.FadeIn(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed.
        /// </summary>
        public static void FadeOut(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form);
            fader.FadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// </summary>
        public static void FadeOutAndClose(Form form, float fadeSpeed)
        {
            Fader fader = new Fader(form)
            {
                shouldClose = true
            };
            fader.FadeOut(fadeSpeed, null);
        }

        /// <summary>
        /// Fade a form out at the defined speed and
        /// close it when the fade has completed.
        /// After the form has closed, call the FadeComplete delegate.
        /// </summary>
        public static void FadeOutAndClose(Form form, float fadeSpeed, FadeCompleted finished)
        {
            Fader fader = new Fader(form)
            {
                shouldClose = true
            };
            fader.FadeOut(fadeSpeed, finished);
        }
    }
}