using FootballManager.Data.Models;
using FootballManager.ViewModels.Players;

using System.Collections.Generic;

namespace FootballManager.Services
{
    public interface IPlayerService
    {
        ICollection<AllPlayersViewModel> GetPlayers();

        ICollection<GetUserPlayersViewModel> GetPlayersByUserId(string userId);

        Player GetPlayerById(string playerId);

        Player Create(AddPlayerFormModel model);

        UserPlayer GetUserPlayerById(string userId, string playerId);

        void Update(Player player);      

        void UpdateInUserPlayer(Player player, string userId);

        void RemoveUserPlayer(UserPlayer userPlayer);
    }
}
