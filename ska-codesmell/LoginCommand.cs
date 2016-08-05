using System.IO;

namespace ska_codesmell
{
    public class LoginCommand : Command
    {
        private static readonly char[] CommandChar = { (char)0x01 };

        public LoginCommand(string name, string password)
            : base(CommandChar, name, password)
        {

        }
    }
}
