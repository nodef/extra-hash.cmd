using System;
using System.IO;
using System.Security.Cryptography;

namespace orez.hash {
	class Program {
		
		/// <summary>
		/// The Begining of Everything.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			oParams p = new oParams(args);
			p.Algorithm = p.Algorithm == null ? "MD5" : p.Algorithm;
			HashAlgorithm alg = HashAlgorithm.Create(p.Algorithm.ToUpper());
			if (alg == null) { Console.Error.WriteLine("err: Invalid hash algorithm \"{0}\".", p.Algorithm); return; }
			Stream inp = p.Input != null ? File.OpenRead(p.Input) : Console.OpenStandardInput();
			string sout = BitConverter.ToString(alg.ComputeHash(inp)).ToLower();
			sout = p.Spaced? sout : sout.Replace("-", "");
			Console.WriteLine(sout);
		}
	}
}
