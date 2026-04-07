using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace XORDrawing;

public partial class XORDrawing : Form
{
    private readonly Rectangle aRect;
    private readonly Rectangle anEllipse;
    private Rectangle moving;
    private int x = 0;
    private int y = 0;

    public XORDrawing()
    {
        InitializeComponent();

        // Set up the fixed shapes using form coordinates.
        aRect = new Rectangle(100, 100, 200, 200);
        anEllipse = new Rectangle(150, 150, 200, 100);
        moving = new Rectangle(x, y, 10, 10);

        // Put the form at the top left and give it a fixed size.
        StartPosition = FormStartPosition.Manual;
        Location = new Point(0, 0);
        SetStyle(ControlStyles.ResizeRedraw, true);
        Width = 500;
        Height = 500;
        BackColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        // Fill the red square in the background.
        using Brush redBrush = new SolidBrush(Color.Red);
        g.FillRectangle(redBrush, aRect);

        // Fill the green ellipse over the square.
        using Brush greenBrush = new SolidBrush(Color.Green);
        g.FillEllipse(greenBrush, anEllipse);

        // This loop moves the little square diagonally across the form.
        while (x < 500)
        {
            // Convert the current form point to screen coordinates as required.
            moving.Location = PointToScreen(new Point(x, y));

            // Draw the small reversible square.
            ControlPaint.FillReversibleRectangle(moving, Color.Red);

            // Slow it down so the movement can actually be seen.
            Thread.Sleep(10);

            // Drawing the same reversible rectangle again removes it.
            ControlPaint.FillReversibleRectangle(moving, Color.Red);

            // Move one step down and to the right for the next frame.
            x++;
            y++;
        }
    }
}
