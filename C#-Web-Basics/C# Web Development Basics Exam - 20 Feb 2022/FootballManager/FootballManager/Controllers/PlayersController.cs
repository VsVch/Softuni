using FootballManager.Data;
using FootballManager.Services;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Linq;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        private readonly IValidator validator;
        private readonly FootballManagerDbContext data;
        private readonly IUserService userService;
       
        public PlayersController(IPlayerService playerService, IValidator validator, FootballManagerDbContext data, IUserService userService)
        {
            this.playerService = playerService;
            this.validator = validator;
            this.data = data; 
            this.userService = userService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = playerService.GetPlayers();

            return View(players);
        }

        [Authorize]
        public HttpResponse Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(AddPlayerFormModel model)
        {
            var errors = validator.PlayerValidator(model, User.Id);

            if (errors.Any())
            {
                Error(errors);
            }

            var player = playerService.Create(model);

            try
            {
                playerService.Update(player);
            }
            catch (Exception)
            {
                throw new Exception("Object is not added in the date base.");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var players = playerService.GetPlayersByUserId(User.Id);

            return View(players);
        }

        [Authorize]
        public HttpResponse AddToCollection(string playerId)
        {

            var player = playerService.GetPlayerById(playerId);

            var user = userService.GetUserById(User.Id);
            
            if (this.data.UsersPlayers.Any(p => p.PlayerId == playerId && p.UserId == user.Id))
            {
              return Error($"Player '{player.FullName}' already exsist in MyCollection.");
            }

            if (player == null)
            {
                Error("Player not exsist");
            }

            try
            {
                playerService.UpdateInUserPlayer(player, User.Id);
            }
            catch (Exception)
            {
                throw new Exception("Object is not added in the date base.");
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(string playerId)
        {
            var userPlayer = playerService.GetUserPlayerById(User.Id, playerId);

            if (userPlayer == null)
            {
                Error("Player or user not exsist");
            }

            playerService.RemoveUserPlayer(userPlayer);

            return Redirect("/Players/Collection");
        }
    }
}
