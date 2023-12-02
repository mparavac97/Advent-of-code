using AOC.Helpers.Contracts;
using AOC.Helpers.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day2
{
    public class GameTaskRunner : ITaskRunner
    {
        private readonly int _red = 12;
        private readonly int _green = 13;
        private readonly int _blue = 14;

        public IFileReader FileReader { get; set; }

        public GameTaskRunner(IFileReader fileReader)
        {
            FileReader = fileReader;
        }

        public void Run()
        {
            var games = FileReader.ReadDocumentAsList();

            int sumOfViableGameIds = 0;
            bool isViable = false;

            foreach (var game in games) //all the games
            {
                var gameInfo = game.Split(':'); //split string to get Id of the game

                var gameObjectId = Int32.Parse(gameInfo[0].Replace("Game ", ""));

                var gameResults = gameInfo[1].Split(";");

                foreach (var gameResult in gameResults) //all the rounds in a game
                {
                    var round = gameResult.Split(",");

                    foreach (var roundResult in round) //all results in a round
                    {
                        if (roundResult.Contains("red"))
                        {
                            var numberOfReds = Int32.Parse(roundResult.Replace(" red", ""));
                            if (numberOfReds > _red)
                            {
                                isViable = false;
                                break;
                            }
                            else
                                isViable = true;
                        }
                        else if (roundResult.Contains("blue"))
                        {
                            var numberOfBlues = Int32.Parse(roundResult.Replace(" blue", ""));
                            if (numberOfBlues > _blue)
                            {
                                isViable = false;
                                break;
                            }
                            else
                                isViable = true;
                        }
                        else if (roundResult.Contains("green"))
                        {
                            var numberOfGreens = Int32.Parse(roundResult.Replace(" green", ""));
                            if (numberOfGreens > _green)
                            {
                                isViable = false;
                                break;
                            }
                            else
                                isViable = true;
                        }
                    }
                    if (!isViable)
                        break;
                }

                Console.WriteLine($"{gameObjectId}: {isViable.ToString()}");

                if (isViable)
                {
                    sumOfViableGameIds += gameObjectId;
                }
            }

            Console.WriteLine(sumOfViableGameIds.ToString());
        }

        //Example: "Game 2: 6 red, 6 blue, 2 green; 1 blue, 1 red; 6 green, 1 red, 10 blue"
    }
}