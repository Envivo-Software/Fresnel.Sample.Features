// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples.Dependencies
{
    public class AnotherAggregateRootQuerySpecification : IQuerySpecification<ExampleAggregateRoot>
    {
        private readonly ExampleAggregateRootRepository _AnotherAggregateRootRepository;

        public AnotherAggregateRootQuerySpecification(ExampleAggregateRootRepository anotherAggregateRootRepository)
        {
            _AnotherAggregateRootRepository = anotherAggregateRootRepository;
        }

        public async Task<IEnumerable<ExampleAggregateRoot>> GetResultsAsync()
        {
            return await Task.FromResult(_AnotherAggregateRootRepository.GetQuery().AsEnumerable());
        }

        public async Task<IEnumerable<ExampleAggregateRoot>> GetResultsAsync(ExamplesOfOnDemandProperties requestor)
        {
            // Here we may use the requestor as part of the query clause:
            if (requestor != null)
            {
                // Execute custom filtering here
            }

            return await Task.FromResult(_AnotherAggregateRootRepository.GetQuery().AsEnumerable());
        }
    }
}