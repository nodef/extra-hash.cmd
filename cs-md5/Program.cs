// OMD5 - calculate md5 checksum for stdin or a file
using System;
using System.IO;
using System.Security.Cryptography;


namespace cs_md5 {
	class Program {
		static void Main(string[] args) {
			MD5 md5 = MD5.Create();
			Stream stream = Console.OpenStandardInput();
			String sout = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
			Console.WriteLine(sout);
		}
	}
}
