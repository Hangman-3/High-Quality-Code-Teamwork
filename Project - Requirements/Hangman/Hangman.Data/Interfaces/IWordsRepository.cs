namespace Hangman.Data.Interfaces 
{
    using System.Collections.Generic;

    public interface IWordsRepository
    {
        IReadOnlyCollection<string> EnglishWords { get; }

        IReadOnlyCollection<string> BulgarianWords { get; }
    }
}