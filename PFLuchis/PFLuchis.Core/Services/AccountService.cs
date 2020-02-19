﻿using PFLuchis.Core.Entities;
using PFLuchis.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PFLuchis.Core.Services
{
    public class AccountService : IAccountService
    {
        //private readonly ICibertecContext _context;
        private readonly IPFLuchisContext _context;
        public AccountService(IPFLuchisContext context)
        {
            _context = context;
        }

        public User ValidateUser(string email, string password)
        {
            // obtener el registro de la bd
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

            return user;
        }
    }
}
