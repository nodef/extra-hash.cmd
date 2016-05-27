// OMD5 - calculate md5 checksum for stdin or a file
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using ISList = System.Collections.Generic.IList<string>;
using ISet = System.Collections.Generic.ISet<string>;
using ISMap = System.Collections.Generic.IDictionary<string, string>;

namespace cs_md5 {
	class Program {
		
		// types
		interface IMap<T> : IDictionary<string, T> { }
		interface IMap : IMap<object> { }


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
		private static IMap ArgsMap(IMap m, string[] args, IMap<string> key, IMap<int> type) {
			for(int i=0; i<args.Length; i++) {
				string k = key.ContainsKey(k=args[i]) ? key[k] : "";
				int t = type.ContainsKey(k) ? type[k] : 0;
				string v = 
				m.Add(k, v);
			}
			return m;
		}
	}
}
