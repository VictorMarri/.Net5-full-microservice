using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.API.Data;
using PlatformService.API.DTOs;
using PlatformService.API.Models;
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

        [Route("{id}", Name = "GetPlatformById")]
        [HttpGet]
        public ActionResult<PlatformReadDTO> GetPlatformById(int id)
        {
            var platformItem = _repository.GetPlatformById(id);

            if(platformItem == null) return NotFound();

            return Ok(_mapper.Map<PlatformReadDTO>(platformItem));
        }

        [HttpPost]
        public ActionResult<PlatformReadDTO> CreatePlatform(PlatformCreateDTO platformCreateDTO)
        {
            var platformCreate = _mapper.Map<Platform>(platformCreateDTO);

            _repository.CreatePlatform(platformCreate);
            _repository.SaveChanges(); // -> Otimizar isso dentro das consultas no Repositorio (pra cada uma)

            var platformReadDTO = _mapper.Map<PlatformReadDTO>(platformCreate);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDTO.Id }, platformReadDTO);
        }

        //TODO: Rota de exclusão de dados
    }
}
