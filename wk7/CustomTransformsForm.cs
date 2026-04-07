using System.Drawing;
using System.Windows.Forms;

namespace CustomTransforms;

public partial class CustomTransformsForm : Form
{
    private readonly PointF[] squarePoints =
    [
        new PointF(250f, 120f),
        new PointF(350f, 120f),
        new PointF(350f, 220f),
        new PointF(250f, 220f)
    ];

    public CustomTransformsForm()
    {
        InitializeComponent();
        SetStyle(ControlStyles.ResizeRedraw, true);
        StartPosition = FormStartPosition.Manual;
        Location = new Point(0, 0);
        Width = 700;
        Height = 500;
        BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        using Pen blackPen = new(Color.Black);
        using Pen bluePen = new(Color.Blue);
        using Font myFont = new("Helvetica", 9);
        using Brush blackWriter = new SolidBrush(Color.Black);

        // Draw the original square first.
        g.DrawPolygon(blackPen, squarePoints);
        g.DrawString("Original square", myFont, blackWriter, 245, 230);

        // Rotate the square around its centre using the custom class.
        PointF centrePoint = FindCentre(squarePoints);
        PointF[] rotatedSquare = Tmatrix.matrixRotate(squarePoints, 35f, centrePoint);

        // Draw the rotated version as the second shape.
        g.DrawPolygon(bluePen, rotatedSquare);
        g.DrawString("Rotated square", myFont, blackWriter, 365, 185);
    }

    private PointF FindCentre(PointF[] shapePoints)
    {
        float totalX = 0f;
        float totalY = 0f;

        // Add up all the point values first.
        for (int i = 0; i < shapePoints.Length; i++)
        {
            totalX += shapePoints[i].X;
            totalY += shapePoints[i].Y;
        }

        // Average x and y gives the centre point of the square.
        return new PointF(totalX / shapePoints.Length, totalY / shapePoints.Length);
    }
}

public class Tmatrix
{
    public static PointF[] matrixRotate(PointF[] shapePoints, float angleInDegrees, PointF centrePoint)
    {
        PointF[] rotatedPoints = new PointF[shapePoints.Length];

        float angleInRadians = angleInDegrees * (MathF.PI / 180f);
        float cosineValue = MathF.Cos(angleInRadians);
        float sineValue = MathF.Sin(angleInRadians);

        for (int i = 0; i < shapePoints.Length; i++)
        {
            // Move the point so the centre of rotation becomes the origin.
            float movedX = shapePoints[i].X - centrePoint.X;
            float movedY = shapePoints[i].Y - centrePoint.Y;

            // Apply the rotation matrix by hand.
            float rotatedX = (movedX * cosineValue) - (movedY * sineValue);
            float rotatedY = (movedX * sineValue) + (movedY * cosineValue);

            // Move the point back to its real position on screen.
            rotatedPoints[i] = new PointF(
                rotatedX + centrePoint.X,
                rotatedY + centrePoint.Y);
        }

        return rotatedPoints;
    }
}
