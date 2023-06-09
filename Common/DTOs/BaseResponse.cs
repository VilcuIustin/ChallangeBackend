﻿namespace Common.DTOs
{
    public class BaseResponse<T>
    {
        public T Content { get; set; } = default;
        public string? Error { get; set; } = null;
        public int StatusCode = 200;

        public BaseResponse()
        {

        }

        public BaseResponse(T value)
        {
            Content = value;
        }
    }
}
