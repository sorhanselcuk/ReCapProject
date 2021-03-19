using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public const string Success = "The process successfully completed !";
        public const string Error = "Someting went wrong !";
        public const string ThereIsNoSuchData = "There is no such data !";
        public const string CarIsNotAvailable = "The car is not available !";
        public const string ThereIsNoSuchEMail = "There is no such E-Mail !";
        public const string NoImageHasBeenUploadedYet = "No image has been uploaded yet !";
        public const string UserRegistered = "The user successfully registered !";
        public const string UserNotFound = "This user not found !";
        public const string PasswordError = "The password is wrong !";
        public const string SuccessfulLogin = "The user successfully entered the system.";
        public const string UserAlreadyExists = "This user has already exists !";
        public const string AccessTokenCreated = "The Access Token Successfully Created !";
        public const string AuthorizationDenied = "You are not Authorized";
    }
}
