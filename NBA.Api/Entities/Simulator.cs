using System;
using System.Collections.Generic;
using System.Linq;
using NBA.Api.Interfaces;
using NBA.Model;

namespace NBA.Api.Entities
{
    public class Simulator:ISimulator
    {
        private readonly IStatCalculator _statCalculator;
        private readonly IGetStatMethods _getStatMethods;

        public Simulator(IStatCalculator statCalculator,
            IGetStatMethods getStatMethods)
        {
            this._statCalculator = statCalculator;
            this._getStatMethods = getStatMethods;
        }

        public int DeviationApllication(double stat, double statdeviation, double stataverage)
        {
            if (stat < stataverage && stataverage - stat >= statdeviation)
                return Convert.ToInt16(Math.Round(stat) == Math.Floor(stat) ? Math.Floor(stat) - 1 : Math.Floor(stat));
            if (stat < stataverage && stataverage - stat < statdeviation)
                return Convert.ToInt16(Math.Round(stat) > stataverage ? Math.Floor(stat) : Math.Round(stat));
            if (stat > stataverage && stat - stataverage < statdeviation)
                return Convert.ToInt16(Math.Round(stat) < stataverage ? Math.Ceiling(stat) : Math.Round(stat));
            return Convert.ToInt16(Math.Round(stat) == Math.Ceiling(stat) ? Math.Ceiling(stat) + 1 : Math.Ceiling(stat));
        }
        public double PaceofPlayCalculator(QuarterModel Stats)
        {
            return Stats.HomeFGA + Stats.AwayFGA + Stats.HomeFTA / 2.5 + Stats.AwayFTA / 2.5 + Stats.HomeTurnovers * 0.7 +
                Stats.AwayTurnovers * 0.7 - Stats.HomeOffensiveRebounds - Stats.AwayOffensiveRebounds;
        }
        public QuarterPredictions QuarterCalculator(QuarterModel Stats, QuarterModel HomeAverages, QuarterModel AwayAverages, QuarterModel HomeDeviation, QuarterModel AwayDeviation)
        {
            double paceofplay = PaceofPlayCalculator(Stats);
            double home2PP = (Stats.HomeFGM - Stats.Home3PM) / (Stats.HomeFGA - Stats.Home3PA);
            double away2PP = (Stats.AwayFGM - Stats.Away3PM) / (Stats.AwayFGA - Stats.Away3PA);
            double home3PP = Stats.Home3PM / Stats.Home3PA;
            double away3PP = Stats.Away3PM / Stats.Away3PA;
            double homeFTP = Stats.HomeFTM / Stats.HomeFTA;
            double awayFTP = Stats.AwayFTM / Stats.AwayFTA;
            int Home3PA = DeviationApllication(Stats.Home3PA, HomeDeviation.Home3PA, HomeAverages.Home3PA);
            int HomeTurnovers = DeviationApllication(Stats.HomeTurnovers, HomeDeviation.HomeTurnovers, HomeAverages.HomeTurnovers);
            int HomeOffensiveRebounds = DeviationApllication(Stats.HomeOffensiveRebounds, HomeDeviation.HomeOffensiveRebounds, HomeAverages.HomeOffensiveRebounds);
            int HomeFTA = DeviationApllication(Stats.HomeFTA, HomeDeviation.HomeFTA, HomeAverages.HomeFTA);
            int Home2PA = Convert.ToInt16(Math.Round(paceofplay / 2 - HomeFTA / 2.5 - HomeTurnovers * 0.7 - Home3PA + HomeOffensiveRebounds));
            int Home2PM = DeviationApllication(Home2PA * home2PP, HomeDeviation.HomeFGM - HomeDeviation.Home3PM, HomeAverages.HomeFGM - HomeAverages.Home3PM);
            int Away3PA = DeviationApllication(Stats.Away3PA, AwayDeviation.Away3PA, AwayAverages.Away3PA);
            int AwayTurnovers = DeviationApllication(Stats.AwayTurnovers, AwayDeviation.AwayTurnovers, AwayAverages.AwayTurnovers);
            int AwayOffensiveRebounds = DeviationApllication(Stats.AwayOffensiveRebounds, AwayDeviation.AwayOffensiveRebounds, AwayAverages.AwayOffensiveRebounds);
            int AwayFTA = DeviationApllication(Stats.AwayFTA, AwayDeviation.AwayFTA, AwayAverages.AwayFTA);
            int Away2PA = Convert.ToInt16(Math.Round(paceofplay / 2 - AwayFTA / 2.5 - AwayTurnovers * 0.7 - Away3PA + AwayOffensiveRebounds));
            int Away2PM = DeviationApllication(Away2PA * away2PP, AwayDeviation.AwayFGM - AwayDeviation.Away3PM, AwayAverages.AwayFGM - AwayAverages.Away3PM);
            QuarterPredictions quarter = new QuarterPredictions
            {
                HomeFGA = Home3PA + Home2PA,
                Home3PA = Home3PA,
                Home3PM = DeviationApllication(Home3PA*home3PP,HomeDeviation.Home3PA,HomeAverages.Home3PM),
                HomeFTA = HomeFTA,
                HomeFTM = DeviationApllication(HomeFTA * homeFTP, HomeDeviation.HomeFTM, HomeAverages.HomeFTM),
                HomeAssists = DeviationApllication(Stats.HomeAssists, HomeDeviation.HomeAssists, HomeAverages.HomeAssists),
                HomeTurnovers = HomeTurnovers,
                HomeOffensiveRebounds = HomeOffensiveRebounds,
                HomeDefensiveRebounds = DeviationApllication(Stats.HomeDefensiveRebounds,HomeDeviation.HomeDefensiveRebounds,HomeAverages.HomeDefensiveRebounds),
                HomeBlocks = DeviationApllication(Stats.HomeBlocks,HomeDeviation.HomeBlocks,HomeAverages.HomeBlocks),
                HomeSteals = DeviationApllication(Stats.HomeSteals,HomeDeviation.HomeSteals,HomeAverages.HomeSteals),
                AwayFGA = Away3PA + Away2PA,
                Away3PA = Away3PA,
                Away3PM = DeviationApllication(Away3PA * away3PP, AwayDeviation.Away3PA, AwayAverages.Away3PM),
                AwayFTA = AwayFTA,
                AwayFTM = DeviationApllication(AwayFTA * awayFTP, AwayDeviation.AwayFTM, AwayAverages.AwayFTM),
                AwayAssists = DeviationApllication(Stats.AwayAssists, AwayDeviation.AwayAssists, AwayAverages.AwayAssists),
                AwayTurnovers = AwayTurnovers,
                AwayOffensiveRebounds = AwayOffensiveRebounds,
                AwayDefensiveRebounds = DeviationApllication(Stats.AwayDefensiveRebounds, AwayDeviation.AwayDefensiveRebounds, AwayAverages.AwayDefensiveRebounds),
                AwayBlocks = DeviationApllication(Stats.AwayBlocks,AwayDeviation.AwayBlocks,AwayAverages.AwayBlocks),
                AwaySteals = DeviationApllication(Stats.AwaySteals, AwayDeviation.AwaySteals, AwayAverages.AwaySteals)
            };
            quarter.HomeFGM = quarter.Home3PM + Home2PM;
            quarter.HomePoints = quarter.Home3PM * 3 + Home2PM * 2 + quarter.HomeFTM;
            quarter.AwayFGM = quarter.Away3PM + Away2PM;
            quarter.AwayPoints = quarter.Away3PM * 3 + Away2PM * 2 + quarter.AwayFTM;
            return quarter;
        }
        public QuarterPredictions QuarterSimulator(Team HomeTeam, Team AwayTeam, int QuarterNo, int GameNo)
        {
            //FullSeason Lists
            List<GameTime> homeGT = _getStatMethods.GetFullSeasonGameTimePlayed(HomeTeam);
            List<GameTime> awayGT = _getStatMethods.GetFullSeasonGameTimePlayed(AwayTeam);
            List<FullSeasonQuarters> homeFullSeasonQuarters = new List<FullSeasonQuarters>();
            List<FullSeasonQuarters> awayFullSeasonQuarters = new List<FullSeasonQuarters>();
            foreach (var game in homeGT)
            {
                try
                {
                    homeFullSeasonQuarters.Add(_getStatMethods.GetFullSeasonQuarters(game.GameNo,QuarterNo));
                }
                catch (Exception)
                {

                }
            }

            foreach (var game in awayGT)
            {
                try
                {
                    awayFullSeasonQuarters.Add(_getStatMethods.GetFullSeasonQuarters(game.GameNo, QuarterNo));
                }
                catch (Exception)
                {
                    
                }
            }

            //Standard Deviations
            QuarterModel TotalDeviation = new QuarterModel();
            QuarterModel HomeDeviation = _statCalculator.DeviationCalculator(homeFullSeasonQuarters, HomeTeam);
            _statCalculator.QuarterModelAddition(TotalDeviation, HomeDeviation);
            QuarterModel AwayDeviation = _statCalculator.DeviationCalculator(awayFullSeasonQuarters, AwayTeam);
            _statCalculator.QuarterModelSwitch(AwayDeviation);
            _statCalculator.QuarterModelAddition(TotalDeviation, AwayDeviation);
            //Season Averages with Coefficients

            var firstGame = true;
            QuarterModel HomeQuarters = new QuarterModel();
            QuarterModel AwayQuarters = new QuarterModel();
            List<Team> homePlayedAgainst = new List<Team>();
            foreach (var game in homeFullSeasonQuarters)
            {
                if (HomeTeam == game.HomeTeam && !homePlayedAgainst.Contains(game.AwayTeam))
                {
                    homePlayedAgainst.Add(game.AwayTeam);
                }
                else if (HomeTeam == game.AwayTeam && !homePlayedAgainst.Contains(game.HomeTeam))
                {
                    homePlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> awayPlayedAgainst = new List<Team>();
            foreach (var game in awayFullSeasonQuarters)
            {
                if (AwayTeam == game.HomeTeam && !awayPlayedAgainst.Contains(game.AwayTeam))
                {
                    awayPlayedAgainst.Add(game.AwayTeam);
                }
                else if (AwayTeam == game.AwayTeam && !awayPlayedAgainst.Contains(game.HomeTeam))
                {
                    awayPlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> commonTeams = new List<Team>();
            foreach (var team1 in homePlayedAgainst)
            {
                foreach (var team2 in awayPlayedAgainst)
                {
                    if (team1 == team2)
                    {
                        commonTeams.Add(team1);
                    }
                }
            }
            List<FullSeasonQuarters> homePlayedCommon = new List<FullSeasonQuarters>();
            List<FullSeasonQuarters> awayPlayedCommon = new List<FullSeasonQuarters>();
            foreach (var team in commonTeams)
            {
                homePlayedCommon.Add(homeFullSeasonQuarters.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
                awayPlayedCommon.Add(awayFullSeasonQuarters.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
            }
            if (homeFullSeasonQuarters.FirstOrDefault(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) ||
                                            (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)) != null)
            {
                firstGame = false;
                QuarterModel homelast5gamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Take(5).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homelast5gamesQuarters, 3);
                QuarterModel homeathomegamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homeathomegamesQuarters, 3);
                QuarterModel homecommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.QuarterModelDivision(homecommon, 4);
                QuarterModel awaylast5gamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Take(5).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awaylast5gamesQuarters, 3);
                QuarterModel awayatawaygamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awayatawaygamesQuarters, 3);
                QuarterModel awaycommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.QuarterModelDivision(awaycommon, 4);
                QuarterModel seasonmatchupsQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Where(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) || (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(seasonmatchupsQuarters, 12);

                _statCalculator.QuarterModelAddition(HomeQuarters, homelast5gamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homeathomegamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homecommon);
                _statCalculator.QuarterModelAddition(HomeQuarters, seasonmatchupsQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaylast5gamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awayatawaygamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaycommon);
                _statCalculator.QuarterModelAdditionSwitch(AwayQuarters, seasonmatchupsQuarters);
                _statCalculator.QuarterModelSwitch(AwayQuarters);
            }
            else
            {
                QuarterModel homelast5gamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Take(5).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homelast5gamesQuarters, 3.166);
                QuarterModel homeathomegamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homeathomegamesQuarters, 2.375);
                QuarterModel homecommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.QuarterModelDivision(homecommon, 3.8);
                QuarterModel awaylast5gamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Take(5).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awaylast5gamesQuarters, 3.166);
                QuarterModel awayatawaygamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awayatawaygamesQuarters, 2.375);
                QuarterModel awaycommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.QuarterModelDivision(awaycommon, 3.8);

                _statCalculator.QuarterModelAddition(HomeQuarters, homelast5gamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homeathomegamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homecommon);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaylast5gamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awayatawaygamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaycommon);
                _statCalculator.QuarterModelSwitch(AwayQuarters);
            }
            _statCalculator.QuarterModelMultiplication(HomeQuarters,AwayDeviation);
            _statCalculator.QuarterModelMultiplication(AwayQuarters,HomeDeviation);
            _statCalculator.QuarterModelAddition(HomeQuarters,AwayQuarters);
            _statCalculator.QuarterModelDivision(HomeQuarters,TotalDeviation);
            QuarterModel homeSeasonAverages = _statCalculator.AverageCalculator(homeFullSeasonQuarters, HomeTeam);
            QuarterModel awaySeasonAverages = _statCalculator.AverageCalculator(awayFullSeasonQuarters, AwayTeam);
            _statCalculator.QuarterModelSwitch(awaySeasonAverages);
            QuarterPredictions Quarter = QuarterCalculator(HomeQuarters, homeSeasonAverages, awaySeasonAverages, HomeDeviation, AwayDeviation);
            Quarter.HomeTeam = HomeTeam;
            Quarter.AwayTeam = AwayTeam;
            Quarter.QuarterNo = QuarterNo;
            Quarter.GameNo = GameNo;
            Quarter.FirstGame = firstGame;
            return Quarter;
        }
        public GamePredictions GameCalculator(GameModel Stats, GameModel HomeAverages, GameModel AwayAverages, GameModel HomeDeviation, GameModel AwayDeviation)
        {
            double paceofplay = PaceofPlayCalculator(Stats);
            double home2PP = (Stats.HomeFGM - Stats.Home3PM) / (Stats.HomeFGA - Stats.Home3PA);
            double away2PP = (Stats.AwayFGM - Stats.Away3PM) / (Stats.AwayFGA - Stats.Away3PA);
            double home3PP = Stats.Home3PM / Stats.Home3PA;
            double away3PP = Stats.Away3PM / Stats.Away3PA;
            double homeFTP = Stats.HomeFTM / Stats.HomeFTA;
            double awayFTP = Stats.AwayFTM / Stats.AwayFTA;
            int Home3PA = DeviationApllication(Stats.Home3PA, HomeDeviation.Home3PA, HomeAverages.Home3PA);
            int HomeTurnovers = DeviationApllication(Stats.HomeTurnovers, HomeDeviation.HomeTurnovers, HomeAverages.HomeTurnovers);
            int HomeOffensiveRebounds = DeviationApllication(Stats.HomeOffensiveRebounds, HomeDeviation.HomeOffensiveRebounds, HomeAverages.HomeOffensiveRebounds);
            int HomeFTA = DeviationApllication(Stats.HomeFTA, HomeDeviation.HomeFTA, HomeAverages.HomeFTA);
            int Home2PA = Convert.ToInt16(Math.Round(paceofplay / 2 - HomeFTA / 2.5 - HomeTurnovers * 0.7 - Home3PA + HomeOffensiveRebounds));
            int Home2PM = DeviationApllication(Home2PA * home2PP, HomeDeviation.HomeFGM - HomeDeviation.Home3PM, HomeAverages.HomeFGM - HomeAverages.Home3PM);
            int Away3PA = DeviationApllication(Stats.Away3PA, AwayDeviation.Away3PA, AwayAverages.Away3PA);
            int AwayTurnovers = DeviationApllication(Stats.AwayTurnovers, AwayDeviation.AwayTurnovers, AwayAverages.AwayTurnovers);
            int AwayOffensiveRebounds = DeviationApllication(Stats.AwayOffensiveRebounds, AwayDeviation.AwayOffensiveRebounds, AwayAverages.AwayOffensiveRebounds);
            int AwayFTA = DeviationApllication(Stats.AwayFTA, AwayDeviation.AwayFTA, AwayAverages.AwayFTA);
            int Away2PA = Convert.ToInt16(Math.Round(paceofplay / 2 - AwayFTA / 2.5 - AwayTurnovers * 0.7 - Away3PA + AwayOffensiveRebounds));
            int Away2PM = DeviationApllication(Away2PA * away2PP, AwayDeviation.AwayFGM - AwayDeviation.Away3PM, AwayAverages.AwayFGM - AwayAverages.Away3PM);
            GamePredictions game = new GamePredictions
            {
                HomeFGA = Home3PA + Home2PA,
                Home3PA = Home3PA,
                Home3PM = DeviationApllication(Home3PA * home3PP, HomeDeviation.Home3PA, HomeAverages.Home3PM),
                HomeFTA = HomeFTA,
                HomeFTM = DeviationApllication(HomeFTA * homeFTP, HomeDeviation.HomeFTM, HomeAverages.HomeFTM),
                HomeAssists = DeviationApllication(Stats.HomeAssists, HomeDeviation.HomeAssists, HomeAverages.HomeAssists),
                HomeTurnovers = HomeTurnovers,
                HomeOffensiveRebounds = HomeOffensiveRebounds,
                HomeDefensiveRebounds = DeviationApllication(Stats.HomeDefensiveRebounds, HomeDeviation.HomeDefensiveRebounds, HomeAverages.HomeDefensiveRebounds),
                HomeBlocks = DeviationApllication(Stats.HomeBlocks, HomeDeviation.HomeBlocks, HomeAverages.HomeBlocks),
                HomeSteals = DeviationApllication(Stats.HomeSteals, HomeDeviation.HomeSteals, HomeAverages.HomeSteals),
                AwayFGA = Away3PA + Away2PA,
                Away3PA = Away3PA,
                Away3PM = DeviationApllication(Away3PA * away3PP, AwayDeviation.Away3PA, AwayAverages.Away3PM),
                AwayFTA = AwayFTA,
                AwayFTM = DeviationApllication(AwayFTA * awayFTP, AwayDeviation.AwayFTM, AwayAverages.AwayFTM),
                AwayAssists = DeviationApllication(Stats.AwayAssists, AwayDeviation.AwayAssists, AwayAverages.AwayAssists),
                AwayTurnovers = AwayTurnovers,
                AwayOffensiveRebounds = AwayOffensiveRebounds,
                AwayDefensiveRebounds = DeviationApllication(Stats.AwayDefensiveRebounds, AwayDeviation.AwayDefensiveRebounds, AwayAverages.AwayDefensiveRebounds),
                AwayBlocks = DeviationApllication(Stats.AwayBlocks, AwayDeviation.AwayBlocks, AwayAverages.AwayBlocks),
                AwaySteals = DeviationApllication(Stats.AwaySteals, AwayDeviation.AwaySteals, AwayAverages.AwaySteals)
            };
            game.HomeFGM = game.Home3PM + Home2PM;
            game.HomePoints = game.Home3PM * 3 + Home2PM * 2 + game.HomeFTM;
            game.AwayFGM = game.Away3PM + Away2PM;
            game.AwayPoints = game.Away3PM * 3 + Away2PM * 2 + game.AwayFTM;
            return game;
        }
        public GamePredictions FullMatchSimulator(Team HomeTeam, Team AwayTeam, int GameNo)
        {
            //FullSeason Lists
            List<FullSeason> homeFullSeason = _getStatMethods.GetFullSeasonList(HomeTeam);
            List<FullSeason> awayFullSeason = _getStatMethods.GetFullSeasonList(AwayTeam);

            //Standard Deviations
            GameModel TotalDeviation = new GameModel();
            GameModel HomeDeviation = _statCalculator.DeviationCalculator(homeFullSeason, HomeTeam);
            _statCalculator.GameModelAddition(TotalDeviation, HomeDeviation);
            GameModel AwayDeviation = _statCalculator.DeviationCalculator(awayFullSeason, AwayTeam);
            _statCalculator.GameModelSwitch(AwayDeviation);
            _statCalculator.GameModelAddition(TotalDeviation, AwayDeviation);
            //Season Averages with Coefficients

            var firstGame = true;
            GameModel HomeGames = new GameModel();
            GameModel AwayGames = new GameModel();

            List<Team> homePlayedAgainst = new List<Team>();
            foreach (var game in homeFullSeason)
            {
                if (HomeTeam == game.HomeTeam && !homePlayedAgainst.Contains(game.AwayTeam))
                {
                    homePlayedAgainst.Add(game.AwayTeam);
                }
                else if (HomeTeam == game.AwayTeam && !homePlayedAgainst.Contains(game.HomeTeam))
                {
                    homePlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> awayPlayedAgainst = new List<Team>();
            foreach (var game in awayFullSeason)
            {
                if (AwayTeam == game.HomeTeam && !awayPlayedAgainst.Contains(game.AwayTeam))
                {
                    awayPlayedAgainst.Add(game.AwayTeam);
                }
                else if (AwayTeam == game.AwayTeam && !awayPlayedAgainst.Contains(game.HomeTeam))
                {
                    awayPlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> commonTeams = new List<Team>();
            foreach (var team1 in homePlayedAgainst)
            {
                foreach (var team2 in awayPlayedAgainst)
                {
                    if (team1 == team2)
                    {
                        commonTeams.Add(team1);
                    }
                }
            }
            List<FullSeason> homePlayedCommon = new List<FullSeason>();
            List<FullSeason> awayPlayedCommon = new List<FullSeason>();
            foreach (var team in commonTeams)
            {
                homePlayedCommon.Add(homeFullSeason.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
                awayPlayedCommon.Add(awayFullSeason.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
            }
            if (homeFullSeason.FirstOrDefault(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) ||
                                            (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)) != null)
            {
                firstGame = false;
                GameModel homelast5games = _statCalculator.AverageCalculator(homeFullSeason.OrderByDescending(x=>x.GameDate).Take(5).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homelast5games, 5.25);
                GameModel homeathomegames = _statCalculator.AverageCalculator(homeFullSeason.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homeathomegames, 2.625);
                GameModel homeCommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.GameModelDivision(homeCommon,3);
                GameModel awaylast5games = _statCalculator.AverageCalculator(awayFullSeason.OrderByDescending(x => x.GameDate).Take(5).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awaylast5games, 5.25);
                GameModel awayatawaygames = _statCalculator.AverageCalculator(awayFullSeason.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awayatawaygames, 2.625); 
                GameModel awayCommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.GameModelDivision(awayCommon, 3);
                GameModel seasonmatchups = _statCalculator.AverageCalculator(homeFullSeason.Where(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) || (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(seasonmatchups, 10.5);

                _statCalculator.GameModelAddition(HomeGames, homelast5games);
                _statCalculator.GameModelAddition(HomeGames, homeathomegames);
                _statCalculator.GameModelAddition(HomeGames, homeCommon);
                _statCalculator.GameModelAddition(HomeGames, seasonmatchups);
                _statCalculator.GameModelAddition(AwayGames, awaylast5games);
                _statCalculator.GameModelAddition(AwayGames, awayatawaygames);
                _statCalculator.GameModelAddition(AwayGames, awayCommon);
                _statCalculator.GameModelAdditionSwitch(AwayGames, seasonmatchups);
                _statCalculator.GameModelSwitch(AwayGames);
            }
            else
            {
                GameModel homelast5games = _statCalculator.AverageCalculator(homeFullSeason.Take(5).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homelast5games, 3);
                GameModel homeCommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.GameModelDivision(homeCommon, 6);
                GameModel homeathomegames = _statCalculator.AverageCalculator(homeFullSeason.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homeathomegames, 2);
                GameModel awaylast5games = _statCalculator.AverageCalculator(awayFullSeason.Take(5).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awaylast5games, 3);
                GameModel awayCommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.GameModelDivision(awayCommon, 6);
                GameModel awayatawaygames = _statCalculator.AverageCalculator(awayFullSeason.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awayatawaygames, 2);

                _statCalculator.GameModelAddition(HomeGames, homelast5games);
                _statCalculator.GameModelAddition(HomeGames, homeCommon);
                _statCalculator.GameModelAddition(HomeGames, homeathomegames);
                _statCalculator.GameModelAddition(AwayGames, awaylast5games);
                _statCalculator.GameModelAddition(AwayGames, awayCommon);
                _statCalculator.GameModelAddition(AwayGames, awayatawaygames);
                _statCalculator.GameModelSwitch(AwayGames);
            }
            _statCalculator.GameModelMultiplication(HomeGames, AwayDeviation);
            _statCalculator.GameModelMultiplication(AwayGames, HomeDeviation);
            _statCalculator.GameModelAddition(HomeGames, AwayGames);
            _statCalculator.GameModelDivision(HomeGames, TotalDeviation);
            GameModel homeSeasonAverages = _statCalculator.AverageCalculator(homeFullSeason, HomeTeam);
            GameModel awaySeasonAverages = _statCalculator.AverageCalculator(awayFullSeason, AwayTeam);
            _statCalculator.GameModelSwitch(awaySeasonAverages);
            GamePredictions Game = GameCalculator(HomeGames, homeSeasonAverages, awaySeasonAverages, HomeDeviation, AwayDeviation);
            Game.HomeTeam = HomeTeam;
            Game.AwayTeam = AwayTeam;
            Game.GameNo = GameNo;
            Game.FirstGame = firstGame;
            return Game;
        }
        public GamePredictions FullMatchSimulator1920(Team HomeTeam, Team AwayTeam, int GameNo, double Coefficient1, double Coefficient2, double Coefficient3, double Coefficient4, double Coefficient5, double Coefficient6, double Coefficient7)
        {
            //FullSeason Lists
            List<FullSeason19_20> homeFullSeason = _getStatMethods.GetFullSeason1920TillGameNo(HomeTeam, GameNo);
            List<FullSeason19_20> awayFullSeason = _getStatMethods.GetFullSeason1920TillGameNo(AwayTeam, GameNo);

            //Standard Deviations
            GameModel TotalDeviation = new GameModel();
            GameModel HomeDeviation = _statCalculator.DeviationCalculator(homeFullSeason, HomeTeam);
            _statCalculator.GameModelAddition(TotalDeviation, HomeDeviation);
            GameModel AwayDeviation = _statCalculator.DeviationCalculator(awayFullSeason, AwayTeam);
            _statCalculator.GameModelSwitch(AwayDeviation);
            _statCalculator.GameModelAddition(TotalDeviation, AwayDeviation);
            //Season Averages with Coefficients

            var firstGame = true;
            GameModel HomeGames = new GameModel();
            GameModel AwayGames = new GameModel();

            List<Team> homePlayedAgainst = new List<Team>();
            foreach (var game in homeFullSeason)
            {
                if (HomeTeam == game.HomeTeam && !homePlayedAgainst.Contains(game.AwayTeam))
                {
                    homePlayedAgainst.Add(game.AwayTeam);
                }
                else if (HomeTeam == game.AwayTeam && !homePlayedAgainst.Contains(game.HomeTeam))
                {
                    homePlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> awayPlayedAgainst = new List<Team>();
            foreach (var game in awayFullSeason)
            {
                if (AwayTeam == game.HomeTeam && !awayPlayedAgainst.Contains(game.AwayTeam))
                {
                    awayPlayedAgainst.Add(game.AwayTeam);
                }
                else if (AwayTeam == game.AwayTeam && !awayPlayedAgainst.Contains(game.HomeTeam))
                {
                    awayPlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> commonTeams = new List<Team>();
            foreach (var team1 in homePlayedAgainst)
            {
                foreach (var team2 in awayPlayedAgainst)
                {
                    if (team1 == team2)
                    {
                        commonTeams.Add(team1);
                    }
                }
            }
            List<FullSeason19_20> homePlayedCommon = new List<FullSeason19_20>();
            List<FullSeason19_20> awayPlayedCommon = new List<FullSeason19_20>();
            foreach (var team in commonTeams)
            {
                homePlayedCommon.Add(homeFullSeason.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
                awayPlayedCommon.Add(awayFullSeason.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
            }
            if (homeFullSeason.FirstOrDefault(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) ||
                                            (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)) != null)
            {
                firstGame = false;
                GameModel homelast5games = _statCalculator.AverageCalculator(homeFullSeason.Take(5).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homelast5games, Coefficient1);
                GameModel homeathomegames = _statCalculator.AverageCalculator(homeFullSeason.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homeathomegames, Coefficient2);
                GameModel homeCommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.GameModelDivision(homeCommon, Coefficient3);
                GameModel awaylast5games = _statCalculator.AverageCalculator(awayFullSeason.Take(5).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awaylast5games, Coefficient1);
                GameModel awayatawaygames = _statCalculator.AverageCalculator(awayFullSeason.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awayatawaygames, Coefficient2);
                GameModel awayCommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.GameModelDivision(awayCommon, Coefficient3);
                GameModel seasonmatchups = _statCalculator.AverageCalculator(homeFullSeason.Where(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) || (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(seasonmatchups, Coefficient4);

                _statCalculator.GameModelAddition(HomeGames, homelast5games);
                _statCalculator.GameModelAddition(HomeGames, homeathomegames);
                _statCalculator.GameModelAddition(HomeGames, homeCommon);
                _statCalculator.GameModelAddition(HomeGames, seasonmatchups);
                _statCalculator.GameModelAddition(AwayGames, awaylast5games);
                _statCalculator.GameModelAddition(AwayGames, awayatawaygames);
                _statCalculator.GameModelAddition(AwayGames, awayCommon);
                _statCalculator.GameModelAdditionSwitch(AwayGames, seasonmatchups);
                _statCalculator.GameModelSwitch(AwayGames);
            }
            else
            {
                GameModel homelast5games = _statCalculator.AverageCalculator(homeFullSeason.Take(5).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homelast5games, Coefficient5);
                GameModel homeCommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.GameModelDivision(homeCommon, Coefficient6);
                GameModel homeathomegames = _statCalculator.AverageCalculator(homeFullSeason.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.GameModelDivision(homeathomegames, Coefficient7);
                GameModel awaylast5games = _statCalculator.AverageCalculator(awayFullSeason.Take(5).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awaylast5games, Coefficient5);
                GameModel awayCommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.GameModelDivision(awayCommon, Coefficient6);
                GameModel awayatawaygames = _statCalculator.AverageCalculator(awayFullSeason.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.GameModelDivision(awayatawaygames, Coefficient7);

                _statCalculator.GameModelAddition(HomeGames, homelast5games);
                _statCalculator.GameModelAddition(HomeGames, homeathomegames);
                _statCalculator.GameModelAddition(HomeGames, homeCommon);
                _statCalculator.GameModelAddition(AwayGames, awaylast5games);
                _statCalculator.GameModelAddition(AwayGames, awayatawaygames);
                _statCalculator.GameModelAddition(AwayGames, awayCommon);
                _statCalculator.GameModelSwitch(AwayGames);
            }
            _statCalculator.GameModelMultiplication(HomeGames, AwayDeviation);
            _statCalculator.GameModelMultiplication(AwayGames, HomeDeviation);
            _statCalculator.GameModelAddition(HomeGames, AwayGames);
            _statCalculator.GameModelDivision(HomeGames, TotalDeviation);
            GameModel homeSeasonAverages = _statCalculator.AverageCalculator(homeFullSeason, HomeTeam);
            GameModel awaySeasonAverages = _statCalculator.AverageCalculator(awayFullSeason, AwayTeam);
            _statCalculator.GameModelSwitch(awaySeasonAverages);
            GamePredictions Game = GameCalculator(HomeGames, homeSeasonAverages, awaySeasonAverages, HomeDeviation, AwayDeviation);
            Game.HomeTeam = HomeTeam;
            Game.AwayTeam = AwayTeam;
            Game.GameNo = GameNo;
            Game.FirstGame = firstGame;
            return Game;
        }
        public QuarterPredictions QuarterSimulator1920(Team HomeTeam, Team AwayTeam, int QuarterNo, int GameNo, double Coefficient1, double Coefficient2, double Coefficient3, double Coefficient4, double Coefficient5, double Coefficient6, double Coefficient7)
        {
            //FullSeason Lists
            List<FullSeasonQuarters19_20> homeFullSeasonQuarters = _getStatMethods.GetFullSeason1920TillGameNoForQuarter(HomeTeam, GameNo, QuarterNo);
            List<FullSeasonQuarters19_20> awayFullSeasonQuarters = _getStatMethods.GetFullSeason1920TillGameNoForQuarter(AwayTeam, GameNo, QuarterNo);

            //Standard Deviations
            QuarterModel TotalDeviation = new QuarterModel();
            QuarterModel HomeDeviation = _statCalculator.DeviationCalculator(homeFullSeasonQuarters, HomeTeam);
            _statCalculator.QuarterModelAddition(TotalDeviation, HomeDeviation);
            QuarterModel AwayDeviation = _statCalculator.DeviationCalculator(awayFullSeasonQuarters, AwayTeam);
            _statCalculator.QuarterModelSwitch(AwayDeviation);
            _statCalculator.QuarterModelAddition(TotalDeviation, AwayDeviation);
            //Season Averages with Coefficients

            var firstGame = true;
            QuarterModel HomeQuarters = new QuarterModel();
            QuarterModel AwayQuarters = new QuarterModel();
            List<Team> homePlayedAgainst = new List<Team>();
            foreach (var game in homeFullSeasonQuarters)
            {
                if (HomeTeam == game.HomeTeam && !homePlayedAgainst.Contains(game.AwayTeam))
                {
                    homePlayedAgainst.Add(game.AwayTeam);
                }
                else if (HomeTeam == game.AwayTeam && !homePlayedAgainst.Contains(game.HomeTeam))
                {
                    homePlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> awayPlayedAgainst = new List<Team>();
            foreach (var game in awayFullSeasonQuarters)
            {
                if (AwayTeam == game.HomeTeam && !awayPlayedAgainst.Contains(game.AwayTeam))
                {
                    awayPlayedAgainst.Add(game.AwayTeam);
                }
                else if (AwayTeam == game.AwayTeam && !awayPlayedAgainst.Contains(game.HomeTeam))
                {
                    awayPlayedAgainst.Add(game.HomeTeam);
                }
            }
            List<Team> commonTeams = new List<Team>();
            foreach (var team1 in homePlayedAgainst)
            {
                foreach (var team2 in awayPlayedAgainst)
                {
                    if (team1 == team2)
                    {
                        commonTeams.Add(team1);
                    }
                }
            }
            List<FullSeasonQuarters19_20> homePlayedCommon = new List<FullSeasonQuarters19_20>();
            List<FullSeasonQuarters19_20> awayPlayedCommon = new List<FullSeasonQuarters19_20>();
            foreach (var team in commonTeams)
            {
                homePlayedCommon.Add(homeFullSeasonQuarters.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
                awayPlayedCommon.Add(awayFullSeasonQuarters.FirstOrDefault(x => x.HomeTeam == team || x.AwayTeam == team));
            }
            if (homeFullSeasonQuarters.FirstOrDefault(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) ||
                                            (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)) != null)
            {
                firstGame = false;
                QuarterModel homelast5gamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Take(5).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homelast5gamesQuarters, Coefficient1);
                QuarterModel homeathomegamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homeathomegamesQuarters, Coefficient2);
                QuarterModel homecommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.QuarterModelDivision(homecommon,Coefficient3);
                QuarterModel awaylast5gamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Take(5).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awaylast5gamesQuarters, Coefficient1);
                QuarterModel awayatawaygamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awayatawaygamesQuarters, Coefficient2);
                QuarterModel awaycommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.QuarterModelDivision(awaycommon, Coefficient3);
                QuarterModel seasonmatchupsQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Where(x => (x.HomeTeam == HomeTeam && x.AwayTeam == AwayTeam) || (x.HomeTeam == AwayTeam && x.AwayTeam == HomeTeam)).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(seasonmatchupsQuarters, Coefficient4);

                _statCalculator.QuarterModelAddition(HomeQuarters, homelast5gamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homeathomegamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homecommon);
                _statCalculator.QuarterModelAddition(HomeQuarters, seasonmatchupsQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaylast5gamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awayatawaygamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaycommon);
                _statCalculator.QuarterModelAdditionSwitch(AwayQuarters, seasonmatchupsQuarters);
                _statCalculator.QuarterModelSwitch(AwayQuarters);
            }
            else
            {
                QuarterModel homelast5gamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Take(5).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homelast5gamesQuarters, Coefficient5);
                QuarterModel homeathomegamesQuarters = _statCalculator.AverageCalculator(homeFullSeasonQuarters.Where(x => x.HomeTeam == HomeTeam).ToList(), HomeTeam);
                _statCalculator.QuarterModelDivision(homeathomegamesQuarters, Coefficient6);
                QuarterModel homecommon = _statCalculator.AverageCalculator(homePlayedCommon, HomeTeam);
                _statCalculator.QuarterModelDivision(homecommon, Coefficient7);
                QuarterModel awaylast5gamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Take(5).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awaylast5gamesQuarters, Coefficient5);
                QuarterModel awayatawaygamesQuarters = _statCalculator.AverageCalculator(awayFullSeasonQuarters.Where(x => x.AwayTeam == AwayTeam).ToList(), AwayTeam);
                _statCalculator.QuarterModelDivision(awayatawaygamesQuarters, Coefficient6);
                QuarterModel awaycommon = _statCalculator.AverageCalculator(awayPlayedCommon, AwayTeam);
                _statCalculator.QuarterModelDivision(awaycommon, Coefficient7);

                _statCalculator.QuarterModelAddition(HomeQuarters, homelast5gamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homeathomegamesQuarters);
                _statCalculator.QuarterModelAddition(HomeQuarters, homecommon);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaylast5gamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awayatawaygamesQuarters);
                _statCalculator.QuarterModelAddition(AwayQuarters, awaycommon);
                _statCalculator.QuarterModelSwitch(AwayQuarters);
            }
            _statCalculator.QuarterModelMultiplication(HomeQuarters, AwayDeviation);
            _statCalculator.QuarterModelMultiplication(AwayQuarters, HomeDeviation);
            _statCalculator.QuarterModelAddition(HomeQuarters, AwayQuarters);
            _statCalculator.QuarterModelDivision(HomeQuarters, TotalDeviation);
            QuarterModel homeSeasonAverages = _statCalculator.AverageCalculator(homeFullSeasonQuarters, HomeTeam);
            QuarterModel awaySeasonAverages = _statCalculator.AverageCalculator(awayFullSeasonQuarters, AwayTeam);
            _statCalculator.QuarterModelSwitch(awaySeasonAverages);
            QuarterPredictions Quarter = QuarterCalculator(HomeQuarters, homeSeasonAverages, awaySeasonAverages, HomeDeviation, AwayDeviation);
            Quarter.HomeTeam = HomeTeam;
            Quarter.AwayTeam = AwayTeam;
            Quarter.QuarterNo = QuarterNo;
            Quarter.GameNo = GameNo;
            Quarter.FirstGame = firstGame;
            return Quarter;
        }
        public PlayerPredictions PlayerSimulator(GamePredictions game, Players player)
        {
            List<PlayerStats> fullStats = _getStatMethods.GetFullSeasonStatsWithPlayer(player);
            List<FullSeason> fullSeason = _getStatMethods.GetFullSeasonList(player.Team);
            PlayerPredictions stats = new PlayerPredictions();
            return stats;
        }
    }
}
