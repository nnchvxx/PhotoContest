using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoContest.Data.Models
{
    public class UserContest
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ContestId { get; set; }
        public Contest Contest { get; set; }
        public int Points { get; set; }
        public bool IsAdded { get; set; }
        public bool IsInvited { get; set; }
        public bool HasUploadedPhoto { get; set; }
    }
}
