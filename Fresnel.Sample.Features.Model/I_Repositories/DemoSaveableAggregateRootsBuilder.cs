﻿// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoSaveableAggregateRootsBuilder : IDomainDependency
    {
        private readonly SaveableEntityRepository _SaveableEntityRepository;
        private readonly ExampleAggregateRootRepository _ExampleAggregateRootRepository;

        public DemoSaveableAggregateRootsBuilder
        (
            SaveableEntityRepository saveableEntityRepository,
            ExampleAggregateRootRepository exampleAggregateRootRepository
        )
        {
            _SaveableEntityRepository = saveableEntityRepository;
            _ExampleAggregateRootRepository = exampleAggregateRootRepository;
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

                    AssociatedEntities =
                        _SaveableEntityRepository
                        .GetQuery()
                        .Take(5)
                        .ToList(),

                    AssociatedAggregates =
                        _ExampleAggregateRootRepository
                        .GetQuery()
                        .Take(5)
                        .Select(e => new AggregateReference<ExampleAggregateRoot>
                        {
                            Id = Guid.NewGuid(),
                            AggregateId = e.Id,
                            Description = e.Name,
                            TypeName = typeof(ExampleAggregateRoot).FullName,
                        }).ToList()
                })
                .ToList();

            return results;
        }
    }
}
