﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace Esmeralda.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public UserProfile UserProfile { get; set; }
        public AdminProfile AdminProfile { get; set; }
    }
}