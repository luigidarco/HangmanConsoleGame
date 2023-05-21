#region Part of gameboard
// {
//     // Console.WriteLine("Hint: " + game.hint);
//     // Console.WriteLine("Hidden Phrase: " + game.hiddenPhrase);
//     Hang p1 = new Hang();
//     while (game.attempts < 6)
//     {
//         Console.Clear();
//         p1.Draw();
//         Console.WriteLine(game.hiddenPhrase);
//         Console.WriteLine("Hint: " + game.hint);
//         Console.WriteLine("Guessed Letters: " + game.GetGuessedLettersString());
//         Console.Write("Enter a letter: ");
//         char letter = Convert.ToChar(Console.ReadLine());

//         // In case of input a repeated letter.
//         if (game.guessedLetters.Contains(letter))
//         {
//             Console.WriteLine("You already guessed this letter!");
//             continue;
//         }

//         // If not, add to the guessed letters list.

//         if (game.secretPhrase.Contains(letter))
//         {
//             Console.WriteLine("You guessed a letter!");
//             game.guessedLetters.Add(letter);
//             game.updateHiddenPhrase(letter);

//         }
//         else
//         {
//             game.attempts++;
//             p1.addHang(game.attempts);
//             Console.WriteLine($"You missed! Attemps left: {(6 - game.attempts)}");
//             Console.ReadLine();


//             //Console.WriteLine(HangDraw());
//         }

//         if (game.hiddenPhrase.SequenceEqual(game.secretPhrase))
//         {
//             Console.Clear();
//             Console.WriteLine("You won!");
//             Console.ReadKey();
//         }
//     }

//     if (game.attempts == 6)
//     {
//         Console.Clear();
//         Console.Beep();
//         p1.Draw();
//         Console.WriteLine("\n > You lost! <");
//         Console.ReadKey();
//         Menu();
//     }

// }
#endregion
#region Predefined Game Script


// void setupPredefinedGame()
// {
//     Console.Write("Enter the phrase: ");
//     string phrase = Console.ReadLine();

//     Console.Write("Enter the hint: ");
//     string hint = Console.ReadLine();

//     Console.Write("How many players? ");
//     int numPlayers = Convert.ToInt32(Console.ReadLine());

//     Phrase customPhrase = new Phrase(phrase, hint, "General");
//     PhraseRepository.add(customPhrase);

//     Game game = new Game(PhraseRepository.getRandomPhrase());
//     startGame(game);

//     //PhraseRepository.add(phrase);
// }
#endregion