using Microsoft.EntityFrameworkCore;
using MusicLibrary.Models;

namespace MusicLibrary.Data
{
    public class MusicDBContext : DbContext
    {
        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base(options)
        {
        } 
        public DbSet<MusicRecord> MusicRecords { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
    
}
