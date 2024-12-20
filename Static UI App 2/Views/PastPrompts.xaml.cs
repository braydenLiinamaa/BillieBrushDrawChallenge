﻿namespace Static_UI_App_2.Views
{
    public partial class PastPrompts : ContentPage
    {
        ImageSource[] newImages = { ImageSource.FromFile("billie_brush.png"), ImageSource.FromFile("webfish.png") };
        public PastPrompts()
        {
            InitializeComponent();
        }

        private void ButtonPressed(object sender, EventArgs e)
        {
            if (sender is ImageButton imgbutton)
            {
                //if (imgbutton == LogoImage)
                    imgbutton.BackgroundColor = Color.FromArgb("#232b2b");
            }
            else if (sender is Button button)
            {

            }
        }
        private void ButtonReleased(object sender, EventArgs e)
        {
            if (sender is ImageButton imgbutton)
            {
                //if (imgbutton == LogoImage)
                    imgbutton.BackgroundColor = Color.FromArgb("#0e1111");
            }
            else if (sender is Button button)
            {

            }
        }

        private async void ChangePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }

}
