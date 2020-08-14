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
        [HttpGet("{id}", Name = "GetCommandById")]
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

            var commandReadDto = _mapper.Map<CommandReadDto>(commanddModel);
            
            
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);
            //return Ok(commandReadDto);

        } 

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            
            _mapper.Map(commandUpdateDto, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

    }
}