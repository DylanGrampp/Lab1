using System;
using System.Runtime.CompilerServices;

namespace GramppLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = projectRootFolder + "/videogames.csv";
            string data = File.ReadAllText(filePath);
            
            List<VideoGame> videoGames = new List<VideoGame>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string row;
                reader.ReadLine();

                while (!reader.EndOfStream && (row = reader.ReadLine())!= null)
                {
                    string[] strings = row.Split(',');

                    string title = strings[0];
                    string platform = strings[1];
                    int year = int.Parse(strings[2]);
                    string genre = strings[3];
                    string publisher = strings[4];
                    double naSales = double.Parse(strings[5]);
                    double euSales = double.Parse(strings[6]);
                    double jpSales = double.Parse(strings[7]);
                    double otherSales = double.Parse(strings[8]);
                    double globalSales = double.Parse(strings[9]);

                    VideoGame game = new VideoGame(title, platform, year, genre, publisher, naSales, euSales, jpSales, otherSales, globalSales);
                    videoGames.Add(game);
                }

                videoGames.Sort();
                videoGames.ForEach(Console.WriteLine);

                Console.Write("\n----------------------------------------");
                Console.Write("\nEnter the publisher to sort by: ");
                string userInput = Console.ReadLine().Trim().ToLower();
                VideoGame.PublisherGames(videoGames, userInput);

                Console.Write("\n----------------------------------------");
                Console.Write("\nEnter the genre to sort by: ");
                string userInput2 = Console.ReadLine().Trim().ToLower();
                VideoGame.GenreData(videoGames, userInput2);
            }
        }
    }
}