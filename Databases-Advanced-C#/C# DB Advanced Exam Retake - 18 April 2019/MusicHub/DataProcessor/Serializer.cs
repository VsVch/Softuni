namespace MusicHub.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.DataProcessor.ExportDtos;
    using Newtonsoft.Json;

    public class Serializer
    {
       
        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var allAlbums = context.Albums                
                .Where(x => x.ProducerId == 10)                
             .OrderByDescending(x => x.Songs.Sum(s => s.Price))            
             .Select(x => new
             {
                 AlbumName = x.Name,
                 ReleaseDate = x.ReleaseDate.ToString("MM/dd/yyyy"),
                 ProducerName = x.Producer.Name,
                 Songs = x.Songs.Select(s => new
                 {
                     SongName = s.Name,
                     Price = s.Price.ToString("f2"),
                     Writer = s.Writer.Name
                 })                 
                 .OrderByDescending(s => s.SongName)
                 .ThenBy(s => s.Writer)
                 .ToList(),
                 AlbumPrice = x.Songs.Sum(s => s.Price).ToString("f2")
             })
            .ToList();

            var result = JsonConvert.SerializeObject(allAlbums, Formatting.Indented);

            return result.TrimEnd();
        }        

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs.Where(x => x.Duration.Minutes > duration)
                .Select(x => new SongExportModel
                {
                    SongName = x.Name,
                    Writer = x.Writer.Name,
                    Performer = x.SongPerformers
                        .Select(sp => sp.Performer)
                        .Select(p => (p.FirstName + " " + p.LastName))
                        .FirstOrDefault(),
                    AlbumProducer = x.SongPerformers
                           .Select(sp => sp.Song).Select(s => s.Album.Producer.Name).FirstOrDefault(),
                    Duration = x.SongPerformers.Select(sp => sp.Song.Duration.ToString("c")).FirstOrDefault(),
                })
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.Writer)
                .ThenBy(x => x.Performer)
                .ToList();

            var result = XmlConverter.Serialize(songs, "Songs");

            return result;
        }
    }
}