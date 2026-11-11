using MusicLibrary.Data;

namespace MusicLibrary.Repositories
{
    public class MusicRecordDataBaseRepository : MusicRecordRepository
    {
        public MusicRecordDataBaseRepository(MusicDBContext context) : base(context)
        {
        }
    }
}
