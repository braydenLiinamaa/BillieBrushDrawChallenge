﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Static_UI_App_2.Model;

namespace Static_UI_App_2.Services
{
    public class UploadImage
    {
        /// open image picker
        public async Task<FileResult> OpenMediaPickerAsync()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Please a pick photo"
                });

                if (result.ContentType == "image/png" ||
                    result.ContentType == "image/jpeg" ||
                    result.ContentType == "image/jpg")
                    return result;
                else
                    await App.Current.MainPage.DisplayAlert("Error Type Image", "Please choose a new image", "Ok");

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// convert file result to stream
        public async Task<Stream> FileResultToStream(FileResult fileResult)
        {
            if (fileResult == null)
                return null;

            return await fileResult.OpenReadAsync();
        }

        /// convert byte array to stream
        public Stream ByteArrayToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }

        /// convert byte array to string
        public string ByteBase64ToString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// convert string to byte array
        public byte[] StringToByteBase64(string text)
        {
            return Convert.FromBase64String(text);
        }

        /// upload the image
        public async Task<ImageFile> Upload(FileResult fileResult)
        {
            byte[] bytes;

            try
            {
                using (var ms = new MemoryStream())
                {
                    var stream = await FileResultToStream(fileResult);
                    stream.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                return new ImageFile
                {
                    byteBase64 = ByteBase64ToString(bytes),
                    ContentType = fileResult.ContentType,
                    FileName = fileResult.FileName
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}