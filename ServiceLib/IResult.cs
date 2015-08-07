using System;

namespace ServiceLib
{
    public interface IResult
    {
        Exception Exception { get; set; }
        Guid Id { get; }
        System.Collections.Generic.List<IResult> InnerResults { get; }
        string Message { get; set; }
        bool Success { get; set; }
    }
}