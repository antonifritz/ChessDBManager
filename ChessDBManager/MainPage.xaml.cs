using Microsoft.Maui.Controls.Shapes;
using System.Text.RegularExpressions;

namespace ChessDBManager;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private async void ImportFileAsync(object sender, EventArgs e)
    {
        var options = new PickOptions
        {
            PickerTitle = "Please select a PGN file",
            FileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.WinUI, new string[] { ".pgn" } } 
        })
        };

        var result = await FilePicker.PickAsync(options);

        if (result != null)
        {
            using var streamReader = new StreamReader(await result.OpenReadAsync());
            string line;
            while ((line = await streamReader.ReadLineAsync()) != null)
            {
                Match headerMatch = Regex.Match(line, @"\[([A-Za-z]+)\s+""([^""]+)""\]");
                if (headerMatch.Success)
                {
                    //HeaderDictionary[headerMatch.Groups[1].Value] = headerMatch.Groups[2].Value;
                    continue;
                }
            }

        }
    }
}

