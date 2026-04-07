using System.Drawing;
using System.Windows.Forms;

namespace ShapeRepresentation;

public partial class ShapeRepresentation : Form
{
    // These points are shared by all the lines in the drawing.
    private readonly Point[] pointsTable =
    [
        new Point(24, 23),   // 0 top left
        new Point(247, 23),  // 1 top middle split
        new Point(385, 23),  // 2 top right
        new Point(247, 71),  // 3 inner top left
        new Point(385, 71),  // 4 inner top right
        new Point(24, 118),  // 5 left middle
        new Point(247, 118), // 6 centre join
        new Point(385, 118), // 7 right middle
        new Point(24, 190),  // 8 bottom left
        new Point(385, 190)  // 9 bottom right
    ];

    // Each row stores the start point index and end point index for one line.
    private readonly int[,] lineTable =
    {
        { 0, 1 },
        { 1, 2 },
        { 1, 3 },
        { 3, 4 },
        { 2, 4 },
        { 0, 5 },
        { 5, 6 },
        { 6, 7 },
        { 8, 9 },
        { 5, 8 },
        { 7, 9 },
        { 6, 3 }
    };

    public ShapeRepresentation()
    {
        InitializeComponent();
        SetStyle(ControlStyles.ResizeRedraw, true);
        BackColor = Color.White;
        Width = 700;
        Height = 500;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        using Pen blackPen = new(Color.Black);

        // One loop and one DrawLine call generate the whole shape.
        for (int lineIndex = 0; lineIndex < lineTable.GetLength(0); lineIndex++)
        {
            int startPointIndex = lineTable[lineIndex, 0];
            int endPointIndex = lineTable[lineIndex, 1];

            g.DrawLine(
                blackPen,
                pointsTable[startPointIndex],
                pointsTable[endPointIndex]);
        }
    }
}
