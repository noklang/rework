using ImageFormat = System.Drawing.Imaging.ImageFormat;
using Tesseract;

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

        /// <summary>The OCR often misreads the % sign. Turn those misreads back into %.</summary>
        private static string FixOcrMistakes(string text)
        {
            return text
                .Replace("1975", "19%")
                .Replace("Z", "%")
                .Replace("55", "%")
                .Replace("75", "%");
        }

        /// <summary>Screenshots the area, makes it 2x bigger and turns it grey. OCR reads that better.</summary>
        private static Bitmap CaptureForOcr(Rectangle area)
        {
            using Bitmap screenshot = new Bitmap(area.Width, area.Height);
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(area.Location, Point.Empty, area.Size);
            }

            Bitmap bigger = new Bitmap(screenshot, area.Width * 2, area.Height * 2);

            for (int y = 0; y < bigger.Height; y++)
            {
                for (int x = 0; x < bigger.Width; x++)
                {
                    Color pixel = bigger.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    bigger.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return bigger;
        }

        private string RunOcr(Bitmap image)
        {
            using var stream = new MemoryStream();
            image.Save(stream, ImageFormat.Png);

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
