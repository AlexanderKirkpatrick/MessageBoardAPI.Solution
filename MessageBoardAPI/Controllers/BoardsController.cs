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
  public class BoardsController : ControllerBase
  {
    private MessageBoardAPIContext _db;
    public BoardsController(MessageBoardAPIContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Board>>> Get()
    {
      List<Board> boardList = await _db.Boards.ToListAsync();
      return boardList;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Board>> Get(int id)
    {
      Board board = await _db.Boards
        .Include(b => b.Threads)
        .FirstAsync(b => b.BoardId == id);
      return board;
    }

    [HttpPost]
    public void Post([FromBody] Board board)
    {
      _db.Boards.Add(board);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Board board)
    {
      board.BoardId = id;
      _db.Entry(board).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
      Board board = await _db.Boards.FirstAsync(b => b.BoardId == id);
      _db.Boards.Remove(board);
      _db.SaveChanges();
    }

    [HttpGet("{BoardId}/threads")]
    public async Task<ActionResult<IEnumerable<Thread>>> ThreadGet(int BoardId)
    {
      List<Thread> theseThreads = await _db.Threads
        .Where(t => t.ParentBoardId == BoardId)
        .Include(t => t.User)
        .ToListAsync();
      return theseThreads;
    }

    [HttpPost("{BoardId}/threads")]
    public async Task Post(int BoardId, [FromBody] Thread thread)
    {
      Board board = await _db.Boards.FirstAsync(b => b.BoardId == BoardId);
      board.Threads.Add(thread);
      _db.SaveChanges();
    }

    [HttpPut("{BoardId}/threads/{ThreadId}")]
    public async Task Put(int BoardId, int ThreadId, [FromBody] Thread thread)
    {
      Board board = await _db.Boards.FirstAsync(b => b.BoardId == BoardId);
      thread.ThreadId = ThreadId;
      _db.Entry(thread).State = EntityState.Modified;
      _db.SaveChanges();
    }
  }
}