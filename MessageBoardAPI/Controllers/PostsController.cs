using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardAPI.Models;

namespace MessageBoardAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private MessageBoardAPIContext _db;
    public PostsController(MessageBoardAPIContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> Get(DateTime StartDate, DateTime EndDate, [FromQuery] PaginationFilter filter)
    {
      IQueryable<Post> postQuery = _db.Posts;
      if (StartDate != DateTime.MinValue)
      {
        postQuery = postQuery.Where(p => p.CreationDate >= StartDate);
      }
      if (EndDate != DateTime.MinValue)
      {
        postQuery = postQuery.Where(p => EndDate >= p.CreationDate);
      }
      List<Post> queryResult = await postQuery
        .Skip((filter.PageNumber - 1) * filter.PageSize)
        .Take(filter.PageSize)
        .ToListAsync();
      return queryResult;
    }
    
    [HttpGet("{PostId}")]
    public async Task<ActionResult<Post>> Get(int PostId)
    {
      Post post = await _db.Posts.Include(p => p.User).FirstAsync(p => p.PostId == PostId);
      return post;
    }

    [HttpPut("{PostId}")]
    public void  Put(int PostId, [FromQuery] int UserId, [FromBody] Post post)
    {
      if (post.UserId == UserId)
      {
        post.PostId = PostId;
        _db.Entry(post).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }

    [HttpDelete("{PostId}")]
    public async Task Delete(int PostId, [FromQuery] int UserId)
    {
      Post postToDelete = await _db.Posts.FirstAsync(p => p.PostId == PostId);
      if (postToDelete.UserId == UserId)
      {
        _db.Posts.Remove(postToDelete);
        _db.SaveChanges();
      }
    }
  }
}