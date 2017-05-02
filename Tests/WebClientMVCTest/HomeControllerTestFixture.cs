using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonUtilities.APIHelpers;
using CommonUtilities;
using Moq;
using DataTier.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebClientMVC.Controllers;
using System.Web.Mvc;

namespace WebClientMVCTest
{
    [TestClass]
    public class HomeControllerTestFixture
    {
        private Mock<IHttpClientHelper> httpClientHelperMock;
        private Mock<IRESTHelper> restHelperMock;
        private Mock<IConfigurationHelper> configurationHelperMock;
        private HttpClient httpClient = new HttpClient();
        private HomeController controller;

        [TestInitialize]
        public void Initialize()
        {
            httpClientHelperMock = new Mock<IHttpClientHelper>(MockBehavior.Strict);
            restHelperMock = new Mock<IRESTHelper>(MockBehavior.Strict);
            configurationHelperMock = new Mock<IConfigurationHelper>(MockBehavior.Strict);
            controller = new HomeController(httpClientHelperMock.Object, restHelperMock.Object, configurationHelperMock.Object);
        }

        [TestMethod]
        public void Index_Test()
        {
            var data = GetQuoteSubsetData();
            restHelperMock.Setup(q => q.GetListOfObjects<List<QuoteSubsetModel>>("any", httpClient)).Returns(Task.FromResult(new List<List<QuoteSubsetModel>>()));
            var result = controller.Index(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()) as Task<ActionResult>;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void QuoteDetail_Test()
        {
            restHelperMock.Setup(q => q.GetSingleObject<QuoteDetailModel>("any", httpClient)).Returns(Task.FromResult(new QuoteDetailModel()));
            var result = controller.QuoteDetail(It.IsAny<int>()) as Task<ActionResult>;
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
