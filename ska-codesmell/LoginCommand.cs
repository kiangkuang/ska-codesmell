using System.IO;

namespace ska_codesmell
{
    public class LoginCommand
    {
        private readonly string _name;
        private readonly string _password;

        public LoginCommand(string name, string password)
        {
            _name = name;
            _password = password;
        }

        private int GetSize()
        {
            return Constants.Header.Length + Constants.SizeLength + Constants.CmdByteLength + Constants.Footer.Length +
                _name.Length + 1 +
                _password.Length + 1;
        }
        public void Write(TextWriter writer)
        {
            writer.Write(Constants.Header);
            writer.Write(GetSize());
            writer.Write(Constants.CommandChar);
            writer.Write(_name);
            writer.Write((char)0x00);
            writer.Write(_password);
            writer.Write((char)0x00);
            writer.Write(Constants.Footer);
        }
    }
}
