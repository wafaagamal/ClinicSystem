﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Presentation
{
    public class SecretaryVM
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public bool IsActive { set; get; }

    }
}
