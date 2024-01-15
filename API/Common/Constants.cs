﻿namespace BulbEd.Common;

public static class Constants
{
    public static class Urls
    {
        private const string Url = "https://localhost:5001/api/";
        public const string Register = Url + "register";
        public const string ResetPassword = Url + "resetpassword";
    }

    public static class Messages
    {
        public const string InvalidEmail = "Invalid email address";
        public const string PasswordResetLinkSent = "Password reset link sent to email";
        public const string PasswordResetLinkMessage = "Please reset your password by clicking the following link: ";
        public const string PasswordResetSuccess = "Password reset successfully";
    }

    // Add more constants as needed
}