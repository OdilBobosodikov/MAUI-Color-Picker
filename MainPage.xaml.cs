using CommunityToolkit.Maui.Alerts;

namespace ColorPicker;

public partial class MainPage : ContentPage
{
    private Random random;

    private bool isRand = false;
    private string hexValue = String.Empty;

    public MainPage()
    {
        InitializeComponent();
        random = new Random();
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color copied",
            CommunityToolkit.Maui.Core.ToastDuration.Short,
            12);
        await toast.Show();
    }

    private void Color_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!isRand)
        {
            var red = Red.Value;
            var green = Green.Value;
            var blue = Blue.Value;
            var alpha = Alpha.Value;
            Color BackgroundColor = Color.FromRgba(red, green, blue, alpha);

            SetColor(BackgroundColor);
        }
    }

    private void SetColor(Color newColor)
    {
        BtnRandom.BackgroundColor = newColor;
        Container.BackgroundColor = newColor;

        hexValue = newColor.ToRgbaHex();
        lblHex.Text = hexValue;

    }

    private void BtnRandom_Clicked(object sender, EventArgs e)
    {
        isRand = true;

        Color BackgroundColor = Color.FromRgba(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

        Red.Value = BackgroundColor.Red;
        Green.Value = BackgroundColor.Green;
        Blue.Value = BackgroundColor.Blue;
        Alpha.Value = BackgroundColor.Alpha;

        SetColor(BackgroundColor);

        isRand = false;
    }
}

