using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public IEnumerable<Command> GetAppCommand()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, Title="egg", Description="Boil Water", Link="Kettle and Pan"},
                
            };
            return commands;
           
        }

        public Command GetCommandById(int Id)
        {
            return new Command{Id=0, Title="egg", Description="Boil Water", Link="Kettle and Pan"};
        }
    }
}