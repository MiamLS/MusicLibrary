using MusicLibrary.Models;

namespace MusicLibrary.Repositories
{
    public class MusicRecordRepositoryList
    {
        
            private readonly List<MusicRecord> _musicRecords = new();

            private int _nextId = 1;

            public MusicRecordRepositoryList()
            {
                Add(new MusicRecord { Title = "Song 1", Artist = "Artist 1", Duration = 180, PublicationYear = 2020 });
                Add(new MusicRecord { Title = "Song 2", Artist = "Artist 2", Duration = 200, PublicationYear = 2021 });
                Add(new MusicRecord { Title = "Song 3", Artist = "Artist 3", Duration = 240, PublicationYear = 2022 });
                Add(new MusicRecord { Title = "Song 4", Artist = "Artist 4", Duration = 150, PublicationYear = 2023 });
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
