// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RandomNumberProvider.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a random number provider singleton
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Utility
{
    using System;
    using System.Linq;

    /// <summary>
    /// Provides a single instance of the <see cref="Random" /> class
    /// </summary>
    public sealed class RandomNumberProvider
    {
        /// <summary>
        /// A single instance of the <see cref="Random" /> class
        /// </summary>
        private static readonly Random Instance = new Random();

        /// <summary>
        /// Gets one and the same instance of the 'Random' class
        /// </summary>
        public static Random Generator
        {
            get { return Instance; }
        }
    }
}