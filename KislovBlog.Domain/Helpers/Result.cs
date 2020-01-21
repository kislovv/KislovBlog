using System;

namespace KislovBlog.Domain.Helpers
{
    public class Result
    {
        public bool Success { get; set; }

        public string Error { get; set; }

        public int ErrorCode { get; set; }

        public Result<T> ToResult<T>(T data = default) =>
            new Result<T> { Success = Success, Data = data, Error = Error };

        public T Match<T>(Func<T> ifComplete, Func<T> ifFail) => Success ? ifComplete() : ifFail();

        public static Result Complete() => new Result { Success = true };

        public static Result<T> Complete<T>(T data) => new Result<T> { Success = true, Data = data };

        public static Result Fail(string error, int errorCode = 0) =>
            new Result { Success = false, Error = error, ErrorCode = errorCode };

        public static Result<T> Fail<T>(string error, int errorCode = 0) =>
            new Result<T> { Success = false, Error = error, ErrorCode = errorCode };
    }

    public class Result<T> : Result
    {
        public T Data { get; set; }

        public TR Match<TR>(Func<T, TR> ifComplete, Func<TR> ifFail) => Success ? ifComplete(Data) : ifFail();
    }
}
