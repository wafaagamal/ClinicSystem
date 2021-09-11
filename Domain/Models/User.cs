using System;
using System.Collections.Generic;

#nullable disable

namespace Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string MobileNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
