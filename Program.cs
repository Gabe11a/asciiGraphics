using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace asciiGraphics
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var Load = new OpenFileDialog() { Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG" };
            while (true)
            {
                Console.ReadLine();
                if (Load.ShowDialog() != DialogResult.OK)
                    continue;
                Console.Clear();
                var bitmap = new Bitmap(Load.FileName);
                bitmap = Resize(bitmap);
                bitmap.ToGreyscale();
                var converter = new BitmapToASCIIConvertor();
                var finalyPicture = converter.Convert(bitmap);
                foreach (var pixel in finalyPicture)
                {
                    Console.WriteLine(pixel);
                }
                Console.SetCursorPosition(0, 0);
                
            }
        }
        private static Bitmap Resize (Bitmap bitmap)
        {
            double maxWidth = 350;
            double maxHeight = bitmap.Height / 1.5 * maxWidth / bitmap.Width;
            if (bitmap.Width>maxWidth || bitmap.Height > maxHeight)
            {
                bitmap = new Bitmap(bitmap, new Size((int)maxWidth, (int)maxHeight));
            }
            return bitmap;
        }
    }
}
