// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoExamplesOfEagerLoadedPropertiesBuilder : IDomainDependency
    {
        private readonly ExampleAggregateRootRepository _ExampleAggregateRootRepository;

        public DemoExamplesOfEagerLoadedPropertiesBuilder(ExampleAggregateRootRepository exampleAggregateRootRepository)
        {
            _ExampleAggregateRootRepository = exampleAggregateRootRepository;
        }

        public IEnumerable<ExamplesOfEagerLoadedProperties> Build()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new ExamplesOfEagerLoadedProperties
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                    EagerLoadedChild = CreateAggregateReference(_ExampleAggregateRootRepository.GetQuery().Last()),
                    EagerLoadedChildren =
                        _ExampleAggregateRootRepository
                        .GetQuery()
                        .Take(5)
                        .Select(e => CreateAggregateReference(e)).ToList()
                })
                .ToList();

            return results;
        }

        private static AggregateReference<ExampleAggregateRoot> CreateAggregateReference(ExampleAggregateRoot e)
        {
            return new AggregateReference<ExampleAggregateRoot>
            {
                Id = Guid.NewGuid(),
                AggregateId = e.Id,
                Description = e.Name,
                TypeName = typeof(ExampleAggregateRoot).FullName,
            };
        }
    }
}
