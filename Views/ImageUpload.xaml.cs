using BillieBrushsDailyChallenge;

namespace BillieBrushsDailyChallenge.Views;

public partial class ImageUpload : ContentPage
{
    Services.UploadImage uploadImage { get; set; }
    public ImageUpload()
	{
		InitializeComponent();
        uploadImage = new Services.UploadImage();
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