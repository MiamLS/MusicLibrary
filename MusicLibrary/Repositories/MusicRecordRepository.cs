using MusicLibrary.Models;

namespace MusicLibrary.Repositories
{
    public class MusicRecordRepository
    {
        private readonly List<MusicRecord> _musicRecords;

        private int _nextId;

        public MusicRecordRepository()
        {
            Add(new MusicRecord { Title = "Song 1", Artist = "Artist 1", Duration = 180, PublicationYear = 2020 });
            Add(new MusicRecord { Title = "Song 2", Artist = "Artist 2", Duration = 200, PublicationYear = 2021 });
            Add(new MusicRecord { Title = "Song 3", Artist = "Artist 3", Duration = 240, PublicationYear = 2022 });
            Add(new MusicRecord { Title = "Song 4", Artist = "Artist 4", Duration = 150, PublicationYear = 2023 });
        }
        
        public List<MusicRecord> GetAll()
        {
            return _musicRecords;
        }

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
    }
}
