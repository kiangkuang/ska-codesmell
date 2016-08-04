using System;
using System.IO;


namespace GeneralizationCs
{
	public class LoginCommand
	{
		private string name;
		private string password;

		private static char[] header = {(char)0xde, (char)0xad};
		private static char[] commandChar = {(char)0x01};
		private static char[] footer = {(char)0xbe, (char)0xef};
		private const int SIZE_LENGTH = 1;
		private const int CMD_BYTE_LENGTH = 1;


		public LoginCommand(string name, string password)
		{
			this.name = name;
			this.password = password;
		}

		private int getSize() {
			return header.Length +  SIZE_LENGTH +  CMD_BYTE_LENGTH + footer.Length +
				name.Length + 1 +
				password.Length + 1;
		}
		public void Write(TextWriter writer) {
			writer.Write(header);
			writer.Write(getSize());
			writer.Write(commandChar);
			writer.Write(name);
			writer.Write((char)0x00);
			writer.Write(password);
			writer.Write((char)0x00);
			writer.Write(footer);
		}
	}
}
