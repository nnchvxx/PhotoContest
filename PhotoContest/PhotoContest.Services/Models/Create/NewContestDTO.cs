﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace PhotoContest.Services.Models.Create
{
    public class NewContestDTO
    {
        [Required, StringLength(50, MinimumLength = 5, ErrorMessage = "Contest name should be between {1} and {2} characters.")]
        public string Name { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        [Required]
        public Guid StatusId { get; set; }
        [Required]
        public DateTime Phase1 { get; set; }
        [Required]
        public DateTime Phase2 { get; set; }
        [Required]
        public DateTime Finished { get; set; }
    }
}