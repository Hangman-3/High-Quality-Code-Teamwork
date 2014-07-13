namespace Hangman.Common.Interfaces
{
    public interface IWord
    {
        char[] Original { get; set; }

        char[] Secret { get; set; }

        bool IsGuessed();
    }
}