using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data;
using MusicLibrary.Models;

namespace MusicLibrary.Repositories
{
    public class MusicRecordRepository
    {
        private readonly MusicDBContext _context;

        public MusicRecordRepository(MusicDBContext context)
        {
            _context = context;
        }

        // Hent alle (med understøttelse af filtrering direkte i databasen)
        public IEnumerable<MusicRecord> GetAll(string? title = null, string? artist = null)
        {
            return _context.MusicRecords
        .Where(m => (string.IsNullOrWhiteSpace(title) || m.Title.Contains(title)) &&
                    (string.IsNullOrWhiteSpace(artist) || m.Artist.Contains(artist)))
        .ToList();
        }

        // Hent efter ID (bruger .Find() ligesom i kattedatabasen)
        public MusicRecord? GetById(int id)
        {
            return _context.MusicRecords.Find(id);
        }

        // Tilføj en ny musikalsk optagelse
        public MusicRecord? Add(MusicRecord musicRec)
        {
            if (musicRec == null)
            {
                throw new ArgumentNullException(nameof(musicRec));
            }

            _context.MusicRecords.Add(musicRec);
            _context.SaveChanges();
            return musicRec;
        }

        // Slet en optagelse baseret på ID
        public MusicRecord? Delete(int id)
        {
            var record = GetById(id);
            if (record != null)
            {
                _context.MusicRecords.Remove(record);
                _context.SaveChanges();
                return record;
            }
            return null;
        }

        // Opdater en eksisterende optagelse
        public MusicRecord? Update(int id, MusicRecord updates)
        {
            var existingRecord = GetById(id);
            if (existingRecord == null) return null;

            existingRecord.Title = updates.Title;
            existingRecord.Artist = updates.Artist;
            existingRecord.Duration = updates.Duration;
            existingRecord.PublicationYear = updates.PublicationYear;

            _context.SaveChanges();
            return existingRecord;
        }
    }
}