﻿using System;

namespace SharedLibrary.ResponseDtos
{
    public class OperationResult<T>
    {
        public StatusCode StatusCode { get; private set; }
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }
        public Exception Exception { get; set; }
        public T Data { get; private set; }
        public static OperationResult<T> NoContentSuccessResult()
        {
            return new OperationResult<T> { Success = true, StatusCode = StatusCode.NoContent };
        }
        public static OperationResult<T> CreatedSuccessResult()
        {
            return new OperationResult<T> { Success = true, StatusCode = StatusCode.Created };
        }
        public static OperationResult<T> OkSuccessResult(T data)
        {
            return new OperationResult<T> { Success = true, Data = data, StatusCode = StatusCode.Ok};
        }
        public static OperationResult<T> CreateFailure(string errorMessage, StatusCode statusCode)
        {
            return new OperationResult<T> { ErrorMessage = errorMessage, Success = false, StatusCode = statusCode};
        }
        public static OperationResult<T> CreateFailure(Exception ex)
        {
            return new OperationResult<T>
            {
                Success = false,
                Exception = ex,
                ErrorMessage = String.Format("{0}{1}{2}", ex.Message, Environment.NewLine, ex.StackTrace),
                StatusCode = StatusCode.Error
            };
        }
    }
    public enum StatusCode
    {
        Ok = 200,
        NotFound = 404,
        BadRequest = 400,
        NoContent = 204,
        Created = 201,
        Forbidden = 403,
        Error = 500
    }
}