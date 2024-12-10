namespace Static_UI_App_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonPressed(object sender, EventArgs e)
        {
            if (sender is ImageButton imgbutton)
            {
                if (imgbutton == LogoImage)
                    imgbutton.BackgroundColor = Color.FromArgb("#232b2b");
            }
            else if (sender is Button button)
            {
                if (button == DrawPromptBtn)
                    button.BackgroundColor = Colors.DarkSalmon;
                else if (button == PastPromptsBtn)
                    button.BackgroundColor = Colors.LightSkyBlue;
                else if (button == ProfileBtn)
                    button.BackgroundColor = Colors.LightGoldenrodYellow;
            }
        }
        private void ButtonReleased(object sender, EventArgs e)
        {
            if (sender is ImageButton imgbutton)
            {
                if (imgbutton == LogoImage)
                    imgbutton.BackgroundColor = Color.FromArgb("#0e1111");
            }
            else if (sender is Button button)
            {
                if (button == DrawPromptBtn)
                    button.BackgroundColor = Colors.Crimson;
                else if (button == PastPromptsBtn)
                    button.BackgroundColor = Colors.DeepSkyBlue;
                else if (button == ProfileBtn)
                    button.BackgroundColor = Colors.Goldenrod;
            }
        }

        private async void ChangePage(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button == DrawPromptBtn)
                    await Navigation.PushAsync(new CurrentPrompt());
                else
                    await Navigation.PushAsync(new MainPage());
            }
        }
    }

}
