using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Utilities
{
	public static class StringExtensions
	{
		public static bool IsNullOrEmpty(this string source)
		{
			return source == null || source.Trim() == "";
		}
		public static string RemoveWhiteSpace(this string source)
		{
			if (source.IsNullOrEmpty())
				return source;

			return Regex.Replace(source, @"\s+", " ");
		}
		public static string RemoveAllSpaces(this string source)
		{
			if (source.IsNullOrEmpty())
				return source;

			return Regex.Replace(source, @"\s+", "");
		}
		public static bool HasValue(this string source)
		{
			return !source.IsNullOrEmpty();
		}
		public static string Truncate(this string source, int maxLength)
		{
			if (source == null)
				return null;

			if (maxLength < source.Length)
				return source.Substring(0, maxLength);

			return source;
		}
		public static HashSet<char> RandomSet(this string source, int setCount)
		{
			if (source == null)
				return null;

			HashSet<char> result = new HashSet<char>();
			Random random = new Random(DateTime.Now.Millisecond);
			while (result.Count < setCount)
			{
				int next = random.Next(0, source.Length - 1);
				char ch = source[next];
				if (!result.Contains(ch))
					result.Add(ch);
			}

			return result;
		}
	}
}
