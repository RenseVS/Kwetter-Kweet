using System;
namespace Kweet_Service.Entities
{
	public class Tweet
	{
        public string UserID { get; set; }
        public string TweetID { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime TweetDate { get; set; }
    }
}

