﻿using Microsoft.AspNetCore.Identity;
using PhotoContest.Data.Audit;
using PhotoContest.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PhotoContest.Data
{
    public class User : IdentityUser<Guid>, IEntity
    {
        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "Value for {0} should be between {1} and {2} characters.")]
        public string FirstName { get; set; }

        [Required, StringLength(20, MinimumLength = 2, ErrorMessage = "Value for {0} should be between {1} and {2} characters.")]
        public string LastName { get; set; }
        public Guid RankId { get; set; }
        public Rank Rank { get; set; }
        //public int CurrentScore { get; set; }
        [NotMapped]
        public Dictionary<Guid, int> ContestScores { get; set; } = new Dictionary<Guid, int>();
        public ICollection<Photo> Photos { get; set; } = new List<Photo>();
        public ICollection<UserContest> UserContests { get; set; } = new List<UserContest>();
        public ICollection<Jury> Juries { get; set; } = new List<Jury>();
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}