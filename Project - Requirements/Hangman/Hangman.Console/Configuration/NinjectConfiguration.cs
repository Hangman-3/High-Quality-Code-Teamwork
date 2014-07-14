namespace Hangman.Models
{
    using Hangman.Common.Interfaces;
    using Hangman.Console.IOEngines;
    using Hangman.Data;
    using Ninject.Modules;
    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IPlayer>().To<Player>();
            this.Bind<IScoreboard>().To<Scoreboard>();
            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IWordsRepository>().To<WordsRepository>();
            this.Bind<IWord>().To<Word>();
        }
    }
}
