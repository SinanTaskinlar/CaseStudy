using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseStudyUrlShortener.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using CaseStudyUrlShortener.Models;

namespace CaseStudyUrlShortener.Helpers.Tests
{
	[TestClass()]
	public class UrlShortenerHelpersTests
	{
		readonly UrlShortenerHelpers helper = new UrlShortenerHelpers();

		[TestMethod()]
		[DataRow("test", false)]
		[DataRow("http://teamdefinex.com/lifeatdefinex", true)]

		public void ValidatorTest(string url, bool result)
		{
			Assert.AreEqual(helper.Validator(url), result);
		}
	}
}