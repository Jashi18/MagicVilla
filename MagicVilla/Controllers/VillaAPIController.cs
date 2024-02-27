﻿using MagicVilla.Models;
using MagicVilla.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<VillaDTO> GetVillas()
        {
            return new List<VillaDTO>()
            {
                new VillaDTO() {Id = 1, Name ="Beach View"},
                new VillaDTO() {Id = 2,Name = "Pool View"}
            };
        }
    }
}