using MusicLibrary.Models;

namespace MusicLibrary.Repositories
{
    public class MusicRecordRepositoryList
    {
        
            private readonly List<MusicRecord> _musicRecords = new();

            private int _nextId = 1;

            public MusicRecordRepositoryList()
            {
                Add(new MusicRecord { Title = "Hey Jude", Artist = "The Beatles", Duration = 432, PublicationYear = 1968 });
                Add(new MusicRecord { Title = "Hotel California", Artist = "Eagles", Duration = 390, PublicationYear = 1977 });
                Add(new MusicRecord { Title = "Staying Alive", Artist = "Bee Gees", Duration = 285, PublicationYear = 1977 });
                Add(new MusicRecord { Title = "Blinding Lights", Artist = "The Weeknd", Duration = 202, PublicationYear = 2019 });
            }

            // GET: api/<MusicRecordController>
            public IEnumerable<MusicRecord> GetAll(string? title = null, string? artist = null)
            {
                IEnumerable<MusicRecord> result = _musicRecords;

                if (!string.IsNullOrWhiteSpace(title))
                {
                    result = result.Where(m =>
                        m.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
                }

                if (!string.IsNullOrWhiteSpace(artist))
                {
                    result = result.Where(m =>
                        m.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase));
                }

                return result;
            }


            //Add method to add a new music record to the repository
            public MusicRecord? Add(MusicRecord musicRec)
            {
                if (musicRec == null)
                {
                    return null;
                }
                musicRec.Id = _nextId++;
                _musicRecords.Add(musicRec);
                return musicRec;
            }

            // Delete method to remove a music record from the repository by its ID
            public MusicRecord? Delete(int id)
            {
                MusicRecord? record = _musicRecords.FirstOrDefault(m => m.Id == id);

                if (record == null)
                {
                    return null;
                }

                _musicRecords.Remove(record);

                return record;
            }

            public MusicRecord? Update(int id, MusicRecord updates)
            {
                MusicRecord? existingRecord = _musicRecords.FirstOrDefault(m => m.Id == id);
                if (existingRecord == null) return null;

                existingRecord.Title = updates.Title;
                existingRecord.Artist = updates.Artist; 
                existingRecord.Duration = updates.Duration;
                existingRecord.PublicationYear = updates.PublicationYear;

                return existingRecord;
            }

        }
    
}
