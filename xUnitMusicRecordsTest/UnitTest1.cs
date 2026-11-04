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

        [Fact]
        public void TestAdd_AddsNewRecordSuccessfullyToList()
        {
            // Arrange
            var newRecord1 = new MusicRecord { Title = "Test Song", Artist = "Test Artist", Duration = 300, PublicationYear = 2024 };

            // Act
            MusicRecord added = _musicRecordRepository.Add(newRecord1);

            // Assert
            Assert.NotNull(added);
            Assert.Equal("Test Song", added.Title);
            Assert.Equal("Test Artist", added.Artist);
            Assert.Equal(300, added.Duration);
            Assert.Equal(2024, added.PublicationYear);
            IEnumerable<MusicRecord> all = _musicRecordRepository.GetAll();
            int countAfterAdd = all.Count();
            Assert.Equal(5, countAfterAdd);
        }

        [Fact]
        public void TestAdd_AddsNullRecord_ReturnsNull()
        {
            // Act - Try to add a null record
            MusicRecord? added = _musicRecordRepository.Add(null);
            // Assert - Check that the returned value is null and the count of records remains unchanged
            Assert.Null(added);
            IEnumerable<MusicRecord> all = _musicRecordRepository.GetAll();
            int countAfterAdd = all.Count();
            Assert.Equal(4, countAfterAdd); // Assuming there were 4 records initially in the repository
        }
    }
}
