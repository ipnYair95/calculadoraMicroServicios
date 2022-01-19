// <summary>
// <copyright file="CalculatorServiceTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Test.Services.Calculator
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Axity.Calculator.DataAccess.DAO.Calculator;
    using Axity.Calculator.Entities.Context;
    using Axity.Calculator.Services.Mapping;
    using Axity.Calculator.Services.Calculator;
    using Axity.Calculator.Services.Calculator.Impl;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using Axity.LeadToCash.Resources.Db;
    using Axity.Calculator.Entities.Model;

    /// <summary>
    /// Class CalculatorServiceTest.
    /// </summary>
    [TestFixture]
    public class CalculatorServiceTest : BaseTest
    {
        private ICalculatorService modelServices;

        private IMapper mapper;

        private ICalculatorDao modelDao;

        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            this.mapper = mapperConfiguration.CreateMapper();

            Users.ListUsers = this.GetAllCalculators().ToList();

            this.modelDao = new CalculatorDao();
            this.modelServices = new CalculatorService(this.mapper, this.modelDao);
        }

        /// <summary>
        /// Method to verify Get All Calculators.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateGetAllCalculators()
        {
            var result = await this.modelServices.GetAllCalculatorAsync();

            Assert.True(result != null);
            Assert.True(result.Any());
        }

        /// <summary>
        /// Method to validate get model by id.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateSpecificCalculators()
        {
            var result = await this.modelServices.GetCalculatorAsync(2);

            // Assert.True(result != null);
            // Assert.True(result.FirstName == "Jorge");
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task InsertCalculator()
        {
            // Arrange
            var model = this.GetCalculatorDto();

            // Act
            var result = await this.modelServices.InsertCalculator(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        // ***************************************** Test para operaciones generales ********************

        /// <summary>
        /// test the insert.
        /// </summary>
        [Test]
        public void ShouldBeErrorWithInvalidOperation()
        {
            int a = 2, b = 0;
            string operation = "invalid";

            ResponseModel expected = new ResponseModel();
            expected.Message = "400: Invalid Operation";
            expected.Result = 0;

            ResponseModel provided = this.modelServices.Operate(operation, a, b);
            Assert.AreEqual(expected.Message, provided.Message);

            // Assert.Throws<ArgumentException>(() => this.modelServices.Operate(operation, a, b));
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        [Test]
        public void ShouldReturnSevenWithSumAndTwoAndFive()
        {
            int a = 2, b = 5;
            string operation = "sum";

            ResponseModel expected = new ResponseModel();
            expected.Message = "200: Success";
            expected.Result = 7;

            ResponseModel provided = this.modelServices.Operate(operation, a, b);
            Assert.AreEqual(expected.Result, provided.Result);
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        [Test]
        public void ShouldReturnFiveSubstractAndTenAndFive()
        {
            int a = 10, b = 5;
            string operation = "subs";

            ResponseModel expected = new ResponseModel();
            expected.Message = "200: Success";
            expected.Result = 5;

            ResponseModel provided = this.modelServices.Operate(operation, a, b);
            Assert.AreEqual(expected.Result, provided.Result);
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        [Test]
        public void ShouldReturnEightWithMultiAndTwoAndFour()
        {
            int a = 2, b = 4;
            string operation = "multi";

            ResponseModel expected = new ResponseModel();
            expected.Message = "200: Success";
            expected.Result = 8;

            ResponseModel provided = this.modelServices.Operate(operation, a, b);
            Assert.AreEqual(expected.Result, provided.Result);
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        [Test]
        public void ShouldReturnFourWithDivitionAndEightAndTwo()
        {
            int a = 8, b = 2;
            string operation = "div";

            ResponseModel expected = new ResponseModel();
            expected.Message = "200: Success";
            expected.Result = 4;

            ResponseModel provided = this.modelServices.Operate(operation, a, b);
            Assert.AreEqual(expected.Result, provided.Result);
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        [Test]
        public void ShouldReturnErrorWithDivisionZero()
        {
            int a = 2, b = 0;
            string operation = "div";

            ResponseModel expected = new ResponseModel();
            expected.Message = "400: Invalid argument, Not Zero for division";
            expected.Result = 0;

            ResponseModel provided = this.modelServices.Operate(operation, a, b);
            Assert.AreEqual(expected.Result, provided.Result);
        }
    }
}
