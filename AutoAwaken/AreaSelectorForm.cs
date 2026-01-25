using System;
using System.Drawing;
using System.Windows.Forms;

namespace AutoAwaken
{
    public partial class AreaSelectorForm : Form
    {
        private Point startPoint;
        private Rectangle selectedArea;
        private bool isDragging = false;

        public Rectangle SelectedArea => selectedArea;

        public AreaSelectorForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Opacity = 0.3; // semi-transparent overlay
            this.BackColor = Color.Black;
            this.TopMost = true;
            this.DoubleBuffered = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startPoint = e.Location;
                isDragging = true;
            }
        }
        private void AreaSelectorForm_Load(object sender, EventArgs e)
        {

        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging)
            {
                var endPoint = e.Location;
                selectedArea = new Rectangle(
                    Math.Min(startPoint.X, endPoint.X),
                    Math.Min(startPoint.Y, endPoint.Y),
                    Math.Abs(startPoint.X - endPoint.X),
                    Math.Abs(startPoint.Y - endPoint.Y)
                );
                Invalidate(); // redraw rectangle
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (isDragging)
            {
                isDragging = false;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (selectedArea != Rectangle.Empty)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectedArea);
                }
            }
        }
    }
}
