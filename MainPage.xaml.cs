namespace VisualElementXY202311;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
        (double x, double y) = GetCoordinatesWithinWindow(myDotnetBotImage);
		coordinatesLabel.Text = $"x={x}, y={y}";

		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

	private (double x, double y) GetCoordinatesWithinWindow(VisualElement element)
	{
        double x = 0;
        double y = 0;
        VisualElement? workingElement = element;
        while (workingElement is VisualElement visualElement)
        {
            x += visualElement.X;
            y += visualElement.Y;
            workingElement = workingElement.Parent as VisualElement;
        }

		return (x, y);
    }
}

