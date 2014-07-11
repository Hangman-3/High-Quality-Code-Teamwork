namespace Hangman.Common.Interfaces 
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public interface IWordsRepository
    {
        IReadOnlyCollection<string> Words { get; }
    }
}