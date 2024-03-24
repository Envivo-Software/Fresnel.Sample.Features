// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.H_Queries
{
    public class ExampleAggregateRootQuerySpecification : IQuerySpecification<ExampleAggregateRoot>
    {
        private readonly ExampleAggregateRootRepository _ExampleAggregateRootRepository;

        public ExampleAggregateRootQuerySpecification(ExampleAggregateRootRepository exampleAggregateRootRepository)
        {
            _ExampleAggregateRootRepository = exampleAggregateRootRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ExampleAggregateRoot>> GetResultsAsync()
        {
            return await Task.FromResult(_ExampleAggregateRootRepository.GetQuery().AsEnumerable());
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<ExampleAggregateRoot>> GetResultsAsync(ExampleUsingQuerySpecifications requestor)
        {
            // Here we may use the requestor as part of the query clause:
            if (requestor != null)
            {
                // Execute custom filtering here
            }

            return await Task.FromResult(_ExampleAggregateRootRepository.GetQuery().AsEnumerable());
        }
    }
}