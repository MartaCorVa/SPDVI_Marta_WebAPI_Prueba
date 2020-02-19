using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SPDVI_Marta_WebAPI.Models
{
    public class PlayerModel
    {
        public string Id;
        public string FirstName;
        public string LastName;
        public string Email;
        public DateTime DateOfBirth;
        public string NickName;
        public string City;
        public DateTime DateJoined;
        public string BlobUri;
    }
}