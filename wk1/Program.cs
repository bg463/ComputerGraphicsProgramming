namespace CGP;

static class Program
{
    [STAThread]
    static void Main()
    {
        // Start the form for this exercise.
        ApplicationConfiguration.Initialize();
        Application.Run(new SimpleDrawing());
    }
}
