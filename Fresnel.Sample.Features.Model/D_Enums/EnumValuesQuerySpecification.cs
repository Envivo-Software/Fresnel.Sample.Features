// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using System.Collections.Generic;

namespace Envivo.Fresnel.Sample.Features.Model.D_Enums
{
    /// <summary>
    ///
    /// </summary>
    public class EnumValuesQuerySpecification : IQuerySpecification<EnumValues.IndividualOptions>
    {
        private List<EnumValues.IndividualOptions> _FilterItems = new List<EnumValues.IndividualOptions>
        {
            EnumValues.IndividualOptions.Red,
            EnumValues.IndividualOptions.Blue
        };

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public IEnumerable<EnumValues.IndividualOptions> GetResults()
        {
            // The requesting object may be used to determine which results to return
            return _FilterItems;
        }
    }
}