using NBA.Api.Interfaces;
using NBA.Model;
using System;
using System.Collections.Generic;

namespace NBA.Api.Entities
{
    public class StatCalculator : IStatCalculator
    {
        private readonly INBAContext _dbContext;
        private readonly IGetStatMethods _getStatMethods;

        public StatCalculator(
            INBAContext dbContext,
            IGetStatMethods getStatMethods)
        {
            _dbContext = dbContext;
            _getStatMethods = getStatMethods;
        }

        /// <summary>
        /// After taking a team's full season stats this method
        /// rearranges the given stats where the home team is the
        /// always given team.
        /// </summary>
        /// <param name="Stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<FullSeason> ArrangeStats(List<FullSeason> Stats, Team team)
        {
            List<FullSeason> newList = new List<FullSeason>();
            foreach (var stat in Stats)
            {
                if (stat.HomeTeam == team)
                {
                    FullSeason game = new FullSeason
                    {
                        GameNo = stat.GameNo,
                        GameDate = stat.GameDate,
                        HomeTeam = stat.HomeTeam,
                        AwayTeam = stat.AwayTeam
                    };
                    GameModelAddition(game, stat);
                    newList.Add(game);
                }
                else if (stat.AwayTeam == team)
                {
                    FullSeason game = new FullSeason
                    {
                        GameNo = stat.GameNo,
                        GameDate = stat.GameDate,
                        HomeTeam = stat.AwayTeam,
                        AwayTeam = stat.HomeTeam
                    };
                    GameModelAdditionSwitch(game, stat);
                    newList.Add(game);
                }
            }
            return newList;
        }
        /// <summary>
        /// After taking a team's full season quarter stats this method
        /// rearranges the given stats where the home team is the
        /// always given team.
        /// </summary>
        /// <param name="Stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<FullSeasonQuarters> ArrangeStats(List<FullSeasonQuarters> Stats, Team team)
        {
            List<FullSeasonQuarters> newList = new List<FullSeasonQuarters>();
            foreach (var stat in Stats)
            {
                if (stat.HomeTeam == team)
                {
                    FullSeasonQuarters quarter = new FullSeasonQuarters
                    {
                        GameNo = stat.GameNo,
                        QuarterNo = stat.QuarterNo,
                        HomeTeam = stat.HomeTeam,
                        AwayTeam = stat.AwayTeam
                    };
                    QuarterModelAddition(quarter, stat);
                    newList.Add(quarter);
                }
                else if (stat.AwayTeam == team)
                {
                    FullSeasonQuarters quarter = new FullSeasonQuarters
                    {
                        GameNo = stat.GameNo,
                        QuarterNo = stat.QuarterNo,
                        HomeTeam = stat.AwayTeam,
                        AwayTeam = stat.HomeTeam
                    };
                    QuarterModelAdditionSwitch(quarter, stat);
                    newList.Add(quarter);
                }
            }
            return newList;
        }
        /// <summary>
        /// After taking a team's full season stats this method
        /// rearranges the given stats where the home team is the
        /// always given team.
        /// </summary>
        /// <param name="Stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<FullSeason19_20> ArrangeStats(List<FullSeason19_20> Stats, Team team)
        {
            List<FullSeason19_20> newList = new List<FullSeason19_20>();
            foreach (var stat in Stats)
            {
                if (stat.HomeTeam == team)
                {
                    FullSeason19_20 game = new FullSeason19_20()
                    {
                        GameNo = stat.GameNo,
                        HomeTeam = stat.HomeTeam,
                        AwayTeam = stat.AwayTeam
                    };
                    GameModelAddition(game, stat);
                    newList.Add(game);
                }
                else if (stat.AwayTeam == team)
                {
                    FullSeason19_20 game = new FullSeason19_20()
                    {
                        GameNo = stat.GameNo,
                        HomeTeam = stat.AwayTeam,
                        AwayTeam = stat.HomeTeam
                    };
                    GameModelAdditionSwitch(game, stat);
                    newList.Add(game);
                }
            }
            return newList;
        }
        /// <summary>
        /// After taking a team's full season quarter stats this method
        /// rearranges the given stats where the home team is the
        /// always given team.
        /// </summary>
        /// <param name="Stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public List<FullSeasonQuarters19_20> ArrangeStats(List<FullSeasonQuarters19_20> Stats, Team team)
        {
            List<FullSeasonQuarters19_20> newList = new List<FullSeasonQuarters19_20>();
            foreach (var stat in Stats)
            {
                if (stat.HomeTeam == team)
                {
                    FullSeasonQuarters19_20 quarter = new FullSeasonQuarters19_20()
                    {
                        GameNo = stat.GameNo,
                        QuarterNo = stat.QuarterNo,
                        HomeTeam = stat.HomeTeam,
                        AwayTeam = stat.AwayTeam
                    };
                    QuarterModelAddition(quarter, stat);
                    newList.Add(quarter);
                }
                else if (stat.AwayTeam == team)
                {
                    FullSeasonQuarters19_20 quarter = new FullSeasonQuarters19_20()
                    {
                        GameNo = stat.GameNo,
                        QuarterNo = stat.QuarterNo,
                        HomeTeam = stat.AwayTeam,
                        AwayTeam = stat.HomeTeam
                    };
                    QuarterModelAdditionSwitch(quarter, stat);
                    newList.Add(quarter);
                }
            }
            return newList;
        }
        /// <summary>
        /// This method simply turns the FullSeason model
        /// into a GameModel
        /// </summary>
        /// <param name="Stats"></param>
        /// <returns></returns>
        public GameModel FullSeasonToGameModel(FullSeason Stats)
        {
            GameModel gameModel = new GameModel
            {
                HomePoints = Stats.HomePoints,
                HomeAssists = Stats.HomeAssists,
                Home3PA = Stats.Home3PA,
                Home3PM = Stats.Home3PM,
                HomeFGA = Stats.HomeFGA,
                HomeFGM = Stats.HomeFGM,
                HomeFTA = Stats.HomeFTA,
                HomeFTM = Stats.HomeFTM,
                HomeTotalRebounds = Stats.HomeTotalRebounds,
                HomeOffensiveRebounds = Stats.HomeOffensiveRebounds,
                HomeTurnovers = Stats.HomeTurnovers,
                HomeBlocks = Stats.HomeBlocks,
                HomeSteals = Stats.HomeSteals,
                HomeDefensiveRebounds = Stats.HomeDefensiveRebounds,
                HomePITP = Stats.HomePITP,
                HomeFastBreakPoints = Stats.HomeFastBreakPoints,
                HomeBenchPoints = Stats.HomeBenchPoints,
                HomePointsofTO = Stats.HomePointsofTO,
                AwayPoints = Stats.AwayPoints,
                AwayAssists = Stats.AwayAssists,
                Away3PA = Stats.Away3PA,
                Away3PM = Stats.Away3PM,
                AwayFGA = Stats.AwayFGA,
                AwayFGM = Stats.AwayFGM,
                AwayFTA = Stats.AwayFTA,
                AwayFTM = Stats.AwayFTM,
                AwayTotalRebounds = Stats.AwayTotalRebounds,
                AwayOffensiveRebounds = Stats.AwayOffensiveRebounds,
                AwayTurnovers = Stats.AwayTurnovers,
                AwayBlocks = Stats.AwayBlocks,
                AwaySteals = Stats.AwaySteals,
                AwayDefensiveRebounds = Stats.AwayDefensiveRebounds,
                AwayPITP = Stats.AwayPITP,
                AwayFastBreakPoints = Stats.AwayFastBreakPoints,
                AwayBenchPoints = Stats.AwayBenchPoints,
                AwayPointsofTO = Stats.AwayPointsofTO,
            };
            return gameModel;
        }
        /// <summary>
        /// This method simply turns the GameMode
        /// into a QuarterModel
        /// </summary>
        /// <param name="Stats"></param>
        /// <returns></returns>
        public QuarterModel GameModeltoQuarterModel(GameModel Stats)
        {
            QuarterModel quarterModel = new QuarterModel
            {
                HomePoints = Stats.HomePoints,
                HomeAssists = Stats.HomeAssists,
                Home3PA = Stats.Home3PA,
                Home3PM = Stats.Home3PM,
                HomeFGA = Stats.HomeFGA,
                HomeFGM = Stats.HomeFGM,
                HomeFTA = Stats.HomeFTA,
                HomeFTM = Stats.HomeFTM,
                HomeOffensiveRebounds = Stats.HomeOffensiveRebounds,
                HomeTurnovers = Stats.HomeTurnovers,
                HomeBlocks = Stats.HomeBlocks,
                HomeSteals = Stats.HomeSteals,
                HomeDefensiveRebounds = Stats.HomeDefensiveRebounds,
                AwayPoints = Stats.AwayPoints,
                AwayAssists = Stats.AwayAssists,
                Away3PA = Stats.Away3PA,
                Away3PM = Stats.Away3PM,
                AwayFGA = Stats.AwayFGA,
                AwayFGM = Stats.AwayFGM,
                AwayFTA = Stats.AwayFTA,
                AwayFTM = Stats.AwayFTM,
                AwayOffensiveRebounds = Stats.AwayOffensiveRebounds,
                AwayTurnovers = Stats.AwayTurnovers,
                AwayBlocks = Stats.AwayBlocks,
                AwaySteals = Stats.AwaySteals,
                AwayDefensiveRebounds = Stats.AwayDefensiveRebounds
            };
            return quarterModel;
        }
        /// <summary>
        /// This method is to take the total of the given List of Stats
        /// </summary>
        /// <param name="stat1"></param>
        /// <param name="stat2"></param>
        public void GameModelAddition(GameModel stat1, FullSeason stat2)
        {
            stat1.HomePoints += stat2.HomePoints;
            stat1.HomeAssists += stat2.HomeAssists;
            stat1.Home3PA += stat2.Home3PA;
            stat1.Home3PM += stat2.Home3PM;
            stat1.HomeFGA += stat2.HomeFGA;
            stat1.HomeFGM += stat2.HomeFGM;
            stat1.HomeFTA += stat2.HomeFTA;
            stat1.HomeFTM += stat2.HomeFTM;
            stat1.HomeTotalRebounds += stat2.HomeTotalRebounds;
            stat1.HomeOffensiveRebounds += stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers += stat2.HomeTurnovers;
            stat1.HomeSteals += stat2.HomeSteals;
            stat1.HomeBlocks += stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds += stat2.HomeDefensiveRebounds;
            stat1.HomePITP += stat2.HomePITP;
            stat1.HomeFastBreakPoints += stat2.HomeFastBreakPoints;
            stat1.HomeBenchPoints += stat2.HomeBenchPoints;
            stat1.HomePointsofTO += stat2.HomePointsofTO;
            stat1.AwayPoints += stat2.AwayPoints;
            stat1.AwayAssists += stat2.AwayAssists;
            stat1.Away3PA += stat2.Away3PA;
            stat1.Away3PM += stat2.Away3PM;
            stat1.AwayFGA += stat2.AwayFGA;
            stat1.AwayFGM += stat2.AwayFGM;
            stat1.AwayFTA += stat2.AwayFTA;
            stat1.AwayFTM += stat2.AwayFTM;
            stat1.AwayTotalRebounds += stat2.AwayTotalRebounds;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.AwayTurnovers;
            stat1.AwaySteals += stat2.AwaySteals;
            stat1.AwayBlocks += stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
            stat1.AwayPITP += stat2.AwayPITP;
            stat1.AwayFastBreakPoints += stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints += stat2.AwayBenchPoints;
            stat1.AwayPointsofTO += stat2.AwayPointsofTO;
        }
        public void GameModelAdditionSwitch(GameModel stat1, GameModel stat2)
        {
            stat1.HomePoints += stat2.AwayPoints;
            stat1.HomeAssists += stat2.AwayAssists;
            stat1.Home3PA += stat2.Away3PA;
            stat1.Home3PM += stat2.Away3PM;
            stat1.HomeFGA += stat2.AwayFGA;
            stat1.HomeFGM += stat2.AwayFGM;
            stat1.HomeFTA += stat2.AwayFTA;
            stat1.HomeFTM += stat2.AwayFTM;
            stat1.HomeTotalRebounds += stat2.AwayTotalRebounds;
            stat1.HomeOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.HomeTurnovers += stat2.AwayTurnovers;
            stat1.HomeSteals += stat2.AwaySteals;
            stat1.HomeBlocks += stat2.AwayBlocks;
            stat1.HomeDefensiveRebounds += stat2.AwayDefensiveRebounds;
            stat1.HomePITP += stat2.AwayPITP;
            stat1.HomeFastBreakPoints += stat2.AwayFastBreakPoints;
            stat1.HomeBenchPoints += stat2.AwayBenchPoints;
            stat1.HomePointsofTO += stat2.AwayPointsofTO;
            stat1.AwayPoints += stat2.HomePoints;
            stat1.AwayAssists += stat2.HomeAssists;
            stat1.Away3PA += stat2.Home3PA;
            stat1.Away3PM += stat2.Home3PM;
            stat1.AwayFGA += stat2.HomeFGA;
            stat1.AwayFGM += stat2.HomeFGM;
            stat1.AwayFTA += stat2.HomeFTA;
            stat1.AwayFTM += stat2.HomeFTM;
            stat1.AwayTotalRebounds += stat2.HomeTotalRebounds;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.HomeTurnovers;
            stat1.AwaySteals += stat2.HomeSteals;
            stat1.AwayBlocks += stat2.HomeBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
            stat1.AwayPITP += stat2.HomePITP;
            stat1.AwayFastBreakPoints += stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints += stat2.HomeBenchPoints;
            stat1.AwayPointsofTO += stat2.HomePointsofTO;
        }
        public void GameModelSwitch(GameModel stat1)
        {
            GameModel stat2 = new GameModel();
            GameModelAddition(stat2,stat1);
            stat1.HomePoints = stat2.AwayPoints;
            stat1.HomeAssists = stat2.AwayAssists;
            stat1.Home3PA = stat2.Away3PA;
            stat1.Home3PM = stat2.Away3PM;
            stat1.HomeFGA = stat2.AwayFGA;
            stat1.HomeFGM = stat2.AwayFGM;
            stat1.HomeFTA = stat2.AwayFTA;
            stat1.HomeFTM = stat2.AwayFTM;
            stat1.HomeTotalRebounds = stat2.AwayTotalRebounds;
            stat1.HomeOffensiveRebounds = stat2.AwayOffensiveRebounds;
            stat1.HomeTurnovers = stat2.AwayTurnovers;
            stat1.HomeSteals = stat2.AwaySteals;
            stat1.HomeBlocks = stat2.AwayBlocks;
            stat1.HomeDefensiveRebounds = stat2.AwayDefensiveRebounds;
            stat1.HomePITP = stat2.AwayPITP;
            stat1.HomeFastBreakPoints = stat2.AwayFastBreakPoints;
            stat1.HomeBenchPoints = stat2.AwayBenchPoints;
            stat1.HomePointsofTO = stat2.AwayPointsofTO;
            stat1.AwayPoints = stat2.HomePoints;
            stat1.AwayAssists = stat2.HomeAssists;
            stat1.Away3PA = stat2.Home3PA;
            stat1.Away3PM = stat2.Home3PM;
            stat1.AwayFGA = stat2.HomeFGA;
            stat1.AwayFGM = stat2.HomeFGM;
            stat1.AwayFTA = stat2.HomeFTA;
            stat1.AwayFTM = stat2.HomeFTM;
            stat1.AwayTotalRebounds = stat2.HomeTotalRebounds;
            stat1.AwayOffensiveRebounds = stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers = stat2.HomeTurnovers;
            stat1.AwaySteals = stat2.HomeSteals;
            stat1.AwayBlocks = stat2.HomeBlocks;
            stat1.AwayDefensiveRebounds = stat2.AwayDefensiveRebounds;
            stat1.AwayPITP = stat2.HomePITP;
            stat1.AwayFastBreakPoints = stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints = stat2.HomeBenchPoints;
            stat1.AwayPointsofTO = stat2.HomePointsofTO;
        }
        public void GameModelAddition(GameModel stat1, GameModel stat2)
        {
            stat1.HomePoints += stat2.HomePoints;
            stat1.HomeAssists += stat2.HomeAssists;
            stat1.Home3PA += stat2.Home3PA;
            stat1.Home3PM += stat2.Home3PM;
            stat1.HomeFGA += stat2.HomeFGA;
            stat1.HomeFGM += stat2.HomeFGM;
            stat1.HomeFTA += stat2.HomeFTA;
            stat1.HomeFTM += stat2.HomeFTM;
            stat1.HomeTotalRebounds += stat2.HomeTotalRebounds;
            stat1.HomeOffensiveRebounds += stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers += stat2.HomeTurnovers;
            stat1.HomeSteals += stat2.HomeSteals;
            stat1.HomeBlocks += stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds += stat2.HomeDefensiveRebounds;
            stat1.HomePITP += stat2.HomePITP;
            stat1.HomeFastBreakPoints += stat2.HomeFastBreakPoints;
            stat1.HomeBenchPoints += stat2.HomeBenchPoints;
            stat1.HomePointsofTO += stat2.HomePointsofTO;
            stat1.AwayPoints += stat2.AwayPoints;
            stat1.AwayAssists += stat2.AwayAssists;
            stat1.Away3PA += stat2.Away3PA;
            stat1.Away3PM += stat2.Away3PM;
            stat1.AwayFGA += stat2.AwayFGA;
            stat1.AwayFGM += stat2.AwayFGM;
            stat1.AwayFTA += stat2.AwayFTA;
            stat1.AwayFTM += stat2.AwayFTM;
            stat1.AwayTotalRebounds += stat2.AwayTotalRebounds;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.AwayTurnovers;
            stat1.AwaySteals += stat2.AwaySteals;
            stat1.AwayBlocks += stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
            stat1.AwayPITP += stat2.AwayPITP;
            stat1.AwayFastBreakPoints += stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints += stat2.AwayBenchPoints;
            stat1.AwayPointsofTO += stat2.AwayPointsofTO;
        }
        public FullSeason GameModelSubtraction(FullSeason stat1, GameModel stat2)
        {
            var stat = new FullSeason();
            GameModelAddition(stat,stat1);
            stat.HomePoints -= stat2.HomePoints;
            stat.HomeAssists -= stat2.HomeAssists;
            stat.Home3PA -= stat2.Home3PA;
            stat.Home3PM -= stat2.Home3PM;
            stat.HomeFGA -= stat2.HomeFGA;
            stat.HomeFGM -= stat2.HomeFGM;
            stat.HomeFTA -= stat2.HomeFTA;
            stat.HomeFTM -= stat2.HomeFTM;
            stat.HomeTotalRebounds -= stat2.HomeTotalRebounds;
            stat.HomeOffensiveRebounds -= stat2.HomeOffensiveRebounds;
            stat.HomeTurnovers -= stat2.HomeTurnovers;
            stat.HomeSteals -= stat2.HomeSteals;
            stat.HomeBlocks -= stat2.HomeBlocks;
            stat.HomeDefensiveRebounds -= stat2.HomeDefensiveRebounds;
            stat.HomePITP -= stat2.HomePITP;
            stat.HomeFastBreakPoints -= stat2.HomeFastBreakPoints;
            stat.HomeBenchPoints -= stat2.HomeBenchPoints;
            stat.HomePointsofTO -= stat2.HomePointsofTO;
            stat.AwayPoints -= stat2.AwayPoints;
            stat.AwayAssists -= stat2.AwayAssists;
            stat.Away3PA -= stat2.Away3PA;
            stat.Away3PM -= stat2.Away3PM;
            stat.AwayFGA -= stat2.AwayFGA;
            stat.AwayFGM -= stat2.AwayFGM;
            stat.AwayFTA -= stat2.AwayFTA;
            stat.AwayFTM -= stat2.AwayFTM;
            stat.AwayTotalRebounds -= stat2.AwayTotalRebounds;
            stat.AwayOffensiveRebounds -= stat2.AwayOffensiveRebounds;
            stat.AwayTurnovers -= stat2.AwayTurnovers;
            stat.AwaySteals -= stat2.AwaySteals;
            stat.AwayBlocks -= stat2.AwayBlocks;
            stat.AwayDefensiveRebounds -= stat2.AwayDefensiveRebounds;
            stat.AwayPITP -= stat2.AwayPITP;
            stat.AwayFastBreakPoints -= stat2.AwayFastBreakPoints;
            stat.AwayBenchPoints -= stat2.AwayBenchPoints;
            stat.AwayPointsofTO -= stat2.AwayPointsofTO;
            return stat;
        }
        public FullSeason19_20 GameModelSubtraction(FullSeason19_20 stat1, GameModel stat2)
        {
            var stat = new FullSeason19_20();
            GameModelAddition(stat, stat1);
            stat.HomePoints -= stat2.HomePoints;
            stat.HomeAssists -= stat2.HomeAssists;
            stat.Home3PA -= stat2.Home3PA;
            stat.Home3PM -= stat2.Home3PM;
            stat.HomeFGA -= stat2.HomeFGA;
            stat.HomeFGM -= stat2.HomeFGM;
            stat.HomeFTA -= stat2.HomeFTA;
            stat.HomeFTM -= stat2.HomeFTM;
            stat.HomeTotalRebounds -= stat2.HomeTotalRebounds;
            stat.HomeOffensiveRebounds -= stat2.HomeOffensiveRebounds;
            stat.HomeTurnovers -= stat2.HomeTurnovers;
            stat.HomeSteals -= stat2.HomeSteals;
            stat.HomeBlocks -= stat2.HomeBlocks;
            stat.HomeDefensiveRebounds -= stat2.HomeDefensiveRebounds;
            stat.HomePITP -= stat2.HomePITP;
            stat.HomeFastBreakPoints -= stat2.HomeFastBreakPoints;
            stat.HomeBenchPoints -= stat2.HomeBenchPoints;
            stat.HomePointsofTO -= stat2.HomePointsofTO;
            stat.AwayPoints -= stat2.AwayPoints;
            stat.AwayAssists -= stat2.AwayAssists;
            stat.Away3PA -= stat2.Away3PA;
            stat.Away3PM -= stat2.Away3PM;
            stat.AwayFGA -= stat2.AwayFGA;
            stat.AwayFGM -= stat2.AwayFGM;
            stat.AwayFTA -= stat2.AwayFTA;
            stat.AwayFTM -= stat2.AwayFTM;
            stat.AwayTotalRebounds -= stat2.AwayTotalRebounds;
            stat.AwayOffensiveRebounds -= stat2.AwayOffensiveRebounds;
            stat.AwayTurnovers -= stat2.AwayTurnovers;
            stat.AwaySteals -= stat2.AwaySteals;
            stat.AwayBlocks -= stat2.AwayBlocks;
            stat.AwayDefensiveRebounds -= stat2.AwayDefensiveRebounds;
            stat.AwayPITP -= stat2.AwayPITP;
            stat.AwayFastBreakPoints -= stat2.AwayFastBreakPoints;
            stat.AwayBenchPoints -= stat2.AwayBenchPoints;
            stat.AwayPointsofTO -= stat2.AwayPointsofTO;
            return stat;
        }
        public void GameModelMultiplication(GameModel stat1, GameModel stat2)
        {
            stat1.HomePoints *= stat2.HomePoints;
            stat1.HomeAssists *= stat2.HomeAssists;
            stat1.Home3PA *= stat2.Home3PA;
            stat1.Home3PM *= stat2.Home3PM;
            stat1.HomeFGA *= stat2.HomeFGA;
            stat1.HomeFGM *= stat2.HomeFGM;
            stat1.HomeFTA *= stat2.HomeFTA;
            stat1.HomeFTM *= stat2.HomeFTM;
            stat1.HomeTotalRebounds *= stat2.HomeTotalRebounds;
            stat1.HomeOffensiveRebounds *= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers *= stat2.HomeTurnovers;
            stat1.HomeSteals *= stat2.HomeSteals;
            stat1.HomeBlocks *= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds *= stat2.HomeDefensiveRebounds;
            stat1.HomePITP *= stat2.HomePITP;
            stat1.HomeFastBreakPoints *= stat2.HomeFastBreakPoints;
            stat1.HomeBenchPoints *= stat2.HomeBenchPoints;
            stat1.HomePointsofTO *= stat2.HomePointsofTO;
            stat1.AwayPoints *= stat2.AwayPoints;
            stat1.AwayAssists *= stat2.AwayAssists;
            stat1.Away3PA *= stat2.Away3PA;
            stat1.Away3PM *= stat2.Away3PM;
            stat1.AwayFGA *= stat2.AwayFGA;
            stat1.AwayFGM *= stat2.AwayFGM;
            stat1.AwayFTA *= stat2.AwayFTA;
            stat1.AwayFTM *= stat2.AwayFTM;
            stat1.AwayTotalRebounds *= stat2.AwayTotalRebounds;
            stat1.AwayOffensiveRebounds *= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers *= stat2.AwayTurnovers;
            stat1.AwaySteals *= stat2.AwaySteals;
            stat1.AwayBlocks *= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds *= stat2.AwayDefensiveRebounds;
            stat1.AwayPITP *= stat2.AwayPITP;
            stat1.AwayFastBreakPoints *= stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints *= stat2.AwayBenchPoints;
            stat1.AwayPointsofTO *= stat2.AwayPointsofTO;
        }
        public void GameModelMultiplication(FullSeason stat1, FullSeason stat2)
        {
            stat1.HomePoints *= stat2.HomePoints;
            stat1.HomeAssists *= stat2.HomeAssists;
            stat1.Home3PA *= stat2.Home3PA;
            stat1.Home3PM *= stat2.Home3PM;
            stat1.HomeFGA *= stat2.HomeFGA;
            stat1.HomeFGM *= stat2.HomeFGM;
            stat1.HomeFTA *= stat2.HomeFTA;
            stat1.HomeFTM *= stat2.HomeFTM;
            stat1.HomeTotalRebounds *= stat2.HomeTotalRebounds;
            stat1.HomeOffensiveRebounds *= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers *= stat2.HomeTurnovers;
            stat1.HomeSteals *= stat2.HomeSteals;
            stat1.HomeBlocks *= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds *= stat2.HomeDefensiveRebounds;
            stat1.HomePITP *= stat2.HomePITP;
            stat1.HomeFastBreakPoints *= stat2.HomeFastBreakPoints;
            stat1.HomeBenchPoints *= stat2.HomeBenchPoints;
            stat1.HomePointsofTO *= stat2.HomePointsofTO;
            stat1.AwayPoints *= stat2.AwayPoints;
            stat1.AwayAssists *= stat2.AwayAssists;
            stat1.Away3PA *= stat2.Away3PA;
            stat1.Away3PM *= stat2.Away3PM;
            stat1.AwayFGA *= stat2.AwayFGA;
            stat1.AwayFGM *= stat2.AwayFGM;
            stat1.AwayFTA *= stat2.AwayFTA;
            stat1.AwayFTM *= stat2.AwayFTM;
            stat1.AwayTotalRebounds *= stat2.AwayTotalRebounds;
            stat1.AwayOffensiveRebounds *= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers *= stat2.AwayTurnovers;
            stat1.AwaySteals *= stat2.AwaySteals;
            stat1.AwayBlocks *= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds *= stat2.AwayDefensiveRebounds;
            stat1.AwayPITP *= stat2.AwayPITP;
            stat1.AwayFastBreakPoints *= stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints *= stat2.AwayBenchPoints;
            stat1.AwayPointsofTO *= stat2.AwayPointsofTO;
        }
        public void GameModelSquareRoot(GameModel stat)
        {
            stat.HomePoints = Math.Sqrt(stat.HomePoints);
            stat.HomeAssists = Math.Sqrt(stat.HomeAssists);
            stat.Home3PA = Math.Sqrt(stat.Home3PA);
            stat.Home3PM = Math.Sqrt(stat.Home3PM);
            stat.HomeFGA = Math.Sqrt(stat.HomeFGA);
            stat.HomeFGM = Math.Sqrt(stat.HomeFGM);
            stat.HomeFTA = Math.Sqrt(stat.HomeFTA);
            stat.HomeFTM = Math.Sqrt(stat.HomeFTM);
            stat.HomeTotalRebounds = Math.Sqrt(stat.HomeTotalRebounds);
            stat.HomeOffensiveRebounds = Math.Sqrt(stat.HomeOffensiveRebounds);
            stat.HomeTurnovers = Math.Sqrt(stat.HomeTurnovers);
            stat.HomeSteals = Math.Sqrt(stat.HomeSteals);
            stat.HomeBlocks = Math.Sqrt(stat.HomeBlocks);
            stat.HomeDefensiveRebounds = Math.Sqrt(stat.HomeDefensiveRebounds);
            stat.HomePITP = Math.Sqrt(stat.HomePITP);
            stat.HomeFastBreakPoints = Math.Sqrt(stat.HomeFastBreakPoints);
            stat.HomeBenchPoints = Math.Sqrt(stat.HomeBenchPoints);
            stat.HomePointsofTO = Math.Sqrt(stat.HomePointsofTO);
            stat.AwayPoints = Math.Sqrt(stat.AwayPoints);
            stat.AwayAssists = Math.Sqrt(stat.AwayAssists);
            stat.Away3PA = Math.Sqrt(stat.Away3PA);
            stat.Away3PM = Math.Sqrt(stat.Away3PM);
            stat.AwayFGA = Math.Sqrt(stat.AwayFGA);
            stat.AwayFGM = Math.Sqrt(stat.AwayFGM);
            stat.AwayFTA = Math.Sqrt(stat.AwayFTA);
            stat.AwayFTM = Math.Sqrt(stat.AwayFTM);
            stat.AwayTotalRebounds = Math.Sqrt(stat.AwayTotalRebounds);
            stat.AwayOffensiveRebounds = Math.Sqrt(stat.AwayOffensiveRebounds);
            stat.AwayTurnovers = Math.Sqrt(stat.AwayTurnovers);
            stat.AwaySteals = Math.Sqrt(stat.AwaySteals);
            stat.AwayBlocks = Math.Sqrt(stat.AwayBlocks);
            stat.AwayDefensiveRebounds = Math.Sqrt(stat.AwayDefensiveRebounds);
            stat.AwayPITP = Math.Sqrt(stat.AwayPITP);
            stat.AwayFastBreakPoints = Math.Sqrt(stat.AwayFastBreakPoints);
            stat.AwayBenchPoints = Math.Sqrt(stat.AwayBenchPoints);
            stat.AwayPointsofTO = Math.Sqrt(stat.AwayPointsofTO);
        }
        public void GameModelDivision(GameModel stats, double divider)
        {
            stats.HomePoints /= divider;
            stats.HomeAssists /= divider;
            stats.Home3PA /= divider;
            stats.Home3PM /= divider;
            stats.HomeFGA /= divider;
            stats.HomeFGM /= divider;
            stats.HomeFTA /= divider;
            stats.HomeFTM /= divider;
            stats.HomeTotalRebounds /= divider;
            stats.HomeOffensiveRebounds /= divider;
            stats.HomeTurnovers /= divider;
            stats.HomeSteals /= divider;
            stats.HomeBlocks /= divider;
            stats.HomeDefensiveRebounds /= divider;
            stats.HomePITP /= divider;
            stats.HomeFastBreakPoints /= divider;
            stats.HomeBenchPoints /= divider;
            stats.HomePointsofTO /= divider;
            stats.AwayPoints /= divider;
            stats.AwayAssists /= divider;
            stats.Away3PA /= divider;
            stats.Away3PM /= divider;
            stats.AwayFGA /= divider;
            stats.AwayFGM /= divider;
            stats.AwayFTA /= divider;
            stats.AwayFTM /= divider;
            stats.AwayTotalRebounds /= divider;
            stats.AwayOffensiveRebounds /= divider;
            stats.AwayTurnovers /= divider;
            stats.AwaySteals /= divider;
            stats.AwayBlocks /= divider;
            stats.AwayDefensiveRebounds /= divider;
            stats.AwayPITP /= divider;
            stats.AwayFastBreakPoints /= divider;
            stats.AwayBenchPoints /= divider;
            stats.AwayPointsofTO /= divider;
        }
        public void GameModelDivision(GameModel stat1, GameModel stat2)
        {
            stat1.HomePoints /= stat2.HomePoints;
            stat1.HomeAssists /= stat2.HomeAssists;
            stat1.Home3PA /= stat2.Home3PA;
            stat1.Home3PM /= stat2.Home3PM;
            stat1.HomeFGA /= stat2.HomeFGA;
            stat1.HomeFGM /= stat2.HomeFGM;
            stat1.HomeFTA /= stat2.HomeFTA;
            stat1.HomeFTM /= stat2.HomeFTM;
            stat1.HomeTotalRebounds /= stat2.HomeTotalRebounds;
            stat1.HomeOffensiveRebounds /= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers /= stat2.HomeTurnovers;
            stat1.HomeSteals /= stat2.HomeSteals;
            stat1.HomeBlocks /= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds /= stat2.HomeDefensiveRebounds;
            stat1.HomePITP /= stat2.HomePITP;
            stat1.HomeFastBreakPoints /= stat2.HomeFastBreakPoints;
            stat1.HomeBenchPoints /= stat2.HomeBenchPoints;
            stat1.HomePointsofTO /= stat2.HomePointsofTO;
            stat1.AwayPoints /= stat2.AwayPoints;
            stat1.AwayAssists /= stat2.AwayAssists;
            stat1.Away3PA /= stat2.Away3PA;
            stat1.Away3PM /= stat2.Away3PM;
            stat1.AwayFGA /= stat2.AwayFGA;
            stat1.AwayFGM /= stat2.AwayFGM;
            stat1.AwayFTA /= stat2.AwayFTA;
            stat1.AwayFTM /= stat2.AwayFTM;
            stat1.AwayTotalRebounds /= stat2.AwayTotalRebounds;
            stat1.AwayOffensiveRebounds /= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers /= stat2.AwayTurnovers;
            stat1.AwaySteals /= stat2.AwaySteals;
            stat1.AwayBlocks /= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds /= stat2.AwayDefensiveRebounds;
            stat1.AwayPITP /= stat2.AwayPITP;
            stat1.AwayFastBreakPoints /= stat2.AwayFastBreakPoints;
            stat1.AwayBenchPoints /= stat2.AwayBenchPoints;
            stat1.AwayPointsofTO /= stat2.AwayPointsofTO;
        }
        public QuarterModel QuarterModelAddition(QuarterModel stat1, QuarterModel stat2)
        {
            stat1.HomePoints += stat2.HomePoints;
            stat1.HomeAssists += stat2.HomeAssists;
            stat1.Home3PA += stat2.Home3PA;
            stat1.Home3PM += stat2.Home3PM;
            stat1.HomeFGA += stat2.HomeFGA;
            stat1.HomeFGM += stat2.HomeFGM;
            stat1.HomeFTA += stat2.HomeFTA;
            stat1.HomeFTM += stat2.HomeFTM;
            stat1.HomeOffensiveRebounds += stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers += stat2.HomeTurnovers;
            stat1.HomeSteals += stat2.HomeSteals;
            stat1.HomeBlocks += stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds += stat2.HomeDefensiveRebounds;
            stat1.AwayPoints += stat2.AwayPoints;
            stat1.AwayAssists += stat2.AwayAssists;
            stat1.Away3PA += stat2.Away3PA;
            stat1.Away3PM += stat2.Away3PM;
            stat1.AwayFGA += stat2.AwayFGA;
            stat1.AwayFGM += stat2.AwayFGM;
            stat1.AwayFTA += stat2.AwayFTA;
            stat1.AwayFTM += stat2.AwayFTM;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.AwayTurnovers;
            stat1.AwaySteals += stat2.AwaySteals;
            stat1.AwayBlocks += stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
            return stat1;
        }
        public QuarterModel QuarterModelAddition(QuarterModel stat1, FullSeasonQuarters stat2)
        {
            stat1.HomePoints += stat2.HomePoints;
            stat1.HomeAssists += stat2.HomeAssists;
            stat1.Home3PA += stat2.Home3PA;
            stat1.Home3PM += stat2.Home3PM;
            stat1.HomeFGA += stat2.HomeFGA;
            stat1.HomeFGM += stat2.HomeFGM;
            stat1.HomeFTA += stat2.HomeFTA;
            stat1.HomeFTM += stat2.HomeFTM;
            stat1.HomeOffensiveRebounds += stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers += stat2.HomeTurnovers;
            stat1.HomeSteals += stat2.HomeSteals;
            stat1.HomeBlocks += stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds += stat2.HomeDefensiveRebounds;
            stat1.AwayPoints += stat2.AwayPoints;
            stat1.AwayAssists += stat2.AwayAssists;
            stat1.Away3PA += stat2.Away3PA;
            stat1.Away3PM += stat2.Away3PM;
            stat1.AwayFGA += stat2.AwayFGA;
            stat1.AwayFGM += stat2.AwayFGM;
            stat1.AwayFTA += stat2.AwayFTA;
            stat1.AwayFTM += stat2.AwayFTM;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.AwayTurnovers;
            stat1.AwaySteals += stat2.AwaySteals;
            stat1.AwayBlocks += stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
            return stat1;
        }
        public void QuarterModelAdditionSwitch(QuarterModel stat1, QuarterModel stat2)
        {
            stat1.HomePoints += stat2.AwayPoints;
            stat1.HomeAssists += stat2.AwayAssists;
            stat1.Home3PA += stat2.Away3PA;
            stat1.Home3PM += stat2.Away3PM;
            stat1.HomeFGA += stat2.AwayFGA;
            stat1.HomeFGM += stat2.AwayFGM;
            stat1.HomeFTA += stat2.AwayFTA;
            stat1.HomeFTM += stat2.AwayFTM;
            stat1.HomeOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.HomeTurnovers += stat2.AwayTurnovers;
            stat1.HomeSteals += stat2.AwaySteals;
            stat1.HomeBlocks += stat2.AwayBlocks;
            stat1.HomeDefensiveRebounds += stat2.AwayDefensiveRebounds;
            stat1.AwayPoints += stat2.HomePoints;
            stat1.AwayAssists += stat2.HomeAssists;
            stat1.Away3PA += stat2.Home3PA;
            stat1.Away3PM += stat2.Home3PM;
            stat1.AwayFGA += stat2.HomeFGA;
            stat1.AwayFGM += stat2.HomeFGM;
            stat1.AwayFTA += stat2.HomeFTA;
            stat1.AwayFTM += stat2.HomeFTM;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.HomeTurnovers;
            stat1.AwaySteals += stat2.HomeSteals;
            stat1.AwayBlocks += stat2.HomeBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
        }
        public void QuarterModelSwitch(QuarterModel stat1)
        {
            QuarterModel stat2 = new QuarterModel();
            QuarterModelAddition(stat2, stat1);
            stat1.HomePoints = stat2.AwayPoints;
            stat1.HomeAssists = stat2.AwayAssists;
            stat1.Home3PA = stat2.Away3PA;
            stat1.Home3PM = stat2.Away3PM;
            stat1.HomeFGA = stat2.AwayFGA;
            stat1.HomeFGM = stat2.AwayFGM;
            stat1.HomeFTA = stat2.AwayFTA;
            stat1.HomeFTM = stat2.AwayFTM;
            stat1.HomeOffensiveRebounds = stat2.AwayOffensiveRebounds;
            stat1.HomeTurnovers = stat2.AwayTurnovers;
            stat1.HomeSteals = stat2.AwaySteals;
            stat1.HomeBlocks = stat2.AwayBlocks;
            stat1.HomeDefensiveRebounds = stat2.AwayDefensiveRebounds;
            stat1.AwayPoints = stat2.HomePoints;
            stat1.AwayAssists = stat2.HomeAssists;
            stat1.Away3PA = stat2.Home3PA;
            stat1.Away3PM = stat2.Home3PM;
            stat1.AwayFGA = stat2.HomeFGA;
            stat1.AwayFGM = stat2.HomeFGM;
            stat1.AwayFTA = stat2.HomeFTA;
            stat1.AwayFTM = stat2.HomeFTM;
            stat1.AwayOffensiveRebounds = stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers = stat2.HomeTurnovers;
            stat1.AwaySteals = stat2.HomeSteals;
            stat1.AwayBlocks = stat2.HomeBlocks;
            stat1.AwayDefensiveRebounds = stat2.AwayDefensiveRebounds;
        }
        public void QuarterModelAdditionSwitch(FullSeasonQuarters stat1, FullSeasonQuarters stat2)
        {
            stat1.HomePoints += stat2.AwayPoints;
            stat1.HomeAssists += stat2.AwayAssists;
            stat1.Home3PA += stat2.Away3PA;
            stat1.Home3PM += stat2.Away3PM;
            stat1.HomeFGA += stat2.AwayFGA;
            stat1.HomeFGM += stat2.AwayFGM;
            stat1.HomeFTA += stat2.AwayFTA;
            stat1.HomeFTM += stat2.AwayFTM;
            stat1.HomeOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.HomeTurnovers += stat2.AwayTurnovers;
            stat1.HomeSteals += stat2.AwaySteals;
            stat1.HomeBlocks += stat2.AwayBlocks;
            stat1.HomeDefensiveRebounds += stat2.AwayDefensiveRebounds;
            stat1.AwayPoints += stat2.HomePoints;
            stat1.AwayAssists += stat2.HomeAssists;
            stat1.Away3PA += stat2.Home3PA;
            stat1.Away3PM += stat2.Home3PM;
            stat1.AwayFGA += stat2.HomeFGA;
            stat1.AwayFGM += stat2.HomeFGM;
            stat1.AwayFTA += stat2.HomeFTA;
            stat1.AwayFTM += stat2.HomeFTM;
            stat1.AwayOffensiveRebounds += stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers += stat2.HomeTurnovers;
            stat1.AwaySteals += stat2.HomeSteals;
            stat1.AwayBlocks += stat2.HomeBlocks;
            stat1.AwayDefensiveRebounds += stat2.AwayDefensiveRebounds;
        }
        public FullSeasonQuarters QuarterModelSubtraction(FullSeasonQuarters stat1, QuarterModel stat2)
        {
            stat1.HomePoints -= stat2.HomePoints;
            stat1.HomeAssists -= stat2.HomeAssists;
            stat1.Home3PA -= stat2.Home3PA;
            stat1.Home3PM -= stat2.Home3PM;
            stat1.HomeFGA -= stat2.HomeFGA;
            stat1.HomeFGM -= stat2.HomeFGM;
            stat1.HomeFTA -= stat2.HomeFTA;
            stat1.HomeFTM -= stat2.HomeFTM;
            stat1.HomeOffensiveRebounds -= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers -= stat2.HomeTurnovers;
            stat1.HomeSteals -= stat2.HomeSteals;
            stat1.HomeBlocks -= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds -= stat2.HomeDefensiveRebounds;
            stat1.AwayPoints -= stat2.AwayPoints;
            stat1.AwayAssists -= stat2.AwayAssists;
            stat1.Away3PA -= stat2.Away3PA;
            stat1.Away3PM -= stat2.Away3PM;
            stat1.AwayFGA -= stat2.AwayFGA;
            stat1.AwayFGM -= stat2.AwayFGM;
            stat1.AwayFTA -= stat2.AwayFTA;
            stat1.AwayFTM -= stat2.AwayFTM;
            stat1.AwayOffensiveRebounds -= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers -= stat2.AwayTurnovers;
            stat1.AwaySteals -= stat2.AwaySteals;
            stat1.AwayBlocks -= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds -= stat2.AwayDefensiveRebounds;
            return stat1;
        }
        public FullSeasonQuarters19_20 QuarterModelSubtraction(FullSeasonQuarters19_20 stat1, QuarterModel stat2)
        {
            stat1.HomePoints -= stat2.HomePoints;
            stat1.HomeAssists -= stat2.HomeAssists;
            stat1.Home3PA -= stat2.Home3PA;
            stat1.Home3PM -= stat2.Home3PM;
            stat1.HomeFGA -= stat2.HomeFGA;
            stat1.HomeFGM -= stat2.HomeFGM;
            stat1.HomeFTA -= stat2.HomeFTA;
            stat1.HomeFTM -= stat2.HomeFTM;
            stat1.HomeOffensiveRebounds -= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers -= stat2.HomeTurnovers;
            stat1.HomeSteals -= stat2.HomeSteals;
            stat1.HomeBlocks -= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds -= stat2.HomeDefensiveRebounds;
            stat1.AwayPoints -= stat2.AwayPoints;
            stat1.AwayAssists -= stat2.AwayAssists;
            stat1.Away3PA -= stat2.Away3PA;
            stat1.Away3PM -= stat2.Away3PM;
            stat1.AwayFGA -= stat2.AwayFGA;
            stat1.AwayFGM -= stat2.AwayFGM;
            stat1.AwayFTA -= stat2.AwayFTA;
            stat1.AwayFTM -= stat2.AwayFTM;
            stat1.AwayOffensiveRebounds -= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers -= stat2.AwayTurnovers;
            stat1.AwaySteals -= stat2.AwaySteals;
            stat1.AwayBlocks -= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds -= stat2.AwayDefensiveRebounds;
            return stat1;
        }
        public void QuarterModelMultiplication(QuarterModel stat1, QuarterModel stat2)
        {
            stat1.HomePoints *= stat2.HomePoints;
            stat1.HomeAssists *= stat2.HomeAssists;
            stat1.Home3PA *= stat2.Home3PA;
            stat1.Home3PM *= stat2.Home3PM;
            stat1.HomeFGA *= stat2.HomeFGA;
            stat1.HomeFGM *= stat2.HomeFGM;
            stat1.HomeFTA *= stat2.HomeFTA;
            stat1.HomeFTM *= stat2.HomeFTM;
            stat1.HomeOffensiveRebounds *= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers *= stat2.HomeTurnovers;
            stat1.HomeSteals *= stat2.HomeSteals;
            stat1.HomeBlocks *= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds *= stat2.HomeDefensiveRebounds;
            stat1.AwayPoints *= stat2.AwayPoints;
            stat1.AwayAssists *= stat2.AwayAssists;
            stat1.Away3PA *= stat2.Away3PA;
            stat1.Away3PM *= stat2.Away3PM;
            stat1.AwayFGA *= stat2.AwayFGA;
            stat1.AwayFGM *= stat2.AwayFGM;
            stat1.AwayFTA *= stat2.AwayFTA;
            stat1.AwayFTM *= stat2.AwayFTM;
            stat1.AwayOffensiveRebounds *= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers *= stat2.AwayTurnovers;
            stat1.AwaySteals *= stat2.AwaySteals;
            stat1.AwayBlocks *= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds *= stat2.AwayDefensiveRebounds;
        }
        public void QuarterModelMultiplication(QuarterModel stat1, FullSeasonQuarters stat2)
        {
            stat1.HomePoints *= stat2.HomePoints;
            stat1.HomeAssists *= stat2.HomeAssists;
            stat1.Home3PA *= stat2.Home3PA;
            stat1.Home3PM *= stat2.Home3PM;
            stat1.HomeFGA *= stat2.HomeFGA;
            stat1.HomeFGM *= stat2.HomeFGM;
            stat1.HomeFTA *= stat2.HomeFTA;
            stat1.HomeFTM *= stat2.HomeFTM;
            stat1.HomeOffensiveRebounds *= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers *= stat2.HomeTurnovers;
            stat1.HomeSteals *= stat2.HomeSteals;
            stat1.HomeBlocks *= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds *= stat2.HomeDefensiveRebounds;
            stat1.AwayPoints *= stat2.AwayPoints;
            stat1.AwayAssists *= stat2.AwayAssists;
            stat1.Away3PA *= stat2.Away3PA;
            stat1.Away3PM *= stat2.Away3PM;
            stat1.AwayFGA *= stat2.AwayFGA;
            stat1.AwayFGM *= stat2.AwayFGM;
            stat1.AwayFTA *= stat2.AwayFTA;
            stat1.AwayFTM *= stat2.AwayFTM;
            stat1.AwayOffensiveRebounds *= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers *= stat2.AwayTurnovers;
            stat1.AwaySteals *= stat2.AwaySteals;
            stat1.AwayBlocks *= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds *= stat2.AwayDefensiveRebounds;
        }
        public void QuarterModelSquareRoot(QuarterModel stat)
        {
            stat.HomePoints = Math.Sqrt(stat.HomePoints);
            stat.HomeAssists = Math.Sqrt(stat.HomeAssists);
            stat.Home3PA = Math.Sqrt(stat.Home3PA);
            stat.Home3PM = Math.Sqrt(stat.Home3PM);
            stat.HomeFGA = Math.Sqrt(stat.HomeFGA);
            stat.HomeFGM = Math.Sqrt(stat.HomeFGM);
            stat.HomeFTA = Math.Sqrt(stat.HomeFTA);
            stat.HomeFTM = Math.Sqrt(stat.HomeFTM);
            stat.HomeOffensiveRebounds = Math.Sqrt(stat.HomeOffensiveRebounds);
            stat.HomeTurnovers = Math.Sqrt(stat.HomeTurnovers);
            stat.HomeSteals = Math.Sqrt(stat.HomeSteals);
            stat.HomeBlocks = Math.Sqrt(stat.HomeBlocks);
            stat.HomeDefensiveRebounds = Math.Sqrt(stat.HomeDefensiveRebounds);
            stat.AwayPoints = Math.Sqrt(stat.AwayPoints);
            stat.AwayAssists = Math.Sqrt(stat.AwayAssists);
            stat.Away3PA = Math.Sqrt(stat.Away3PA);
            stat.Away3PM = Math.Sqrt(stat.Away3PM);
            stat.AwayFGA = Math.Sqrt(stat.AwayFGA);
            stat.AwayFGM = Math.Sqrt(stat.AwayFGM);
            stat.AwayFTA = Math.Sqrt(stat.AwayFTA);
            stat.AwayFTM = Math.Sqrt(stat.AwayFTM);
            stat.AwayOffensiveRebounds = Math.Sqrt(stat.AwayOffensiveRebounds);
            stat.AwayTurnovers = Math.Sqrt(stat.AwayTurnovers);
            stat.AwaySteals = Math.Sqrt(stat.AwaySteals);
            stat.AwayBlocks = Math.Sqrt(stat.AwayBlocks);
            stat.AwayDefensiveRebounds = Math.Sqrt(stat.AwayDefensiveRebounds);
        }
        public void QuarterModelDivision(QuarterModel stats, double divider)
        {
            stats.HomePoints /= divider;
            stats.HomeAssists /= divider;
            stats.Home3PA /= divider;
            stats.Home3PM /= divider;
            stats.HomeFGA /= divider;
            stats.HomeFGM /= divider;
            stats.HomeFTA /= divider;
            stats.HomeFTM /= divider;
            stats.HomeOffensiveRebounds /= divider;
            stats.HomeTurnovers /= divider;
            stats.HomeSteals /= divider;
            stats.HomeBlocks /= divider;
            stats.HomeDefensiveRebounds /= divider;
            stats.AwayPoints /= divider;
            stats.AwayAssists /= divider;
            stats.Away3PA /= divider;
            stats.Away3PM /= divider;
            stats.AwayFGA /= divider;
            stats.AwayFGM /= divider;
            stats.AwayFTA /= divider;
            stats.AwayFTM /= divider;
            stats.AwayOffensiveRebounds /= divider;
            stats.AwayTurnovers /= divider;
            stats.AwaySteals /= divider;
            stats.AwayBlocks /= divider;
            stats.AwayDefensiveRebounds /= divider;
        }
        public void QuarterModelDivision(QuarterModel stat1, QuarterModel stat2)
        {
            stat1.HomePoints /= stat2.HomePoints;
            stat1.HomeAssists /= stat2.HomeAssists;
            stat1.Home3PA /= stat2.Home3PA;
            stat1.Home3PM /= stat2.Home3PM;
            stat1.HomeFGA /= stat2.HomeFGA;
            stat1.HomeFGM /= stat2.HomeFGM;
            stat1.HomeFTA /= stat2.HomeFTA;
            stat1.HomeFTM /= stat2.HomeFTM;
            stat1.HomeOffensiveRebounds /= stat2.HomeOffensiveRebounds;
            stat1.HomeTurnovers /= stat2.HomeTurnovers;
            stat1.HomeSteals /= stat2.HomeSteals;
            stat1.HomeBlocks /= stat2.HomeBlocks;
            stat1.HomeDefensiveRebounds /= stat2.HomeDefensiveRebounds;
            stat1.AwayPoints /= stat2.AwayPoints;
            stat1.AwayAssists /= stat2.AwayAssists;
            stat1.Away3PA /= stat2.Away3PA;
            stat1.Away3PM /= stat2.Away3PM;
            stat1.AwayFGA /= stat2.AwayFGA;
            stat1.AwayFGM /= stat2.AwayFGM;
            stat1.AwayFTA /= stat2.AwayFTA;
            stat1.AwayFTM /= stat2.AwayFTM;
            stat1.AwayOffensiveRebounds /= stat2.AwayOffensiveRebounds;
            stat1.AwayTurnovers /= stat2.AwayTurnovers;
            stat1.AwaySteals /= stat2.AwaySteals;
            stat1.AwayBlocks /= stat2.AwayBlocks;
            stat1.AwayDefensiveRebounds /= stat2.AwayDefensiveRebounds;
        }
        /// <summary>
        /// This method calculates the average of every parameter in the given stats
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public GameModel AverageCalculator(List<FullSeason> stats, Team team)
        {
            var newList = new List<FullSeason>();
            foreach (var item in stats)
            {
                newList.Add(item);
            }
            newList = ArrangeStats(newList, team);
            var average = new GameModel();
            foreach (var stat in newList)
            {
                GameModelAddition(average, stat);
            }
            GameModelDivision(average, newList.Count);
            return average;
        }
        /// <summary>
        /// This method calculates the standard deviation of
        /// every parameter in the given list
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public GameModel DeviationCalculator(List<FullSeason> stats, Team team)
        {
            var newList = stats;
            var deviation = new GameModel();
            newList = ArrangeStats(newList, team);
            GameModel average = AverageCalculator(newList, team);
            foreach (var item in newList)
            {
                var asd = GameModelSubtraction(item, average);
                GameModelMultiplication(asd, asd);
                GameModelAddition(deviation, asd);
            }
            GameModelDivision(deviation, newList.Count);
            GameModelSquareRoot(deviation);
            return deviation;
        }
        /// <summary>
        /// This method calculates the average of every parameter in the given stats
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public QuarterModel AverageCalculator(List<FullSeasonQuarters> stats, Team team)
        {
            var newList = new List<FullSeasonQuarters>();
            foreach (var item in stats)
            {
                newList.Add(item);
            }
            newList = ArrangeStats(newList, team);
            var average = new QuarterModel();
            foreach (var stat in newList)
            {
                QuarterModelAddition(average, stat);
            }
            QuarterModelDivision(average, newList.Count);
            return average;
        }
        /// <summary>
        /// This method calculates the standard deviation of
        /// every parameter in the given list
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public QuarterModel DeviationCalculator(List<FullSeasonQuarters> stats, Team team)
        {
            List<FullSeasonQuarters> newList = new List<FullSeasonQuarters>();
            foreach (var quarter in stats)
            {
                FullSeasonQuarters qtr = new FullSeasonQuarters();
                QuarterModelAddition(qtr, quarter);
                newList.Add(quarter);
            }
            var deviation = new GameModel();
            newList = ArrangeStats(newList, team);
            QuarterModel average = AverageCalculator(newList, team);
            foreach (var item in newList)
            {
                var asd = QuarterModelSubtraction(item, average);
                QuarterModelMultiplication(asd, asd);
                QuarterModelAddition(deviation, asd);
            }
            QuarterModelDivision(deviation, newList.Count);
            QuarterModelSquareRoot(deviation);
            return deviation;
        }
        /// <summary>
        /// This method calculates the average of every parameter in the given stats
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public GameModel AverageCalculator(List<FullSeason19_20> stats, Team team)
        {
            var newList = new List<FullSeason19_20>();
            foreach (var item in stats)
            {
                newList.Add(item);
            }
            newList = ArrangeStats(newList, team);
            var average = new GameModel();
            foreach (var stat in newList)
            {
                GameModelAddition(average, stat);
            }
            GameModelDivision(average, newList.Count);
            return average;
        }
        /// <summary>
        /// This method calculates the standard deviation of
        /// every parameter in the given list
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public GameModel DeviationCalculator(List<FullSeason19_20> stats, Team team)
        {
            var newList = stats;
            var deviation = new GameModel();
            newList = ArrangeStats(newList, team);
            GameModel average = AverageCalculator(newList, team);
            foreach (var item in newList)
            {
                var asd = GameModelSubtraction(item, average);
                GameModelMultiplication(asd, asd);
                GameModelAddition(deviation, asd);
            }
            GameModelDivision(deviation, newList.Count);
            GameModelSquareRoot(deviation);
            return deviation;
        }
        /// <summary>
        /// This method calculates the average of every parameter in the given stats
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public QuarterModel AverageCalculator(List<FullSeasonQuarters19_20> stats, Team team)
        {
            var newList = new List<FullSeasonQuarters19_20>();
            foreach (var item in stats)
            {
                newList.Add(item);
            }
            newList = ArrangeStats(newList, team);
            var average = new QuarterModel();
            foreach (var stat in newList)
            {
                QuarterModelAddition(average, stat);
            }
            QuarterModelDivision(average, newList.Count);
            return average;
        }
        /// <summary>
        /// This method calculates the standard deviation of
        /// every parameter in the given list
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="team"></param>
        /// <returns></returns>
        public QuarterModel DeviationCalculator(List<FullSeasonQuarters19_20> stats, Team team)
        {
            List<FullSeasonQuarters19_20> newList = new List<FullSeasonQuarters19_20>();
            foreach (var quarter in stats)
            {
                FullSeasonQuarters19_20 qtr = new FullSeasonQuarters19_20();
                QuarterModelAddition(qtr, quarter);
                newList.Add(quarter);
            }
            var deviation = new GameModel();
            newList = ArrangeStats(newList, team);
            QuarterModel average = AverageCalculator(newList, team);
            foreach (var item in newList)
            {
                var asd = QuarterModelSubtraction(item, average);
                QuarterModelMultiplication(asd, asd);
                QuarterModelAddition(deviation, asd);
            }
            QuarterModelDivision(deviation, newList.Count);
            QuarterModelSquareRoot(deviation);
            return deviation;
        }
    }
}
