using assignment3;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    void Start()
    {
        const string filename = "top2000-2022.csv";
        try
        {
            List<Song> songs = ReadSongs(filename);
            //DisplaySongs(songs, 95, 100);

            int minValue = 50;
            Dictionary<int, List<Song>> yearSongs = GetYearSongs(songs);
            DisplayYearSongs(yearSongs, minValue);
        }
        catch (Exception)
        {
            throw new Exception("File does not exist.");
        }
    }       

    // Read all songs within the file
    List<Song> ReadSongs(string filename) 
    {
        List<Song> results = new List<Song>();
        StreamReader filereader = new StreamReader(filename);
        while (!filereader.EndOfStream)
        {
            string line = filereader.ReadLine();
            Song song = new Song();
            string[] lineArray = line.Split(';');
            song.Ranking = int.Parse(lineArray[0]);
            song.Title = lineArray[1];
            song.Artist = lineArray[2];
            song.Year = int.Parse(lineArray[3]);
            results.Add(song);
        }
        return results;
    }

    void DisplaySongs(List<Song> songs, int startRanking, int endRanking) 
    {
        foreach (Song s in songs)
        {
            if (s.Ranking >= startRanking && s.Ranking <= endRanking)
                Console.WriteLine($"{s.Ranking}. {s.Artist} - {s.Title}");
        }
    }

    // Generate a dictionary foreach year in the list, and add the songs
    Dictionary<int, List<Song>> GetYearSongs (List<Song> songs)
    {
        Dictionary<int, List<Song>> yearSongs = new Dictionary<int, List<Song>>();

        foreach (Song song in songs)
        {
            if (!yearSongs.ContainsKey(song.Year))
                yearSongs[song.Year] = new List<Song>();

            yearSongs[song.Year].Add(song);
        }
        return yearSongs;
    }

    void DisplayYearSongs(Dictionary<int, List<Song>> yearSongs, int minimum) 
    {
        Console.WriteLine($"year songs (with at least {minimum} songs)");

        // Loop for each year in the dictionary 
        foreach (int year in yearSongs.Keys)
        {
            if (yearSongs[year].Count >= minimum)
                Console.WriteLine($"{year}: {yearSongs[year].Count}");
        }
    }
}