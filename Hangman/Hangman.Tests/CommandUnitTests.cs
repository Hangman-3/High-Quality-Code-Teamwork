using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman.Common.Enums;
using Hangman.Models;

namespace Hangman.Tests
{
    [TestClass]
    public class CommandUnitTests
    {
        [TestMethod]
        public void TestTopCommandInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("top");
            Assert.AreEqual(CommandType.Top, command.Type);
        }

        [TestMethod]
        public void TestRestartCommandInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("restart");
            Assert.AreEqual(CommandType.Restart, command.Type);
        }

        [TestMethod]
        public void TestHelpCommandInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("help");
            Assert.AreEqual(CommandType.Help, command.Type);
        }

        [TestMethod]
        public void TestExitCommandInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("exit");
            Assert.AreEqual(CommandType.Exit, command.Type);
        }

        [TestMethod]
        public void TestCommandWithUpperCaseLettresInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("reStaRt");
            Assert.AreEqual(CommandType.Restart, command.Type);
        }

        [TestMethod]
        public void TestWrongCommandInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("wrongCommand");
            Assert.AreEqual(CommandType.Default, command.Type);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullCommandInCommandFactory()
        {
            var command = CommandFactory.ParseCommand(null);
        }

        [TestMethod]
        public void TestCommandArgumentsInCommandFactory()
        {
            var command = CommandFactory.ParseCommand("command");
            Assert.AreEqual("command", command.Arguments);
        }
    }
}
