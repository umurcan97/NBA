using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBA.Api.Interfaces;
using NBA.Model;

namespace NBA.Api.Entities
{
    public class OddCalculator : IOddCalculator
    {
        private readonly INBAContext _dbContext;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGetStatMethods _getStatMethods;
        private readonly ISimulator _simulator;

        public OddCalculator(
            INBAContext dbContext,
            IUnitOfWork unitOfWork,
            IGetStatMethods getStatMethods,
            ISimulator simulator
        )
        {
            this._dbContext = dbContext;
            this._unitOfWork = unitOfWork;
            this._getStatMethods = getStatMethods;
            this._simulator = simulator;
        }

    }
}
