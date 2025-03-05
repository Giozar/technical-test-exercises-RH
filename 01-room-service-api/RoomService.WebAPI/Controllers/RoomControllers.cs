using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoomService.WebAPI.Models;

namespace RoomService.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        // Lista que simula una base de datos en memoria
        private static readonly List<Room> _rooms = new List<Room>();
        
        // Método para pruebas - permite limpiar la lista de habitaciones
        public void ClearRooms()
        {
            _rooms.Clear();
        }

        // GET api/rooms
        [HttpGet]
        public IActionResult GetAllRooms([FromQuery] List<int> Floors)
        {
            // Si se proporcionan pisos para filtrar
            if (Floors != null && Floors.Any())
            {
                var filteredRooms = _rooms.Where(r => Floors.Contains(r.Floor)).ToList();
                return Ok(filteredRooms);
            }

            // Si no hay filtros, devolver todas las habitaciones
            return Ok(_rooms);
        }

        // GET api/rooms/{id}
        [HttpGet("{id}")]
        public IActionResult GetRoomById(int id)
        {
            var room = _rooms.FirstOrDefault(r => r.Id == id);
            
            if (room == null)
                return NotFound($"Room con ID {id} no encontrado");

            return Ok(room);
        }

        // POST api/rooms
        [HttpPost]
        public IActionResult CreateRoom([FromBody] Room room)
        {
            // Validar si el modelo es válido
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Verificar si ya existe una habitación con el mismo ID
            if (_rooms.Any(r => r.Id == room.Id))
                return Conflict($"Ya existe una habitación con ID {room.Id}");

            // Si no se proporciona la fecha, asignar la fecha actual en formato Unix timestamp
            if (room.AddedDate == 0)
            {
                var dateTimeOffset = DateTimeOffset.UtcNow;
                room.AddedDate = dateTimeOffset.ToUnixTimeSeconds();
            }

            _rooms.Add(room);
            return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
        }
    }
}