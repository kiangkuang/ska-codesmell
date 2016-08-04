using System.IO;
using NUnit.Framework;

namespace ska_codesmell.UnitTests
{
    [TestFixture]
    public class LoginCommandTest
    {
        [TestCase("alice", "p@ssw0rd")]
        [TestCase("bab", "cardinals")]
        public void TestLoginCommandWriter(string name, string password)
        {
            StringWriter expectedWriter = new StringWriter();

            expectedWriter.Write(new char[] { (char)0xde, (char)0xad });
            expectedWriter.Write(name.Length + password.Length + 8);
            expectedWriter.Write(new char[] { (char)0x01 });
            expectedWriter.Write(name);
            expectedWriter.Write((char)0x00);
            expectedWriter.Write(password);
            expectedWriter.Write(new char[] { (char)0x00, (char)0xbe, (char)0xef });

            string expected = expectedWriter.ToString();

            LoginCommand cmd = new LoginCommand(name, password);
            StringWriter writer = new StringWriter();
            cmd.Write(writer);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], writer.ToString()[i], "comparison failed at byte number " + i);
            }
        }
    }
}
