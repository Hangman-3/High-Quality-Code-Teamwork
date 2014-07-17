namespace Hangman.Common.Interfaces
{
    using System.Text;

    public interface IWord
    {
        StringBuilder Original { get; set; }

        StringBuilder Secret { get; set; }
    }
}