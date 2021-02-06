using System;
using OpenQA.Selenium.Chrome;

namespace NBA.Api.Interfaces
{
    using NBA.Model;
    using System.Collections.Generic;
    public interface IStatScraper
    {
        Team GetTeamEnumByTeamName(string TeamName);
        Team GetTeamEnumByTeamId(int TeamID);
        Team GetTeamEnumByTeamShortName(string TeamShortName);
        Team GetTeamEnumByTeamMascotName(string TeamMascotName);
        bool DoesGameExist(int GameNo);
        bool DoesQuarterExist(int GameNo, int QuarterNo);
        bool DoesQuarterExist(int GameNo);
        bool DoesPlayerStatGameExist(int GameNo);
        bool DoesGamePredictionExist(int GameNo);
        bool DoesQuarterPredictionExist(int GameNo);
        void DeleteGame(int GameNo);
        void DeleteQuarter(int GameNo, int QuarterNo);
        void AddStatList(List<FullSeason> Stats);
        void AddStatGame(FullSeason Stat);
        void AddStatGame(FullSeason19_20 Stat);
        void AddStatQuarter(FullSeasonQuarters Stat);
        void AddStatQuarter(FullSeasonQuarters19_20 Stat);
        void AddQuarterPrediction(QuarterPredictions Quarter);
        void AddGamePrediction(GamePredictions game);
        void AddPlayerStat(PlayerStats stat);
        void AddPlayerStatList(List<PlayerStats> Stats);
        void AddPlayerInfoList(List<Players> players);
        void AddGameTime(GameTime date);
        DateTime DateTimeConverter(string date);
        GameTime DateScraper(ChromeDriver driver, int GameNo, string url);
        FullSeason GameScraper(ChromeDriver driver, int GameNo);
        FullSeason19_20 GameScraper1920(ChromeDriver driver, int GameNo, string url);
        FullSeasonQuarters QuarterScraper(ChromeDriver driver, int GameNo, int QuarterNo);
        FullSeasonQuarters19_20 QuarterScraper1920(ChromeDriver driver, int GameNo, int QuarterNo);
        List<PlayerStats> PlayerStatScraper(ChromeDriver driver, int GameNo);
        List<Players> PlayerInfoScraper(ChromeDriver driver, int No1, int No2);
        List<GameTime> GetListOfGamesPlayed();
        List<GameTime> GetListOfGamesToBePlayed();
    }
}
