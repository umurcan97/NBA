using System.ComponentModel.DataAnnotations;

namespace NBA.Model
{
    public class QuarterPredictions: QuarterModel
    {
        [Key]
        public int ID { get; set; }
        public bool FirstGame { get; set; }
        public int GameNo { get; set; }
        public int QuarterNo { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
    }
}
