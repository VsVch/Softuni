using BattleCards.Data;
using BattleCards.ViewModels;
using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.mvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        public HttpResponse Add()
        {
            
            return this.View();
        }

        [HttPost("/Cards/Add")]
        public HttpResponse DoAdd() 
        {
            var dbContext = new ApplicationDbContext();

            if (this.Request.FormDate["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 characters long");
            }

            dbContext.Cards.Add(new Card 
            { 
                Attack = int.Parse(this.Request.FormDate["attack"]),
                Health = int.Parse(this.Request.FormDate["health"]),
                Description = this.Request.FormDate["description"],
                Name = this.Request.FormDate["name"],
                ImageUrl = this.Request.FormDate["image"],
                Keyword = this.Request.FormDate["keyword"],               
                
            });

            dbContext.SaveChanges();

            return this.View();
        }

        public HttpResponse All()
        {
            var db = new ApplicationDbContext();
            var cardsViewmodel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Description = x.Description,
            })
            .ToList();
            return this.View(new AllCardsViewModel { Cards = cardsViewmodel });
        }

        public HttpResponse Collection()
        {
            return this.View();
        }
    }
}
