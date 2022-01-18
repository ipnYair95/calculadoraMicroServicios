// <summary>
// <copyright file="IDatabaseContext.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Calculator.Entities.Context
{
    using Axity.Calculator.Entities.Model;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Interface IDataBaseContext.
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Gets or sets CatUser.
        /// </summary>
        /// <value>
        /// Object UserModel CatUser.
        /// </value>
        DbSet<CalculatorModel> CatCalculator { get; set; }
    }
}