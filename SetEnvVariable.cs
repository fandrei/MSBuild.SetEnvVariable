using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace MSBuild.SetEnvVariable
{
	public class SetEnvVariable : Task
	{
		private string _name;
		private string _value;
	    private EnvironmentVariableTarget _target = EnvironmentVariableTarget.Process;


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

	    public string Target
	    {
            get { return _target.ToString(); }
            set { _target = (EnvironmentVariableTarget)Enum.Parse(typeof(EnvironmentVariableTarget), value); }
	    }

		public override bool Execute()
		{
			try
			{
				Environment.SetEnvironmentVariable(_name, _value, _target);
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
