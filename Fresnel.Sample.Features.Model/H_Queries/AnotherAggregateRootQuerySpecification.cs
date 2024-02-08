// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.H_Queries
{
    public class AnotherAggregateRootQuerySpecification : IQuerySpecification<AnotherAggregateRoot>
    {
        private List<AnotherAggregateRoot> _Items;

        public AnotherAggregateRootQuerySpecification()
        {
            _Items =
                Enumerable.Range(1, 10)
                .Select(i => new AnotherAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(AnotherAggregateRoot)} {i}",
                    Description = "A description goes here"
                })
                .ToList();
        }

        public async Task<IEnumerable<AnotherAggregateRoot>> GetResultsAsync()
        {
            return await Task.FromResult(_Items.AsEnumerable());
        }

        public async Task<IEnumerable<AnotherAggregateRoot>> GetResultsAsync(PropertiesUsingQuerySpecifications requestor)
        {
            // Here we may use the requestor as part of the query clause:
            if (requestor != null)
            {
                // Execute custom filtering here
            }

            return await Task.FromResult(_Items.AsEnumerable());
        }
    }
}