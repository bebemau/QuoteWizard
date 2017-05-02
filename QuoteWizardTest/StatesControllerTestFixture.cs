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
    public class StatesControllerTestFixture
    {
        private Mock<IQuotesProvider> quotesProviderMock;

        [TestInitialize]
        public void Initialize()
        {
            quotesProviderMock = new Mock<IQuotesProvider>(MockBehavior.Strict);
        }


        [TestMethod]
        public void GetStates_Test()
        {
            quotesProviderMock.Setup(q => q.GetQuoteSubset(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(new List<QuoteSubsetModel>());
            var controller = new StatesController(quotesProviderMock.Object);
            var result = controller.Get();

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
            
            var data = new QuoteSubsetModel
            {
                QuoteID = 9,
                CustomerState = "AL",
                FormerInsurer = "Some Small Company",
                Vehicles = new List<VehicleModel>()
                   {
                       new VehicleModel
                       {
                            Make = "Chevrolet"
                       }
                   }
            };
            result.Add(data);

            return result;
        }

    }
}
