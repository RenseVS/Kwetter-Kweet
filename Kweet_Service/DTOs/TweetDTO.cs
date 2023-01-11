using System;
using System.ComponentModel.DataAnnotations;

namespace Kweet_Service.DTOs
{
	public class TweetDTO
	{
        public string UserID { get; set; }
        public string TweetID { get; set; }
        public string UserName { get; set; }
        [Required]
        [MaxLength(140)]
        public string Message { get; set; }
        public DateTime TweetDate { get; } = DateTime.Now;
    }
}

