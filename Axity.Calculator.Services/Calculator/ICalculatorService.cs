// <summary>
// <copyright file="ICalculatorService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Services.Calculator
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Calculator.Dtos.Calculator;
    using Axity.Calculator.Entities.Model;

    /// <summary>
    /// Interface Calculator Service.
    /// </summary>
    public interface ICalculatorService
    {
        /// <summary>
        /// Method for get all users from db.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<CalculatorDto>> GetAllCalculatorAsync();

        /// <summary>
        /// Method for get Calculator by id from db.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<CalculatorDto> GetCalculatorAsync(int id);

        /// <summary>
        /// Method for add Calculator to DB.
        /// </summary>
        /// <param name="model">Calculator Dto.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> InsertCalculator(CalculatorDto model);

        /// <summary>
        /// Method for get User by id.
        /// </summary>
        /// <param name="op">Operation.</param>
        /// <param name="num1">Value a.</param>
        /// <param name="num2">Value b.</param>
        /// <returns>Rsult operation.</returns>
        ResponseModel Operate(string op, int num1, int num2);
    }
}
