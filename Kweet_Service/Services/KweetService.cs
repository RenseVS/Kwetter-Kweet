using System;
using AutoMapper;
using Kweet_Service.Data;
using Kweet_Service.DTOs;
using Kweet_Service.Entities;
using MassTransit;
using MessageContracts;
using MongoDB.Driver;

namespace Kweet_Service.Services
{
	public class KweetService
	{
		private readonly IDBContext _context;
		private readonly IMapper _mapper;
        private readonly IPublishEndpoint _endpoint;
        public KweetService(IDBContext context, IMapper mapper, IPublishEndpoint endpoint)
		{
			_context = context;
			_mapper = mapper;
            _endpoint = endpoint;
		}

		public async Task<TweetDTO> Tweet(TweetDTO tweet) {
			Tweet entity = _mapper.Map<TweetDTO, Tweet>(tweet);
            await _context.Tweet.InsertOneAsync(entity);
            await _endpoint.Publish(_mapper.Map<Tweet, TweetMade>(entity));
            return tweet;
        }

        public async Task<TweetDTO> GetTweet(string tweetID)
        {
            Tweet entity = await _context.Tweet.Find(x => x.TweetID == tweetID).FirstOrDefaultAsync();
            return _mapper.Map<Tweet, TweetDTO>(entity);
        }

		public async Task<IEnumerable<TweetDTO>> GetUserTweets(string userID) {
            IEnumerable<Tweet> entity = await _context.Tweet.Find(x => x.UserID == userID).ToListAsync();
            return _mapper.Map<IEnumerable<Tweet>, IEnumerable<TweetDTO>>(entity);
        }
    }
}

