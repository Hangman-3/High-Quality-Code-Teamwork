namespace Hangman.Common.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IWord
    {
        char[] Original { get; set; }
        char[] Secret { get; set; }
        bool IsGuessed();
    }
}