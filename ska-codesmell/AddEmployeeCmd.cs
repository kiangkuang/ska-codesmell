using System.IO;

namespace ska_codesmell
{
    public class AddEmployeeCmd
    {
        private readonly string _Name;
        private readonly string _Address;
        private readonly string _City;
        private readonly string _State;
        private readonly int _YearlySalary;

        public AddEmployeeCmd(string name, string address, string city, string state, int yearlySalary)
        {
            _Name = name;
            _Address = address;
            _City = city;
            _State = state;
            _YearlySalary = yearlySalary;
        }

        private int GetSize()
        {
            return Constants.Header.Length +
                   Constants.SizeLength +
                   Constants.CmdByteLength +
                   _Name.Length + 1 +
                   _Address.Length + 1 +
                   _City.Length + 1 +
                   _State.Length + 1 +
                   _YearlySalary.ToString().Length + 1 +
                   Constants.Footer.Length;
        }

        public void Write(TextWriter writer)
        {
            writer.Write(Constants.Header);
            writer.Write(GetSize());
            writer.Write(Constants.CommandCharAdd);
            writer.Write(_Name);
            writer.Write((char)0x00);
            writer.Write(_Address);
            writer.Write((char)0x00);
            writer.Write(_City);
            writer.Write((char)0x00);
            writer.Write(_State);
            writer.Write((char)0x00);
            writer.Write(_YearlySalary);
            writer.Write((char)0x00);
            writer.Write(Constants.Footer);
        }
    }
}
