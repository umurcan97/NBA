using System;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace NBA.Api.Entities
{
    using NBA.Api.Interfaces;
    using NBA.Model;
    using System.Collections.Generic;

    public class StatScraper : IStatScraper
    {
        private readonly INBAContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetStatMethods _getStatMethods;

        public StatScraper(
            INBAContext dbContext,
            IUnitOfWork unitOfWork,
            IGetStatMethods getStatMethods)
        {
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
            this._getStatMethods = getStatMethods;
        }


        public Team GetTeamEnumByTeamName(string TeamName)
        {
            switch (TeamName)
            {
                case "ATLANTAHAWKS": return Team.AtlantaHawks;
                case "BOSTONCELTICS": return Team.BostonCeltics;
                case "BROOKLYNNETS": return Team.BrooklynNets;
                case "CHARLOTTEHORNETS": return Team.CharlotteHornets;
                case "CHICAGOBULLS": return Team.ChicagoBulls;
                case "CLEVELANDCAVALIERS": return Team.ClevelandCavaliers;
                case "DALLASMAVERICKS": return Team.DallasMavericks;
                case "DENVERNUGGETS": return Team.DenverNuggets;
                case "DETROITPISTONS": return Team.DetroitPistons;
                case "GOLDENSTATEWARRIORS": return Team.GoldenStateWarriors;
                case "HOUSTONROCKETS": return Team.HoustonRockets;
                case "INDIANAPACERS": return Team.IndianaPacers;
                case "LACLIPPERS": return Team.LosAngelesClippers;
                case "LOSANGELESLAKERS": return Team.LosAngelesLakers;
                case "MEMPHISGRIZZLIES": return Team.MemphisGrizzlies;
                case "MIAMIHEAT": return Team.MiamiHeat;
                case "MILWAUKEEBUCKS": return Team.MilwaukeeBucks;
                case "MINNESOTATIMBERWOLVES": return Team.MinnesotaTimberwolves;
                case "NEWORLEANSPELICANS": return Team.NewOrleansPelicans;
                case "NEWYORKKNICKS": return Team.NewYorkKnicks;
                case "OKLAHOMACITYTHUNDER": return Team.OklahomaCityThunder;
                case "ORLANDOMAGIC": return Team.OrlandoMagic;
                case "PHILADELPHIA76ERS": return Team.Philadelphia76ers;
                case "PHOENIXSUNS": return Team.PhoenixSuns;
                case "PORTLANDTRAILBLAZERS": return Team.PortlandTrailBlazers;
                case "SACRAMENTOKINGS": return Team.SacramentoKings;
                case "SANANTONIOSPURS": return Team.SanAntonioSpurs;
                case "TORONTORAPTORS": return Team.TorontoRaptors;
                case "UTAHJAZZ": return Team.UtahJazz;
                case "WASHINGTONWIZARDS": return Team.WashingtonWizards;
                default: return Team.Error;
            }
        }
        public Team GetTeamEnumByTeamId(int TeamID)
        {
            switch (TeamID)
            {
                case 0: return Team.AtlantaHawks;
                case 1: return Team.BostonCeltics;
                case 2: return Team.BrooklynNets;
                case 3: return Team.CharlotteHornets;
                case 4: return Team.ChicagoBulls;
                case 5: return Team.ClevelandCavaliers;
                case 6: return Team.DallasMavericks;
                case 7: return Team.DenverNuggets;
                case 8: return Team.DetroitPistons;
                case 9: return Team.GoldenStateWarriors;
                case 10: return Team.HoustonRockets;
                case 11: return Team.IndianaPacers;
                case 12: return Team.LosAngelesClippers;
                case 13: return Team.LosAngelesLakers;
                case 14: return Team.MemphisGrizzlies;
                case 15: return Team.MiamiHeat;
                case 16: return Team.MilwaukeeBucks;
                case 17: return Team.MinnesotaTimberwolves;
                case 18: return Team.NewOrleansPelicans;
                case 19: return Team.NewYorkKnicks;
                case 20: return Team.OklahomaCityThunder;
                case 21: return Team.OrlandoMagic;
                case 22: return Team.Philadelphia76ers;
                case 23: return Team.PhoenixSuns;
                case 24: return Team.PortlandTrailBlazers;
                case 25: return Team.SacramentoKings;
                case 26: return Team.SanAntonioSpurs;
                case 27: return Team.TorontoRaptors;
                case 28: return Team.UtahJazz;
                case 29: return Team.WashingtonWizards;
                default: return Team.Error;
            }
        }
        public Team GetTeamEnumByTeamShortName(string TeamShortName)
        {
            switch (TeamShortName)
            {
                case "ATL": return Team.AtlantaHawks;
                case "BOS": return Team.BostonCeltics;
                case "BKN": return Team.BrooklynNets;
                case "CHA": return Team.CharlotteHornets;
                case "CHI": return Team.ChicagoBulls;
                case "CLE": return Team.ClevelandCavaliers;
                case "DAL": return Team.DallasMavericks;
                case "DEN": return Team.DenverNuggets;
                case "DET": return Team.DetroitPistons;
                case "GSW": return Team.GoldenStateWarriors;
                case "HOU": return Team.HoustonRockets;
                case "IND": return Team.IndianaPacers;
                case "LAC": return Team.LosAngelesClippers;
                case "LAL": return Team.LosAngelesLakers;
                case "MEM": return Team.MemphisGrizzlies;
                case "MIA": return Team.MiamiHeat;
                case "MIL": return Team.MilwaukeeBucks;
                case "MIN": return Team.MinnesotaTimberwolves;
                case "NOP": return Team.NewOrleansPelicans;
                case "NYK": return Team.NewYorkKnicks;
                case "OKC": return Team.OklahomaCityThunder;
                case "ORL": return Team.OrlandoMagic;
                case "PHI": return Team.Philadelphia76ers;
                case "PHX": return Team.PhoenixSuns;
                case "POR": return Team.PortlandTrailBlazers;
                case "SAC": return Team.SacramentoKings;
                case "SAS": return Team.SanAntonioSpurs;
                case "TOR": return Team.TorontoRaptors;
                case "UTA": return Team.UtahJazz;
                case "WAS": return Team.WashingtonWizards;
                default: return Team.Error;
            }
        }
        public Team GetTeamEnumByTeamMascotName(string TeamMascotName)
        {
            switch (TeamMascotName)
            {
                case "HAWKS": return Team.AtlantaHawks;
                case "CELTICS": return Team.BostonCeltics;
                case "NETS": return Team.BrooklynNets;
                case "HORNETS": return Team.CharlotteHornets;
                case "BULLS": return Team.ChicagoBulls;
                case "CAVALIERS": return Team.ClevelandCavaliers;
                case "MAVERICKS": return Team.DallasMavericks;
                case "NUGGETS": return Team.DenverNuggets;
                case "PISTONS": return Team.DetroitPistons;
                case "WARRIORS": return Team.GoldenStateWarriors;
                case "ROCKETS": return Team.HoustonRockets;
                case "PACERS": return Team.IndianaPacers;
                case "CLIPPERS": return Team.LosAngelesClippers;
                case "LAKERS": return Team.LosAngelesLakers;
                case "GRIZZLIES": return Team.MemphisGrizzlies;
                case "HEAT": return Team.MiamiHeat;
                case "BUCKS": return Team.MilwaukeeBucks;
                case "TIMBERWOLVES": return Team.MinnesotaTimberwolves;
                case "PELICANS": return Team.NewOrleansPelicans;
                case "KNICKS": return Team.NewYorkKnicks;
                case "THUNDER": return Team.OklahomaCityThunder;
                case "MAGIC": return Team.OrlandoMagic;
                case "76ERS": return Team.Philadelphia76ers;
                case "SUNS": return Team.PhoenixSuns;
                case "TRAILBLAZERS": return Team.PortlandTrailBlazers;
                case "KINGS": return Team.SacramentoKings;
                case "SPURS": return Team.SanAntonioSpurs;
                case "RAPTORS": return Team.TorontoRaptors;
                case "JAZZ": return Team.UtahJazz;
                case "WIZARDS": return Team.WashingtonWizards;
                default: return Team.Error;
            }
        }
        public bool DoesGameExist(int GameNo)
        {
            bool GameExists = true;
            FullSeason game = _dbContext.FullSeason.FirstOrDefault(x => x.GameNo == GameNo);
            if (game == null)
                GameExists = false;
            return GameExists;
        }
        public bool DoesQuarterExist(int GameNo, int QuarterNo)
        {
            bool QuarterExists = true;
            FullSeasonQuarters game = _dbContext.FullSeasonQuarters.FirstOrDefault(x => x.GameNo == GameNo && x.QuarterNo == QuarterNo);
            if (game == null)
                QuarterExists = false;
            return QuarterExists;
        }
        public bool DoesQuarterExist(int GameNo)
        {
            bool QuarterExists = true;
            FullSeasonQuarters game = _dbContext.FullSeasonQuarters.FirstOrDefault(x => x.GameNo == GameNo);
            if (game == null)
                QuarterExists = false;
            return QuarterExists;
        }
        public bool DoesPlayerStatGameExist(int GameNo)
        {
            List<PlayerStats> stats = this._dbContext.PlayerStats.Where(x => x.GameNo == GameNo).ToList();
            return stats.Count != 0;
        }
        public bool DoesGamePredictionExist(int GameNo)
        {
            bool GameExists = true;
            GamePredictions game = _dbContext.GamePredictions.FirstOrDefault(x => x.GameNo == GameNo);
            if (game == null)
                GameExists = false;
            return GameExists;
        }
        public bool DoesQuarterPredictionExist(int GameNo)
        {
            bool QuarterExists = true;
            QuarterPredictions game = _dbContext.QuarterPredictions.FirstOrDefault(x => x.GameNo == GameNo);
            if (game == null)
                QuarterExists = false;
            return QuarterExists;
        }
        public void DeleteGame(int GameNo)
        {
            List<FullSeason> game = _dbContext.FullSeason.Where(x => x.GameNo == GameNo).ToList();
            for (int i = 0; i < game.Count; i++)
            {
                _dbContext.FullSeason.Remove(game[i]);
            }
            _unitOfWork.Commit();
        }
        public void DeleteQuarter(int GameNo, int QuarterNo)
        {
            FullSeasonQuarters quarter = _dbContext.FullSeasonQuarters.FirstOrDefault(x => x.GameNo == GameNo && x.QuarterNo == QuarterNo);
            _dbContext.FullSeasonQuarters.Remove(quarter);
            _unitOfWork.Commit();
        }
        public void AddStatList(List<FullSeason> Stats)
        {
            for (int i = 0; i < Stats.Count; i++)
            {
                _dbContext.FullSeason.Add(Stats[i]);
            }
            _unitOfWork.Commit();
        }
        public void AddStatGame(FullSeason Stat)
        {
            _dbContext.FullSeason.Add(Stat);
            _unitOfWork.Commit();
        }
        public void AddStatGame(FullSeason19_20 Stat)
        {
            _dbContext.FullSeason1920.Add(Stat);
            _unitOfWork.Commit();
        }
        public void AddStatQuarter(FullSeasonQuarters Stat)
        {
            _dbContext.FullSeasonQuarters.Add(Stat);
            _unitOfWork.Commit();
        }
        public void AddStatQuarter(FullSeasonQuarters19_20 Stat)
        {
            _dbContext.FullSeasonQuarters1920.Add(Stat);
            _unitOfWork.Commit();
        }
        public void AddQuarterPrediction(QuarterPredictions Quarter)
        {
            _dbContext.QuarterPredictions.Add(Quarter);
            _unitOfWork.Commit();
        }
        public void AddGamePrediction(GamePredictions game)
        {
            this._dbContext.GamePredictions.Add(game);
            _unitOfWork.Commit();
        }
        public void AddPlayerStat(PlayerStats stat)
        {
            _dbContext.PlayerStats.Add(stat);
            _unitOfWork.Commit();
        }
        public void AddPlayerStatList(List<PlayerStats> Stats)
        {
            foreach (var stat in Stats)
            {
                _dbContext.PlayerStats.Add(stat);
            }
            _unitOfWork.Commit();
        }
        public void AddPlayerInfoList(List<Players> players)
        {
            foreach (Players player in players)
            {
                Players newplayer = _getStatMethods.GetPlayerWithName(player.Name);
                if (newplayer != null)
                {
                    player.ID = newplayer.ID;
                    newplayer = this._dbContext.Players.Find(player.ID);
                    newplayer.Position = player.Position;
                    newplayer.Number = player.Number;
                    newplayer.Team = player.Team;
                    newplayer.Height = player.Height;
                    newplayer.Weight = player.Weight;
                }
                else
                {
                    this._dbContext.Players.Add(player);
                }
            }
            _unitOfWork.Commit();
        }
        public void AddGameTime(GameTime date)
        {
            _dbContext.GameTime.Add(date);
            _unitOfWork.Commit();
        }
        public DateTime DateTimeConverter(string date)
        {
            int firstComma = date.IndexOf(',');
            date = date.Substring(firstComma + 2);
            int Month = date.IndexOf(' ');
            string month = date.Substring(0, Month);
            date = date.Substring(Month + 1);
            switch (month)
            {
                case "JANUARY":
                    Month = 1;
                    break;
                case "FEBRUARY":
                    Month = 2;
                    break;
                case "MARCH":
                    Month = 3;
                    break;
                case "APRIL":
                    Month = 4;
                    break;
                case "MAY":
                    Month = 5;
                    break;
                case "JUNE":
                    Month = 6;
                    break;
                case "JULY":
                    Month = 7;
                    break;
                case "AUGUST":
                    Month = 8;
                    break;
                case "SEPTEMBER":
                    Month = 9;
                    break;
                case "OCTOBER":
                    Month = 10;
                    break;
                case "NOVEMBER":
                    Month = 11;
                    break;
                case "DECEMBER":
                    Month = 12;
                    break;
            }

            int Day = 1;
            if (date[1] == '0' || date[1] == '1' || date[1] == '2' || date[1] == '3' || date[1] == '4' ||
                date[1] == '5' || date[1] == '6' || date[1] == '7' || date[1] == '8' || date[1] == '9')
                Day = 2;
            string day = date.Substring(0, Day);
            date = date.Substring(Day + 4);
            Day = int.Parse(day);
            int Year = int.Parse(date.Substring(0, 4));
            string hour = date.Substring(5);
            if (hour[1] == ':')
                hour = hour.Insert(0, "0");
            int Hour = int.Parse(hour.Substring(0, 2));
            int Minute = int.Parse(hour.Substring(3, 2));
            if (hour.Substring(6, 2) == "PM")
            {
                Hour += 12;
                if (Hour == 24)
                {
                    Hour = 12;
                }
            }

            return DateTime.Parse(Year + "-" + Month.ToString("00") + "-" + Day.ToString("00") + " " + Hour + ":" + Minute + ":" + "00");
        }
        public GameTime DateScraper(ChromeDriver driver, int GameNo, string url)
        {
            driver.Navigate().GoToUrl(url);
            GameTime game = new GameTime();
            string date = "/html/body/div[1]/div[2]/section/div[1]/div[5]/div/div[2]/p[1]";
            game.GameDate = DateTimeConverter(driver.FindElementByXPath(date).Text);
            game.GameNo = GameNo;
            return game;
        }
        public FullSeason GameScraper(ChromeDriver driver, int GameNo)
        {
            FullSeason stat = new FullSeason();
            string AwayPITP =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[1]";
            string AwayFastBreakPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[2]";
            string AwayBenchPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[4]";
            string AwayTeamRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[5]";
            string AwayTeamTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[7]";
            string AwayPointsofTO =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[8]";
            string HomePITP =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[1]";
            string HomeFastBreakPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[2]";
            string HomeBenchPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[4]";
            string HomeTeamRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[5]";
            string HomeTeamTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[7]";
            string HomePointsofTO =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[8]";
            stat.AwayPITP = int.Parse(driver.FindElementByXPath(AwayPITP).Text);
            stat.AwayFastBreakPoints = int.Parse(driver.FindElementByXPath(AwayFastBreakPoints).Text);
            stat.AwayBenchPoints = int.Parse(driver.FindElementByXPath(AwayBenchPoints).Text);
            int awayteamreb = int.Parse(driver.FindElementByXPath(AwayTeamRebounds).Text);
            int awayteamto = int.Parse(driver.FindElementByXPath(AwayTeamTurnovers).Text);
            stat.AwayPointsofTO = int.Parse(driver.FindElementByXPath(AwayPointsofTO).Text);
            stat.HomePITP = int.Parse(driver.FindElementByXPath(HomePITP).Text);
            stat.HomeFastBreakPoints = int.Parse(driver.FindElementByXPath(HomeFastBreakPoints).Text);
            stat.HomeBenchPoints = int.Parse(driver.FindElementByXPath(HomeBenchPoints).Text);
            int hometeamreb = int.Parse(driver.FindElementByXPath(HomeTeamRebounds).Text);
            int hometeamto = int.Parse(driver.FindElementByXPath(HomeTeamTurnovers).Text);
            stat.HomePointsofTO = int.Parse(driver.FindElementByXPath(HomePointsofTO).Text);
            driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div/ul/li[2]/a").Click();
            Thread.Sleep(1000);
            int line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver.FindElementByXPath("/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string AwayTeam =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[1]/h1/span";
            string HomeTeam =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[1]/h1/span";
            string AwayFGM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string AwayFGA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Away3PM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Away3PA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string AwayFTM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string AwayFTA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string AwayOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string AwayDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string AwayAssists =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string AwaySteals =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string AwayBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string AwayTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string HomeFGM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string HomeFGA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Home3PM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Home3PA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string HomeFTM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string HomeFTA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string HomeOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string HomeDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string HomeAssists =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string HomeSteals =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string HomeBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string HomeTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            stat.GameNo = GameNo;
            stat.GameDate = _getStatMethods.GetGameDate(GameNo);
            stat.HomeTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(HomeTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            stat.AwayTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(AwayTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            try
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA).Text);
            }
            catch (Exception)
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA + "/a").Text);
            }

            try
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM).Text);
            }
            catch (Exception)
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM + "/a").Text);
            }

            try
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA).Text);
            }
            catch (Exception)
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA + "/a").Text);
            }

            try
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM).Text);
            }
            catch (Exception)
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM + "/a").Text);
            }

            try
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA).Text);
            }
            catch (Exception)
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA + "/a").Text);
            }

            try
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM).Text);
            }
            catch (Exception)
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM + "/a").Text);
            }

            try
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists).Text);
            }
            catch (Exception)
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists + "/a").Text);
            }

            try
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks).Text);
            }
            catch (Exception)
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks + "/a").Text);
            }

            try
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers).Text) + hometeamto;
            }
            catch (Exception)
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers + "/a").Text) + hometeamto;
            }

            try
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals).Text);
            }
            catch (Exception)
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals + "/a").Text);
            }

            stat.HomePoints = stat.HomeFGM * 2 + stat.Home3PM + stat.HomeFTM;
            stat.HomeTotalRebounds = stat.HomeDefensiveRebounds + stat.HomeOffensiveRebounds + hometeamreb;
            try
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA).Text);
            }
            catch (Exception)
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA + "/a").Text);
            }

            try
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM).Text);
            }
            catch (Exception)
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM + "/a").Text);
            }

            try
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA).Text);
            }
            catch (Exception)
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA + "/a").Text);
            }

            try
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM).Text);
            }
            catch (Exception)
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM + "/a").Text);
            }

            try
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA).Text);
            }
            catch (Exception)
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA + "/a").Text);
            }

            try
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM).Text);
            }
            catch (Exception)
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM + "/a").Text);
            }

            try
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists).Text);
            }
            catch (Exception)
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists + "/a").Text);
            }

            try
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks).Text);
            }
            catch (Exception)
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks + "/a").Text);
            }

            try
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers).Text) + awayteamto;
            }
            catch (Exception)
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers + "/a").Text) + awayteamto;
            }

            try
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals).Text);
            }
            catch (Exception)
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals + "/a").Text);
            }

            stat.AwayPoints = stat.AwayFGM * 2 + stat.Away3PM + stat.AwayFTM;
            stat.AwayTotalRebounds = stat.AwayDefensiveRebounds + stat.AwayOffensiveRebounds + awayteamreb;
            return stat;
        }
        public FullSeason19_20 GameScraper1920(ChromeDriver driver, int GameNo, string url)
        {
            driver.Navigate().GoToUrl(url);
            FullSeason19_20 stat = new FullSeason19_20();
            string AwayPITP =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[1]";
            string AwayFastBreakPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[2]";
            string AwayBenchPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[4]";
            string AwayTeamRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[5]";
            string AwayTeamTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[7]";
            string AwayPointsofTO =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[1]/td[8]";
            string HomePITP =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[1]";
            string HomeFastBreakPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[2]";
            string HomeBenchPoints =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[4]";
            string HomeTeamRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[5]";
            string HomeTeamTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[7]";
            string HomePointsofTO =
                "/html/body/div[1]/div[2]/div[4]/section[1]/div/div/table[2]/tbody/tr[2]/td[8]";
            stat.AwayPITP = int.Parse(driver.FindElementByXPath(AwayPITP).Text);
            stat.AwayFastBreakPoints = int.Parse(driver.FindElementByXPath(AwayFastBreakPoints).Text);
            stat.AwayBenchPoints = int.Parse(driver.FindElementByXPath(AwayBenchPoints).Text);
            int awayteamreb = int.Parse(driver.FindElementByXPath(AwayTeamRebounds).Text);
            int awayteamto = int.Parse(driver.FindElementByXPath(AwayTeamTurnovers).Text);
            stat.AwayPointsofTO = int.Parse(driver.FindElementByXPath(AwayPointsofTO).Text);
            stat.HomePITP = int.Parse(driver.FindElementByXPath(HomePITP).Text);
            stat.HomeFastBreakPoints = int.Parse(driver.FindElementByXPath(HomeFastBreakPoints).Text);
            stat.HomeBenchPoints = int.Parse(driver.FindElementByXPath(HomeBenchPoints).Text);
            int hometeamreb = int.Parse(driver.FindElementByXPath(HomeTeamRebounds).Text);
            int hometeamto = int.Parse(driver.FindElementByXPath(HomeTeamTurnovers).Text);
            stat.HomePointsofTO = int.Parse(driver.FindElementByXPath(HomePointsofTO).Text);
            driver.FindElementByXPath("/html/body/div[1]/div[2]/div[2]/div/ul/li[2]/a").Click();
            Thread.Sleep(1000);
            int line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver.FindElementByXPath("/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string AwayTeam =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[1]/h1/span";
            string HomeTeam =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[1]/h1/span";
            string AwayFGM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string AwayFGA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Away3PM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Away3PA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string AwayFTM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string AwayFTA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string AwayOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string AwayDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string AwayAssists =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string AwaySteals =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string AwayBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string AwayTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string HomeFGM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string HomeFGA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Home3PM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Home3PA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string HomeFTM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string HomeFTA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string HomeOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string HomeDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string HomeAssists =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string HomeSteals =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string HomeBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string HomeTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            stat.GameNo = GameNo;
            stat.HomeTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(HomeTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            stat.AwayTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(AwayTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            try
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA).Text);
            }
            catch (Exception)
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA + "/a").Text);
            }

            try
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM).Text);
            }
            catch (Exception)
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM + "/a").Text);
            }

            try
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA).Text);
            }
            catch (Exception)
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA + "/a").Text);
            }

            try
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM).Text);
            }
            catch (Exception)
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM + "/a").Text);
            }

            try
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA).Text);
            }
            catch (Exception)
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA + "/a").Text);
            }

            try
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM).Text);
            }
            catch (Exception)
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM + "/a").Text);
            }

            try
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists).Text);
            }
            catch (Exception)
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists + "/a").Text);
            }

            try
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks).Text);
            }
            catch (Exception)
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks + "/a").Text);
            }

            try
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers).Text) + hometeamto;
            }
            catch (Exception)
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers + "/a").Text) + hometeamto;
            }

            try
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals).Text);
            }
            catch (Exception)
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals + "/a").Text);
            }

            stat.HomePoints = stat.HomeFGM * 2 + stat.Home3PM + stat.HomeFTM;
            stat.HomeTotalRebounds = stat.HomeDefensiveRebounds + stat.HomeOffensiveRebounds + hometeamreb;
            try
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA).Text);
            }
            catch (Exception)
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA + "/a").Text);
            }

            try
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM).Text);
            }
            catch (Exception)
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM + "/a").Text);
            }

            try
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA).Text);
            }
            catch (Exception)
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA + "/a").Text);
            }

            try
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM).Text);
            }
            catch (Exception)
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM + "/a").Text);
            }

            try
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA).Text);
            }
            catch (Exception)
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA + "/a").Text);
            }

            try
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM).Text);
            }
            catch (Exception)
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM + "/a").Text);
            }

            try
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists).Text);
            }
            catch (Exception)
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists + "/a").Text);
            }

            try
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks).Text);
            }
            catch (Exception)
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks + "/a").Text);
            }

            try
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers).Text) + awayteamto;
            }
            catch (Exception)
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers + "/a").Text) + awayteamto;
            }

            try
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals).Text);
            }
            catch (Exception)
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals + "/a").Text);
            }

            stat.AwayPoints = stat.AwayFGM * 2 + stat.Away3PM + stat.AwayFTM;
            stat.AwayTotalRebounds = stat.AwayDefensiveRebounds + stat.AwayOffensiveRebounds + awayteamreb;
            return stat;
        }
        public FullSeasonQuarters QuarterScraper(ChromeDriver driver, int GameNo, int QuarterNo)
        {
            FullSeasonQuarters stat = new FullSeasonQuarters();
            switch (QuarterNo)
            {
                case 1:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[2]")
                        .Click();
                    break;
                case 2:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[3]")
                        .Click();
                    break;
                case 3:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[4]")
                        .Click();
                    break;
                case 4:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[5]")
                        .Click();
                    break;
                default: break;
            }

            Thread.Sleep(2000);
            int line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver.FindElementByXPath("/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string AwayTeam =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[1]/h1/span";
            string HomeTeam =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[1]/h1/span";
            string AwayFGM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string AwayFGA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Away3PM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Away3PA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string AwayFTM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string AwayFTA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string AwayOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string AwayDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string AwayAssists =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string AwaySteals =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string AwayBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string AwayTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string HomeFGM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string HomeFGA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Home3PM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Home3PA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string HomeFTM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string HomeFTA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string HomeOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string HomeDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string HomeAssists =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string HomeSteals =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string HomeBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string HomeTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            stat.GameNo = GameNo;
            stat.QuarterNo = QuarterNo;
            stat.HomeTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(HomeTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            stat.AwayTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(AwayTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            try
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA).Text);
            }
            catch (Exception)
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA + "/a").Text);
            }

            try
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM).Text);
            }
            catch (Exception)
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM + "/a").Text);
            }

            try
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA).Text);
            }
            catch (Exception)
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA + "/a").Text);
            }

            try
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM).Text);
            }
            catch (Exception)
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM + "/a").Text);
            }

            try
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA).Text);
            }
            catch (Exception)
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA + "/a").Text);
            }

            try
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM).Text);
            }
            catch (Exception)
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM + "/a").Text);
            }

            try
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists).Text);
            }
            catch (Exception)
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists + "/a").Text);
            }

            try
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks).Text);
            }
            catch (Exception)
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks + "/a").Text);
            }

            try
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers).Text);
            }
            catch (Exception)
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers + "/a").Text);
            }

            try
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals).Text);
            }
            catch (Exception)
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals + "/a").Text);
            }

            stat.HomePoints = stat.HomeFGM * 2 + stat.Home3PM + stat.HomeFTM;
            try
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA).Text);
            }
            catch (Exception)
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA + "/a").Text);
            }

            try
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM).Text);
            }
            catch (Exception)
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM + "/a").Text);
            }

            try
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA).Text);
            }
            catch (Exception)
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA + "/a").Text);
            }

            try
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM).Text);
            }
            catch (Exception)
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM + "/a").Text);
            }

            try
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA).Text);
            }
            catch (Exception)
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA + "/a").Text);
            }

            try
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM).Text);
            }
            catch (Exception)
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM + "/a").Text);
            }

            try
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists).Text);
            }
            catch (Exception)
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists + "/a").Text);
            }

            try
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks).Text);
            }
            catch (Exception)
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks + "/a").Text);
            }

            try
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers).Text);
            }
            catch (Exception)
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers + "/a").Text);
            }

            try
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals).Text);
            }
            catch (Exception)
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals + "/a").Text);
            }

            stat.AwayPoints = stat.AwayFGM * 2 + stat.Away3PM + stat.AwayFTM;
            return stat;
        }
        public FullSeasonQuarters19_20 QuarterScraper1920(ChromeDriver driver, int GameNo, int QuarterNo)
        {
            driver.Navigate().GoToUrl("https://www.nba.com/game/002190" + GameNo.ToString("0000") + "/box-score");
            FullSeasonQuarters19_20 stat = new FullSeasonQuarters19_20();
            switch (QuarterNo)
            {
                case 1:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[2]")
                        .Click();
                    break;
                case 2:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[3]")
                        .Click();
                    break;
                case 3:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[4]")
                        .Click();
                    break;
                case 4:
                    driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[1]/div/form/div[2]/label/div/select/option[5]")
                        .Click();
                    break;
                default: break;
            }

            Thread.Sleep(2000);
            int line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver.FindElementByXPath("/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string AwayTeam =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[1]/h1/span";
            string HomeTeam =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[1]/h1/span";
            string AwayFGM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string AwayFGA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Away3PM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Away3PA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string AwayFTM =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string AwayFTA =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string AwayOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string AwayDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string AwayAssists =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string AwaySteals =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string AwayBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string AwayTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            line = 16;
            for (; line >= 5; line--)
            {
                try
                {
                    int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[3]/a").Text);
                    break;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            string HomeFGM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[3]";
            string HomeFGA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[4]";
            string Home3PM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[6]";
            string Home3PA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[7]";
            string HomeFTM =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[9]";
            string HomeFTA =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[10]";
            string HomeOffensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[12]";
            string HomeDefensiveRebounds =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[13]";
            string HomeAssists =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[15]";
            string HomeSteals =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[16]";
            string HomeBlocks =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[17]";
            string HomeTurnovers =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line + "]/td[18]";
            stat.GameNo = GameNo;
            stat.QuarterNo = QuarterNo;
            stat.HomeTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(HomeTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            stat.AwayTeam = GetTeamEnumByTeamName(driver.FindElementByXPath(AwayTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            try
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA).Text);
            }
            catch (Exception)
            {
                stat.HomeFGA = int.Parse(driver.FindElementByXPath(HomeFGA + "/a").Text);
            }

            try
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM).Text);
            }
            catch (Exception)
            {
                stat.HomeFGM = int.Parse(driver.FindElementByXPath(HomeFGM + "/a").Text);
            }

            try
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA).Text);
            }
            catch (Exception)
            {
                stat.Home3PA = int.Parse(driver.FindElementByXPath(Home3PA + "/a").Text);
            }

            try
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM).Text);
            }
            catch (Exception)
            {
                stat.Home3PM = int.Parse(driver.FindElementByXPath(Home3PM + "/a").Text);
            }

            try
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA).Text);
            }
            catch (Exception)
            {
                stat.HomeFTA = int.Parse(driver.FindElementByXPath(HomeFTA + "/a").Text);
            }

            try
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM).Text);
            }
            catch (Exception)
            {
                stat.HomeFTM = int.Parse(driver.FindElementByXPath(HomeFTM + "/a").Text);
            }

            try
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists).Text);
            }
            catch (Exception)
            {
                stat.HomeAssists = int.Parse(driver.FindElementByXPath(HomeAssists + "/a").Text);
            }

            try
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.HomeOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks).Text);
            }
            catch (Exception)
            {
                stat.HomeBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks + "/a").Text);
            }

            try
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers).Text);
            }
            catch (Exception)
            {
                stat.HomeTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers + "/a").Text);
            }

            try
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals).Text);
            }
            catch (Exception)
            {
                stat.HomeSteals = int.Parse(driver.FindElementByXPath(HomeSteals + "/a").Text);
            }

            stat.HomePoints = stat.HomeFGM * 2 + stat.Home3PM + stat.HomeFTM;
            try
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA).Text);
            }
            catch (Exception)
            {
                stat.AwayFGA = int.Parse(driver.FindElementByXPath(AwayFGA + "/a").Text);
            }

            try
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM).Text);
            }
            catch (Exception)
            {
                stat.AwayFGM = int.Parse(driver.FindElementByXPath(AwayFGM + "/a").Text);
            }

            try
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA).Text);
            }
            catch (Exception)
            {
                stat.Away3PA = int.Parse(driver.FindElementByXPath(Away3PA + "/a").Text);
            }

            try
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM).Text);
            }
            catch (Exception)
            {
                stat.Away3PM = int.Parse(driver.FindElementByXPath(Away3PM + "/a").Text);
            }

            try
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA).Text);
            }
            catch (Exception)
            {
                stat.AwayFTA = int.Parse(driver.FindElementByXPath(AwayFTA + "/a").Text);
            }

            try
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM).Text);
            }
            catch (Exception)
            {
                stat.AwayFTM = int.Parse(driver.FindElementByXPath(AwayFTM + "/a").Text);
            }

            try
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists).Text);
            }
            catch (Exception)
            {
                stat.AwayAssists = int.Parse(driver.FindElementByXPath(AwayAssists + "/a").Text);
            }

            try
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds).Text);
            }
            catch (Exception)
            {
                stat.AwayOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds + "/a").Text);
            }

            try
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks).Text);
            }
            catch (Exception)
            {
                stat.AwayBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks + "/a").Text);
            }

            try
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers).Text);
            }
            catch (Exception)
            {
                stat.AwayTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers + "/a").Text);
            }

            try
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals).Text);
            }
            catch (Exception)
            {
                stat.AwaySteals = int.Parse(driver.FindElementByXPath(AwaySteals + "/a").Text);
            }

            stat.AwayPoints = stat.AwayFGM * 2 + stat.Away3PM + stat.AwayFTM;
            return stat;
        }
        public List<PlayerStats> PlayerStatScraper(ChromeDriver driver, int GameNo)
        {
            Thread.Sleep(1500);
            string AwayTeam =
                "/html/body/div[1]/div[2]/div[4]/section[2]/div[1]/h1/span";
            string HomeTeam =
                "/html/body/div[1]/div[2]/div[4]/section[3]/div[1]/h1/span";
            List<Players> homePlayers = new List<Players>();
            List<Players> awayPlayers = new List<Players>();
            Team Home = GetTeamEnumByTeamName(driver.FindElementByXPath(HomeTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            Team Away = GetTeamEnumByTeamName(driver.FindElementByXPath(AwayTeam).Text.Replace(" ", "").ToUpper()
                .Replace('İ', 'I'));
            int line = 16;
            for (; line >= 1; line--)
            {
                try
                {
                    int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[21]").Text);
                    Players Player = _getStatMethods.GetPlayerWithName(
                        driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[1]/div/a/span").Text);
                    Player.line = line;
                    awayPlayers.Add(Player);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            line = 16;
            for (; line >= 1; line--)
            {
                try
                {
                    int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[21]").Text);
                    Players Player = _getStatMethods.GetPlayerWithName(
                        driver.FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + line +
                            "]/td[1]/div/a/span").Text);
                    Player.line = line;
                    homePlayers.Add(Player);
                }
                catch (Exception)
                {
                    continue;
                }
            }
            List<PlayerStats> Stats = new List<PlayerStats>();
            foreach (var player in homePlayers)
            {
                PlayerStats stat = new PlayerStats();
                stat.Player = player;
                stat.GameNo = GameNo;
                string HomeMinutes =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[2]";
                string HomeFGM =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[3]";
                string HomeFGA =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[4]";
                string Home3PM =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[6]";
                string Home3PA =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[7]";
                string HomeFTM =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[9]";
                string HomeFTA =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[10]";
                string HomeOffensiveRebounds =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[12]";
                string HomeDefensiveRebounds =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[13]";
                string HomeAssists =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[15]";
                string HomeSteals =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[16]";
                string HomeBlocks =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[17]";
                string HomeTurnovers =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[18]";
                string HomeFouls =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[19]";
                string HomePlusMinus =
                    "/html/body/div[1]/div[2]/div[4]/section[3]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[21]";

                string time = driver.FindElementByXPath(HomeMinutes).Text;
                stat.Minutes = int.Parse(time.Substring(0, time.IndexOf(':')));
                stat.Seconds = int.Parse(time.Substring(time.IndexOf(':') + 1, 2));
                stat.PlayerFouls = int.Parse(driver.FindElementByXPath(HomeFouls).Text);
                stat.PlayerPlusMinus = int.Parse(driver.FindElementByXPath(HomePlusMinus).Text);
                try
                {
                    stat.PlayerFGA = int.Parse(driver.FindElementByXPath(HomeFGA).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFGA = int.Parse(driver.FindElementByXPath(HomeFGA + "/a").Text);
                }

                try
                {
                    stat.PlayerFGM = int.Parse(driver.FindElementByXPath(HomeFGM).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFGM = int.Parse(driver.FindElementByXPath(HomeFGM + "/a").Text);
                }

                try
                {
                    stat.Player3PA = int.Parse(driver.FindElementByXPath(Home3PA).Text);
                }
                catch (Exception)
                {
                    stat.Player3PA = int.Parse(driver.FindElementByXPath(Home3PA + "/a").Text);
                }

                try
                {
                    stat.Player3PM = int.Parse(driver.FindElementByXPath(Home3PM).Text);
                }
                catch (Exception)
                {
                    stat.Player3PM = int.Parse(driver.FindElementByXPath(Home3PM + "/a").Text);
                }

                try
                {
                    stat.PlayerFTA = int.Parse(driver.FindElementByXPath(HomeFTA).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFTA = int.Parse(driver.FindElementByXPath(HomeFTA + "/a").Text);
                }

                try
                {
                    stat.PlayerFTM = int.Parse(driver.FindElementByXPath(HomeFTM).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFTM = int.Parse(driver.FindElementByXPath(HomeFTM + "/a").Text);
                }

                try
                {
                    stat.PlayerAssists = int.Parse(driver.FindElementByXPath(HomeAssists).Text);
                }
                catch (Exception)
                {
                    stat.PlayerAssists = int.Parse(driver.FindElementByXPath(HomeAssists + "/a").Text);
                }

                try
                {
                    stat.PlayerDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds).Text);
                }
                catch (Exception)
                {
                    stat.PlayerDefensiveRebounds = int.Parse(driver.FindElementByXPath(HomeDefensiveRebounds + "/a").Text);
                }

                try
                {
                    stat.PlayerOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds).Text);
                }
                catch (Exception)
                {
                    stat.PlayerOffensiveRebounds = int.Parse(driver.FindElementByXPath(HomeOffensiveRebounds + "/a").Text);
                }

                try
                {
                    stat.PlayerBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks).Text);
                }
                catch (Exception)
                {
                    stat.PlayerBlocks = int.Parse(driver.FindElementByXPath(HomeBlocks + "/a").Text);
                }

                try
                {
                    stat.PlayerTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers).Text);
                }
                catch (Exception)
                {
                    stat.PlayerTurnovers = int.Parse(driver.FindElementByXPath(HomeTurnovers + "/a").Text);
                }

                try
                {
                    stat.PlayerSteals = int.Parse(driver.FindElementByXPath(HomeSteals).Text);
                }
                catch (Exception)
                {
                    stat.PlayerSteals = int.Parse(driver.FindElementByXPath(HomeSteals + "/a").Text);
                }

                stat.PlayerPoints = stat.PlayerFGM * 2 + stat.Player3PM + stat.PlayerFTM;
                Stats.Add(stat);
            }
            foreach (var player in awayPlayers)
            {
                PlayerStats stat = new PlayerStats();
                stat.Player = player;
                stat.GameNo = GameNo;
                string AwayMinutes =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[2]";
                string AwayFGM =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[3]";
                string AwayFGA =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[4]";
                string Away3PM =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[6]";
                string Away3PA =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[7]";
                string AwayFTM =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[9]";
                string AwayFTA =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[10]";
                string AwayOffensiveRebounds =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[12]";
                string AwayDefensiveRebounds =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[13]";
                string AwayAssists =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[15]";
                string AwaySteals =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[16]";
                string AwayBlocks =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[17]";
                string AwayTurnovers =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[18]";
                string AwayFouls =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[19]";
                string AwayPlusMinus =
                    "/html/body/div[1]/div[2]/div[4]/section[2]/div[2]/div[2]/div/table/tbody/tr[" + player.line + "]/td[21]";

                string time = driver.FindElementByXPath(AwayMinutes).Text;
                stat.Minutes = int.Parse(time.Substring(0, time.IndexOf(':')));
                stat.Seconds = int.Parse(time.Substring(time.IndexOf(':') + 1, 2));
                stat.PlayerFouls = int.Parse(driver.FindElementByXPath(AwayFouls).Text);
                stat.PlayerPlusMinus = int.Parse(driver.FindElementByXPath(AwayPlusMinus).Text);
                try
                {
                    stat.PlayerFGA = int.Parse(driver.FindElementByXPath(AwayFGA).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFGA = int.Parse(driver.FindElementByXPath(AwayFGA + "/a").Text);
                }

                try
                {
                    stat.PlayerFGM = int.Parse(driver.FindElementByXPath(AwayFGM).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFGM = int.Parse(driver.FindElementByXPath(AwayFGM + "/a").Text);
                }

                try
                {
                    stat.Player3PA = int.Parse(driver.FindElementByXPath(Away3PA).Text);
                }
                catch (Exception)
                {
                    stat.Player3PA = int.Parse(driver.FindElementByXPath(Away3PA + "/a").Text);
                }

                try
                {
                    stat.Player3PM = int.Parse(driver.FindElementByXPath(Away3PM).Text);
                }
                catch (Exception)
                {
                    stat.Player3PM = int.Parse(driver.FindElementByXPath(Away3PM + "/a").Text);
                }

                try
                {
                    stat.PlayerFTA = int.Parse(driver.FindElementByXPath(AwayFTA).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFTA = int.Parse(driver.FindElementByXPath(AwayFTA + "/a").Text);
                }

                try
                {
                    stat.PlayerFTM = int.Parse(driver.FindElementByXPath(AwayFTM).Text);
                }
                catch (Exception)
                {
                    stat.PlayerFTM = int.Parse(driver.FindElementByXPath(AwayFTM + "/a").Text);
                }

                try
                {
                    stat.PlayerAssists = int.Parse(driver.FindElementByXPath(AwayAssists).Text);
                }
                catch (Exception)
                {
                    stat.PlayerAssists = int.Parse(driver.FindElementByXPath(AwayAssists + "/a").Text);
                }

                try
                {
                    stat.PlayerDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds).Text);
                }
                catch (Exception)
                {
                    stat.PlayerDefensiveRebounds = int.Parse(driver.FindElementByXPath(AwayDefensiveRebounds + "/a").Text);
                }

                try
                {
                    stat.PlayerOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds).Text);
                }
                catch (Exception)
                {
                    stat.PlayerOffensiveRebounds = int.Parse(driver.FindElementByXPath(AwayOffensiveRebounds + "/a").Text);
                }

                try
                {
                    stat.PlayerBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks).Text);
                }
                catch (Exception)
                {
                    stat.PlayerBlocks = int.Parse(driver.FindElementByXPath(AwayBlocks + "/a").Text);
                }

                try
                {
                    stat.PlayerTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers).Text);
                }
                catch (Exception)
                {
                    stat.PlayerTurnovers = int.Parse(driver.FindElementByXPath(AwayTurnovers + "/a").Text);
                }

                try
                {
                    stat.PlayerSteals = int.Parse(driver.FindElementByXPath(AwaySteals).Text);
                }
                catch (Exception)
                {
                    stat.PlayerSteals = int.Parse(driver.FindElementByXPath(AwaySteals + "/a").Text);
                }

                stat.PlayerPoints = stat.PlayerFGM * 2 + stat.Player3PM + stat.PlayerFTM;
                Stats.Add(stat);
            }

            return Stats;
        }
        public List<Players> PlayerInfoScraper(ChromeDriver driver, int No1, int No2)
        {
            List<Players> players = new List<Players>();
            driver.Navigate().GoToUrl("https://www.nba.com/players");
            Thread.Sleep(5000);
            driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            Thread.Sleep(500);
            driver.FindElementByXPath("/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[1]/div[7]/div/div[3]/div/label/div/select/option[1]").Click();
            for (int i = No1; i <= No2; i++)
            {
                Players player = new Players();
                player.Name = driver
                    .FindElementByXPath(
                        "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                        "]/td[1]/a/div[2]").Text.Replace("\n", " ").Replace("\r", "");
                try
                {
                    player.Team = GetTeamEnumByTeamShortName(driver.FindElementByXPath(
                        "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                        "]/td[2]/a").Text);
                }
                catch (Exception)
                {
                    player.Team = Team.Error;
                }
                try
                {
                    player.Number = int.Parse(driver
                        .FindElementByXPath(
                            "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                            "]/td[3]").Text);
                }
                catch (Exception)
                {
                    player.Number = -1;
                }
                player.Position = driver
                    .FindElementByXPath(
                        "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                        "]/td[4]")
                    .Text;
                string height = driver.FindElementByXPath(
                    "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                    "]/td[5]").Text;
                int feet = int.Parse(height.Substring(0, 1));
                int inches = int.Parse(height.Remove(0, 2));
                player.Height = Convert.ToInt16(Math.Round(30.48 * feet + 2.54 * inches));
                string weight = driver
                    .FindElementByXPath(
                        "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                        "]/td[6]").Text;
                player.Weight = Convert.ToInt16(Math.Round(int.Parse(weight.Substring(0, 3)) / 2.2));
                player.Country = driver
                    .FindElementByXPath(
                        "/html/body/div[1]/div[2]/div[3]/section/div/div[2]/div[2]/div/div/div/table/tbody/tr[" + i +
                        "]/td[8]").Text;
                players.Add(player);
            }
            return players;
        }
        public List<GameTime> GetListOfGamesPlayed()
        {
            DateTime date = DateTime.Now.AddHours(-8);
            List<GameTime> games = this._dbContext.GameTime.Where(x => x.GameDate < date).OrderBy(z=>z.GameDate).ToList();
            return games;
        }
        public List<GameTime> GetListOfGamesPlayedTillTomorrow()
        {
            DateTime date = DateTime.Now.AddHours(16);
            List<GameTime> games = this._dbContext.GameTime.Where(x=> x.GameDate < date).OrderBy(z => z.GameDate).ToList();
            return games;
        }
        public List<GameTime> GetListOfGamesToBePlayed()
        {
            DateTime date = DateTime.Now.AddHours(-8);
            DateTime date2 = DateTime.Now.AddHours(16);
            List<GameTime> games = this._dbContext.GameTime.Where(x => x.GameDate > date && x.GameDate < date2).OrderBy(z => z.GameDate).ToList();
            return games;
        }
    }
}
