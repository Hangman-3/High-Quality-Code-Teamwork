// <copyright file="NinjectoThreadSafe.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Console
{
    using System;
    using System.Linq;

    /// <summary>
    /// Thread safe class
    /// </summary>
    public sealed class NinjectoThreadSafe
    {
        /// <summary>
        /// Serves as a lock object
        /// </summary>
        private static readonly object SyncLock = new object();

        /// <summary>
        /// Hold the only instance of this class
        /// </summary>
        private static volatile NinjectoThreadSafe instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="NinjectoThreadSafe" /> class from being created.
        /// </summary>
        private NinjectoThreadSafe()
        {
        }

        /// <summary>
        /// Gets the the instance
        /// </summary>
        public static NinjectoThreadSafe Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncLock)
                    {
                        if (instance == null)
                        {
                            instance = new NinjectoThreadSafe();
                        }
                    }
                }

                return instance;
            }
        }
    }
}