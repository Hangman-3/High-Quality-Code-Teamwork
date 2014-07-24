namespace Hangman.Common.Interfaces
{
    using Hangman.Common.Enums;
 
    public interface ICommand
    {
        string Arguments { get; set; }

        CommandType Type { get; set; }
    }
}