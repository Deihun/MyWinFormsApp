using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsApp.SupportClass
{
    public class Scalingsupport
    {
        private const float REF_WIDTH = 1900f;
        private const float REF_HEIGHT = 1080f;
        public int getPercentage(double percentage, int value)
        {
            percentage = percentage > 100 ? 100 : percentage;
            percentage = percentage <= 0 ? 1 : percentage;
                double currentpercent = percentage * 0.01;
            return Convert.ToInt32(currentpercent * value);
        }

        public Size ScaleObject(Size originalSize)
        {
            int screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            float widthRatio = screenWidth / REF_WIDTH;
            float heightRatio = screenHeight / REF_HEIGHT;

            float scaleFactor = Math.Min(widthRatio, heightRatio);
            int newWidth = (int)(originalSize.Width * scaleFactor);
            int newHeight = (int)(originalSize.Height * scaleFactor);

            return new Size(newWidth, newHeight);
        }
    }
}
