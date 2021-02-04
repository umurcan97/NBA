using NBA.Api.Entities;
using NBA.Api.Interfaces;
using NBA.Model;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace NBA.StatScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            INBAContext db = new NBAContext();
            IUnitOfWork uw = new UnitOfWork(db);
            IGetStatMethods _getStatMethods = new GetStatMethods(db);
            IStatScraper _statScraper = new Api.Entities.StatScraper(db, uw, _getStatMethods);
            IStatCalculator _statCalculator = new StatCalculator(db, _getStatMethods);
            ISimulator _simulator = new Simulator(_statCalculator, _getStatMethods);
            IPredictor _predictor = new Predictor(db, uw, _getStatMethods, _simulator, _statScraper);
            //for (int i = 200; i < 707; i++)
            //{
            //    IPredictor predictor=new Predictor(_getStatMethods,_simulator,_statScraper);
            //    predictor.PredictQuarter(1,i);
            //}
            //for (int i = 708; i < 972; i++)
            //{
            //    IPredictor predictor = new Predictor(_getStatMethods, _simulator, _statScraper);
            //    predictor.PredictQuarter(1, i);
            //}
            //QuarterPredictions quarter1 = _simulator.QuarterSimulator(Team.MemphisGrizzlies, Team.LosAngelesLakers, 1, 87);
            //QuarterPredictions quarter2 = _simulator.QuarterSimulator(Team.MemphisGrizzlies, Team.LosAngelesLakers, 2, 87);
            //QuarterPredictions quarter3 = _simulator.QuarterSimulator(Team.MemphisGrizzlies, Team.LosAngelesLakers, 3, 87);
            //QuarterPredictions quarter4 = _simulator.QuarterSimulator(Team.MemphisGrizzlies, Team.LosAngelesLakers, 4, 87);

            ////FullGame
            //int i = 0;
            //int k = 1;
            //try
            //{
            //    int gameNo = _getStatMethods.GetLatestGameNoFullSeason() + 1;
            //    i = gameNo / 25;
            //    k = gameNo % 25;
            //}
            //catch (Exception)
            //{
            //    int gameNo = 0;
            //    bool GameExist = true;
            //    while (GameExist == true)
            //    {
            //        gameNo += 1;
            //        GameExist = _statScraper.DoesGameExist(gameNo);
            //    }
            //}
            //for (; i < 23; i++)
            //{
            //    using (var driver = new ChromeDriver())
            //    {
            //        driver.Manage().Window.Maximize();
            //        driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //        Thread.Sleep(2000);
            //        driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //        int nextgameno = _getStatMethods.GetNextGame(DateTime.Now.AddHours(-8));
            //        if (game.GameNo >= nextgameno)
            //            return;
            //        for (; k < 25; k++)
            //        {
            //            if (game.GameNo >= nextgameno)
            //                return;
            //            if (game.GameNo == 16 || game.GameNo == 145 || game.GameNo == 154 || game.GameNo == 160 || game.GameNo == 166 || game.GameNo == 167 || game.GameNo == 171 || game.GameNo == 179 || game.GameNo == 183 || game.GameNo == 185 || game.GameNo == 194 || game.GameNo == 197 || game.GameNo == 199 || game.GameNo == 204 || game.GameNo == 215 || game.GameNo == 225 || game.GameNo == 235 || game.GameNo == 240 || game.GameNo == 255 || game.GameNo == 263 || game.GameNo == 264 || game.GameNo == 278 || game.GameNo == 321)
            //                continue;
            //            bool GameExists = _statScraper.DoesGameExist(game.GameNo);
            //            if (GameExists)
            //            {
            //                continue;
            //            }
            //            try
            //            {
            //                FullSeason stat = _statScraper.GameScraper(driver, game.GameNo,
            //                    "https://www.nba.com/game/002200" + (game.GameNo).ToString("0000"));
            //                _statScraper.AddStatGame(stat);
            //            }
            //            catch (Exception)
            //            {
            //                k--;
            //            }
            //        }
            //    }
            //    k = 0;
            //}

            ////FullGame

            //List<GameTime> games = _statScraper.GetListOfGamesPlayed();


            //using (var driver = new ChromeDriver())
            //{

            //    driver.Manage().Window.Maximize();
            //    driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //    Thread.Sleep(2000);
            //    driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //    foreach (var game in games)
            //    {
            //        if (game.GameNo == 16 || game.GameNo == 145 || game.GameNo == 154 || game.GameNo == 160 || game.GameNo == 166 || game.GameNo == 167 || game.GameNo == 171 || game.GameNo == 179 || game.GameNo == 183 || game.GameNo == 185 || game.GameNo == 194 || game.GameNo == 197 || game.GameNo == 199 || game.GameNo == 204 || game.GameNo == 215 || game.GameNo == 225 || game.GameNo == 235 || game.GameNo == 240 || game.GameNo == 255 || game.GameNo == 263 || game.GameNo == 264 || game.GameNo == 278 || game.GameNo == 321)
            //            continue;
            //        if (_statScraper.DoesGameExist(game.GameNo))
            //            continue;
            //        try
            //        {
            //            FullSeason stat = _statScraper.GameScraper(driver, game.GameNo,
            //                "https://www.nba.com/game/002200" + (game.GameNo).ToString("0000"));
            //            _statScraper.AddStatGame(stat);
            //        }
            //        catch (Exception)
            //        {

            //        }
            //    }
            //}

            ////FullGame Date Scraper

            //int i = 22;
            //int k = 9;
            //for (; i < 23; i++)
            //{
            //    using (var driver = new ChromeDriver())
            //    {
            //        for (; k < 25; k++)
            //        {
            //            if (game.GameNo >= 563)
            //                return;
            //            try
            //            {
            //                GameTime time = _statScraper.DateScraper(driver, game.GameNo,
            //                    "https://www.nba.com/game/002200" + (game.GameNo).ToString("0000"));
            //                _statScraper.AddGameTime(time);
            //            }
            //            catch (Exception)
            //            {
            //                k--;
            //            }
            //        }
            //    }
            //    k = 0;
            //}

            ////Quarters

            //int i = 0;
            //int k = 1;
            //int l = 1;
            //try
            //{
            //    l = _getStatMethods.GetLatestQuarterNoFullSeasonQuarters() + 1;
            //    if (l == 5)
            //    {
            //        int gameNo = _getStatMethods.GetLatestGameNoFullSeasonQuarters() + 1;
            //        l = 1;
            //        i = gameNo / 25;
            //        k = gameNo % 25;
            //    }
            //    else
            //    {
            //        int gameNo = _getStatMethods.GetLatestGameNoFullSeasonQuarters();
            //        i = gameNo / 25;
            //        k = gameNo % 25;
            //        if (gameNo == 0)
            //        {
            //            i = 0;
            //            k = 1;
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //}
            //for (; i < 22; i++)
            //{
            //    int nextgameno = _getStatMethods.GetNextGame(DateTime.Now.AddHours(-8));
            //    if (game.GameNo >= nextgameno)
            //        break;
            //    using (var driver = new ChromeDriver())
            //    {
            //        driver.Manage().Window.Maximize();
            //        driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //        Thread.Sleep(2000);
            //        driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //        Thread.Sleep(1000);
            //        for (; k < 25; k++)
            //        {
            //            if (game.GameNo >= nextgameno)
            //                break;
            //            if (game.GameNo == 16 || game.GameNo == 145 || game.GameNo == 154 || game.GameNo == 160 || game.GameNo == 166 || game.GameNo == 167 || game.GameNo == 171 || game.GameNo == 179 || game.GameNo == 183 || game.GameNo == 185 || game.GameNo == 194 || game.GameNo == 197 || game.GameNo == 199 || game.GameNo == 204 || game.GameNo == 215 || game.GameNo == 225 || game.GameNo == 235 || game.GameNo == 240 || game.GameNo == 255 || game.GameNo == 263 || game.GameNo == 264 || game.GameNo == 278 || game.GameNo == 321)
            //                continue;
            //            driver.Navigate().GoToUrl("https://www.nba.com/game/002200" + (game.GameNo).ToString("0000") + "/box-score");
            //            List<FullSeasonQuarters> season = new List<FullSeasonQuarters>();
            //            for (; l < 5; l++)
            //            {
            //                try
            //                {
            //                    FullSeasonQuarters stat = _statScraper.QuarterScraper(driver, game.GameNo, l);
            //                    season.Add(stat);
            //                }
            //                catch (Exception)
            //                {
            //                    l--;
            //                }
            //            }
            //            foreach (var quarter in season)
            //            {
            //                if (quarter.HomePoints > 50 || quarter.HomePoints < 10 || quarter.AwayPoints > 50 ||
            //                    quarter.AwayPoints < 10)
            //                {
            //                    return;
            //                }
            //                _statScraper.AddStatQuarter(quarter);
            //            }
            //            l = 1;
            //        }
            //    }
            //    k = 0;
            //}

            ////Quarters

            //List<GameTime> games = _statScraper.GetListOfGamesPlayed();

            //using (var driver = new ChromeDriver())
            //{
            //    driver.Manage().Window.Maximize();
            //    driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //    Thread.Sleep(2000);
            //    driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //    Thread.Sleep(1000);
            //    foreach (var game in games)
            //    {
            //        if (_statScraper.DoesQuarterExist(game.GameNo))
            //            continue;
            //        if (game.GameNo == 16 || game.GameNo == 145 || game.GameNo == 154 || game.GameNo == 160 || game.GameNo == 166 || game.GameNo == 167 || game.GameNo == 171 || game.GameNo == 179 || game.GameNo == 183 || game.GameNo == 185 || game.GameNo == 194 || game.GameNo == 197 || game.GameNo == 199 || game.GameNo == 204 || game.GameNo == 215 || game.GameNo == 225 || game.GameNo == 235 || game.GameNo == 240 || game.GameNo == 255 || game.GameNo == 263 || game.GameNo == 264 || game.GameNo == 278 || game.GameNo == 321)
            //            continue;
            //        driver.Navigate().GoToUrl("https://www.nba.com/game/002200" + (game.GameNo).ToString("0000") + "/box-score");
            //        List<FullSeasonQuarters> season = new List<FullSeasonQuarters>();
            //        for (int l = 1; l < 5; l++)
            //        {
            //            try
            //            {
            //                FullSeasonQuarters stat = _statScraper.QuarterScraper(driver, game.GameNo, l);
            //                season.Add(stat);
            //            }
            //            catch (Exception)
            //            {
            //                l--;
            //            }
            //        }
            //        foreach (var quarter in season)
            //        {
            //            if (quarter.HomePoints > 50 || quarter.HomePoints < 10 || quarter.AwayPoints > 50 ||
            //                quarter.AwayPoints < 10)
            //            {
            //                return;
            //            }
            //            _statScraper.AddStatQuarter(quarter);
            //        }
            //    }
            //}

            ////Player Stats

            //List<GameTime> games = _statScraper.GetListOfGamesPlayed();
            //using (var driver = new ChromeDriver())
            //{
            //    driver.Manage().Window.Maximize();
            //    driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //    Thread.Sleep(2000);
            //    driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //    foreach (var game in games)
            //    {
            //        if (game.GameNo == 16 || game.GameNo == 145 || game.GameNo == 154 || game.GameNo == 160 || game.GameNo == 166 || game.GameNo == 167 || game.GameNo == 171 || game.GameNo == 179 || game.GameNo == 183 || game.GameNo == 185 || game.GameNo == 194 || game.GameNo == 197 || game.GameNo == 199 || game.GameNo == 204 || game.GameNo == 215 || game.GameNo == 225 || game.GameNo == 235 || game.GameNo == 240 || game.GameNo == 255 || game.GameNo == 263 || game.GameNo == 264 || game.GameNo == 278 || game.GameNo == 321)
            //            continue;
            //        if (_statScraper.DoesPlayerStatGameExist(game.GameNo))
            //            continue;
            //        try
            //        {
            //            List<PlayerStats> stats = _statScraper.PlayerStatScraper(driver, game.GameNo,
            //                "https://www.nba.com/game/002200" + (game.GameNo).ToString("0000") + "/box-score");
            //            _statScraper.AddPlayerStatList(stats);
            //        }
            //        catch (Exception)
            //        {

            //        }
            //    }
            //}

            ////Quarter Predictor

            //int lastgameno = _getStatMethods.GetLatestGameNoQuarterPredictions();
            //int lastquarterno = _getStatMethods.GetLatestQuarterNoQuarterPredictions();
            //if (lastquarterno == 4)
            //{
            //    lastquarterno = 0;
            //    lastgameno += 1;
            //}

            //int i = lastgameno;
            //int j = lastquarterno + 1;
            //for (; i < _getStatMethods.GetNextGame(DateTime.Now.AddHours(16)); i++)
            //{
            //    GameTime gametime = _getStatMethods.GetGameTime(i);
            //    for (; j < 5; j++)
            //    {
            //        try
            //        {
            //            QuarterPredictions quarter = _simulator.QuarterSimulator(gametime.HomeTeam, gametime.AwayTeam, j, i);
            //            _statScraper.AddQuarterPrediction(quarter);
            //        }
            //        catch (Exception)
            //        {
            //            continue;
            //        }
            //    }
            //    j = 1;
            //}

            ////Game Predictor

            //int lastgameno = _getStatMethods.GetLatestGameNoGamePredictions();

            //int i = lastgameno + 1;
            //for (; i < _getStatMethods.GetNextGame(DateTime.Now.AddHours(16)); i++)
            //{
            //    GameTime gametime = _getStatMethods.GetGameTime(i);
            //    GamePredictions game = _simulator.FullMatchSimulator(gametime.HomeTeam, gametime.AwayTeam, i);
            //    _statScraper.AddGamePrediction(game);
            //}

            //// PlayerInfoScraper
            //using (var driver = new ChromeDriver())
            //{
            //    List<Players> players = _statScraper.PlayerInfoScraper(driver, 1, 501);
            //    _statScraper.AddPlayerInfoList(players);
            //}

            ////GameTimeUpdate

            //for (int j = 0; j < 6; j++)
            //{
            //    using (var driver = new ChromeDriver())
            //    {
            //        for (int i = 1; i <= 100; i++)
            //        {
            //            if (j * 100 + i == 16)
            //                continue;
            //            if (j * 100 + i < 133)
            //            {
            //                GameTime game = db.GameTime.Find(j * 100 + i);
            //                if (game.GameDate < DateTime.Now.AddHours(-8))
            //                {
            //                    continue;
            //                }
            //                driver.Navigate().GoToUrl("https://www.nba.com/game/002200" + (j * 100 + i).ToString("0000") + "/box-score");
            //                if (i == 1)
            //                {
            //                    Thread.Sleep(1000);
            //                    driver.FindElementByXPath("/html/body/div[3]/div[3]/div/div/div[2]/div/div/button").Click();
            //                }
            //                game.AwayTeam = _statScraper.GetTeamEnumByTeamName(driver
            //                    .FindElementByXPath("/html/body/div[1]/div[2]/div[5]/section[2]/div[1]/h1/span").Text.Replace(" ", "").ToUpper().Replace('İ', 'I'));
            //                game.HomeTeam = _statScraper.GetTeamEnumByTeamName(driver
            //                    .FindElementByXPath("/html/body/div[1]/div[2]/div[5]/section[3]/div[1]/h1/span").Text.Replace(" ", "").ToUpper().Replace('İ', 'I'));
            //                uw.Commit();
            //            }
            //            else
            //            {

            //                GameTime game = db.GameTime.Find(j * 100 + i);
            //                driver.Navigate().GoToUrl("https://www.nba.com/game/002200" + (j * 100 + i).ToString("0000"));
            //                if (i == 1)
            //                {
            //                    Thread.Sleep(1000);
            //                    driver.FindElementByXPath("/html/body/div[3]/div[3]/div/div/div[2]/div/div/button").Click();
            //                }

            //                string teams = null;
            //                while (teams==null)
            //                {
            //                    try
            //                    {
            //                        teams = driver
            //                            .FindElementByXPath("/html/body/div[1]/div[2]/section/div[1]/div[5]/div/div[2]/h1")
            //                            .Text;
            //                    }
            //                    catch (Exception e)
            //                    {
            //                        driver.Navigate().Refresh();
            //                    }
            //                }
            //                string away = teams.Substring(0, teams.IndexOf('@') - 1).ToUpper().Replace('İ', 'I').Replace(" ","");
            //                string home = teams.Substring(teams.IndexOf('@') + 2).ToUpper().Replace('İ', 'I').Replace(" ", "");
            //                game.AwayTeam = _statScraper.GetTeamEnumByTeamMascotName(away);
            //                game.HomeTeam = _statScraper.GetTeamEnumByTeamMascotName(home);
            //                uw.Commit();
            //            }
            //        }
            //    }
            //}

            ////FullGame 19-20

            //int i = 0;
            //int k = 1;
            //try
            //{
            //    int gameNo = _getStatMethods.GetLatestGameNoFullSeason1920();
            //    i = gameNo / 25;
            //    k = gameNo % 25 + 1;
            //}
            //catch (Exception)
            //{

            //}
            //for (; i < 39; i++)
            //{
            //    using (var driver = new ChromeDriver())
            //    {
            //        driver.Manage().Window.Maximize();
            //        driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //        Thread.Sleep(2000);
            //        driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //        if (game.GameNo >= 971)
            //            return;
            //        for (; k < 25; k++)
            //        {
            //            if (game.GameNo >= 971)
            //                return;
            //            if (game.GameNo == 707)
            //                continue;
            //            try
            //            {
            //                FullSeason19_20 stat = _statScraper.GameScraper1920(driver, game.GameNo,
            //                    "https://www.nba.com/game/002190" + (game.GameNo).ToString("0000"));
            //                _statScraper.AddStatGame(stat);
            //            }
            //            catch (Exception)
            //            {
            //                k--;
            //            }
            //        }
            //    }
            //    k = 0;
            //}

            ////FullSeasonQuarters 19-20

            //int i = 0;
            //int k = 1;
            //int j = 1;
            //try
            //{
            //    int quarterNo = _getStatMethods.GetLatestQuarterNoFullSeasonQuarters1920();
            //    int gameNo = _getStatMethods.GetLatestGameNoFullSeasonQuarters1920();
            //    if (quarterNo == 4)
            //    {
            //        j = 0;
            //        gameNo += 1;
            //        quarterNo = 0;
            //    }
            //    i = gameNo / 25;
            //    k = gameNo % 25;
            //    j = quarterNo + 1;
            //}
            //catch (Exception)
            //{

            //}
            //for (; i < 39; i++)
            //{
            //    using (var driver = new ChromeDriver())
            //    {
            //        driver.Manage().Window.Maximize();
            //        driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //        Thread.Sleep(2000);
            //        driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //        driver.Manage().Window.Minimize();
            //        if (game.GameNo >= 971)
            //            return;
            //        for (; k < 25; k++)
            //        {
            //            if (game.GameNo >= 971)
            //                return;
            //            if (game.GameNo == 707)
            //                continue;
            //            try
            //            {
            //                driver.Navigate().GoToUrl("https://www.nba.com/game/002190" + (game.GameNo).ToString("0000") + "/box-score");
            //                List<FullSeasonQuarters19_20> stats = new List<FullSeasonQuarters19_20>();
            //                for (; j < 5; j++)
            //                {
            //                    FullSeasonQuarters19_20 stat = _statScraper.QuarterScraper1920(driver, game.GameNo, j);
            //                    stats.Add(stat);
            //                }

            //                foreach (var stat in stats)
            //                {
            //                    _statScraper.AddStatQuarter(stat);
            //                }
            //                j = 1;
            //            }
            //            catch (Exception)
            //            {
            //                k--;
            //            }
            //        }
            //    }
            //    k = 0;
            //}

            ////FullSeasonQuarters 19-20 Add-ons

            //List<int> games = new List<int>();
            //List<int> quarters = new List<int>();
            //for (int l = 1; l < 971; l++)
            //{
            //    if (l == 707)
            //    {
            //        continue;
            //    }
            //    for (int m = 1; m < 5; m++)
            //    {
            //        if (!_getStatMethods.QuarterExist1920(l, m))
            //        {
            //            games.Add(l);
            //            quarters.Add(m);
            //        }
            //    }
            //}

            //using (var driver = new ChromeDriver())
            //{
            //    driver.Manage().Window.Maximize();
            //    driver.Navigate().GoToUrl("https://www.nba.com/schedule");
            //    Thread.Sleep(2000);
            //    driver.FindElementByXPath("/html/body/div[2]/div[3]/div/div/div[2]/div/div/button").Click();
            //    for (int l = 0; l < games.Count; l++)
            //    {
            //        FullSeasonQuarters19_20 stat = _statScraper.QuarterScraper1920(driver, games[l], quarters[l]);
            //        _statScraper.AddStatQuarter(stat);
            //    }
            //}

            ////CoEfficientOptimizerGame

            //for (int i = 0; i < 1000; i++)
            //{
            //    _predictor.CoefficientOptimizerGame();
            //}

            ////CoEfficientOptimizerQuarter

            //for (int i = 0; i < 1000; i++)
            //{
            //    _predictor.CoefficientOptimizerQuarter();
            //}
        }
    }
}

