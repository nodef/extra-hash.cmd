// OHASH - calculate hash for stdin or a file
using System;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace orez.hash {
	class Program {
		
		/// <summary>
		/// The Begining of Everything.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		static void Main(string[] args) {
			// get input parameters
			oParams p = new oParams();
			try { GetOpt(p, args); }
			catch(Exception e) { Console.Error.WriteLine("e: "+e.Message); }
			// calculate md5
			HashAlgorithm halgo = HashAlgorithm.Create(p.algo.ToUpper());
			Stream inp = p.input != null ? File.OpenRead(p.input) : Console.OpenStandardInput();
			string sout = BitConverter.ToString(halgo.ComputeHash(inp)).ToLower();
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
