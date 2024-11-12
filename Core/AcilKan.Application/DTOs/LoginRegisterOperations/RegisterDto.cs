﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Application.DTOs.LoginRegisterOperations
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodGroup { get; set; }
        public bool Gender { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
    }
}