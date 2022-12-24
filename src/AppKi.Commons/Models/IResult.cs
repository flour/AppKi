﻿namespace AppKi.Commons.Models;

public interface IResult
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public int StatusCode { get; set; }
}

public interface IResult<T> : IResult
{
    T Data { get; set; }
}