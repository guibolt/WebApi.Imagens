using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace WebApi.Imagens.Core.Helpers
{
    public static class TratarImagemHelper
    {
        public static string ResizeBase64ImageString(string tipo, string Base64String, int percentual)
        {
            if (tipo.ToUpper().Contains("JPG") || tipo.ToUpper().Contains("JPEG") || tipo.ToUpper().Contains("PNG"))
            {
                Base64String = Base64String.Replace("data:image/png;base64,", "");

                // Converte a string base64 para byte
                byte[] imageBytes = Convert.FromBase64String(Base64String);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    // Converte byte[] para Imagem
                    ms.Write(imageBytes, 0, imageBytes.Length);
                    Image image = Image.FromStream(ms, true);

                    //chama método para diminuir a resolucão da imagem
                    var imag = ScaleImage(image, percentual);

                    using (MemoryStream ms1 = new MemoryStream())
                    {
                        //volta a imagem para byte
                        imag.Save(ms1, ImageFormat.Jpeg);
                        byte[] imageBytes1 = ms1.ToArray();

                        //volta imagem para Base64 
                        string base64String = Convert.ToBase64String(imageBytes1);
                        return base64String;
                    }
                }
            }
            return Base64String;
        }

        public static Image ScaleImage(Image image, int percentual)
        {
            var width = (int)image.PhysicalDimension.Width;
            var ratio = 0.0;
            if (width > 4000)
                ratio = (double)25 / 100;
            else if (width <= 4000 && width > 3000)
                ratio = (double)30 / 100;
            else if (width <= 3000 && width > 2000)
                ratio = (double)40 / 100;
            else if (width <= 2000 && width > 1300)
                ratio = (double)65 / 100;
            else
                ratio = 1;

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
    }
}
