using System.IO;

namespace ska_codesmell
{
    public class Command
    {
        private const int SizeLength = 1;
        private const int CmdByteLength = 1;
        private static readonly char[] Header = { (char)0xde, (char)0xad };
        private static readonly char[] Footer = { (char)0xbe, (char)0xef };

        private readonly char[] _CommandChar;
        private readonly string[] _Parameters;

        protected Command(char[] commandChar, params string[] parameters)
        {
            _CommandChar = commandChar;
            _Parameters = parameters;
        }

        private int GetSize()
        {
            int size = Header.Length +
                       SizeLength +
                       CmdByteLength +
                       Footer.Length;

            foreach (string parameter in _Parameters)
            {
                size += parameter.Length + 1;
            }

            return size;
        }

        public void Write(TextWriter writer)
        {
            writer.Write(Header);
            writer.Write(GetSize());
            writer.Write(_CommandChar);
            foreach (string parameter in _Parameters)
            {
                writer.Write(parameter);
                writer.Write((char)0x00);
            }
            writer.Write(Footer);
        }
    }
}
