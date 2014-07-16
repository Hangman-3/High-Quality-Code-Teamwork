namespace Hangman.Console
{
    using System;
    using System.Linq;

    public sealed class NinjectoThreadSafe
    {
        private static readonly object syncLock = new object();

        private static volatile NinjectoThreadSafe instance;// volatile modifier is used to show that the variable will be accessed by multiple threads concurrently.

        private NinjectoThreadSafe()
        {
        }

        public static NinjectoThreadSafe Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
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