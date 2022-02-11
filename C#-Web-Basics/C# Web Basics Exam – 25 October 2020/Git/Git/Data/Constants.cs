using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git.Data
{
    public static class Constants
    {
        public const int DefaultMaxLenght = 20;
        public const int UsernameMinLenght = 5;
        public const int PasswordMinLenght = 6;
        public const string UsernameEmailValidator = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int RepositoryMaxLenght = 10;
        public const int RepositoryMinLenght = 3;
        public const string RepositoryPublicStatus = "Public";
        public const string RepositoryPrivateStatus = "Private";

        public const int CommentDescriptionMinLenght = 5;
    }
}
