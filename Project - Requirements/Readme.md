#High-Quality Code Construction – “Hangman” Game

Your task is to write an interactive **console-based implementation of the game “Hangman”** in which the player tries to guess a secret word by guessing its letters sequentially. At the start of the game the computer generates a **random secret word** from a predefined set of 10 words: _computer, programmer, software, debugger, compiler, developer, algorithm, array, method and variable_. The generated word is initially shown as **underscores** (e.g. if the secret letter is developer, it is shown as _ _ _ _ _ _ _ _ _). At each step the player enters a **guess letter** to the computer and the computer **reveals all occurrences of this letter** in the secret word while the other letters remain shown as underscores. For example, if the secret word is developer and the guess letter is e, after revealing this letter, the result will be as follows:  _ e _ e _ _ _ e _. In case of incorrect letter guess, appropriate message is shown. If the player guesses all the letters in the secret word, the **game finishes** and the total number of mistakes (incorrect letter guesses) is shown. When the game is finished, a new game automatically starts.

If the player is bored, he or she can enter the command **'help'** instead of a guess letter and as a response the computer should reveal the first (from left to right) hidden letter.

The player can request starting a new game by entering the command **'restart'**.

Your program should implement a **local top scoreboard** which keeps the best results and the names of their authors. Initially, at the program start, the scoreboard is empty. It keeps the **top 5 results** sorted in ascending order by the number of mistakes. When a game is finished by revealing all hidden letters and without using the **'help'** command, the player’s result can enter in the top scoreboard if his or her number of mistakes is less than some of the other achievements staying in the top scoreboard. When the player’s result enters the scoreboard, the player should enter his or her name or nickname.

The player can request printing the top scoreboard during the game by entering the command **'top'**.

The player can request stopping the game and exiting from the program the command **'exit'**.

##Example Game Session
The player’s input is shown in italic:
```
Welcome to “Hangman” game. Please try to guess my secret word.
Use 'top' to view the top scoreboard, 'restart' to start a new game,'help' to cheat and 'exit' to quit the game.
The secret word is: _ _ _ _ _ _ _ _ _
Enter your guess: e
Good job! You revealed 3 letters.
The secret word is: _ e _ e _ _ _ e _
Enter your guess: a
Sorry! There are no unrevealed letters “a”.
The secret word is: _ e _ e _ _ _ e _
Enter your guess: r
Good job! You revealed 1 letter.
The secret word is: _ e _ e _ _ _ e r
Enter your guess: d
Good job! You revealed 1 letter.
The secret word is: d e _ e _ _ _ e r
Enter your guess: v
Good job! You revealed 1 letter.
The secret word is: d e v e _ _ _ e r
Enter your guess: l
Good job! You revealed 1 letter.
The secret word is: d e v e l _ _ e r
Enter your guess: o
Good job! You revealed 1 letter.
The secret word is: d e v e l o _ e r
Enter your guess: p
You won with 1 mistakes.
The secret word is: d e v e l o p e r
Please enter your name for the top scoreboard: Bay Ivan
Scoreboard:
1. Bay Ivan --> 1 mistake

Welcome to “Hangman” game. Please try to guess my secret word.
Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.
The secret word is: _ _ _ _ _ _ _ _
Enter your guess: e
Good job! You revealed 1 letter.
The secret word is: _ _ _ _ _ _ e _
Enter your guess: a
Sorry! There are no unrevealed letters “a”.
The secret word is: _ _ _ _ _ _ e _
Enter your guess: r
Good job! You revealed 1 letter.
The secret word is: _ _ _ _ _ _ e r
Enter your guess or command: restart

Welcome to “Hangman” game. Please try to guess my secret word.
Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.
The secret word is: _ _ _ _ _
Enter your guess: a
Good job! You revealed 1 letter.
The secret word is: a _ _ a _
Enter your guess: help
OK, I reveal for you the next letter 'r'.
The secret word is: a r r a _
Enter your guess: y
You won with 0 mistakes but you have cheated. You are not allowed to enter into the scoreboard.
The secret word is: a r r a y

Welcome to “Hangman” game. Please try to guess my secret word.
Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.
The secret word is: _ _ _ _ _ _
Enter your guess: o
Good job! You revealed 1 letter.
The secret word is: _ _ _ _ o _
Enter your guess or command: win
Incorrect guess or command!
Enter your guess or command: top
Scoreboard:
1. Bay Ivan --> 1 mistake
Enter your guess or command: exit
Good bye!
Some players could try to cheat by entering illegal moves, so be cautious and prevent illegal input.
```