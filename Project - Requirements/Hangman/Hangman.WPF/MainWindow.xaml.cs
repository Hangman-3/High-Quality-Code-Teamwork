namespace Hangman.WPF
{
    using System;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Hangman.Common.Enums;
    using Hangman.Data.Repositories;
    using Hangman.WPF.IOEngines;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WpfHangman wpfHangman;

        public MainWindow()
        {
            this.InitializeComponent();
            TextCompositionManager.AddTextInputHandler(this, new TextCompositionEventHandler(OnTextComposition));
        }

        public void RunGameEngine()
        {
            var wpfReader = new WpfReader(this.CommandHiddenTextBlock);
            var wpfWriter = new WpfWriter(this.MessageTextBlock, this.SecretWordTextBlock);
            this.wpfHangman = new WpfHangman(wpfReader, wpfWriter, new WordsFromStaticListRepository());
            this.wpfHangman.Start();
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            this.RunGameEngine();
            this.StartButton.IsEnabled = false;
        }

        private void OnLetterButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand((sender as Button).Content as string);
        }

        private void OnRestartButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Restart.ToString());
        }

        private void OnHelpButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Help.ToString());
        }

        private void OnRankListButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Top.ToString());
        }

        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Exit.ToString());
        }

        private void ResponseCommand(string command)
        {
            if (this.wpfHangman == null)
            {
                return;
            }

            this.CommandHiddenTextBlock.Text = command;
            this.wpfHangman.Response();
        }

        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            string key = e.Text;
            this.ResponseCommand(key);
        }
    }
}