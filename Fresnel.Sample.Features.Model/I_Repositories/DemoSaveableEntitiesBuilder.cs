// SPDX-FileCopyrightText: Copyright (c) 2022-2025 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    public class DemoSaveableEntitiesBuilder : IDomainDependency
    {
        public IEnumerable<SaveableEntity> Build()
        {
            var results =
                Enumerable.Range(1, 50)
                .Select(i => new SaveableEntity
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableEntity)} {i}",
                    Description = $"This is the description for item {i}",
                    CreatedAt = DateTime.Now.AddMilliseconds(i)
                })
                .ToList();

            return results;
        }
    }
}
