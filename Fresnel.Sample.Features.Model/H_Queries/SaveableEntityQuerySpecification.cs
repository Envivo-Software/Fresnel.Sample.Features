// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.B_Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.H_Queries
{
    public class SaveableEntityQuerySpecification : IQuerySpecification<ObjectWithCollections, SaveableEntity>
    {
        private List<SaveableEntity> _SaveableEntities;

        public SaveableEntityQuerySpecification()
        {
            _SaveableEntities =
                Enumerable.Range(1, 10)
                .Select(i => new SaveableEntity
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableEntity)} {i}",
                    Description = "A description goes here"
                })
                .ToList();
        }

        public IEnumerable<SaveableEntity> GetResults()
        {
            return GetResults(null);
        }

        public IEnumerable<SaveableEntity> GetResults(ObjectWithCollections requestor)
        {
            // If we wanted, we could use the requestor as part of the query clause:
            if (requestor != null)
            {
                return
                    _SaveableEntities
                    .Where(e => e.Name == requestor?.Name)
                    .ToList();
            }

            return _SaveableEntities;
        }
    }
}