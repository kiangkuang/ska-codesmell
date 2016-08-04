using System;
using System.IO;

namespace GeneralizationCs
{

	public class AddEmployeeCmd
	{
		private static char[] header = {(char)0xde, (char)0xad};
		private static char[] commandChar = {(char)0x02};
		private static char[] footer = {(char)0xbe, (char)0xef};
		private const int SIZE_LENGTH = 1;
		private const  int CMD_BYTE_LENGTH = 1;
		private string name;
		private string address;
		private string city;
		private string state;
		private string yearlySalary;

		public AddEmployeeCmd(string name, string address, string city, string state, int yearlySalary)
		{
			this.name = name;
			this.address = address;
			this.city = city;
			this.state = state;
			this.yearlySalary = yearlySalary + "";
		}

		private int getSize() {
			return header.Length +  SIZE_LENGTH +  CMD_BYTE_LENGTH + footer.Length +
				name.Length + 1 +
				address.Length + 1 +
				city.Length + 1 +
				state.Length + 1 +
				yearlySalary.Length + 1;
		}


		public void Write(TextWriter writer) {
			writer.Write(header);
			writer.Write(getSize());
			writer.Write(commandChar);
			writer.Write(name);
			writer.Write((char)0x00);
			writer.Write(address);
			writer.Write((char)0x00);
			writer.Write(city);
			writer.Write((char)0x00);
			writer.Write(state);
			writer.Write((char)0x00);
			writer.Write(yearlySalary);
			writer.Write((char)0x00);
			writer.Write(footer);
		}
	}
}
