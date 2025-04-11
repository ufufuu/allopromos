using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
namespace allopromo.Core.UnitTests.Application
{
    [TestFixture]
    public class MediaServiceTests
    {
        private Mock<HttpClient> httClientMock { get; set; }
        [Test]
        public void getImageInformationUrlAsync_SHOULD_Return()
        {
        }
    } 
}
