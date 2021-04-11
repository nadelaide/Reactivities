using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class ConcertsController : BaseApiController
    {
        private readonly DataContext _context;
        public ConcertsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Concert>>> GetConcerts()
        {
            return await _context.Concerts.ToListAsync();
        }

        [HttpGet("{id}")] // concerts/id
        public async Task<ActionResult<Concert>> GetConcert(Guid id)
        {
            return await _context.Concerts.FindAsync(id);
        }
    }
}