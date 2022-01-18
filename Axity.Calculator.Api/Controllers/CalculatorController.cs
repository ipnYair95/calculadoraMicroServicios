// <summary>
// <copyright file="CalculatorController.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Axity.Calculator.Dtos.Calculator;
    using Axity.Calculator.Facade.Calculator;
    using Microsoft.AspNetCore.Mvc;
    using Axity.Calculator.Entities.Model;

    /// <summary>
    /// Class Calculator Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorFacade logicFacade;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorController"/> class.
        /// </summary>
        /// <param name="logicFacade">Calculator Facade.</param>
        public CalculatorController(ICalculatorFacade logicFacade)
        {
            this.logicFacade = logicFacade ?? throw new ArgumentNullException(nameof(logicFacade));
        }

        /// <summary>
        /// Method to get all Calculator.
        /// </summary>
        /// <returns>List of Calculator.</returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await this.logicFacade.GetListCalculatorActive();
            return this.Ok(response);
        }

        /// <summary>
        /// Method to get Calculator By Id.
        /// </summary>
        /// <param name="id">Calculator Id.</param>
        /// <returns>Calculator Model.</returns>
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            CalculatorDto response = null;
            response = await this.logicFacade.GetListCalculatorActive(id);
            return this.Ok(response);
        }

        /// <summary>
        /// Method to Add Calculator.
        /// </summary>
        /// <param name="dataToStore">Calculator Model.</param>
        /// <returns>Success or exception.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CalculatorDto dataToStore)
        {
            var response = await this.logicFacade.InsertCalculator(dataToStore);
            return this.Ok(response);
        }

        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <returns>Pong.</returns>
        [Route("/ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return this.Ok("Pong");
        }

        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <param name="op">Operation.</param>
        /// <param name="num1">Value a.</param>
        /// <param name="num2">Value b.</param>
        /// <returns>Pong.</returns>
        [Route("/makeOperation/{op}/{num1}/{num2}")]
        [HttpGet]
        public IActionResult MakeOperation(string op, int num1, int num2)
        {
            ResponseModel resp = this.logicFacade.Operate(op, num1, num2);
            return this.Ok(resp);
        }
    }
}