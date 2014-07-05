namespace Hangman.Data.Utility
{
    using System;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public static class Utility
    {
        //public static int GetNumberOfGuessedLetters(this string word, char letterForGuess)
        //{
        //    return word.ToCharArray().GetNumberOfGuessedLetters(letterForGuess);
        //}

        //public static int GetNumberOfGuessedLetters(this StringBuilder word, char letterForGuess)
        //{
        //    return word.ToString().ToCharArray().GetNumberOfGuessedLetters(letterForGuess);
        //}

    //    public static int GetNumberOfGuessedLetters(this char[] word, char letterForGuess)
    //    {
    //        if (word == null || char.IsWhiteSpace(letterForGuess))
    //        {
    //            throw new ArgumentNullException();
    //        }

    //        int guessedLetters = 0;

    //        for (int i = 0; i < word.Length; i++)
    //        {
    //            if (word[i] == letterForGuess)
    //            {
    //                guessedLetters++;
    //            }
    //        }

    //        return guessedLetters;
    //    }

    //    public static void EraseGuessedLetters(this char[] word, char guessedLetter, char eraseSymbol)
    //    {
    //        if (word == null || char.IsWhiteSpace(guessedLetter))
    //        {
    //            throw new ArgumentNullException();
    //        }

    //        for (int i = 0; i < word.Length; i++)
    //        {
    //            if (word[i] == guessedLetter)
    //            {
    //                word[i] = eraseSymbol;
    //            }
    //        }
    //    }
    }
}