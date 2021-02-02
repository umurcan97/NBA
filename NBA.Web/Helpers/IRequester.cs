using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Web.Helpers
{
    public interface IRequester
    {
        Task<Result> Send(RequestInfo requestInfo);
        Task<Result<TResponse>> Send<TResponse>(RequestInfo requestInfo);
    }
}
