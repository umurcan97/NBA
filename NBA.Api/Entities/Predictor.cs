using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Api.Interfaces;
using NBA.Model;

namespace NBA.Api.Entities
{
    public class Predictor:IPredictor
    {
        private readonly INBAContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetStatMethods _getStatMethods;
        private readonly ISimulator _simulator;
        private readonly IStatScraper _statscraper;

        public Predictor(
            INBAContext dbContext,
            IUnitOfWork unitOfWork,
            IGetStatMethods getStatMethods,
            ISimulator simulator,
            IStatScraper statScraper)
        {
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
            this._getStatMethods = getStatMethods;
            this._simulator = simulator;
            this._statscraper = statScraper;
        }
        public void PredictQuarter(int QuarterNo, int GameNo)
        {
            Team HomeTeam = _getStatMethods.GetHomeTeam(GameNo);
            Team AwayTeam = _getStatMethods.GetAwayTeam(GameNo);
            QuarterPredictions Quarter = _simulator.QuarterSimulator(HomeTeam, AwayTeam, QuarterNo, GameNo);
            _statscraper.AddQuarterPrediction(Quarter);
        }

        public void CoefficientOptimizerGame(int No)
        {
            int firstgames = 0;
            int othergames = 0;
            double Coefficient1, Coefficient2, Coefficient3, Coefficient4, Coefficient5, Coefficient6, Coefficient7;
            CoEfficientOptimizer optimizer = new CoEfficientOptimizer();
            Coefficient1 = Math.Floor((double)(No / 729));
            Coefficient2 = Math.Floor((No - Coefficient1 * 729) / 81);
            Coefficient3 = Math.Floor((No - Coefficient1 * 729 - Coefficient2 * 81) / 9);
            Coefficient4 = Math.Floor(No - Coefficient1 * 729 - Coefficient2 * 81 - Coefficient3 * 9);
            Coefficient1++;
            Coefficient2++;
            Coefficient3++;
            Coefficient4++;
            double total = Coefficient1 + Coefficient2 + Coefficient3 + Coefficient4;
            Coefficient1 = total / Coefficient1;
            Coefficient2 = total / Coefficient2;
            Coefficient3 = total / Coefficient3;
            Coefficient4 = total / Coefficient4;

            Coefficient5 = Math.Floor((double)((No % 729) / 81));
            Coefficient6 = Math.Floor((No % 729 - Coefficient5 * 81) / 9);
            Coefficient7 = Math.Floor(No % 729 - Coefficient5 * 81 - Coefficient6 * 9);
            Coefficient5++;
            Coefficient6++;
            Coefficient7++;
            total = Coefficient5 + Coefficient6 + Coefficient7;
            Coefficient5 = total / Coefficient5;
            Coefficient6 = total / Coefficient6;
            Coefficient7 = total / Coefficient7;
            optimizer.Coefficient1 = Coefficient1;
            optimizer.Coefficient2 = Coefficient2;
            optimizer.Coefficient3 = Coefficient3;
            optimizer.Coefficient4 = Coefficient4;
            optimizer.Coefficient5 = Coefficient5;
            optimizer.Coefficient6 = Coefficient6;
            optimizer.Coefficient7 = Coefficient7;
            for (int i = 750; i < 971; i++)
            {
                if (i == 707)
                {
                    continue;
                }
                Team homeTeam = _getStatMethods.GetHomeTeam1920(i);
                Team awayTeam = _getStatMethods.GetAwayTeam1920(i);
                GamePredictions prediction = _simulator.FullMatchSimulator1920(homeTeam, awayTeam, i, Coefficient1, Coefficient2, Coefficient3, Coefficient4, Coefficient5, Coefficient6, Coefficient7);
                FullSeason19_20 game = _getStatMethods.GetFullSeason1920(i);
                if (prediction.FirstGame)
                {
                    firstgames++;
                    optimizer.FirstHomePoints += Math.Abs(game.HomePoints - prediction.HomePoints) / game.HomePoints * 100;
                    optimizer.FirstHome3PA += Math.Abs(game.Home3PA - prediction.Home3PA) / game.Home3PA * 100;
                    optimizer.FirstHome3PM += Math.Abs(game.Home3PM - prediction.Home3PM) / game.Home3PM * 100;
                    optimizer.FirstHomeFGA += Math.Abs(game.HomeFGA - prediction.HomeFGA) / game.HomeFGA * 100;
                    optimizer.FirstHomeFGM += Math.Abs(game.HomeFGM - prediction.HomeFGM) / game.HomeFGM * 100;
                    optimizer.FirstHomeFTA += Math.Abs(game.HomeFTA - prediction.HomeFTA) / game.HomeFTA * 100;
                    optimizer.FirstHomeFTM += Math.Abs(game.HomeFTM - prediction.HomeFTM) / game.HomeFTM * 100;
                    optimizer.FirstAwayPoints += Math.Abs(game.AwayPoints - prediction.AwayPoints) / game.AwayPoints * 100;
                    optimizer.FirstAway3PA += Math.Abs(game.Away3PA - prediction.Away3PA) / game.Away3PA * 100;
                    optimizer.FirstAway3PM += Math.Abs(game.Away3PM - prediction.Away3PM) / game.Away3PM * 100;
                    optimizer.FirstAwayFGA += Math.Abs(game.AwayFGA - prediction.AwayFGA) / game.AwayFGA * 100;
                    optimizer.FirstAwayFGM += Math.Abs(game.AwayFGM - prediction.AwayFGM) / game.AwayFGM * 100;
                    optimizer.FirstAwayFTA += Math.Abs(game.AwayFTA - prediction.AwayFTA) / game.AwayFTA * 100;
                    optimizer.FirstAwayFTM += Math.Abs(game.AwayFTM - prediction.AwayFTM) / game.AwayFTM * 100;
                    optimizer.FirstTotalHomePoints += Convert.ToInt16(prediction.HomePoints);
                    optimizer.FirstTotalHome3PA += Convert.ToInt16(prediction.Home3PA);;
                    optimizer.FirstTotalHome3PM += Convert.ToInt16(prediction.Home3PM);;
                    optimizer.FirstTotalHomeFGA += Convert.ToInt16(prediction.HomeFGA);;
                    optimizer.FirstTotalHomeFGM += Convert.ToInt16(prediction.HomeFGM);;
                    optimizer.FirstTotalHomeFTA += Convert.ToInt16(prediction.HomeFTA);;
                    optimizer.FirstTotalHomeFTM += Convert.ToInt16(prediction.HomeFTM); ;
                    optimizer.FirstTotalAwayPoints += Convert.ToInt16(prediction.AwayPoints); ;
                    optimizer.FirstTotalAway3PA += Convert.ToInt16(prediction.Away3PA);;
                    optimizer.FirstTotalAway3PM += Convert.ToInt16(prediction.Away3PM);;
                    optimizer.FirstTotalAwayFGA += Convert.ToInt16(prediction.AwayFGA);;
                    optimizer.FirstTotalAwayFGM += Convert.ToInt16(prediction.AwayFGM);;
                    optimizer.FirstTotalAwayFTA += Convert.ToInt16(prediction.AwayFTA);;
                    optimizer.FirstTotalAwayFTM += Convert.ToInt16(prediction.AwayFTM); ;
                }
                else
                {
                    othergames++;
                    optimizer.HomePoints += Math.Abs(game.HomePoints - prediction.HomePoints) / game.HomePoints * 100;
                    optimizer.Home3PA += Math.Abs(game.Home3PA - prediction.Home3PA) / game.Home3PA * 100;
                    optimizer.Home3PM += Math.Abs(game.Home3PM - prediction.Home3PM) / game.Home3PM * 100;
                    optimizer.HomeFGA += Math.Abs(game.HomeFGA - prediction.HomeFGA) / game.HomeFGA * 100;
                    optimizer.HomeFGM += Math.Abs(game.HomeFGM - prediction.HomeFGM) / game.HomeFGM * 100;
                    optimizer.HomeFTA += Math.Abs(game.HomeFTA - prediction.HomeFTA) / game.HomeFTA * 100;
                    optimizer.HomeFTM += Math.Abs(game.HomeFTM - prediction.HomeFTM) / game.HomeFTM * 100;
                    optimizer.AwayPoints += Math.Abs(game.AwayPoints - prediction.AwayPoints) / game.AwayPoints * 100;
                    optimizer.Away3PA += Math.Abs(game.Away3PA - prediction.Away3PA) / game.Away3PA * 100;
                    optimizer.Away3PM += Math.Abs(game.Away3PM - prediction.Away3PM) / game.Away3PM * 100;
                    optimizer.AwayFGA += Math.Abs(game.AwayFGA - prediction.AwayFGA) / game.AwayFGA * 100;
                    optimizer.AwayFGM += Math.Abs(game.AwayFGM - prediction.AwayFGM) / game.AwayFGM * 100;
                    optimizer.AwayFTA += Math.Abs(game.AwayFTA - prediction.AwayFTA) / game.AwayFTA * 100;
                    optimizer.AwayFTM += Math.Abs(game.AwayFTM - prediction.AwayFTM) / game.AwayFTM * 100;
                    optimizer.FirstTotalHomePoints += Convert.ToInt16(prediction.HomePoints);
                    optimizer.FirstTotalHome3PA += Convert.ToInt16(prediction.Home3PA); ;
                    optimizer.FirstTotalHome3PM += Convert.ToInt16(prediction.Home3PM); ;
                    optimizer.FirstTotalHomeFGA += Convert.ToInt16(prediction.HomeFGA); ;
                    optimizer.FirstTotalHomeFGM += Convert.ToInt16(prediction.HomeFGM); ;
                    optimizer.FirstTotalHomeFTA += Convert.ToInt16(prediction.HomeFTA); ;
                    optimizer.FirstTotalHomeFTM += Convert.ToInt16(prediction.HomeFTM); ;
                    optimizer.FirstTotalAwayPoints += Convert.ToInt16(prediction.AwayPoints); ;
                    optimizer.FirstTotalAway3PA += Convert.ToInt16(prediction.Away3PA); ;
                    optimizer.FirstTotalAway3PM += Convert.ToInt16(prediction.Away3PM); ;
                    optimizer.FirstTotalAwayFGA += Convert.ToInt16(prediction.AwayFGA); ;
                    optimizer.FirstTotalAwayFGM += Convert.ToInt16(prediction.AwayFGM); ;
                    optimizer.FirstTotalAwayFTA += Convert.ToInt16(prediction.AwayFTA); ;
                    optimizer.FirstTotalAwayFTM += Convert.ToInt16(prediction.AwayFTM); ;
                }
            }
            optimizer.FirstHomePoints /= firstgames;
            optimizer.FirstHome3PA /= firstgames;
            optimizer.FirstHome3PM /= firstgames;
            optimizer.FirstHomeFGA /= firstgames;
            optimizer.FirstHomeFGM /= firstgames;
            optimizer.FirstHomeFTA /= firstgames;
            optimizer.FirstHomeFTM /= firstgames;
            optimizer.FirstAwayPoints /= firstgames;
            optimizer.FirstAway3PA /= firstgames;
            optimizer.FirstAway3PM /= firstgames;
            optimizer.FirstAwayFGA /= firstgames;
            optimizer.FirstAwayFGM /= firstgames;
            optimizer.FirstAwayFTA /= firstgames;
            optimizer.FirstAwayFTM /= firstgames;
            optimizer.HomePoints /= othergames;
            optimizer.Home3PA /= othergames;
            optimizer.Home3PM /= othergames;
            optimizer.HomeFGA /= othergames;
            optimizer.HomeFGM /= othergames;
            optimizer.HomeFTA /= othergames;
            optimizer.HomeFTM /= othergames;
            optimizer.AwayPoints /= othergames;
            optimizer.Away3PA /= othergames;
            optimizer.Away3PM /= othergames;
            optimizer.AwayFGA /= othergames;
            optimizer.AwayFGM /= othergames;
            optimizer.AwayFTA /= othergames;
            optimizer.AwayFTM /= othergames;
            this._dbContext.CoEfficientOptimizer.Add(optimizer);
            this._unitOfWork.Commit();
        }

        public void CoefficientOptimizerQuarter(int No)
        {
            int firstgames = 0;
            int othergames = 0;
            double Coefficient1, Coefficient2, Coefficient3, Coefficient4, Coefficient5, Coefficient6, Coefficient7;
            CoEfficientOptimizer optimizer = new CoEfficientOptimizer();
            Coefficient1 = Math.Floor((double)(No / 729));
            Coefficient2 = Math.Floor((No - Coefficient1 * 729) / 81);
            Coefficient3 = Math.Floor((No - Coefficient1 * 729 - Coefficient2 * 81) / 9);
            Coefficient4 = Math.Floor(No - Coefficient1 * 729 - Coefficient2 * 81 - Coefficient3 * 9);
            Coefficient1++;
            Coefficient2++;
            Coefficient3++;
            Coefficient4++;
            double total = Coefficient1 + Coefficient2 + Coefficient3 + Coefficient4;
            Coefficient1 = total / Coefficient1;
            Coefficient2 = total / Coefficient2;
            Coefficient3 = total / Coefficient3;
            Coefficient4 = total / Coefficient4;

            Coefficient5 = Math.Floor((double)(No % 729 / 81));
            Coefficient6 = Math.Floor((No % 729 - Coefficient5 * 81) / 9);
            Coefficient7 = Math.Floor(No % 729 - Coefficient5 * 81 - Coefficient6 * 9);
            Coefficient5++;
            Coefficient6++;
            Coefficient7++;
            total = Coefficient5 + Coefficient6 + Coefficient7;
            Coefficient5 = total / Coefficient5;
            Coefficient6 = total / Coefficient6;
            Coefficient7 = total / Coefficient7;
            optimizer.Coefficient1 = Coefficient1;
            optimizer.Coefficient2 = Coefficient2;
            optimizer.Coefficient3 = Coefficient3;
            optimizer.Coefficient4 = Coefficient4;
            optimizer.Coefficient5 = Coefficient5;
            optimizer.Coefficient6 = Coefficient6;
            optimizer.Coefficient7 = Coefficient7;
            for (int i = 750; i < 971; i++)
            {
                if (i == 707)
                {
                    continue;
                }
                Team homeTeam = _getStatMethods.GetHomeTeam1920(i);
                Team awayTeam = _getStatMethods.GetAwayTeam1920(i);
                for (int j = 1; j < 5; j++)
                {
                    QuarterPredictions prediction = _simulator.QuarterSimulator1920(homeTeam, awayTeam, j, i, Coefficient1, Coefficient2, Coefficient3, Coefficient4, Coefficient5, Coefficient6, Coefficient7);
                    FullSeasonQuarters19_20 game = _getStatMethods.GetFullSeasonQuarters1920(i, j);
                    if (game.HomePoints == prediction.HomePoints && game.AwayPoints == prediction.AwayPoints)
                    {
                        if(prediction.FirstGame)
                            optimizer.TotalHomePoints++;
                        optimizer.TotalAwayPoints++;
                    }
                    if (prediction.FirstGame)
                    {
                        firstgames++;
                        optimizer.FirstHomePoints += Math.Abs(game.HomePoints - prediction.HomePoints) / game.HomePoints * 100;
                        if (game.Home3PA == 0)
                        {
                            optimizer.FirstHome3PA += 100;
                        }
                        else
                        {
                            optimizer.FirstHome3PA += Math.Abs(game.Home3PA - prediction.Home3PA) / game.Home3PA * 100;
                        }
                        if (game.Home3PM == 0)
                        {
                            optimizer.Home3PM += 100;
                        }
                        else
                        {
                            optimizer.Home3PM += Math.Abs(game.Home3PM - prediction.Home3PM) / game.Home3PM * 100;
                        }
                        optimizer.FirstHomeFGA += Math.Abs(game.HomeFGA - prediction.HomeFGA) / game.HomeFGA * 100;
                        optimizer.FirstHomeFGM += Math.Abs(game.HomeFGM - prediction.HomeFGM) / game.HomeFGM * 100;
                        if (game.HomeFTA == 0)
                        {
                            optimizer.FirstHomeFTA += 100;
                        }
                        else
                        {
                            optimizer.FirstHomeFTA += Math.Abs(game.HomeFTA - prediction.HomeFTA) / game.HomeFTA * 100;
                        }
                        if (game.HomeFTM == 0)
                        {
                            optimizer.FirstHomeFTM += 100;
                        }
                        else
                        {
                            optimizer.FirstHomeFTM += Math.Abs(game.HomeFTM - prediction.HomeFTM) / game.HomeFTM * 100;
                        }
                        optimizer.FirstAwayPoints += Math.Abs(game.AwayPoints - prediction.AwayPoints) / game.AwayPoints * 100;
                        if (game.Away3PA == 0)
                        {
                            optimizer.FirstAway3PA += 100;
                        }
                        else
                        {
                            optimizer.FirstAway3PA += Math.Abs(game.Away3PA - prediction.Away3PA) / game.Away3PA * 100;
                        }
                        if (game.Away3PM == 0)
                        {
                            optimizer.FirstAway3PM += 100;
                        }
                        else
                        {
                            optimizer.FirstAway3PM += Math.Abs(game.Away3PM - prediction.Away3PM) / game.Away3PM * 100;
                        }
                        optimizer.FirstAwayFGA += Math.Abs(game.AwayFGA - prediction.AwayFGA) / game.AwayFGA * 100;
                        optimizer.FirstAwayFGM += Math.Abs(game.AwayFGM - prediction.AwayFGM) / game.AwayFGM * 100;
                        if (game.AwayFTA == 0)
                        {
                            optimizer.FirstAwayFTA += 100;
                        }
                        else
                        {
                            optimizer.FirstAwayFTA += Math.Abs(game.AwayFTA - prediction.AwayFTA) / game.AwayFTA * 100;
                        }
                        if (game.AwayFTM == 0)
                        {
                            optimizer.FirstAwayFTM += 100;
                        }
                        else
                        {
                            optimizer.AwayFTM += Math.Abs(game.AwayFTM - prediction.AwayFTM) / game.AwayFTM * 100;
                        }
                        optimizer.FirstTotalHomePoints += Convert.ToInt16(prediction.HomePoints);
                        optimizer.FirstTotalHome3PA += Convert.ToInt16(prediction.Home3PA); 
                        optimizer.FirstTotalHome3PM += Convert.ToInt16(prediction.Home3PM); 
                        optimizer.FirstTotalHomeFGA += Convert.ToInt16(prediction.HomeFGA); 
                        optimizer.FirstTotalHomeFGM += Convert.ToInt16(prediction.HomeFGM); 
                        optimizer.FirstTotalHomeFTA += Convert.ToInt16(prediction.HomeFTA); 
                        optimizer.FirstTotalHomeFTM += Convert.ToInt16(prediction.HomeFTM); 
                        optimizer.FirstTotalAwayPoints += Convert.ToInt16(prediction.AwayPoints);
                        optimizer.FirstTotalAway3PA += Convert.ToInt16(prediction.Away3PA); 
                        optimizer.FirstTotalAway3PM += Convert.ToInt16(prediction.Away3PM); 
                        optimizer.FirstTotalAwayFGA += Convert.ToInt16(prediction.AwayFGA); 
                        optimizer.FirstTotalAwayFGM += Convert.ToInt16(prediction.AwayFGM); 
                        optimizer.FirstTotalAwayFTA += Convert.ToInt16(prediction.AwayFTA); 
                        optimizer.FirstTotalAwayFTM += Convert.ToInt16(prediction.AwayFTM); 
                    }
                    else
                    {
                        othergames++;
                        optimizer.HomePoints += Math.Abs(game.HomePoints - prediction.HomePoints) / game.HomePoints * 100;
                        if (game.Home3PA == 0)
                        {
                            optimizer.Home3PA += 100;
                        }
                        else
                        {
                            optimizer.Home3PA += Math.Abs(game.Home3PA - prediction.Home3PA) / game.Home3PA * 100;
                        }
                        if (game.Home3PM == 0)
                        {
                            optimizer.Home3PM += 100;
                        }
                        else
                        {
                            optimizer.Home3PM += Math.Abs(game.Home3PM - prediction.Home3PM) / game.Home3PM * 100;
                        }
                        optimizer.HomeFGA += Math.Abs(game.HomeFGA - prediction.HomeFGA) / game.HomeFGA * 100;
                        optimizer.HomeFGM += Math.Abs(game.HomeFGM - prediction.HomeFGM) / game.HomeFGM * 100;
                        if (game.HomeFTA == 0)
                        {
                            optimizer.HomeFTA += 100;
                        }
                        else
                        {
                            optimizer.HomeFTA += Math.Abs(game.HomeFTA - prediction.HomeFTA) / game.HomeFTA * 100;
                        }
                        if (game.HomeFTM == 0)
                        {
                            optimizer.HomeFTM += 100;
                        }
                        else
                        {
                            optimizer.HomeFTM += Math.Abs(game.HomeFTM - prediction.HomeFTM) / game.HomeFTM * 100;
                        }
                        optimizer.AwayPoints += Math.Abs(game.AwayPoints - prediction.AwayPoints) / game.AwayPoints * 100;
                        if (game.Away3PA == 0)
                        {
                            optimizer.Away3PA += 100;
                        }
                        else
                        {
                            optimizer.Away3PA += Math.Abs(game.Away3PA - prediction.Away3PA) / game.Away3PA * 100;
                        }
                        if (game.Away3PM == 0)
                        {
                            optimizer.Away3PM += 100;
                        }
                        else
                        {
                            optimizer.Away3PM += Math.Abs(game.Away3PM - prediction.Away3PM) / game.Away3PM * 100;
                        }
                        optimizer.AwayFGA += Math.Abs(game.AwayFGA - prediction.AwayFGA) / game.AwayFGA * 100;
                        optimizer.AwayFGM += Math.Abs(game.AwayFGM - prediction.AwayFGM) / game.AwayFGM * 100;
                        if (game.AwayFTA == 0)
                        {
                            optimizer.AwayFTA += 100;
                        }
                        else
                        {
                            optimizer.AwayFTA += Math.Abs(game.AwayFTA - prediction.AwayFTA) / game.AwayFTA * 100;
                        }
                        if (game.AwayFTM == 0)
                        {
                            optimizer.AwayFTM += 100;
                        }
                        else
                        {
                            optimizer.AwayFTM += Math.Abs(game.AwayFTM - prediction.AwayFTM) / game.AwayFTM * 100;
                        }
                        optimizer.FirstTotalHomePoints += Convert.ToInt16(prediction.HomePoints);
                        optimizer.FirstTotalHome3PA += Convert.ToInt16(prediction.Home3PA);
                        optimizer.FirstTotalHome3PM += Convert.ToInt16(prediction.Home3PM);
                        optimizer.FirstTotalHomeFGA += Convert.ToInt16(prediction.HomeFGA);
                        optimizer.FirstTotalHomeFGM += Convert.ToInt16(prediction.HomeFGM);
                        optimizer.FirstTotalHomeFTA += Convert.ToInt16(prediction.HomeFTA);
                        optimizer.FirstTotalHomeFTM += Convert.ToInt16(prediction.HomeFTM);
                        optimizer.FirstTotalAwayPoints += Convert.ToInt16(prediction.AwayPoints);
                        optimizer.FirstTotalAway3PA += Convert.ToInt16(prediction.Away3PA);
                        optimizer.FirstTotalAway3PM += Convert.ToInt16(prediction.Away3PM);
                        optimizer.FirstTotalAwayFGA += Convert.ToInt16(prediction.AwayFGA);
                        optimizer.FirstTotalAwayFGM += Convert.ToInt16(prediction.AwayFGM);
                        optimizer.FirstTotalAwayFTA += Convert.ToInt16(prediction.AwayFTA);
                        optimizer.FirstTotalAwayFTM += Convert.ToInt16(prediction.AwayFTM);
                    }
                }
            }
            optimizer.FirstHomePoints /= firstgames;
            optimizer.FirstHome3PA /= firstgames;
            optimizer.FirstHome3PM /= firstgames;
            optimizer.FirstHomeFGA /= firstgames;
            optimizer.FirstHomeFGM /= firstgames;
            optimizer.FirstHomeFTA /= firstgames;
            optimizer.FirstHomeFTM /= firstgames;
            optimizer.FirstAwayPoints /= firstgames;
            optimizer.FirstAway3PA /= firstgames;
            optimizer.FirstAway3PM /= firstgames;
            optimizer.FirstAwayFGA /= firstgames;
            optimizer.FirstAwayFGM /= firstgames;
            optimizer.FirstAwayFTA /= firstgames;
            optimizer.FirstAwayFTM /= firstgames;
            optimizer.HomePoints /= othergames;
            optimizer.Home3PA /= othergames;
            optimizer.Home3PM /= othergames;
            optimizer.HomeFGA /= othergames;
            optimizer.HomeFGM /= othergames;
            optimizer.HomeFTA /= othergames;
            optimizer.HomeFTM /= othergames;
            optimizer.AwayPoints /= othergames;
            optimizer.Away3PA /= othergames;
            optimizer.Away3PM /= othergames;
            optimizer.AwayFGA /= othergames;
            optimizer.AwayFGM /= othergames;
            optimizer.AwayFTA /= othergames;
            optimizer.AwayFTM /= othergames;
            this._dbContext.CoEfficientOptimizer.Add(optimizer);
            _unitOfWork.Commit();
        }
    }
}
