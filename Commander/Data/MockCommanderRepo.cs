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
                new Command{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle and Pan"},
                new Command{Id=1, HowTo="Make popcorn", Line="Boil Water", Platform="Blender"},
                new Command{Id=2, HowTo="Drink water", Line="Pour water", Platform="Wine bottle"}
                
            };
            return commands;
           
        }

        public Command GetCommandById(int Id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil Water", Platform="Kettle and Pan"};
        }
    }
}