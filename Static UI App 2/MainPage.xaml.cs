namespace Static_UI_App_2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
