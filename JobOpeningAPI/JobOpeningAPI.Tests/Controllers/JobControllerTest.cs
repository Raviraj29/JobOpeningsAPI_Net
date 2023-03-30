using JobOpeningAPI.ApiResponse;
using JobOpeningAPI.Controllers;
using JobOpeningAPI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace JobOpeningAPI.Tests.Controllers
{
    [TestClass]
    public class JobControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            JobController controller = new JobController();
            controller.Request = Substitute.For<HttpRequestMessage>();  // using nSubstitute
            controller.Configuration = Substitute.For<HttpConfiguration>();
            JObList joblist = new JObList();
            // Act
            HttpResponseMessage result = controller.GetJobs(joblist);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, (int)result.StatusCode);
        }

        [TestMethod]
        public void GetById()
        {

            var controller = new JobController();
            controller.Request = Substitute.For<HttpRequestMessage>();
            controller.Configuration = Substitute.For<HttpConfiguration>();
            // Act on Test  
            var result = controller.GetJobById(1);
            // Assert the result  
            Assert.IsNotNull(result);
            Assert.AreEqual(200, (int)result.StatusCode);
        }
    }
}
