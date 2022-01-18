// <summary>
// <copyright file="ResponseModel.cs" company="Axity">
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
    /// Class Calculator ResponseModel.
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Gets or sets Message.
        /// </summary>
        /// <value>
        /// String Message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets Result.
        /// </summary>
        /// <value>
        /// String Result.
        /// </value>
        public double Result { get; set; }
    }
}
