using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MSBuild.SetEnvVariable
{
	public class SetEnvVariable : Task
	{
		private string _name;
		private string _value;

		[Required]
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public override bool Execute()
		{
			try
			{
				Environment.SetEnvironmentVariable(_name, _value);
				return true;
			}
			catch (Exception exc)
			{
				Console.WriteLine(exc);
				return false;
			}
		}
	}
}
