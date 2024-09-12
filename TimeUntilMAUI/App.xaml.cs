namespace TimeUntilMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = new Window(new MainPage());

#if WINDOWS
        window.Height = 700;
        window.Width = 900;
#endif

        return window;
 
    }
}
