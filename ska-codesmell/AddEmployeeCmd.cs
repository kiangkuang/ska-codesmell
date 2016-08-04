using System;
using System.IO;

namespace GeneralizationCs
{

	public class AddEmployeeCmd
	{
		private static readonly char[] Header = {(char)0xde, (char)0xad};
		private static readonly char[] CommandChar = {(char)0x02};
		private static readonly char[] Footer = {(char)0xbe, (char)0xef};
		private const int SizeLength = 1;
		private const  int CmdByteLength = 1;
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

		private int GetSize() {
			return Header.Length +  SizeLength +  CmdByteLength + Footer.Length +
				_name.Length + 1 +
				_address.Length + 1 +
				_city.Length + 1 +
				_state.Length + 1 +
				_yearlySalary.Length + 1;
		}


		public void Write(TextWriter writer) {
			writer.Write(Header);
			writer.Write(GetSize());
			writer.Write(CommandChar);
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
			writer.Write(Footer);
		}
	}
}
