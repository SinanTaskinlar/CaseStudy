using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseStudyUrlShortener.Repositories.Base;
using Moq;
using CaseStudyUrlShortener.Models;

namespace CaseStudyUrlShortener.Controllers.Tests
{
	[TestClass]
	public class UrlControllerTests
	{
		private UrlController _urlController;
		private readonly Mock<IAddressRepository> _mockAddressRepository;

		public UrlControllerTests()
		{
			_mockAddressRepository = new Mock<IAddressRepository>();
			_urlController = new UrlController(_mockAddressRepository.Object);
		}

		[TestMethod]
		public void Should_Generate()
		{
			// setup
			var address = GetAddress();
			_mockAddressRepository.Setup(a => a.GetByOriginalUrl(address.Long)).Returns(address);

			// body
			var result = _urlController.Generate(address);

			// tear down
			Assert.IsNotNull(result);

			// verify
			_mockAddressRepository.Verify(a => a.GetByOriginalUrl(address.Long), Times.Once);
		}

		[TestMethod]
		public void Should_Dispatch()
		{
			// setup
			var address = GetAddress();
			_mockAddressRepository.Setup(a => a.GetByShortUrl(address.Short)).Returns(address);

			// body
			var result = _urlController.Dispatch(address);

			// tear down
			Assert.IsNotNull(result);

			// verify
			_mockAddressRepository.Verify(a => a.GetByShortUrl(address.Short), Times.Once);

		}

		private Address GetAddress()
		{
			return new Address
			{
				Id = 1,
				Long = "http://teamdefinex.com/xD2Lq1dskjfdk",
				Short = "http://dfx.com/abgchr"
			};
		}
	}
}