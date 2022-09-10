using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.API.Data;
using PlatformService.API.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDTO>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms...");

            var platformItems = _repository.GetAllPlatforms();
            
            return Ok(_mapper.Map<IEnumerable<PlatformReadDTO>>(platformItems));
        }
    }
}
