// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.I_Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples.Dependencies
{
    public class AnotherAggregateRootQuerySpecification : IQuerySpecification<AnotherAggregateRoot>
    {
        private readonly AnotherAggregateRootRepository _AnotherAggregateRootRepository;

        public AnotherAggregateRootQuerySpecification(AnotherAggregateRootRepository anotherAggregateRootRepository)
        {
            _AnotherAggregateRootRepository = anotherAggregateRootRepository;
        }

        public async Task<IEnumerable<AnotherAggregateRoot>> GetResultsAsync()
        {
            return await Task.FromResult(_AnotherAggregateRootRepository.GetQuery().AsEnumerable());
        }

        public async Task<IEnumerable<AnotherAggregateRoot>> GetResultsAsync(PropertiesLoadedOnDemand requestor)
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