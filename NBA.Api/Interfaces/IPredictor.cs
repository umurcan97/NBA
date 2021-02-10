using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Api.Interfaces
{
    public interface IPredictor
    {
        void PredictQuarter(int QuarterNo, int GameNo);
        void CoefficientOptimizerGame(int No);
        void CoefficientOptimizerQuarter(int No);
    }
}
