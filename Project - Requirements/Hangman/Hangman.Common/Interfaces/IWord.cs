using System.Text;
namespace Hangman.Common.Interfaces
{
    public interface IWord
    {
        StringBuilder Original { get; set; }

        StringBuilder Secret { get; set; }

        bool IsGuessed();
    }
}