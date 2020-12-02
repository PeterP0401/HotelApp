using AutoMapper;
using Hotel.Domain.DTOs;
using Hotel.Domain.Entity;
using Hotel.Domain.Interfaces;
using Hotel.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservacionesController : ControllerBase
    {
        private readonly IReservacionesIRepository _repository;
        public ReservacionesController(IReservacionesIRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reservaciones = await _repository.GetReservacion();

            return Ok(reservaciones);
        }
        [HttpGet("{Id_Reserva:int}")]
        public async Task<IActionResult> Get(int Id_Reserva)
        {
            var reservacion = await _repository.GetReservacion(Id_Reserva);
            return Ok(reservacion);
        }
        [HttpPost]
        public async Task<IActionResult> Post(Reservaciones reservacion)
        {
            await _repository.AddReservacion(reservacion);
            return Ok(reservacion);
        }
        [HttpDelete("{Id_Reserva:int}")]
        public async Task<ActionResult> Delete(int Id_Reserva)
        {
            var result = await _repository.DeleteReservacion(Id_Reserva);
            return Ok(result);
        }
        [HttpPut("{Id_Reserva:int}")]
        public async Task<IActionResult> Put(int Id_Reserva, Reservaciones reservacionDto)
        {
            reservacionDto.IdReserva = Id_Reserva;
            var result = await _repository.UpdateReservacion(reservacionDto);
            return Ok(result);
        }


    }
}

