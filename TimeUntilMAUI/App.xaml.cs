namespace TimeUntilMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainPage();
    }

#if WINDOWS
    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        window.Height = 700;
        window.Width = 900;     

        return window;
    }
#endif
}
