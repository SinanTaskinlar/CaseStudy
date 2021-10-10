using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CaseStudyUrlShortener.Models;
using System.Net;

namespace CaseStudyUrlShortener.Helpers
{
	public class UrlShortenerHelpers : IDisposable
	{

//request data sample: http://teamdefinex.com/lifeatdefinex
public Address Shortener(Address address)
{
//return: adres içerisindeki tüm karakterlerin ascii numaralarının toplamı.
			foreach (var item in (byte[])Encoding.ASCII.GetBytes(address.Long)) { address.Id += item; }
			//return: adres içerisinde gönderilen uzun karakter dizisi, 6 karakterlik yeni diziyle değiştiriliyor.
			address.Short = Regex.Replace(
					input: new Uri(address.Long).AbsoluteUri,
					pattern: String.Format(
												format: @"\b{0}\{1}\b",
												arg0: new Uri(address.Long).Host,
												arg1: new Uri(address.Long).AbsolutePath),
					replacement: "dfx.com/" + WebEncoders.Base64UrlEncode(BitConverter.GetBytes(address.Id))
					);

			//return sample:http://dfx.com/xD2Lq1
			return address;
		}

		public bool Validator(string url)
		{
			string urlPattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
			Regex validator = new Regex(urlPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

			if (validator.IsMatch(url) && Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
			{
				Uri uri = new Uri(url);
				if (uri.Host == "teamdefinex.com" || uri.Host == "dfx.com")
					return true;
				else
					return false;
			}
			else
				return false;
		}

		public void Dispose()
		{
		}
	}
}
