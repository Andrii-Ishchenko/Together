﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Together.Domain.Identity;

namespace Together.Domain
{
    public class GroupUser
    {
        [Key, Column(Order = 0)]
        public int GroupId { get; set; }

        [Key, Column(Order = 1)]
        public int UserId { get; set; }
        
        public virtual Group Group { get; set; }

        public virtual AppUser User { get; set; }
    }
}
