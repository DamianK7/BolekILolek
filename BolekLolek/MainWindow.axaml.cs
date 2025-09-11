using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace BolekLolek;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BohaterComboBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (BohaterComboBox.SelectedItem is ComboBoxItem bohaterComboBoxItem)
        {
            string bohater = bohaterComboBoxItem.Content.ToString();
            //string imagePath = $"Assets/Images/{bohater}.jpg";
            //bohaterImage.Source = new Bitmap(imagePath);
        }
    }
    
    
    
    
    
    private void SubmitButton_OnClick(object sender, RoutedEventArgs e)
    {
        string nazwaZad = NazwaZadania.Text;

        string bohater = "";
        if (BohaterComboBox.SelectedItem is ComboBoxItem bohaterComboBoxItem)
        {
            bohater = bohaterComboBoxItem.Content.ToString();
        }

        string priorytet = "";
        
        if (prioNiski.IsChecked == true) priorytet = "Niski ";
        if (prioNormalny.IsChecked == true) priorytet = "Normalny ";
        if (prioWysoki.IsChecked == true) priorytet = "Wysoki ";


        string dodatkowe = "";
        if(NaDworze.IsChecked == true) dodatkowe = "Na Dworze ";
        if(pSprzet.IsChecked == true) dodatkowe = "Potrzebny Sprzet ";
        if(zUdzInnych.IsChecked == true) dodatkowe = "Potrzebny Udział innych";
        
        
        ZadaniaListBox.Items.Add(nazwaZad, bohater, priorytet);
        
        string lista = string.Join(",", ZadaniaListBox.Items);
    }
    

   
}