// <summary>
// <copyright file="CalculatorService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Services.Calculator.Impl
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Axity.Calculator.DataAccess.DAO.Calculator;
    using Axity.Calculator.Dtos.Calculator;
    using Axity.Calculator.Entities.Model;

    /// <summary>
    /// Class Calculator Service.
    /// </summary>
    public class CalculatorService : ICalculatorService
    {
        private readonly IMapper mapper;

        private readonly ICalculatorDao modelDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="CalculatorService"/> class.
        /// </summary>
        /// <param name="mapper">Object to mapper.</param>
        /// <param name="modelDao">Object to modelDao.</param>
        public CalculatorService(IMapper mapper, ICalculatorDao modelDao)
        {
            this.mapper = mapper;
            this.modelDao = modelDao ?? throw new ArgumentNullException(nameof(modelDao));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<CalculatorDto>> GetAllCalculatorAsync()
        {
            return this.mapper.Map<List<CalculatorDto>>(await this.modelDao.GetAllCalculatorAsync());
        }

        /// <inheritdoc/>
        public async Task<CalculatorDto> GetCalculatorAsync(int id)
        {
            return this.mapper.Map<CalculatorDto>(await this.modelDao.GetCalculatorAsync(id));
        }

        /// <inheritdoc/>
        public async Task<bool> InsertCalculator(CalculatorDto model)
        {
            return await this.modelDao.InsertCalculator(this.mapper.Map<CalculatorModel>(model));
        }

        /// <inheritdoc/>
        public ResponseModel Operate(string op, int num1, int num2)
        {
            ResponseModel resp = new ResponseModel();
            Regex rx = new Regex(@"^(sum|subs|multi|div){1}$");
            double result = 0;

            if (!rx.IsMatch(op))
            {
                // throw new ArgumentException("Invalid Operation");
                resp.Result = result;
                resp.Message = "400: Invalid Operation";
                return resp;
            }

            if (op == "div" && num2 == 0)
            {
                // throw new ArgumentException("Not Zero with division");
                resp.Result = result;
                resp.Message = "400: Invalid argument, Not Zero for division";
                return resp;
            }

            switch (op)
            {
                case @"sum":
                    result = num1 + num2;
                    break;
                case @"subs":
                    result = num1 - num2;
                    break;
                case @"div":
                    result = num1 / num2;
                    break;
                case @"multi":
                    result = num1 * num2;
                    break;
            }

            resp.Result = result;
            resp.Message = "Ok";
            return resp;
        }
    }
}
