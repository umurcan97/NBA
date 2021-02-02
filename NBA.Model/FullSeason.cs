using System;

namespace NBA.Model
{
    using System.ComponentModel.DataAnnotations;
    public class FullSeason:GameModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime GameDate { get; set; }
        public int GameNo { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
