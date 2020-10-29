using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KdAPI_Demo._6_Common
{
	public static class Encryption
	{
		///<summary>
		///电商Sign签名
		///</summary>
		///<param name="content">内容</param>
		///<param name="keyValue">Appkey</param>
		///<param name="charset">URL编码 </param>
		///<returns>DataSign签名</returns>
		public static string encrypt(String content, String keyValue, String charset)
		{
			if (keyValue != null)
			{
				return base64(MD5(content + keyValue, charset), charset);
			}
			return base64(MD5(content, charset), charset);
		}

		///<summary>
		/// 字符串MD5加密
		///</summary>
		///<param name="str">要加密的字符串</param>
		///<param name="charset">编码方式</param>
		///<returns>密文</returns>
		private static string MD5(string str, string charset)
		{
			byte[] buffer = System.Text.Encoding.GetEncoding(charset).GetBytes(str);
			try
			{
				System.Security.Cryptography.MD5CryptoServiceProvider check;
				check = new System.Security.Cryptography.MD5CryptoServiceProvider();
				byte[] somme = check.ComputeHash(buffer);
				string ret = "";
				foreach (byte a in somme)
				{
					if (a < 16)
						ret += "0" + a.ToString("X");
					else
						ret += a.ToString("X");
				}
				return ret.ToLower();
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// base64编码
		/// </summary>
		/// <param name="str">内容</param>
		/// <param name="charset">编码方式</param>
		/// <returns></returns>
		private static string base64(String str, String charset)
		{
			return Convert.ToBase64String(System.Text.Encoding.GetEncoding(charset).GetBytes(str));
		}
    }
}
