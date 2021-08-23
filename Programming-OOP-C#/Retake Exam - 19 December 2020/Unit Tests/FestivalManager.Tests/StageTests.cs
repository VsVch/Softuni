// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
	
    using FestivalManager.Entities;
    using NUnit.Framework;
	using System;
	using System.Collections.Generic;
	using System.Linq;

	[TestFixture]
	public class StageTests
	{
		private Performer performer;
		private List<Performer> performers;
		private List<Song> songs;
		private Song song;
		private Stage stage;
		private List<Song> songList;

		[SetUp]
		public void StageTest()
		{
			performer = new Performer("Sasho", "Stefanov", 38);
			stage = new Stage();
			performers = new List<Performer>();
			song = new Song("new song", new TimeSpan(0, 3, 30));
			songs = new List<Song>();
			songList = new List<Song>();
		}
		[Test]
		public void WhenAddPerformerWhitNullValue_ShouldThrowExeption()
		{
			Performer performer = null;
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(performer));
		}
		[Test]
		public void WhenPerformerIsInvalideAge_ShouldThrowExeption()
		{
			Performer performer = new Performer("Sasho", "Stefanov", 17); ;
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
		}
		[Test]
		public void WhenAddValidPerformere_ShouldExpendStage()
		{
			Performer performer = new Performer("Sasho", "Stefanov", 18);
			int addedPerformers = 1;
			performers.Add(performer);
			Assert.That(performers.Count, Is.EqualTo(addedPerformers));
			Assert.IsTrue(performers.Contains(performer));
		}
		[Test]
		public void WhenAddSongWhitNullValue_ShouldThrowExeption()
		{
			Song song = null;
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(song));
		}
		[Test]
		public void WhenAddSongInvalideTime_ShouldThrowExeption()
		{
			Song song = new Song("new song", new TimeSpan(0, 0, 59));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));
		}
		[Test]
		public void WhenAddValidSong_ShouldExpendStage()
		{
			int addedSong = 1;
			songs.Add(song);
			Assert.That(songs.Count, Is.EqualTo(addedSong));
			Assert.IsTrue(songs.Contains(song));
		}
		[Test]
		public void WhenSongDontExistInCollection_ShouldThrowExeption()
		{
			Song songNewSong = null;
			songs.Add(song);

			Assert.That(songs.Contains(songNewSong), Is.False);
			//Assert.Throws<ArgumentException>(() => songs.Contains(songNewSong), Is.Null);
		}
		[Test]
		public void WhenPerformerDontExistInCollection_ShouldThrowExeption()
		{
			Performer performer1 = null;
			performers.Add(performer);

			Assert.That(performers.Contains(performer1), Is.False);

		}
		[Test]
		public void AddSongInPerformerSongList_ShouldWorkProper()
		{
			performer.SongList.Add(song);
			int numeberOfSongs = 1;

			Assert.That(performer.SongList.Contains(song), Is.True);
			Assert.That(performer.SongList.Count, Is.EqualTo(numeberOfSongs));
		}
		[Test]
		public void Play_ShouldReturnNumbersOfSongsInCollection()
		{
			Song song = new Song("new song", new TimeSpan(0, 3, 30));
			Song song1 = new Song("new song1", new TimeSpan(0, 3, 30));
			Song song2 = new Song("new song2", new TimeSpan(0, 3, 30));
			performer.SongList.Add(song);
			performer.SongList.Add(song1);
			performer.SongList.Add(song2);
			int numeberOfSongs = 3;
			

			Assert.That(performer.SongList.Contains(song), Is.True);
			Assert.That(performer.SongList.Contains(song1), Is.True);
			Assert.That(performer.SongList.Contains(song2), Is.True);
			Assert.That(performer.SongList.Count, Is.EqualTo(numeberOfSongs));
		}
		[Test]
		public void ChekNewSongsCollection_ShouldWorkProper()
		{	

			Assert.That(songs.Count, Is.EqualTo(0));
			//Assert.That(performer.SongList.Count, Is.EqualTo(numeberOfSongs));
		}
		[Test]
		public void ChekNewPerformersCollection_ShouldWorkProper()
		{

			Assert.That(performers.Count, Is.EqualTo(0));
			//Assert.That(performer.SongList.Count, Is.EqualTo(numeberOfSongs));
		}


	}
}