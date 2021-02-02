using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Model
{
    public interface IUnitOfWork
    {
        int Commit();
    }
}
