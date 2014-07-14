using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Console
{
    public sealed class NinjectoThreadSafe
    {
        private static volatile NinjectoThreadSafe instance; // volatile modifier is used to show that the variable will be accessed by multiple threads concurrently.

        private static object syncLock = new object();

        private NinjectoThreadSafe() { }

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
