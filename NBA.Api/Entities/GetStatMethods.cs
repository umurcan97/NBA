using System;

namespace NBA.Api.Entities
{
    using NBA.Api.Interfaces;
    using NBA.Model;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    public class GetStatMethods : IGetStatMethods
    {
        private readonly INBAContext _dbContext;
        public GetStatMethods(
            INBAContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public string GetTeamNameByID(int TeamID)
        {
            Teams team = this._dbContext.Teams.Where(x => x.Id == TeamID + 1).First();
            return team.TeamName;
        }
        public int GetTeamIdByName(string TeamName)
        {
            Teams team = this._dbContext.Teams.Where(x => x.TeamName == TeamName).First();
            return team.Id - 1;
        }
        public int GetLatestGameNoFullSeason()
        {
            FullSeason game = this._dbContext.FullSeason.OrderByDescending(x => x.GameNo).FirstOrDefault();
            if (game == null)
                return 0;
            return game.GameNo;
        }
        public int GetLatestGameNoFullSeason1920()
        {
            FullSeason19_20 game = this._dbContext.FullSeason1920.OrderByDescending(x => x.GameNo).FirstOrDefault();
            if (game == null)
                return 0;
            return game.GameNo;
        }
        public int GetLatestGameNoFullSeasonQuarters1920()
        {
            FullSeasonQuarters19_20 game = this._dbContext.FullSeasonQuarters1920.OrderByDescending(x => x.GameNo).FirstOrDefault();
            if (game == null)
                return 0;
            return game.GameNo;
        }
        public int GetLatestQuarterNoFullSeasonQuarters1920()
        {
            FullSeasonQuarters19_20 game = this._dbContext.FullSeasonQuarters1920.OrderByDescending(x => x.ID).FirstOrDefault();
            if (game == null)
                return 0;
            return game.QuarterNo;
        }
        public int GetLatestGameNoFullSeasonQuarters()
        {
            FullSeasonQuarters quarter = this._dbContext.FullSeasonQuarters.OrderByDescending(x => x.ID).First();
            return quarter.GameNo;
        }
        public int GetLatestQuarterNoFullSeasonQuarters()
        {
            FullSeasonQuarters quarter = this._dbContext.FullSeasonQuarters.OrderByDescending(x => x.ID).First();
            return quarter.QuarterNo;
        }
        public int GetLatestGameNoPlayerStats()
        {
            PlayerStats stat = this._dbContext.PlayerStats.OrderByDescending(x => x.GameNo).FirstOrDefault();
            if (stat == null)
                return 0;
            return stat.GameNo;
        }
        public int GetLatestGameNoQuarterPredictions()
        {
            try
            {
                QuarterPredictions quarter = this._dbContext.Predictions.OrderByDescending(x => x.ID).First();
                return quarter.GameNo;
            }
            catch (Exception)
            {
                return 85;
            }
        }
        public int GetLatestQuarterNoQuarterPredictions()
        {
            try
            {
                QuarterPredictions quarter = this._dbContext.Predictions.OrderByDescending(x => x.ID).First();
                return quarter.QuarterNo;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public int GetLatestGameNoGamePredictions()
        {
            GamePredictions game = this._dbContext.GamePredictions.OrderByDescending(x => x.ID).FirstOrDefault();
            if (game == null)
                return 106;
            return game.GameNo;
        }
        public bool QuarterExist1920(int GameNo, int QuarterNo)
        {
            FullSeasonQuarters19_20 quarter = this._dbContext.FullSeasonQuarters1920.FirstOrDefault(x =>
                x.GameNo == GameNo && x.QuarterNo == QuarterNo);
            if (quarter == null)
                return false;
            return true;
        }
        public Team GetHomeTeam(int GameNo)
        {
            var game = this._dbContext.FullSeason.First(x => x.GameNo == GameNo);
            return game.HomeTeam;
        }
        public Team GetAwayTeam(int GameNo)
        {
            var game = this._dbContext.FullSeason.First(x => x.GameNo == GameNo);
            return game.AwayTeam;
        }
        public Team GetHomeTeam1920(int GameNo)
        {
            var game = this._dbContext.FullSeason1920.First(x => x.GameNo == GameNo);
            return game.HomeTeam;
        }
        public Team GetAwayTeam1920(int GameNo)
        {
            var game = this._dbContext.FullSeason1920.First(x => x.GameNo == GameNo);
            return game.AwayTeam;
        }
        public DateTime GetGameDate(int GameNo)
        {
            GameTime gameTime = this._dbContext.GameTime.FirstOrDefault(x => x.GameNo == GameNo);
            return gameTime.GameDate;
        }
        public GameTime GetGameTime(int GameNo)
        {
            GameTime game = this._dbContext.GameTime.FirstOrDefault(x => x.GameNo == GameNo);
            return game;
        }
        public int GetNextGame(DateTime date)
        {
            GameTime game = this._dbContext.GameTime.Where(x => x.GameDate > date).FirstOrDefault();
            return game.GameNo;
        }
        public FullSeason GetFullSeason(int GameNo)
        {
            return _dbContext.FullSeason.First(x => x.GameNo == GameNo);
        }
        public FullSeason19_20 GetFullSeason1920(int GameNo)
        {
            return _dbContext.FullSeason1920.First(x => x.GameNo == GameNo);
        }
        public FullSeasonQuarters GetFullSeasonQuarters(int GameNo, int QuarterNo)
        {
            return _dbContext.FullSeasonQuarters.First(x => x.GameNo == GameNo && x.QuarterNo == QuarterNo);
        }
        public FullSeasonQuarters19_20 GetFullSeasonQuarters1920(int GameNo, int QuarterNo)
        {
            return _dbContext.FullSeasonQuarters1920.First(x => x.GameNo == GameNo && x.QuarterNo == QuarterNo);
        }
        public Players GetPlayerWithName(string name)
        {
            return this._dbContext.Players.FirstOrDefault(x => x.Name == name);
        }
        public List<FullSeason> GetFullSeasonTillGameNo(Team team, int GameNo)
        {
            List<FullSeason> gameModels = this._dbContext.FullSeason.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.GameNo < GameNo)
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeason> GetFullSeasonList(Team team)
        {
            List<FullSeason> gameModels = this._dbContext.FullSeason.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team))
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeason> GetFullSeasonForHomeOrAwayList(Team team, bool isHome)
        {
            if (isHome)
            {
                List<FullSeason> gameModels = this._dbContext.FullSeason
                    .Where(x => x.HomeTeam == team).OrderByDescending(y => y.GameNo).ToList();
                return gameModels;
            }
            else
            {
                List<FullSeason> gameModels = this._dbContext.FullSeason
                    .Where(x => x.AwayTeam == team).OrderByDescending(y => y.GameNo).ToList();
                return gameModels;
            }
        }
        public List<FullSeason> GetLast5List(Team team)
        {
            List<FullSeason> gameModels = this._dbContext.FullSeason.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team))
                .OrderByDescending(y => y.GameNo).Take(5).ToList();
            return gameModels;
        }
        public List<FullSeason> GetSeasonMatchups(Team team1, Team team2)
        {
            List<FullSeason> gameModels = this._dbContext.FullSeason
                .Where(x => (x.AwayTeam == team1 && x.HomeTeam == team2) ||
                            (x.HomeTeam == team1 && x.AwayTeam == team2))
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeasonQuarters> GetFullSeasonTillGameNoForQuarter(Team team, int GameNo, int QuarterNo)
        {
            List<FullSeasonQuarters> quarters = this._dbContext.FullSeasonQuarters.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.QuarterNo == QuarterNo && x.GameNo < GameNo)
                .OrderByDescending(y => y.GameNo).ToList();
            return quarters;
        }
        public List<FullSeasonQuarters> GetFullSeasonListForQuarter(Team team, int QuarterNo)
        {
            List<FullSeasonQuarters> gameModels = this._dbContext.FullSeasonQuarters.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.QuarterNo == QuarterNo)
                .OrderByDescending(y => y.GameNo)
                .ToList();
            return gameModels;
        }
        public List<FullSeasonQuarters> GetFullSeasonForHomeOrAwayListForQuarter(Team team, bool isHome, int QuarterNo)
        {
            if (isHome)
            {
                List<FullSeasonQuarters> gameModels = this._dbContext.FullSeasonQuarters
                    .Where(x => x.HomeTeam == team && x.QuarterNo == QuarterNo).OrderByDescending(y => y.GameNo)
                    .ToList();
                return gameModels;
            }
            else
            {
                List<FullSeasonQuarters> gameModels = this._dbContext.FullSeasonQuarters
                    .Where(x => x.AwayTeam == team && x.QuarterNo == QuarterNo).OrderByDescending(y => y.GameNo)
                    .ToList();
                return gameModels;
            }
        }
        public List<FullSeasonQuarters> GetLast5ListForQuarter(Team team, int QuarterNo)
        {
            List<FullSeasonQuarters> gameModels = this._dbContext.FullSeasonQuarters.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.QuarterNo == QuarterNo)
                .OrderByDescending(y => y.GameNo).Take(5).ToList();
            return gameModels;
        }
        public List<FullSeasonQuarters> GetSeasonMatchupsForQuarter(Team team1, Team team2, int QuarterNo)
        {
            List<FullSeasonQuarters> gameModels = this._dbContext.FullSeasonQuarters
                .Where(x => (x.AwayTeam == team1 && x.HomeTeam == team2 && x.QuarterNo == QuarterNo) ||
                            (x.HomeTeam == team1 && x.AwayTeam == team2 && x.QuarterNo == QuarterNo))
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeason19_20> GetFullSeason1920TillGameNo(Team team, int GameNo)
        {
            List<FullSeason19_20> gameModels = this._dbContext.FullSeason1920.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.GameNo < GameNo)
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeason19_20> GetFullSeason1920List(Team team)
        {
            List<FullSeason19_20> gameModels = this._dbContext.FullSeason1920.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team))
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeason19_20> GetFullSeason1920ForHomeOrAwayList(Team team, bool isHome)
        {
            if (isHome)
            {
                List<FullSeason19_20> gameModels = this._dbContext.FullSeason1920
                    .Where(x => x.HomeTeam == team).OrderByDescending(y => y.GameNo).ToList();
                return gameModels;
            }
            else
            {
                List<FullSeason19_20> gameModels = this._dbContext.FullSeason1920
                    .Where(x => x.AwayTeam == team).OrderByDescending(y => y.GameNo).ToList();
                return gameModels;
            }
        }
        public List<FullSeason19_20> GetLast5List1920(Team team)
        {
            List<FullSeason19_20> gameModels = this._dbContext.FullSeason1920.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team))
                .OrderByDescending(y => y.GameNo).Take(5).ToList();
            return gameModels;
        }
        public List<FullSeason19_20> GetSeason1920Matchups(Team team1, Team team2)
        {
            List<FullSeason19_20> gameModels = this._dbContext.FullSeason1920
                .Where(x => (x.AwayTeam == team1 && x.HomeTeam == team2) ||
                            (x.HomeTeam == team1 && x.AwayTeam == team2))
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<FullSeasonQuarters19_20> GetFullSeason1920TillGameNoForQuarter(Team team, int GameNo, int QuarterNo)
        {
            List<FullSeasonQuarters19_20> quarters = this._dbContext.FullSeasonQuarters1920.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.QuarterNo == QuarterNo && x.GameNo < GameNo)
                .OrderByDescending(y => y.GameNo).ToList();
            return quarters;
        }
        public List<FullSeasonQuarters19_20> GetFullSeason1920ListForQuarter(Team team, int QuarterNo)
        {
            List<FullSeasonQuarters19_20> gameModels = this._dbContext.FullSeasonQuarters1920.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.QuarterNo == QuarterNo)
                .OrderByDescending(y => y.GameNo)
                .ToList();
            return gameModels;
        }
        public List<FullSeasonQuarters19_20> GetFullSeason1920ForHomeOrAwayListForQuarter(Team team, bool isHome, int QuarterNo)
        {
            if (isHome)
            {
                List<FullSeasonQuarters19_20> gameModels = this._dbContext.FullSeasonQuarters1920
                    .Where(x => x.HomeTeam == team && x.QuarterNo == QuarterNo).OrderByDescending(y => y.GameNo)
                    .ToList();
                return gameModels;
            }
            else
            {
                List<FullSeasonQuarters19_20> gameModels = this._dbContext.FullSeasonQuarters1920
                    .Where(x => x.AwayTeam == team && x.QuarterNo == QuarterNo).OrderByDescending(y => y.GameNo)
                    .ToList();
                return gameModels;
            }
        }
        public List<FullSeasonQuarters19_20> GetLast5List1920ForQuarter(Team team, int QuarterNo)
        {
            List<FullSeasonQuarters19_20> gameModels = this._dbContext.FullSeasonQuarters1920.Where(x =>
                    (x.AwayTeam == team || x.HomeTeam == team) && x.QuarterNo == QuarterNo)
                .OrderByDescending(y => y.GameNo).Take(5).ToList();
            return gameModels;
        }
        public List<FullSeasonQuarters19_20> GetSeason1920MatchupsForQuarter(Team team1, Team team2, int QuarterNo)
        {
            List<FullSeasonQuarters19_20> gameModels = this._dbContext.FullSeasonQuarters1920
                .Where(x => (x.AwayTeam == team1 && x.HomeTeam == team2 && x.QuarterNo == QuarterNo) ||
                            (x.HomeTeam == team1 && x.AwayTeam == team2 && x.QuarterNo == QuarterNo))
                .OrderByDescending(y => y.GameNo).ToList();
            return gameModels;
        }
        public List<PlayerStats> GetFullSeasonStatsWithPlayerID(int PlayerId)
        {
            List<PlayerStats> Stats = this._dbContext.PlayerStats.Where(x => x.ID == PlayerId).ToList();
            return Stats;
        }
        public List<PlayerStats> GetFullSeasonStatsWithPlayer(Players Player)
        {
            List<PlayerStats> Stats = this._dbContext.PlayerStats.Where(x => x.Player == Player).ToList();
            return Stats;
        }
        public List<PlayerStats> GetFullSeasonStatsWithPlayerName(string PlayerName)
        {
            Players player = this._dbContext.Players.FirstOrDefault(x => x.Name == PlayerName);
            return GetFullSeasonStatsWithPlayer(player);
        }
        public List<PlayerStats> GetLast5StatsWithPlayerID(int PlayerId)
        {
            List<PlayerStats> Stats = this._dbContext.PlayerStats.Where(x => x.ID == PlayerId)
                .OrderByDescending(z => z.GameNo).Take(5).ToList();
            return Stats;
        }
        public List<PlayerStats> GetLast5StatsWithPlayer(Players Player)
        {
            List<PlayerStats> Stats = this._dbContext.PlayerStats.Where(x => x.Player == Player)
                .OrderByDescending(z => z.GameNo).Take(5).ToList();
            return Stats;
        }
        public List<PlayerStats> GetLast5StatsWithPlayerName(string PlayerName)
        {
            Players player = this._dbContext.Players.FirstOrDefault(x => x.Name == PlayerName);
            return GetLast5StatsWithPlayer(player);
        }
    }
}
