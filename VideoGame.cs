using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GramppLab1
{
    internal class VideoGame : IComparable<VideoGame>
    {
        public string Title { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NaSales { get; set; }
        public double EuSales { get; set; }
        public double JpSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }

        public VideoGame(string title, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            Title = title;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NaSales = naSales;
            EuSales = euSales;
            JpSales = jpSales;
            OtherSales = otherSales;
            GlobalSales = globalSales;
        }

        public override string ToString()
        {
            return Title + "," + Platform + "," + Year + "," + Genre + "," + Publisher + "," + NaSales + "," + EuSales + "," + JpSales + "," + OtherSales + "," + GlobalSales;
        }

        public int CompareTo(VideoGame other)
        {
            return Title.CompareTo(other.Title);
        }

        public static void PublisherGames(List<VideoGame> videoGames, string publisher)
        {
            var totalGames = videoGames.Count;

            List<VideoGame> publisherGames = videoGames.Where(p => p.Publisher.ToLower().Equals(publisher.ToLower())).ToList<VideoGame>();

            float totalPublishers = publisherGames.Count;

            var pct = totalPublishers / totalGames * 100;

            publisherGames.ForEach(Console.WriteLine);

            Console.WriteLine($"\nThere are {totalPublishers} {publisher} games out of {totalGames} which is {pct:0.##}%");
        }

        public static void GenreData(List<VideoGame> videoGames, string genre)
        {
            var totalGenres = videoGames.Count;

            List<VideoGame> GenreData = videoGames.Where(p => p.Genre.ToLower().Equals(genre.ToLower())).ToList<VideoGame>();

            float numGenres = GenreData.Count;

            var pct = numGenres / totalGenres * 100;

            GenreData.ForEach(Console.WriteLine);

            Console.WriteLine($"\nThere are {numGenres} {genre} games out of {totalGenres} which is {pct:0.##}%");
        }
    }
}
