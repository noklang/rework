namespace AutoAwaken
{
    /// <summary>
    /// A dark see-through window over the whole screen. Drag with the left mouse
    /// button to pick an area; the window closes when you let go.
    /// </summary>
    public partial class AreaSelectorForm : Form
    {
        private Point dragStart;
        private bool isDragging = false;

        public Rectangle SelectedArea { get; private set; }

        public AreaSelectorForm()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Opacity = 0.3;
            BackColor = Color.Black;
            TopMost = true;
            DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragStart = e.Location;
                isDragging = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (!isDragging) return;

            SelectedArea = new Rectangle(
                Math.Min(dragStart.X, e.X),
                Math.Min(dragStart.Y, e.Y),
                Math.Abs(dragStart.X - e.X),
                Math.Abs(dragStart.Y - e.Y));
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (!isDragging) return;

            isDragging = false;
            DialogResult = DialogResult.OK;
            Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (SelectedArea != Rectangle.Empty)
            {
                using var pen = new Pen(Color.Red, 2);
                e.Graphics.DrawRectangle(pen, SelectedArea);
            }
        }

        private void AreaSelectorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
