using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MessageBoardAPI.Models
{
  public class Message
  {
        public int MessageId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Group { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Author { get; set; }
  }
}