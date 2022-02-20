using FootballManager.Data;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballManagerDbContext data;

        public PlayerService(FootballManagerDbContext data)
        {
            this.data = data;
        }

        public Player Create(AddPlayerFormModel model)
        {
            var player = new Player
            {                
                FullName = model.FullName,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = model.Speed,
                Endurance = model.Endurance,
                Description = model.Description,
            };

            return player;
        }

        public Player GetPlayerById(string playerId)
        {
            var palyer = this.data
                .Players
                .Where(p => p.Id == playerId)
                .Select(p => new Player
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description,
                })
                .FirstOrDefault();

            return palyer;
        }

        public ICollection<AllPlayersViewModel> GetPlayers()
        {
            var palyers = this.data
                .Players
                .Select(p => new AllPlayersViewModel
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Position = p.Position,
                    Speed = p.Speed,
                    Endurance = p.Endurance,
                    Description = p.Description,
                })
                .ToList();

            return palyers;
        }

        public ICollection<GetUserPlayersViewModel> GetPlayersByUserId(string userId)
        {
            var palyers = this.data
                .UsersPlayers
                .Where(p => p.UserId == userId)
                .Select(p => new GetUserPlayersViewModel
                {
                    Id = p.Player.Id,
                    FullName = p.Player.FullName,
                    ImageUrl = p.Player.ImageUrl,
                    Position = p.Player.Position,
                    Speed = p.Player.Speed,
                    Endurance = p.Player.Endurance,
                    Description = p.Player.Description,
                })
                .ToList();

            return palyers;
        }

        public UserPlayer GetUserPlayerById(string userId, string playerId)
        {
            var playerUser = this.data.UsersPlayers.FirstOrDefault(p => p.UserId == userId && p.PlayerId == playerId);

            return playerUser;
        }

        public void RemoveUserPlayer(UserPlayer userPlayer)
        {
            this.data.Remove(userPlayer);

            this.data.SaveChanges();
        }

        public void Update(Player player)
        {
            this.data.Players.Add(player);

            this.data.SaveChanges();
        }

        public void UpdateInUserPlayer(Player player, string userId)
        {
            this.data.UsersPlayers.Add(new UserPlayer { PlayerId = player.Id, UserId = userId });

            this.data.SaveChanges();
        }
    }
}
