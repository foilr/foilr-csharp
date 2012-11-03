using System;

namespace Foilr
{
	public class AliasAttribute : Attribute
	{
		public AliasAttribute(string alias)
		{
			Alias = alias;
		}

		public string Alias { get; private set; }
	}
}