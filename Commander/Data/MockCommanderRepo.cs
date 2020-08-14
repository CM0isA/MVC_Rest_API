using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommand()
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

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}