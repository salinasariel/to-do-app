﻿using System.ComponentModel.DataAnnotations;

namespace simple_to_do.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string address { get; set; }

    }
}
