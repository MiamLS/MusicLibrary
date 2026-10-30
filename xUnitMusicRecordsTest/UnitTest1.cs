using MusicLibrary.Models;
using MusicLibrary.Repositories;

namespace xUnitMusicRecordsTest
{
    public class UnitTest1
    {

        private MusicRecordRepository _musicRecordRepository;
        public UnitTest1()
        {
            _musicRecordRepository = new MusicRecordRepository();
        }

        [Fact]
        public void TestGetAll_ReturnsAllRecords()
        {
            // Arrange
            var newRecord1 = new MusicRecord { Title = "Test Song", Artist = "Test Artist", Duration = 300, PublicationYear = 2024 };
            var newRecord2 = new MusicRecord { Title = "Another Test Song", Artist = "Another Test Artist", Duration = 250, PublicationYear = 2023 };

            // Act
            _musicRecordRepository.Add(newRecord1);
            _musicRecordRepository.Add(newRecord2);
            IEnumerable<MusicRecord> allRecords = _musicRecordRepository.GetAll();

            // Assert
            Assert.NotNull(allRecords);
            Assert.Equal(6, allRecords.Count()); // Assuming there were 4 records initially in the repository

        }
        [Fact]
        public void TestGetall_ReturnsAll_existingRecords()
        {
            // Act
            IEnumerable<MusicRecord> allRecords = _musicRecordRepository.GetAll();
            // Assert
            Assert.NotNull(allRecords);
            Assert.Equal(4, allRecords.Count()); // Assuming there are 4 records initially in the repository
        }
    }
}
