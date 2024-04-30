namespace GuessTheWord
{
    using System;

    class Program
    {
        static void Main()
        {
            GameFieldOfMiracles();
        }
        static void GameFieldOfMiracles()
        {
            try
            {
                string[] wordsToGuess = { "велосипед", "телефон", "книга", "сон", "сонце", "ранок", "програмування", "дощ", "навчання", "навушники" };
                Random random = new Random();

                string playAgain;

                do

                {
                    string wordToGuess = wordsToGuess[random.Next(wordsToGuess.Length)];
                    int attempts = wordToGuess.Length;

                    Console.Write("Давайте пограємо в гру в слова? Введiть `y`, якщо хочете грати, або `n`, якщо не хочете: ");
                    playAgain = Console.ReadLine().ToLower();

                    if (playAgain == "y")
                    {
                        Console.WriteLine($"Відгадайте моє таємне слово. Воно мiстить {wordToGuess.Length} букв.");
                        Console.WriteLine("Вгадувати можна по однiй буквi за раз.");
                        Console.WriteLine($"Вам дано {attempts} неправильних здогадок.");
                        Console.WriteLine("Нехай щастить!\n");

                        char[] guessedWord = new char[wordToGuess.Length];
                        for (int i = 0; i < guessedWord.Length; i++)
                        {
                            guessedWord[i] = '_';
                        }

                        while (attempts > 0)
                        {
                            Console.WriteLine($"Ваше слово: {string.Join(" ", guessedWord)}");

                            Console.Write($"Введiть наступну букву: ");
                            char guess = Console.ReadLine().ToLower()[0];

                            bool found = false;
                            for (int i = 0; i < wordToGuess.Length; i++)
                            {
                                if (wordToGuess[i] == guess)
                                {
                                    guessedWord[i] = guess;
                                    found = true;
                                }
                            }
                            if (guessedWord.SequenceEqual(wordToGuess))
                            {
                                Console.WriteLine($"Ви виграли! Загадане слово було \"{wordToGuess}\".");
                                break;
                            }
                            if (!found)
                            {
                                attempts--;
                                Console.WriteLine($"Буква \"{guess}\" вiдсутня у словi. Залишилося спроб: {attempts}");
                            }
                            if (attempts == 0)
                            {
                                Console.WriteLine($"Ви програли. Загадане слово було \"{wordToGuess}\".");
                            }

                        }
                    }
                    else if (playAgain == "n")
                    {
                        Console.WriteLine("До зустрічi!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Будь ласка, введiть `y`, якщо хочете грати, або `n`, якщо не хочете.");
                        return;
                    }
                    Console.WriteLine("Натисніть будь-яку клавішу, щоб продовжити...");
                    Console.ReadKey();
                    Console.Clear();
                }
                while (playAgain == "y");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

}
