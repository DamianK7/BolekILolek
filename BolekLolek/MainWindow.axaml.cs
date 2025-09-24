using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;

namespace BolekLolek;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();
        DodajButton.Click += DodajButton_Click;
        //BohaterComboBox.SelectionChanged += BohaterComboBox_SelectionChanged;
    }
    /* private void BohaterComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
       var bohater = (BohaterComboBox.SelectedItem as ComboBoxItem).Content.ToString();
       string zdjecie = bohater switch
       {
           "Bolek" => "Assets/bolek.png",
           "Lolek" => "Assets/lolek.png",
       };

       BohaterImage.Source = new Avalonia.Media.Imaging.Bitmap(zdjecie);
    }
    */
    
    
    
    private void DodajButton_Click(object sender, RoutedEventArgs e)
    {
        string nazwaZadania = NazwaZadaniaTextBox.Text ?? "";
        
        object bohater = (BohaterComboBox.SelectedItem as ComboBoxItem)?.Content ?? "brak";

        string priorytet = prioNiski.IsChecked == true ? "Niski" :
            prioNormalny.IsChecked == true ? "Normalny" :
            prioWysoki.IsChecked == true ? "Wysoki" :
            "nie wybrano";
        
        
        
        string podsumowanie = $"{bohater} - {nazwaZadania} [{priorytet}]";
        
        ZadaniaListBox.Items.Add(podsumowanie);
    }
    

   
}