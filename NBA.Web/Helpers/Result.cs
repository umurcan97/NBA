using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NBA.Web.Helpers
{
    public class Result
    {
        public bool Failed { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }

        public Exception Exception { get; set; }

        public static Result NewFailure(string message)
        {
            return new Result { Failed = true, Message = message };
        }
        public static Result NewSuccess()
        {
            return new Result();
        }
        public static Result NewException(Exception exception)
        {
            return new Result { Exception = exception, Failed = true, Message = exception.Message, Code = -1 };
        }

        public static Result NewUnauthorized()
        {
            return new Result { Failed = true, Message = "Unauthorized", Code = -2 };
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public static new Result<T> NewFailure(string message)
        {
            return new Result<T> { Failed = true, Message = message };
        }
        public static Result<T> NewSuccess(T data)
        {
            return new Result<T> { Data = data };
        }
        public static new Result<T> NewException(Exception exception)
        {
            return new Result<T> { Exception = exception, Failed = true, Message = exception.Message, Code = -1 };
        }
    }
}