// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoAnotherAggregateRootsBuilder : IDomainDependency
    {
        public IEnumerable<AnotherAggregateRoot> Build()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new AnotherAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(AnotherAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}",
                })
                .ToList();

            return results;
        }
    }
}
