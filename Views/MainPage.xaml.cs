namespace BillieBrushsDailyChallenge
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnClicked_Past(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PastPrompts());
        }

        private async void btnClicked_Upload(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ImageUpload());
        }
    }
}
