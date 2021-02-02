namespace NBA.Model
{
    using System.Data.Entity;
    public interface INBAContext
    {
        IDbSet<FullSeason> FullSeason { get; set; }
        IDbSet<FullSeasonQuarters> FullSeasonQuarters { get; set; }
        IDbSet<QuarterPredictions> Predictions { get; set; }
        IDbSet<GamePredictions> GamePredictions { get; set; }
        IDbSet<PlayerPredictions> PlayerPredictions { get; set; }
        IDbSet<Teams> Teams { get; set; }
        IDbSet<Players> Players { get; set; }
        IDbSet<PlayerStats> PlayerStats { get; set; }
        IDbSet<GameTime> GameTime { get; set; }
        IDbSet<FullSeason19_20> FullSeason1920 { get; set; }
        IDbSet<FullSeasonQuarters19_20> FullSeasonQuarters1920 { get; set; }
        IDbSet<CoEfficientOptimizer> CoEfficientOptimizer { get; set; }
    }
}
