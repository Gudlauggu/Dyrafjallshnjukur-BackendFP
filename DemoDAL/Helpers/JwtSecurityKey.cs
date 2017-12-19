﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Helpers
{
    class JwtSecurityKey
    {
        private static byte[] secretBytes = Encoding.UTF8.GetBytes("A secret for HmacSha256");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(secretBytes); }
        }

        public static void SetSecret(string secret)
        {
            secretBytes = Encoding.UTF8.GetBytes(secret);
        }
    }
}