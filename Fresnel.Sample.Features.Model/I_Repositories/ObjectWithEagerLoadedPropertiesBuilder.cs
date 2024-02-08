// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class ObjectWithEagerLoadedPropertiesBuilder : IDomainDependency
    {
        private readonly AnotherAggregateRootRepository _AnotherAggregateRootRepository;

        public ObjectWithEagerLoadedPropertiesBuilder(AnotherAggregateRootRepository anotherAggregateRootRepository)
        {
            _AnotherAggregateRootRepository = anotherAggregateRootRepository;
        }

        public IEnumerable<ObjectWithEagerLoadedProperties> Build()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new ObjectWithEagerLoadedProperties
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                    EagerLoadedChild = CreateAggregateReference(_AnotherAggregateRootRepository.GetQuery().Last()),
                    EagerLoadedChildren =
                        _AnotherAggregateRootRepository
                        .GetQuery()
                        .Take(5)
                        .Select(e => CreateAggregateReference(e)).ToList()
                })
                .ToList();

            return results;
        }

        private static AggregateReference<AnotherAggregateRoot> CreateAggregateReference(AnotherAggregateRoot e)
        {
            return new AggregateReference<AnotherAggregateRoot>
            {
                Id = Guid.NewGuid(),
                AggregateId = e.Id,
                Description = e.Name,
                TypeName = typeof(AnotherAggregateRoot).FullName,
            };
        }
    }
}
