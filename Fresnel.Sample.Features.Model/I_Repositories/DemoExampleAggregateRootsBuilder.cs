// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoExampleAggregateRootsBuilder : IDomainDependency
    {
        public IEnumerable<ExampleAggregateRoot> Build()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new ExampleAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(ExampleAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                })
                .ToList();

            return results;
        }
    }
}
