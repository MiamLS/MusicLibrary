using MusicLibrary.Models;
using MusicLibrary.Repositories;

namespace xUnitMusicRecordsTest
{
    public class UnitTest1
    {

        private MusicRecordRepositoryList _musicRecordRepository;
        public UnitTest1()
        {
            _musicRecordRepository = new MusicRecordRepositoryList();
        }

        [Fact]
        public void TestGetAll_ReturnsAllRecords()
        {
            // Arrange
            var newRecord1 = new MusicRecord { Title = "As it Was", Artist = "Harry Styles", Duration = 167, PublicationYear = 2022 };
            var newRecord2 = new MusicRecord { Title = "Dancing Queen", Artist = "ABBA", Duration = 232, PublicationYear = 1976 };

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

        // Tester for searching by title
        [Fact]
        public void TestSearchByTitle()
        {
            // Arrange
            string title = "Hey Jude";

            // Act
            var result = _musicRecordRepository.GetAll(title: title);

            // Assert
            var record = Assert.Single(result);
            Assert.Equal("Hey Jude", record.Title);
        }


        // Tester for searching by artist
        [Fact]
        public void TestSearchByArtist()
        {
            // Arrange
            string artist = "Bee Gees";

            // Act
            var result = _musicRecordRepository.GetAll(artist: artist);

            // Assert
            var record = Assert.Single(result);
            Assert.Equal("Bee Gees", record.Artist);
        }

        // Tester for searching by title and artist
        [Fact]
        public void TestSearchByTitleAndArtist()
        {
            // Arrange
            string title = "Blinding Lights";
            string artist = "The Weeknd";

            // Act
            var result = _musicRecordRepository.GetAll(title, artist);

            // Assert
            var record = Assert.Single(result);
            Assert.Equal("Blinding Lights", record.Title);
            Assert.Equal("The Weeknd", record.Artist);
        }

        [Fact]
        public void TestAdd_AddsNewRecordSuccessfullyToList()
        {
            // Arrange
            var newRecord1 = new MusicRecord { Title = "Flowers", Artist = "Miley Cyrus", Duration = 200, PublicationYear = 2023 };

            // Act
            MusicRecord added = _musicRecordRepository.Add(newRecord1);

            // Assert
            Assert.NotNull(added);
            Assert.Equal("Flowers", added.Title);
            Assert.Equal("Miley Cyrus", added.Artist);
            Assert.Equal(200, added.Duration);
            Assert.Equal(2023, added.PublicationYear);
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

        // Tester for deleting an existing record
        [Fact]
        public void TestDelete_ExistingRecord()
        {
            // Arrange
            int id = 2;

            // Act
            MusicRecord? deletedRecord = _musicRecordRepository.Delete(id);

            // Assert
            Assert.NotNull(deletedRecord);
            Assert.Equal(id, deletedRecord.Id);
            Assert.Equal(3, _musicRecordRepository.GetAll().Count());
        }

        // Tester for deleting a non-existing record

        [Fact]
        public void TestDelete_NonExistingRecord()
        {
            // Arrange
            int id = 999;

            // Act
            MusicRecord? deletedRecord = _musicRecordRepository.Delete(id);

            // Assert
            Assert.Null(deletedRecord);
            Assert.Equal(4, _musicRecordRepository.GetAll().Count());
        }

        [Fact]
        public void TestUpdate_ExistingRecord()
        {
            // Arrange
            int id = 1;
            var updates = new MusicRecord { Title = "Thriller", Artist = "Michael Jackson", Duration = 359, PublicationYear = 1982 };
            // Act
            MusicRecord? updatedRecord = _musicRecordRepository.Update(id, updates);
            // Assert
            Assert.NotNull(updatedRecord);
            Assert.Equal(id, updatedRecord.Id);
            Assert.Equal("Thriller", updatedRecord.Title);
            Assert.Equal("Michael Jackson", updatedRecord.Artist);
            Assert.Equal(359, updatedRecord.Duration);
            Assert.Equal(1982, updatedRecord.PublicationYear);
        }

        [Fact]
        public void TestUpdate_NonExistingRecord()
        {
            // Arrange
            int id = 999;
            var updates = new MusicRecord { Title = "Thriller", Artist = "Michael Jackson", Duration = 359, PublicationYear = 1982 };
            // Act
            MusicRecord? updatedRecord = _musicRecordRepository.Update(id, updates);
            // Assert
            Assert.Null(updatedRecord);
        }
    }
}
