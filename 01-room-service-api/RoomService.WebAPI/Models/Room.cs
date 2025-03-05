using System;
using System.ComponentModel.DataAnnotations;

namespace RoomService.WebAPI.Models
{
    public class Room
    {
        public int Id { get; set; }
        
        [Required]
        public string Category { get; set; }
        
        [Required]
        public int Number { get; set; }
        
        [Required]
        public int Floor { get; set; }
        
        public bool IsAvailable { get; set; }
        
        public long AddedDate { get; set; }
    }
}