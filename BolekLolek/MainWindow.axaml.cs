using System;
using System.Collections.Generic;
using Avalonia;
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
        UsunButton.Click += UsunButton_Click;
        BohaterComboBox.SelectionChanged += BohaterComboBox_SelectionChanged;
        Kalendarz.SelectedDate = DateTime.Today;
        
    }
    

    private void BohaterComboBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        string? selected = (BohaterComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();

        if (selected == "Bolek")
            BohaterImage.Source = new Bitmap("Assets/Bolek.jpg");
        else if (selected == "Lolek")
            BohaterImage.Source = new Bitmap("Assets/Lolek.jpg");
        else
            BohaterImage.Source = null;
    }
    
    
    
    
    private void DodajButton_Click(object sender, RoutedEventArgs e)
    {
        string nazwaZadania = NazwaZadaniaTextBox.Text ?? "";
        
        object bohater = (BohaterComboBox.SelectedItem as ComboBoxItem)?.Content ?? "brak";

        string priorytet = prioNiski.IsChecked == true ? "Niski" :
            prioNormalny.IsChecked == true ? "Normalny" :
            prioWysoki.IsChecked == true ? "Wysoki" :
            "nie wybrano";
        
        var opcjdodatkowe = new List<string>();
        if(CheckNaDworze.IsChecked == true) opcjdodatkowe.Add("Na Dworze");
        if(CheckpSprzet.IsChecked == true) opcjdodatkowe.Add("Potrzebny sprzet");
        if(CheckzUdzInnych.IsChecked == true ) opcjdodatkowe.Add("Z udziałem innych");
        
        string dodatkowetext = string.Join(", ", opcjdodatkowe);

        DateTime? selectedDate = Kalendarz.SelectedDate;
        string? onlyDate = selectedDate?.ToShortDateString();
        
        string podsumowanie = $"{bohater} - {nazwaZadania} [{priorytet}] - {dodatkowetext} - data {onlyDate}";
        
        ZadaniaListBox.Items.Add(podsumowanie);
    }

    private void UsunButton_Click(object sender, RoutedEventArgs e)
    {
        if (ZadaniaListBox.SelectedItem != null)
        {
            ZadaniaListBox.Items.Remove(ZadaniaListBox.SelectedItem);
        }
    }
}