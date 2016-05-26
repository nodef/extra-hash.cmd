// OMD5 - calculate md5 checksum for stdin or a file
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Map = System.Collections.Generic.Dictionary<string, string>;

namespace cs_md5 {
	class Program {
		static void Main(string[] args) {
			Map opt = GetOpt(args);
			MD5 md5 = MD5.Create();
			Stream stream = Console.OpenStandardInput();
			string sout = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
			Console.WriteLine(sout);
		}

		// get omd5 options
		private static Map GetOpt(string[] args) {
			Map name = new Map() {["--algo"]="-a"};
			Regex opt = new Regex("-(a)", RegexOptions.IgnoreCase);
			return ArgsMap(new Map(), args, name, opt);
		}

		// get command-line arguments as a map
		private static Map ArgsMap(Map m, string[] args, Map name, Regex opt) {
			for(int i=0; i<args.Length; i++) {
				string k = name.ContainsKey(k=args[i]) ? name[k] : k;
				string v = opt.Match(k).Length == k.Length ? args[++i] : "";
				m.Add(k, v);
			}
			return m;
		}
	}
}
