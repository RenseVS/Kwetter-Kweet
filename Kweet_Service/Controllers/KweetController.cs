using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kweet_Service.DTOs;
using Kweet_Service.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kweet_Service.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class KweetController : Controller
    {
        private readonly KweetService _kweetService;
        public KweetController(KweetService kweetService)
        {
            _kweetService = kweetService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TweetDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TweetDTO>> Kweet([FromBody] TweetDTO tweet)
        {
            try
            {
                var result = await _kweetService.Tweet(tweet);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("user/{userid}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TweetDTO>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TweetDTO>>> GetUserTweets([FromRoute] string userid)
        {
            try
            {
                var result = await _kweetService.GetUserTweets(userid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Route("tweet/{tweetid}")]
        [HttpGet]
        [ProducesResponseType(typeof(TweetDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TweetDTO>> GetTweet([FromRoute] string tweetid)
        {
            try
            {
                var result = await _kweetService.GetTweet(tweetid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

