﻿using Static_UI_App_2;

namespace Static_UI_App_2.Views
{
    public partial class CurrentPrompt : ContentPage
    {
        String[] characters = { "a cat", "a dog", "a bird", "a fish", "a person", "a rock", "the rock", "pikachu", "Sonic Hedgehog", "Hatsune Miku", "Luigi", "a scarecrow", "a mannequin" };
        String[] actions = { "running", "dancing", "doing a backflip", "playing an instrument", "just standing there, menacingly", "with a gun", "in the midst of an epic battle", "going super saiyan" };
        String[] locations = { "in the middle of a city", "in a small village", "in the forest", "in a park", "on the street", "on the moon", "on the roof of a building", "in a cave", "in deep space", "in the backrooms" };
        Services.UploadImage uploadImage { get; set; }
        public CurrentPrompt()
        {
            InitializeComponent();
            PromptLabel.Text = RandomizePrompt();
            uploadImage = new Services.UploadImage();
        }
        private String RandomizePrompt()
        {
            Random random = new Random();
            int x = random.Next(0, characters.Length);
            int y = random.Next(0, actions.Length);
            int z = random.Next(0, locations.Length);
            return $"Draw {characters[x]}" 
                + ((random.Next(3) > 1) ? $" {actions[y]}" : "") + ((random.Next(3) == 1) ? $" {locations[z]}." : ".");
        }

        private void RandomizePrompt(object sender, EventArgs e)
        {
            PromptLabel.Text = RandomizePrompt();
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
                if (button == GeneratePromptBtn)
                    button.BackgroundColor = Colors.DarkSalmon;
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
                if (button == GeneratePromptBtn)
                    button.BackgroundColor = Colors.Crimson;
            }
        }
        private async void ChangePage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void UploadImage_Clicked(object sender, EventArgs e)
        {
            var img = await uploadImage.OpenMediaPickerAsync(); /// Open image picker

            var imagefile = await uploadImage.Upload(img); // allow for upload

            Image_Upload.Source = ImageSource.FromStream(() =>
            uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64)) /// allow image to be read as a variable
            );
        }
    }

}
