using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Tesseract;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using PixelFormat = System.Drawing.Imaging.PixelFormat;

namespace AutoAwaken
{
    /// <summary>
    /// Takes a picture of part of the screen and reads the text in it (OCR).
    /// </summary>
    class ScreenReader : IDisposable
    {
        private readonly TesseractEngine engine;

        public ScreenReader()
        {
            string tessDataFolder = Path.Combine(Application.StartupPath, "tessdata");
            engine = new TesseractEngine(tessDataFolder, "eng", EngineMode.TesseractOnly);
        }

        /// <summary>Reads the text inside the given screen area, with common OCR mistakes fixed.</summary>
        public string ReadText(Rectangle area)
        {
            using Bitmap image = CaptureForOcr(area);
            string rawText = RunOcr(image);
            Console.WriteLine($"[DEBUG] OCR rawText: '{rawText}'");

            return FixOcrMistakes(rawText);
        }

        /// <summary>The OCR often misreads the % sign (and a few words). Turn those misreads back.</summary>
        private static string FixOcrMistakes(string text)
        {
            text = text
                .Replace("Ma><", "Max")
                .Replace("°lo", "%")
                .Replace("°/o", "%")
                .Replace("1975", "19%")
                .Replace("Z", "%")
                .Replace("55", "%")
                .Replace("75", "%");

            // "+ 25" → "+25"
            return Regex.Replace(text, @"\+[ \t]+", "+");
        }

        /// <summary>Screenshots the area, makes it 2x bigger and turns it grey. OCR reads that better.</summary>
        private static Bitmap CaptureForOcr(Rectangle area)
        {
            using Bitmap screenshot = new Bitmap(area.Width, area.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            }

            // Smooth upscale keeps letter edges clean, which helps the OCR
            Bitmap bigger = new Bitmap(area.Width * 2, area.Height * 2, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bigger))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(screenshot, 0, 0, bigger.Width, bigger.Height);
            }

            MakeGray(bigger);
            return bigger;
        }

        /// <summary>Turns the image grey by editing the raw pixel bytes (much faster than GetPixel/SetPixel).</summary>
        private static void MakeGray(Bitmap image)
        {
            var rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData data = image.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            try
            {
                int byteCount = data.Stride * image.Height;
                byte[] pixels = new byte[byteCount];
                Marshal.Copy(data.Scan0, pixels, 0, byteCount);

                // Bytes are stored as B, G, R, A
                for (int i = 0; i < byteCount; i += 4)
                {
                    byte gray = (byte)((pixels[i] + pixels[i + 1] + pixels[i + 2]) / 3);
                    pixels[i] = gray;
                    pixels[i + 1] = gray;
                    pixels[i + 2] = gray;
                }

                Marshal.Copy(pixels, 0, data.Scan0, byteCount);
            }
            finally
            {
                image.UnlockBits(data);
            }
        }

        private string RunOcr(Bitmap image)
        {
            // BMP has no compression, so it is much faster to save and load than PNG
            using var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Bmp);

            using var pix = Pix.LoadFromMemory(stream.ToArray());
            using var page = engine.Process(pix);
            return page.GetText();
        }

        public void Dispose()
        {
            engine.Dispose();
        }
    }
}
