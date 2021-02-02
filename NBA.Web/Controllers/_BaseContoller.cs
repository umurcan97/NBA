using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using NBA.Web.Helpers;

namespace NBA.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        #region redirect

        public ActionResult RedirectToDashboard()
        {
            return RedirectToAction("Index", "Home");
        }
        public JsonResult SendJson(object value)
        {
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region token

        /// <summary>
        /// Login veya Register sonrasinda Api'dan gelecek token bilgisini, Session'da saklamak icin kullanilan key
        /// </summary>
        public const string JwtSessionKey = "_jwt_";

        /// <summary>
        /// Session'dan, kullaniciya ait Auth bilgilerini tutan objeyi okumak icin kullanilir.
        /// Eger kullanici Register/Login olmadiysa bu method null deger donecektir
        /// Kullanici login olmus mu kontrolu icin sadece null kontrolu yapmak yeterlidir
        /// </summary>

        #endregion

        #region requester

        private readonly IRequester requester = new Requester();

        /// <summary>
        /// HTTP GET methodu
        /// </summary>
        /// <typeparam name="T">Response json objesinin donusturulecegi C# object tipi</typeparam>
        /// <param name="url">Request atilacak url</param>
        /// <returns></returns>
        public Task<Result<T>> Get<T>(string url)
        {
            return requester.Send<T>(new RequestInfo { HttpMethod = HttpMethod.Get, Url = url});
        }

        /// <summary>
        /// HTTP GET methodu
        /// </summary>
        /// <param name="url">Request atilacak url</param>
        /// <returns></returns>
        public Task<Result> Get(string url)
        {
            return requester.Send(new RequestInfo { HttpMethod = HttpMethod.Get, Url = url});
        }

        /// <summary>
        /// HTTP POST methodu
        /// </summary>
        /// <param name="url">Request atilacak url</param>
        /// <param name="data">request object icine aktarilacak olan C# object instance (json'a parse edilerek gonderiliyor)</param>
        /// <returns></returns>
        public Task<Result> Post(string url, object data)
        {
            return requester.Send(new RequestInfo { HttpMethod = HttpMethod.Post, Url = url, Data = data });
        }

        /// <summary>
        /// HTTP PUT methodu
        /// </summary>
        /// <param name="url">Request atilacak url</param>
        /// <param name="data">request object icine aktarilacak olan C# object instance (json'a parse edilerek gonderiliyor)</param>
        /// <returns></returns>
        public Task<Result> Put(string url, object data)
        {
            return requester.Send(new RequestInfo { HttpMethod = HttpMethod.Put, Url = url, Data = data });
        }

        /// <summary>
        /// HTTP DELETE methodu
        /// </summary>
        /// <param name="url">Request atilacak url</param>
        /// <param name="data">request object icine aktarilacak olan C# object instance (json'a parse edilerek gonderiliyor)</param>
        /// <returns></returns>
        public Task<Result> Delete(string url, object data)
        {
            return requester.Send(new RequestInfo { HttpMethod = HttpMethod.Delete, Url = url, Data = data });
        }

        /// <summary>
        /// HTTP POST methodu
        /// </summary>
        /// <typeparam name="T">api'dan gelecek response'i bind edebilecegimiz C# object tipi</typeparam>
        /// <param name="url">Request atilacak url</param>
        /// <param name="data">request object icine aktarilacak olan C# object instance (json'a parse edilerek gonderiliyor)</param>
        /// <returns></returns>
        public Task<Result<TResponse>> Post<TResponse>(string url, object data)
        {
            return requester.Send<TResponse>(new RequestInfo { HttpMethod = HttpMethod.Post, Url = url, Data = data });
        }

        /// <summary>
        /// HTTP DELETE methodu
        /// </summary>
        /// <typeparam name="T">api'dan gelecek response'i bind edebilecegimiz C# object tipi</typeparam>
        /// <param name="url">Request atilacak url</param>
        /// <param name="data">request object icine aktarilacak olan C# object instance (json'a parse edilerek gonderiliyor)</param>
        /// <returns></returns>
        public Task<Result<TResponse>> Delete<TResponse>(string url, object data)
        {
            return requester.Send<TResponse>(new RequestInfo { HttpMethod = HttpMethod.Delete, Url = url, Data = data });
        }

        /// <summary>
        /// HTTP PUT methodu
        /// </summary>
        /// <typeparam name="T">api'dan gelecek response'i bind edebilecegimiz C# object tipi</typeparam>
        /// <param name="url">Request atilacak url</param>
        /// <param name="data">request object icine aktarilacak olan C# object instance (json'a parse edilerek gonderiliyor)</param>
        /// <returns></returns>
        public Task<Result<TResponse>> Put<TResponse>(string url, object data)
        {
            return requester.Send<TResponse>(new RequestInfo { HttpMethod = HttpMethod.Put, Url = url, Data = data });
        }

        #endregion
    }
}