﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Client.DBContexts.Entities
{
    public class SavingSudoku
    {
        [Key]
        public int ID { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        [Required, MaxLength(64)]
        public string Name { get; set; }
        [Required]
        public string Data { get; set; }
        public DateTime Time { get; set; }
    }
}
