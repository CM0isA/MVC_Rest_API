using System.Collections.Generic;
using Commander.Data;
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

        public CommandsController(ICommanderRepo repo)
        {
            _repository = repo;
        }        
        //GET api/commands/
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllComands()
        {
            var commandItems = _repository.GetAllCommand();

            return Ok(commandItems);
            
        }
        //GET api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult <Command> GetCommandById(int Id)
        {
            var commandItems = _repository.GetCommandById(Id);
            return Ok(commandItems);
        }

    }
}