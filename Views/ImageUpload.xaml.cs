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
        var img = await uploadImage.OpenMediaPickerAsync();

        var imagefile = await uploadImage.Upload(img);

        Image_Upload.Source = ImageSource.FromStream(() =>
            uploadImage.ByteArrayToStream(uploadImage.StringToByteBase64(imagefile.byteBase64))
        );
    }
}