using System.IO;

namespace ska_codesmell
{
    public class AddEmployeeCmd
    {
        private readonly string _name;
        private readonly string _address;
        private readonly string _city;
        private readonly string _state;
        private readonly string _yearlySalary;

        public AddEmployeeCmd(string name, string address, string city, string state, int yearlySalary)
        {
            _name = name;
            _address = address;
            _city = city;
            _state = state;
            _yearlySalary = yearlySalary + "";
        }

        private int GetSize()
        {
            return Constants.Header.Length + Constants.SizeLength + Constants.CmdByteLength + Constants.Footer.Length +
                _name.Length + 1 +
                _address.Length + 1 +
                _city.Length + 1 +
                _state.Length + 1 +
                _yearlySalary.Length + 1;
        }

        public void Write(TextWriter writer)
        {
            writer.Write(Constants.Header);
            writer.Write(GetSize());
            writer.Write(Constants.CommandCharAdd);
            writer.Write(_name);
            writer.Write((char)0x00);
            writer.Write(_address);
            writer.Write((char)0x00);
            writer.Write(_city);
            writer.Write((char)0x00);
            writer.Write(_state);
            writer.Write((char)0x00);
            writer.Write(_yearlySalary);
            writer.Write((char)0x00);
            writer.Write(Constants.Footer);
        }
    }
}
