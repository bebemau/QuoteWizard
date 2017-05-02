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
    public class QuotesControllerTestFixture
    {
        private Mock<IQuotesProvider> quotesProviderMock;
        private QuotesController controller;

        [TestInitialize]
        public void Initialize()
        {
            quotesProviderMock = new Mock<IQuotesProvider>(MockBehavior.Strict);
            controller = new QuotesController(quotesProviderMock.Object);
        }

        [TestMethod]
        public void GetQuotesSubset_HasData()
        {
            var providerResult = GetQuoteSubsetData();
            quotesProviderMock.Setup(q => q.GetQuoteSubset(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(providerResult);
            var result = controller.GetQuotesSubset(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetQuotesSubset_NoData()
        {
            var providerResult = GetQuoteSubsetData();
            quotesProviderMock.Setup(q => q.GetQuoteSubset(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<QuoteSubsetModel>());
            var result = controller.GetQuotesSubset(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.AreEqual(0, result.Count);
        }

        

        [TestMethod]
        public void GetQuotesDetail_NotNull()
        {
            quotesProviderMock.Setup(q => q.GetQuoteDetail(It.IsAny<int>())).Returns(new QuoteDetailModel());
            var result = controller.GetQuoteDetail(It.IsAny<int>());

            Assert.IsNotNull(result);
        }

        private List<QuoteSubsetModel> GetQuoteSubsetData()
        {
            var result = new List<QuoteSubsetModel>()
            {
                new QuoteSubsetModel
                    {
                    QuoteID = 7,
                    CustomerState = "AL",
                    FormerInsurer = "Some Small Company",
                    Vehicles = new List<VehicleModel>()
                        {
                            new VehicleModel
                            {
                                Make = "Chevrolet"
                            }
                        }
                    },
                new QuoteSubsetModel
                    {
                    QuoteID = 9,
                    CustomerState = "WA",
                    FormerInsurer = "Some Small Company",
                    Vehicles = new List<VehicleModel>()
                        {
                            new VehicleModel
                            {
                                Make = "Honda"
                            }
                        }
                    },
                new QuoteSubsetModel
                    {
                    QuoteID = 5,
                    CustomerState = "CA",
                    FormerInsurer = "Some Big Company",
                    Vehicles = new List<VehicleModel>()
                        {
                            new VehicleModel
                            {
                                Make = "Chevrolet"
                            }
                        }
                    },
            };

            return result;
        }


    }
}
