using System.IO;

namespace ska_codesmell
{
    public class LoginCommand
    {
        private readonly string _Name;
        private readonly string _Password;

        public LoginCommand(string name, string password)
        {
            _Name = name;
            _Password = password;
        }

        private int GetSize()
        {
            return Constants.Header.Length +
                   Constants.SizeLength +
                   Constants.CmdByteLength +
                   _Name.Length + 1 +
                   _Password.Length + 1 +
                   Constants.Footer.Length;
        }

        public void Write(TextWriter writer)
        {
            writer.Write(Constants.Header);
            writer.Write(GetSize());
            writer.Write(Constants.CommandCharLogin);
            writer.Write(_Name);
            writer.Write((char)0x00);
            writer.Write(_Password);
            writer.Write((char)0x00);
            writer.Write(Constants.Footer);
        }
    }
}
