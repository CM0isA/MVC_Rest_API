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
        private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        public CommandsController(ICommanderRepo repo)
        {
            _repository = (MockCommanderRepo)repo;
        }        
        //GET api/commands/
        [HttpGet]
        public ActionResult <IEnumerable<Command>> GetAllComands()
        {
            var commandItems = _repository.GetAppCommand();

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