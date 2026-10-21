namespace AutoAwaken
{
    /// <summary>
    /// The colors of the dark grey / black / white design.
    /// MainForm.Designer.cs uses the same values.
    /// </summary>
    static class Theme
    {
        public static readonly Color Background = Color.FromArgb(18, 18, 18);  // window
        public static readonly Color Card = Color.FromArgb(30, 30, 30);        // section panels
        public static readonly Color Input = Color.FromArgb(42, 42, 42);       // text boxes
        public static readonly Color Border = Color.FromArgb(64, 64, 64);
        public static readonly Color Text = Color.FromArgb(240, 240, 240);
        public static readonly Color MutedText = Color.FromArgb(150, 150, 150);

        public static readonly Color StartButton = Color.White;               // Start (idle)
        public static readonly Color RunningButton = Color.FromArgb(90, 90, 90); // Start while running
    }
}
