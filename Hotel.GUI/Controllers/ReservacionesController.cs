using Hotel.GUI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hotel.GUI.Controllers
{
    public class ReservacionesController : Controller
    {
        HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            var json = await client.GetStringAsync("https://localhost:44390/api/Reservaciones");
            var reservaciones = JsonConvert.DeserializeObject<IEnumerable<Reservaciones>>(json);
            return View(reservaciones);
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(Reservaciones reservaciones)
        {
            if (reservaciones != null)
            {
               var json = await client.PostAsJsonAsync("https://localhost:44390/api/Reservaciones/",reservaciones);
                if (json.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reservaciones);
                }
            }
            else
            {
                return View();

            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {

            var json = await client.GetStringAsync("https://localhost:44390/api/Reservaciones/"+Id);
            var reservaciones = JsonConvert.DeserializeObject<Reservaciones>(json);
            return View(reservaciones);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var json = await client.GetStringAsync("https://localhost:44390/api/Reservaciones/" + id);
            var reservaciones = JsonConvert.DeserializeObject<Reservaciones>(json);
            return View(reservaciones);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var json = await client.DeleteAsync("https://localhost:44390/api/Reservaciones/" + id);
            if (json.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public async Task<IActionResult> EditAsync(int id)
        {
            var json = await client.GetStringAsync("https://localhost:44390/api/Reservaciones/" + id);
            var reservaciones = JsonConvert.DeserializeObject<Reservaciones>(json);
            return View(reservaciones);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Reservaciones reservacion)
        {
            if (reservacion != null)
            {
                var json = await client.PutAsJsonAsync("https://localhost:44390/api/Reservaciones/"+id, reservacion);
                if (json.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(reservacion);
                }
            }
            else
            {
                return View(reservacion);

            }
        }
    }
}
