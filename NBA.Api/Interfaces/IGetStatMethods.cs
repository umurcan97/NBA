using System;

namespace NBA.Api.Interfaces
{
    using NBA.Model;
    using System.Collections.Generic;

    public interface IGetStatMethods
    {
        string GetTeamNameByID(int TeamID);
        int GetTeamIdByName(string TeamName);
        int GetLatestGameNoFullSeason();
        int GetLatestGameNoFullSeason1920();
        int GetLatestGameNoFullSeasonQuarters1920();
        int GetLatestQuarterNoFullSeasonQuarters1920();
        int GetLatestGameNoFullSeasonQuarters();
        int GetLatestQuarterNoFullSeasonQuarters();
        int GetLatestGameNoPlayerStats();
        int GetLatestGameNoQuarterPredictions();
        int GetLatestQuarterNoQuarterPredictions();
        int GetLatestGameNoGamePredictions();
        bool QuarterExist1920(int GameNo, int QuarterNo);
        Team GetHomeTeam(int GameNo);
        Team GetAwayTeam(int GameNo);
        Team GetHomeTeam1920(int GameNo);
        Team GetAwayTeam1920(int GameNo);
        DateTime GetGameDate(int GameNo);
        GameTime GetGameTime(int GameNo);
        int GetNextGame(DateTime date);
        FullSeason GetFullSeason(int GameNo);
        FullSeason19_20 GetFullSeason1920(int GameNo);
        FullSeasonQuarters GetFullSeasonQuarters(int GameNo, int QuarterNo);
        FullSeasonQuarters19_20 GetFullSeasonQuarters1920(int GameNo, int QuarterNo);
        Players GetPlayerWithName(string name);
        List<FullSeason> GetFullSeasonTillGameNo(Team team, int GameNo);
        List<FullSeason> GetFullSeasonList(Team team);
        List<FullSeason> GetFullSeasonForHomeOrAwayList(Team team, bool isHome);
        List<FullSeason> GetLast5List(Team team);
        List<FullSeason> GetSeasonMatchups(Team team1, Team team2);
        List<FullSeasonQuarters> GetFullSeasonTillGameNoForQuarter(Team team, int GameNo, int QuarterNo);
        List<FullSeasonQuarters> GetFullSeasonListForQuarter(Team team, int QuarterNo);
        List<FullSeasonQuarters> GetFullSeasonForHomeOrAwayListForQuarter(Team team, bool isHome, int QuarterNo);
        List<FullSeasonQuarters> GetLast5ListForQuarter(Team team, int QuarterNo);
        List<FullSeasonQuarters> GetSeasonMatchupsForQuarter(Team team1, Team team2, int QuarterNo);
        List<FullSeason19_20> GetFullSeason1920TillGameNo(Team team, int GameNo);
        List<FullSeason19_20> GetFullSeason1920List(Team team);
        List<FullSeason19_20> GetFullSeason1920ForHomeOrAwayList(Team team, bool isHome);
        List<FullSeason19_20> GetLast5List1920(Team team);
        List<FullSeason19_20> GetSeason1920Matchups(Team team1, Team team2);
        List<FullSeasonQuarters19_20> GetFullSeason1920TillGameNoForQuarter(Team team, int GameNo, int QuarterNo);
        List<FullSeasonQuarters19_20> GetFullSeason1920ListForQuarter(Team team, int QuarterNo);
        List<FullSeasonQuarters19_20> GetFullSeason1920ForHomeOrAwayListForQuarter(Team team, bool isHome, int QuarterNo);
        List<FullSeasonQuarters19_20> GetLast5List1920ForQuarter(Team team, int QuarterNo);
        List<FullSeasonQuarters19_20> GetSeason1920MatchupsForQuarter(Team team1, Team team2, int QuarterNo);
        List<PlayerStats> GetFullSeasonStatsWithPlayerID(int PlayerId);
        List<PlayerStats> GetFullSeasonStatsWithPlayer(Players Player);
        List<PlayerStats> GetFullSeasonStatsWithPlayerName(string PlayerName);
        List<PlayerStats> GetLast5StatsWithPlayerID(int PlayerId);
        List<PlayerStats> GetLast5StatsWithPlayer(Players Player);
        List<PlayerStats> GetLast5StatsWithPlayerName(string PlayerName);
    }
}
