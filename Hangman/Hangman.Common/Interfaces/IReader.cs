// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReader.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a reader class interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Interfaces
{
    /// <summary>
    /// Interface that reader classes must implement
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Reads console input
        /// </summary>
        /// <returns>Returns console input as a string</returns>  
        string Read();
    }
}