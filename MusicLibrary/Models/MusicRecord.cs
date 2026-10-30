namespace MusicLibrary.Models
{
    public class MusicRecord
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Artist { get; set; }

        public int Duration { get; set; } 
        public int PublicationYear { get; set; }
        override public string ToString()
        {
            return $"{Title} by {Artist}, Duration: {Duration} seconds, Published in {PublicationYear}";
        }
    }
}
