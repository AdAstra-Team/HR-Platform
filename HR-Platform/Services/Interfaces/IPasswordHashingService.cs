﻿namespace AdAstra.HRPlatform.API.Services.Interfaces
{
    public interface IPasswordHashingService
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}