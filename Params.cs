namespace App {
	class Params {

		// data
		/// <summary>
		/// Input file. Default is standard input.
		/// </summary>
		public string Input;
		/// <summary>
		/// Hash algorithm. Default is MD5.
		/// </summary>
		public string Algorithm;
		/// <summary>
		/// Spaced value. Default is false.
		/// </summary>
		public bool Spaced;


		// constructor
		/// <summary>
		/// Get paramters from input arguments.
		/// </summary>
		/// <param name="args">Input arguments.</param>
		public Params(string[] args) {
			for (int i = 0; i < args.Length; i++) {
				string av = args[i];
				if (av == "-a" || av == "--algorithm") Algorithm = ++i >= args.Length ? null : args[i];
				else if (av == "-i" || av == "--input") Input = ++i > args.Length ? null : args[i];
				else if (av == "-s" || av == "--spaced") Spaced = true;
			}
		}
	}
}
