// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoSaveableAggregateRootsBuilder : IDomainDependency
    {
        private readonly AnotherAggregateRootRepository _AnotherAggregateRootRepository;

        public DemoSaveableAggregateRootsBuilder(AnotherAggregateRootRepository anotherAggregateRootRepository)
        {
            _AnotherAggregateRootRepository = anotherAggregateRootRepository;
        }

        public IEnumerable<SaveableAggregateRoot> Build()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new SaveableAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                    AssociatedItems =
                        _AnotherAggregateRootRepository
                        .GetQuery()
                        .Take(5)
                        .Select(e => new AggregateReference<AnotherAggregateRoot>
                        {
                            Id = Guid.NewGuid(),
                            AggregateId = e.Id,
                            Description = e.Name,
                            TypeName = typeof(AnotherAggregateRoot).FullName,
                        }).ToList()
                })
                .ToList();

            return results;
        }
    }
}
