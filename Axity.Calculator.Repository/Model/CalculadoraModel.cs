// <summary>
// <copyright file="CalculadoraModel.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Entities.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Class Calculator CalculadoraModel.
    /// </summary>
    public class CalculadoraModel
    {
        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        /// <value>
        /// String Message.
        /// </value>
        public int Num1 { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        /// <value>
        /// String Result.
        /// </value>
        public int Num2 { get; set; }

        /// <summary>
        /// Gets or sets Operation.
        /// </summary>
        /// <value>
        /// String Operation.
        /// </value>
        public string Operation { get; set; }

        /// <summary>
        /// Method for get User by id.
        /// </summary>
        /// <returns>Rsult operation.</returns>
        public double MakeOperation()
        {
            switch (this.Operation)
            {
                case @"sum":
                    return this.Num1 + this.Num2;
                case @"subs":
                    return this.Num1 - this.Num2;
                case @"div":
                    return this.Num1 / this.Num2;
                case @"multi":
                    return this.Num1 * this.Num2;
            }

            return 0;
        }
    }
}
