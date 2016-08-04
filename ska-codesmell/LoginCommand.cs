using System;
using System.IO;


namespace ska_codesmell
{
	public class LoginCommand
	{
		private readonly string _name;
		private readonly string _password;

		private static readonly char[] Header = {(char)0xde, (char)0xad};
		private static readonly char[] CommandChar = {(char)0x01};
		private static readonly char[] Footer = {(char)0xbe, (char)0xef};
		private const int SizeLength = 1;
		private const int CmdByteLength = 1;


		public LoginCommand(string name, string password)
		{
			_name = name;
			_password = password;
		}

		private int GetSize() {
			return Header.Length +  SizeLength +  CmdByteLength + Footer.Length +
				_name.Length + 1 +
				_password.Length + 1;
		}
		public void Write(TextWriter writer) {
			writer.Write(Header);
			writer.Write(GetSize());
			writer.Write(CommandChar);
			writer.Write(_name);
			writer.Write((char)0x00);
			writer.Write(_password);
			writer.Write((char)0x00);
			writer.Write(Footer);
		}
	}
}
