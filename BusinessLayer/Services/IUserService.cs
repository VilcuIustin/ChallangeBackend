﻿using Common.DTOs;
using Common.DTOs.Requests;
using Common.DTOs.Responses;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        public Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest loginData = default!);
        public Task<BaseResponse<bool>> EnrollAsync(RegisterRequest registerData = default!);
    }
}
