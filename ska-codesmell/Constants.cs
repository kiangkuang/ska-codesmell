namespace ska_codesmell
{
    public class Constants
    {
        public const int SizeLength = 1;
        public const int CmdByteLength = 1;
        public static readonly char[] Header = { (char)0xde, (char)0xad };
        public static readonly char[] CommandCharLogin = { (char)0x01 };
        public static readonly char[] CommandCharAdd = { (char)0x02 };
        public static readonly char[] Footer = { (char)0xbe, (char)0xef };
    }
}