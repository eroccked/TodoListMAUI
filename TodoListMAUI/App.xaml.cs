namespace TodoListMAUI;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 500;
        const int newHeight = 800;

        window.MaximumWidth = newWidth + 500;
        window.MaximumHeight = newHeight + 500;
        window.MinimumWidth = newWidth;
        window.MinimumHeight = newHeight;
        return window;
    }
}