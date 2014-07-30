// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.WPF
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Hangman.Common.Enums;
    using Hangman.Data.Repositories;
    using Hangman.WPF.IOEngines;

    /// <summary>
    /// Interaction logic for MainWindow XAML
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Hangman game for WPF
        /// </summary>
        private WpfHangman wpfHangman;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            TextCompositionManager.AddTextInputHandler(this, new TextCompositionEventHandler(this.OnTextComposition));
        }

        /// <summary>
        /// Runs game engine for WPF
        /// </summary>
        public void RunGameEngine()
        {
            var wpfReader = new WpfReader(this.CommandHiddenTextBlock);
            var wpfWriter = new WpfWriter(this.MessageTextBlock, this.SecretWordTextBlock);
            this.wpfHangman = new WpfHangman(wpfReader, wpfWriter, new WordsFromStaticListRepository());
            this.wpfHangman.Start();
        }

        /// <summary>
        /// Click event handler for the start game button
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            this.RunGameEngine();
            this.StartButton.IsEnabled = false;
        }

        /// <summary>
        /// Click event handler for the letter buttons
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnLetterButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand((sender as Button).Content as string);
        }

        /// <summary>
        /// Click event handler for the restart button
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnRestartButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Restart.ToString());
        }

        /// <summary>
        /// Click event handler for the help button
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnHelpButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Help.ToString());
        }

        /// <summary>
        /// Click event handler for the rank list button
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnRankListButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Top.ToString());
        }

        /// <summary>
        /// Click event handler for the exit button
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.ResponseCommand(CommandType.Exit.ToString());
        }

        /// <summary>
        /// Response to some command
        /// </summary>
        /// <param name="command">The command</param>
        private void ResponseCommand(string command)
        {
            if (this.wpfHangman == null)
            {
                return;
            }

            this.CommandHiddenTextBlock.Text = command;
            this.wpfHangman.Response();
        }

        /// <summary>
        /// Keyboard input event handler
        /// </summary>
        /// <param name="sender">The control that the action event is for</param>
        /// <param name="e">The event</param>
        private void OnTextComposition(object sender, TextCompositionEventArgs e)
        {
            string key = e.Text;
            this.ResponseCommand(key);
        }
    }
}