// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.NestedObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoExampleOfNestedObjectsBuilder : IDomainDependency
    {

        public IEnumerable<ExampleOfNestedObjects> Build()
        {
            var results =
                Enumerable.Range(1, 15)
                .Select(i => new ExampleOfNestedObjects
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(ExampleOfNestedObjects)} {i}",
                    Description = $"This is the description for item {i}",
                    Level2 = new NestedLevel2
                    {
                        Id = Guid.NewGuid(),
                        Description = $"This is nested item {i}"
                    }
                })
                .ToList();

            return results;
        }
    }
}
