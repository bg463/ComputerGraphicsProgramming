using System.Drawing;
using System.Windows.Forms;

namespace Flicker;

public partial class Flicker : Form
{
    private Rectangle rect;
    private int x = 0;
    private int y = 200;
    private int xStep = 1;
    private int yStep = 1;
    private readonly System.Windows.Forms.Timer animationTimer;

    public Flicker()
    {
        InitializeComponent();

        // Position the form in the top left like the starter file.
        StartPosition = FormStartPosition.Manual;
        Location = new Point(0, 0);
        Width = 400;
        Height = 400;

        // Turn on double buffering so the flicker is reduced.
        DoubleBuffered = true;
        SetStyle(ControlStyles.ResizeRedraw, true);
        BackColor = Color.White;

        // Start with the same small rectangle near the lower half of the form.
        rect = new Rectangle(x, y, 50, 50);

        // Timer is used so the form keeps repainting without freezing OnPaint.
        animationTimer = new System.Windows.Forms.Timer();
        animationTimer.Interval = 10;
        animationTimer.Tick += AnimationTimerTick;
        animationTimer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        using Pen blackPen = new(Color.Black);
        using Brush redBrush = new SolidBrush(Color.Red);
        using Font myFont = new("Helvetica", 9);

        // Fill the background first.
        g.Clear(Color.White);

        // Draw the moving rectangle in its current position.
        g.DrawRectangle(blackPen, rect);

        // Keep the message in the middle area like the original example.
        g.DrawString("Moving rectangle", myFont, redBrush, 150, 150);
    }

    private void AnimationTimerTick(object? sender, EventArgs e)
    {
        x += xStep;
        y += yStep;

        // Bounce when the rectangle reaches either side of the form.
        if (x <= 0 || x + rect.Width >= ClientSize.Width)
        {
            xStep = -xStep;
        }

        // Bounce when the rectangle reaches the top or bottom.
        if (y <= 0 || y + rect.Height >= ClientSize.Height)
        {
            yStep = -yStep;
        }

        rect.Location = new Point(x, y);

        // Ask the form to repaint using the new position.
        Invalidate();
    }
}
