using DemoASPMVC.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DemoASPMVC.Services
{
    public class GameService
    {
        private List<Game> _games;

        

        public GameService()
        {
            
            

            _games = new List<Game>();
            _games.Add(new Game { Id = 1, Title = "Starfield", Description = "Bugland dans l'espace", Genre = "RPG"});
            _games.Add(new Game { Id = 2, Title = "Rocket league", Description = "Vroumvroum ballon", Genre = "Aucun"});
            _games.Add(new Game { Id = 3, Title = "League of legend", Description = "Kikooworld pour kevin de 12ans", Genre = "Cancer"});
            _games.Add(new Game { Id = 4, Title = "Baldur's gate 3", Description = "Le 1 était mieux", Genre = "RPG"});
        }

        public List<Game> GetGames()
        {
            return _games;
        }

        public Game GetById(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public void Create(Game game)
        {
            game.Id = _games.Max(g => g.Id) +1;
            _games.Add(game);
        }
    }
}
