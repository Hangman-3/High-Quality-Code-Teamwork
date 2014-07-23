namespace Hangman.WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using Hangman.Data.Repositories;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        public void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            var wpfHangman = new WpfHangman(new WordsFromFileRepository());
            wpfHangman.Start();
        }

        public void OnLetterButtonClick(object sender, RoutedEventArgs e)
        {
            this.textBlock.Text = (sender as Button).Content as string;
        }
    }
}