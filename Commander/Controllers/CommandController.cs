using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
    //api/commands
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        //GET api/commands/
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllComands()
        {
            var commandItems = _repository.GetAllCommand();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
            
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int Id)
        {
            var commandItems = _repository.GetCommandById(Id);
            if(commandItems != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItems));
            }
            else 
                return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commanddModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commanddModel);
            _repository.SaveChanges();

            return Ok(commanddModel);

        } 

    }
}