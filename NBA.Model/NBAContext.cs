namespace NBA.Model
{
    using System.Data.Entity;
    public class NBAContext : DbContext, INBAContext
    {
        public NBAContext() : base("NBAContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NBAContext, NBA.Model.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
        public IDbSet<FullSeason> FullSeason { get; set; }
        public IDbSet<FullSeasonQuarters> FullSeasonQuarters { get; set; }
        public IDbSet<QuarterPredictions> Predictions { get; set; }
        public IDbSet<GamePredictions> GamePredictions { get; set; }
        public IDbSet<PlayerPredictions> PlayerPredictions { get; set; }
        public IDbSet<Teams> Teams { get; set; }
        public IDbSet<Players> Players { get; set; }
        public IDbSet<PlayerStats> PlayerStats { get; set; }
        public IDbSet<GameTime> GameTime { get; set; }
        public IDbSet<FullSeason19_20> FullSeason1920 { get; set; }
        public IDbSet<FullSeasonQuarters19_20> FullSeasonQuarters1920 { get; set; }
        public IDbSet<CoEfficientOptimizer> CoEfficientOptimizer { get; set; }
    }
}
