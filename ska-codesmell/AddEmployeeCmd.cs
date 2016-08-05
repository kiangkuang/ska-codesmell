using System.IO;

namespace ska_codesmell
{
    public class AddEmployeeCmd : Command
    {
        private static readonly char[] CommandChar = { (char)0x02 };

        public AddEmployeeCmd(string name, string address, string city, string state, int yearlySalary)
            : base(CommandChar, name, address, city, state, yearlySalary.ToString())
        {

        }
    }
}
