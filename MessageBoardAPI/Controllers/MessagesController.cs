using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoardAPI.Models;

namespace MessageBoardAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardAPIContext _db;

    public MessagesController(MessageBoardAPIContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<List<Message>> Get(string groups, string authors, DateTime date)
    {
      IQueryable<Message> query = _db.Messages.AsQueryable();
      if (groups != null)
      {
        query = query.Where(entry => entry.Group == groups);
      }
      if (authors != null)
      {
        query = query.Where(entry => entry.Author == authors);
      }
      if (date != DateTime.MinValue)
      {
        query = query.Where(entry => entry.Date == date);
      }
      return await query.ToListAsync();
    }

    // POST api/Messages
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId}, message);
    }
    // GET: api/Messages/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
        var message = await _db.Messages.FindAsync(id);

        if (message == null)
        {
            return NotFound();
        }

        return message;
    }
        // PUT: api/Messages/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      _db.Entry(message).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }
    // DELETE: api/Messages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}