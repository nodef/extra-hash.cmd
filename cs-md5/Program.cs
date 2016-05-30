// OMD5 - calculate md5 checksum for stdin or a file
using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace orez.md5 {
	class Program {
		
		/// <summary>
		/// The Begining of Everything.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			// get input parameters
			oParams p = new oParams();
			try { GetOpt(p, new string[] { "Program.cs" }); }
			catch(Exception e) { Console.Error.WriteLine("e: "+e.Message); }
			// calculate md5
			MD5 md5 = MD5.Create(p.algo.ToUpper());
			Stream inp = p.input != null ? File.OpenRead(p.input) : Console.OpenStandardInput();
			string sout = BitConverter.ToString(md5.ComputeHash(inp)).ToLower();
			sout = p.spaced? sout : sout.Replace("-", "");
			Console.WriteLine(sout);
		}

		/// <summary>
		/// Get omd5 options.
		/// </summary>
		/// <param name="dst">destination oparams object.</param>
		/// <param name="src">source arguments list.</param>
		private static void GetOpt(oParams dst, IList<string> src) {
			for(int i=0; i<src.Count; i++) {
				switch(src[i]) {
					case "-a":
					case "--algo":
						dst.algo = src[++i];
						break;
					case "-s":
					case "--spaced":
						dst.spaced = true;
						break;
					default:
						if(!src[i].StartsWith("-")) dst.input = src[i];
						else throw new InvalidDataException("invalid option \'"+src[i]+"\'");
						break;
				}
			}
		}
	}
}
