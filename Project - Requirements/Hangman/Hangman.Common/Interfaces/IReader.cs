// <copyright file="IReader.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
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