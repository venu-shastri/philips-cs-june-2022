using System;
using System.Collections.Generic;
//using System.Linq;

public static class StringExtensions
{
	//Extension method for target type (first Argument prefixed with "this")
	public static string Localize(this string source, string cultureName)
	{
		return "hhhhhh";
	}
}

public class Program
{
	public static void Main()
	{
		string s = "hello";
		s.Localize("de"); 
		StringExtensions.Localize(s,"de");
		List<string> stringList = new List<string>();
		stringList.FirstOrDefault(); 
		System.Linq.Enumerable.FirstOrDefault(stringList);
	}
}
