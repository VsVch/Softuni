namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter 
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone 
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong 
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var writers = new List<Writer>();

            var writersDto = JsonConvert.DeserializeObject<ICollection<WriterImportModel>>(jsonString);

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                writers.Add(writer);
                sb.AppendLine(string.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.Writers.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var producers = new List<Producer>();

            var producersDto = JsonConvert.DeserializeObject<ICollection<ProducerAlbumInputModel>>(jsonString);

            foreach (var producerDto in producersDto)
            {
                if (!IsValid(producerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    PhoneNumber = producerDto.PhoneNumber,
                    Pseudonym = producerDto.Pseudonym,
                };

                var albums = new List<Album>();

                foreach (var albumDto in producerDto.Albums)
                {
                    if (!IsValid(albumDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isValidDate = DateTime.TryParseExact(albumDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate);

                    if (isValidDate == false)
                    {
                        sb.AppendLine(ErrorMessage);
                        break;
                    }
                    var album = new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = releaseDate
                    };

                    albums.Add(album);
                }

                producer.Albums = albums;
                producers.Add(producer);

                var producerPhonNumber = string.Empty;

                if (producer.PhoneNumber == null)
                {
                    producerPhonNumber = string.Format
                    (SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count());
                }
                else
                {
                    producerPhonNumber = string.Format
                   (SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count());
                }            
                              
                sb.AppendLine(producerPhonNumber);               
            }

            context.Producers.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var songs = new List<Song>();

            var songsDto = XmlConverter.Deserializer<SongInputModel>(xmlString, "Songs");

            foreach (var songDto in songsDto)
            {
                if (!IsValid(songDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidDuration = TimeSpan.TryParseExact(songDto.Duration, "c",
                                                            CultureInfo.CurrentCulture, out TimeSpan duration);

                var isValidDateFormat = DateTime.TryParseExact(songDto.CreatedOn, "dd/MM/yyyy",
                                                               CultureInfo.InvariantCulture, DateTimeStyles.None,
                                                               out var createdOn);

                if (isValidDuration == false || isValidDateFormat == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = context.Writers.Find(songDto.WriterId);
                var album = context.Albums.FirstOrDefault(a => a.Id == songDto.AlbumId);

                if (writer == null || album == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isCorrectGener = Enum.TryParse<Genre>(songDto.Genre, out var correctGener);

                if (isCorrectGener == false)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song 
                { 
                    Name = songDto.Name,
                    Duration = duration,
                    CreatedOn = createdOn,
                    Genre = correctGener,
                    AlbumId= album.Id,
                    WriterId = writer.Id,
                    Price = songDto.Price                    
                };

                songs.Add(song);
                sb.AppendLine(string.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var sb = new StringBuilder();            

            var songsPerformers = XmlConverter.Deserializer<SongPerformerInputModel>(xmlString, "Performers");

            foreach (var songPerformer in songsPerformers)
            {

                if (!IsValid(songPerformer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                
                var performer = new Performer
                {
                    FirstName = songPerformer.FirstName,
                    LastName = songPerformer.LastName,
                    Age = songPerformer.Age,
                    NetWorth = songPerformer.NetWorth                   
                };

                var songs = new List<SongPerformer>();

                var isValidSong = true;

                foreach (var songDto in songPerformer.PerformersSongs)
                {
                    var isValidsongId = int.TryParse(songDto.Id, out var songId);

                    if (isValidsongId == false)
                    {
                        isValidSong = false;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var currentSong = context.Songs
                        .FirstOrDefault(x => x.Id == songId);

                    if (currentSong == null)
                    {
                        isValidSong = false;
                        sb.AppendLine(ErrorMessage);
                        break;
                    }

                    var performerSong = new SongPerformer
                    {
                        SongId = songId,
                    };

                    songs.Add(performerSong);
                }

                if (isValidSong == false)
                {
                    continue;
                }

                performer.PerformerSongs = songs;                

                sb.AppendLine(String.Format(SuccessfullyImportedPerformer,
                    performer.FirstName, performer.PerformerSongs.Count()));

                context.Performers.Add(performer);
                context.SaveChanges();
            }           

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}