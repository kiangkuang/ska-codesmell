using System.IO;
using NUnit.Framework;

namespace ska_codesmell.UnitTests
{
    [TestFixture]
    public class AddEmployeeCmdTest
    {
        [TestCase("John Smith", "456 His House", "Autumnland", "NZ", 12345)]
        [TestCase("Fred Brooks", "123 My House", "Springfield", "IL", 72000)]
        public void TestAddEmployeeCmdWriter(string name, string address, string city, string state, int yearlySalary)
        {
            StringWriter expectedWriter = new StringWriter();

            expectedWriter.Write(new char[] { (char)0xde, (char)0xad });
            expectedWriter.Write(name.Length + address.Length + city.Length + state.Length + yearlySalary.ToString().Length + 11);
            expectedWriter.Write((char)0x02);
            expectedWriter.Write(name);
            expectedWriter.Write((char)0x00);
            expectedWriter.Write(address);
            expectedWriter.Write((char)0x00);
            expectedWriter.Write(city);
            expectedWriter.Write((char)0x00);
            expectedWriter.Write(state);
            expectedWriter.Write((char)0x00);
            expectedWriter.Write(yearlySalary);
            expectedWriter.Write(new char[] { (char)0x00, (char)0xbe, (char)0xef });

            string expected = expectedWriter.ToString();

            AddEmployeeCmd cmd = new AddEmployeeCmd(name, address, city, state, yearlySalary);
            StringWriter writer = new StringWriter();
            cmd.Write(writer);

            string actual = writer.ToString();

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], "comparison failed at byte number " + i);
            }
        }
    }
}
