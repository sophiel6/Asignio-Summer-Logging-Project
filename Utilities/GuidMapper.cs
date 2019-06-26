using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace Utilities
{
	public static class GuidMapper
	{
		public const int TOKEN_LENGTH = 32;

		public static Guid Map(byte[] bytes)
		{
			if (bytes == null)
				return Guid.Empty;

			return new Guid(bytes);
		}

		public static byte[] Map(Guid guid)
		{
			if (guid == null)
				return null;

			return guid.ToByteArray();
		}

		public static string NormalizeToken(string token)
		{
			if (string.IsNullOrEmpty(token))
				token = "0";

			if (TOKEN_LENGTH < token.Length)
				return token.Substring(0, TOKEN_LENGTH);

			while (token.Length < TOKEN_LENGTH)
				token += "0";

			return token;
		}

		public static StringBuilder NormalizeToken(StringBuilder token)
		{
			if (null == token)
				token = new StringBuilder("0");

			if (TOKEN_LENGTH < token.Length)
				return new StringBuilder(token.ToString().Substring(0, TOKEN_LENGTH));

			while (token.Length < TOKEN_LENGTH)
				token.Append("0");

			return token;
		}

		public static bool TryParse(string token, out Guid guid)
		{
			guid = Guid.Empty;
			try
			{
				guid = Map(token.ToBytes());
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string ToHEX(this byte[] bytes)
		{
			if (bytes == null) return "";
			StringBuilder result = new StringBuilder();
			foreach (byte b in bytes)
				result.AppendFormat("{0:x2}", b);

			return result.ToString();
		}
		public static string ToToken(this Guid source)
		{
			return Map(source).ToHEX();
		}
		public static Guid FromToken(string token)
		{
			Guid guid = Guid.Empty;
			if (!token.IsNullOrEmpty())
			{
				try
				{
					guid = Map(token.ToBytes());
				}
				catch (ArgumentException ae)
				{					
					guid = Guid.Empty;
				}
				catch (FormatException fe)
				{					
					guid = Guid.Empty;
				}
				catch (Exception ex)
				{					
					guid = Guid.Empty;
				}
			}

			return guid;
		}
		public static byte[] ToBytes(this string hexString)
		{
			if (hexString.IsNullOrEmpty())
				throw new ArgumentNullException("hexString");

			if (hexString.Length % 2 != 0)
			{
				throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
			}

			byte[] HexAsBytes = new byte[hexString.Length / 2];
			for (int index = 0; index < HexAsBytes.Length; index++)
			{
				string byteValue = hexString.Substring(index * 2, 2);
				HexAsBytes[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}

			return HexAsBytes;
		}

		public static string FromDeviceToken(string source)
		{
			string[] parts = source.Split('-');
			if (parts.Length < 2)
				return source;

			Guid guid = GuidMapper.Map(parts[1].ToBytes());
			return string.Format("{0}:{1}", parts[0], guid);
		}		

		public static string FromBasicToken(string source)
		{
			return source.Replace('_', '.').Replace('+', ':');
		}

		public static string ToBasicToken(string source)
		{
			return source.Replace('.', '_').Replace(':', '+');
		}

	}
}
