using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CommonUtilities;
using QuoteWizard.Controllers;
using DataTier;
using DataTier.Models;
using System.Collections.Generic;
using System.Web.Http;


namespace QuoteWizardTest
{
    [TestClass]
    public class InsurersControllerTestFixture
    {
        private Mock<IQuotesProvider> quotesProviderMock;

        [TestInitialize]
        public void Initialize()
        {
            quotesProviderMock = new Mock<IQuotesProvider>(MockBehavior.Strict);
        }


        [TestMethod]
        public void Get_Test()
        {
            quotesProviderMock.Setup(q => q.GetQuoteSubset(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<QuoteSubsetModel>());
            var controller = new InsurersController(quotesProviderMock.Object);
            var result = controller.Get();

            Assert.IsNotNull(result);
        }

    }
}
