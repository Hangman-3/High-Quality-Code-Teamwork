namespace Hangman.Models.Interfaces 
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IWordsRepository
    {
        IReadOnlyCollection<string> EnglishWords { get; }

        IReadOnlyCollection<string> BulgarianWords { get; }
    }
}