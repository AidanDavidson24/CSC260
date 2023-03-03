using System;
using VideoGameList.Interface;
using VideoGameList.Migrations;
using VideoGameList.Models;

namespace VideoGameList.Data
{
    public class GameListDAL : IDataAccessLayer
    {
        private static List<Games> Gamelist = new List<Games>
        {
            //new Games("Lego Star Wars The Skywalker Saga", "PC, PS4, Xbox One, Switch", "Adventure-Action", 'E', 2022, "LEGOStarWarsTheSkywalkerSaga.jfif","", null),
            //new Games("Goat Simulator 3", "PC, PS5, Xbox One", "Adventure, Sandbox", 'T', 2022, "GoatSim.jpg", "", null),
            //new Games("Gotham Knights", "PC, PS5, Xbox One", "Action, Role-play", 'T', 2022, "GothamKnights.jfif", "", null),
            //new Games("Satisfactory","PC", "Adventure, Indie, Simulation, Strategy, Early Access", null, 2020, "satifactory.jpg", "", null),
            //new Games("South Park: The Stick of Truth", "PC, PS4, Xbox One, Switch", "Role-play", 'M', 2014, "SPSOT.jpg", "", null),
            //new Games("Hunt: Showdown", "PC, PS5, PS4, Xbox", "Action", 'M', 2019, "Hunt.jpg", "", null)
        };

        private GameDbContext db;

        public GameListDAL(GameDbContext indb)
        {
            db = indb;
        }

        public void AddGame(Games game)
        {
            db.Games.Add(game);
            db.SaveChanges();
            //Gamelist.Add(game);
        }

        public void EditGame(Games game)
        {
            //Gamelist[Gamelist.FindIndex(x => x.Id == game.Id)] = game;
            db.Games.Update(game);
            db.SaveChanges();
        }

        public Games GetGame(int? id)
        {
            //Games foundgame = Gamelist.Find(x => x.Id == id);
            //return foundgame;

            return db.Games.Where(game => game.Id == id).FirstOrDefault();
        }

        public int GetGameCount()
        {
            return Gamelist.Count;
        }

        public IEnumerable<Games> GetGames()
        {
            //return Gamelist;
            return db.Games.OrderBy(game => game.ReleaseYear).ToList();
        }

        public void LoanGame(int? id, string name)
        {
            DateTime dt = DateTime.Now;
            Games onegame = GetGame(id);
            onegame.LoanedTo = name;
            onegame.LoanedDate = dt;
            db.Games.Update(onegame);
            db.SaveChanges();
        }

        public void RemoveGame(int? id)
        {
            //Gamelist.Remove(GetGame(id));
            Games foundGame = GetGame(id);
            db.Games.Remove(foundGame);
            db.SaveChanges();
        }

        public void ReturnGame(int? id)
        {
            Games onegame = GetGame(id);
            onegame.LoanedDate = null;
            onegame.LoanedTo = null;
        }

        public IEnumerable<Games> FilterGames(string genre, string platform)
        {
            if (genre == null)
                genre = "";

            if (platform == null)
                platform = string.Empty;  //same as ""

            if (genre == "" && platform == "")  //if both are empty return whole list
                return GetGames();

            IEnumerable<Games> lstGames = GetGames().Where
                (Games => (!string.IsNullOrEmpty(Games.Genre) && Games.Genre.ToLower().Contains(genre.ToLower()))).ToList();

            IEnumerable<Games> lstGames2 = lstGames.Where
                (Games => (!string.IsNullOrEmpty(Games.Platform) && Games.Platform.ToLower().Equals(platform.ToLower()))).ToList();

            if (lstGames2.Count() == 0)
                return lstGames;

            return lstGames2;
        }
    }
}
