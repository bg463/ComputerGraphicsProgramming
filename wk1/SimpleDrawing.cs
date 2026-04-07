using System.Drawing;
using System.Windows.Forms;

namespace CGP;

public partial class SimpleDrawing : Form
{
    public SimpleDrawing()
    {
        InitializeComponent();

        // I used ResizeRedraw so the shapes get drawn again properly if the window changes.
        SetStyle(ControlStyles.ResizeRedraw, true);
        Width = 500;
        Height = 500;
        BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        using Pen blackPen = new(Color.Black);

        // Triangle from the starter exercise.
        g.DrawLine(blackPen, 50, 50, 100, 100);
        g.DrawLine(blackPen, 100, 100, 200, 100);
        g.DrawLine(blackPen, 200, 100, 50, 50);

        // Other basic shapes from the original file.
        g.DrawRectangle(blackPen, 200, 200, 150, 150);
        g.DrawEllipse(blackPen, new Rectangle(250, 50, 150, 100));

        Point[] pts =
        [
            new Point(50, 300),
            new Point(150, 300),
            new Point(150, 400),
            new Point(100, 350),
            new Point(50, 400)
        ];

        // Green fill for the polygon.
        Color myColour = Color.FromArgb(0, 255, 0);
        using SolidBrush brush = new(myColour);
        g.FillPolygon(brush, pts);

        // Part 3: draw a circle inside a square using the same bounding box.
        Rectangle square = new(50, 150, 100, 100);
        g.DrawRectangle(blackPen, square);
        g.DrawEllipse(blackPen, square);
    }
}
