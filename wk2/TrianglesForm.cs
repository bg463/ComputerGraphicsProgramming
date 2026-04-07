using System.Drawing;
using System.Windows.Forms;

namespace Triangles;

public partial class TrianglesForm : Form
{
    // These are the starting points given in the exercise sheet.
    private readonly PointF pointA = new(100f, 100f);
    private readonly PointF pointB = new(500f, 100f);
    private readonly PointF pointC = new(300f, 446f);

    public TrianglesForm()
    {
        InitializeComponent();

        // Redraw the shape if the window gets resized or uncovered.
        SetStyle(ControlStyles.ResizeRedraw, true);
        BackColor = Color.White;
        Width = 700;
        Height = 650;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        using Pen blackPen = new(Color.Black);

        // Start by drawing the biggest triangle first.
        DrawNestedTriangles(g, blackPen, pointA, pointB, pointC);
    }

    private void DrawNestedTriangles(Graphics g, Pen pen, PointF a, PointF b, PointF c)
    {
        // Put the current triangle points into an array so DrawPolygon can use them.
        PointF[] triangle = [a, b, c];
        g.DrawPolygon(pen, triangle);

        // Stop once the triangle gets too small to really see.
        if (TriangleSize(a, b, c) < 1f)
        {
            return;
        }

        // Work out the midpoints of each side.
        PointF abMid = GetMidPoint(a, b);
        PointF bcMid = GetMidPoint(b, c);
        PointF caMid = GetMidPoint(c, a);

        // Draw the next triangle formed by joining the three midpoints.
        DrawNestedTriangles(g, pen, abMid, bcMid, caMid);
    }

    private PointF GetMidPoint(PointF firstPoint, PointF secondPoint)
    {
        // This just works out the point halfway between two corners.
        return new PointF(
            (firstPoint.X + secondPoint.X) / 2f,
            (firstPoint.Y + secondPoint.Y) / 2f);
    }

    private float TriangleSize(PointF a, PointF b, PointF c)
    {
        // I used the longest side as a simple way to decide when the triangle is too small.
        float sideAB = DistanceBetween(a, b);
        float sideBC = DistanceBetween(b, c);
        float sideCA = DistanceBetween(c, a);

        return MathF.Max(sideAB, MathF.Max(sideBC, sideCA));
    }

    private float DistanceBetween(PointF firstPoint, PointF secondPoint)
    {
        // Difference in x and y between the two points.
        float xDifference = secondPoint.X - firstPoint.X;
        float yDifference = secondPoint.Y - firstPoint.Y;

        // Pythagoras is used here to get the side length.
        return MathF.Sqrt((xDifference * xDifference) + (yDifference * yDifference));
    }
}
