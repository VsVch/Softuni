namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            var result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var currAlbums = context.Producers
                .FirstOrDefault(x => x.Id == producerId)
                .Albums
                .Select(album => new
                {
                    AlbumName = album.Name,
                    ReliseDate = album.ReleaseDate,
                    ProduserName = album.Producer.Name,
                    CurrSongs = album.Songs.Select(song => new
                    {
                        SongName = song.Name,
                        Price = song.Price,
                        SongWriter = song.Writer.Name
                    })
                    .OrderByDescending(x => x.SongName)
                    .ThenBy(x => x.SongWriter),

                    AlbumPrice = album.Price
                })
                .OrderByDescending(x => x.AlbumPrice)
                .ToList();



            var sb = new StringBuilder();

            foreach (var album in currAlbums)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReliseDate:MM/dd/yyyy}");
                sb.AppendLine($"-ProducerName: {album.ProduserName}");
                sb.AppendLine($"-Songs:");

                var counter = 1;
                foreach (var song in album.CurrSongs)
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");
                }
                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }


        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var currSongs = context.Songs
                .Include(x => x.SongPerformers).ThenInclude(x => x.Performer)
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    ProducerName = s.Album.Producer.Name,
                    SongDuration = s.Duration,
                    PerformerName = s.SongPerformers.Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName).FirstOrDefault()

                })                
                .OrderBy(x => x.SongName)
                .ThenBy(x => x.WriterName)
                .ThenBy(x => x.PerformerName)
                .ToList();

            var sb = new StringBuilder();
            var counter = 1;
            
            foreach (var song in currSongs)
            {
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");
                sb.AppendLine($"---Performer: {song.PerformerName}");
                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.SongDuration.ToString("c", CultureInfo.InvariantCulture)}");                
            }

            return sb.ToString().TrimEnd();         
        }
    }
}

