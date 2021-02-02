using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public class CoEfficientOptimizer
    {
        [Key]
        public int ID { get; set; }
        public double Coefficient1 { get; set; }
        public double Coefficient2 { get; set; }
        public double Coefficient3 { get; set; }
        public double Coefficient4 { get; set; }
        public double HomePoints { get; set; }
        public double AwayPoints { get; set; }
        public double HomeFGA { get; set; }
        public double HomeFGM { get; set; }
        public double Home3PA { get; set; }
        public double Home3PM { get; set; }
        public double HomeFTA { get; set; }
        public double HomeFTM { get; set; }
        public double AwayFGA { get; set; }
        public double AwayFGM { get; set; }
        public double Away3PA { get; set; }
        public double Away3PM { get; set; }
        public double AwayFTA { get; set; }
        public double AwayFTM { get; set; }
        public int TotalHomePoints { get; set; }
        public int TotalAwayPoints { get; set; }
        public int TotalHomeFGA { get; set; }
        public int TotalHomeFGM { get; set; }
        public int TotalHome3PA { get; set; }
        public int TotalHome3PM { get; set; }
        public int TotalHomeFTA { get; set; }
        public int TotalHomeFTM { get; set; }
        public int TotalAwayFGA { get; set; }
        public int TotalAwayFGM { get; set; }
        public int TotalAway3PA { get; set; }
        public int TotalAway3PM { get; set; }
        public int TotalAwayFTA { get; set; }
        public int TotalAwayFTM { get; set; }
        public double Coefficient5 { get; set; }
        public double Coefficient6 { get; set; }
        public double Coefficient7 { get; set; }
        public double FirstHomePoints { get; set; }
        public double FirstAwayPoints { get; set; }
        public double FirstHomeFGA { get; set; }
        public double FirstHomeFGM { get; set; }
        public double FirstHome3PA { get; set; }
        public double FirstHome3PM { get; set; }
        public double FirstHomeFTA { get; set; }
        public double FirstHomeFTM { get; set; }
        public double FirstAwayFGA { get; set; }
        public double FirstAwayFGM { get; set; }
        public double FirstAway3PA { get; set; }
        public double FirstAway3PM { get; set; }
        public double FirstAwayFTA { get; set; }
        public double FirstAwayFTM { get; set; }
        public int FirstTotalHomePoints { get; set; }
        public int FirstTotalAwayPoints { get; set; }
        public int FirstTotalHomeFGA { get; set; }
        public int FirstTotalHomeFGM { get; set; }
        public int FirstTotalHome3PA { get; set; }
        public int FirstTotalHome3PM { get; set; }
        public int FirstTotalHomeFTA { get; set; }
        public int FirstTotalHomeFTM { get; set; }
        public int FirstTotalAwayFGA { get; set; }
        public int FirstTotalAwayFGM { get; set; }
        public int FirstTotalAway3PA { get; set; }
        public int FirstTotalAway3PM { get; set; }
        public int FirstTotalAwayFTA { get; set; }
        public int FirstTotalAwayFTM { get; set; }
    }
}
