// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.B_Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.H_Queries
{
    public class SaveableEntityQuerySpecification : IQuerySpecification<SaveableEntity>
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

        public Task<IEnumerable<SaveableEntity>> GetResultsAsync()
        {
            return Task.FromResult(_SaveableEntities.AsEnumerable());
        }

        public Task<IEnumerable<SaveableEntity>> GetResultsAsync(ObjectWithCollections requestor)
        {
            // If we wanted, we could use the requestor as part of the query clause:
            var filterName = requestor?.Name;
            if (!string.IsNullOrEmpty(filterName))
            {
                var results =
                    _SaveableEntities
                    .Where(e => e.Name == filterName)
                    .ToList()
                    .AsEnumerable();
                return Task.FromResult(results);
            }

            return Task.FromResult(_SaveableEntities.AsEnumerable());
        }

        public Task<IEnumerable<SaveableEntity>> GetResultsAsync(SaveableAggregateRoot requestor)
        {
            // If we wanted, we could use the requestor as part of the query clause:
            if (requestor != null)
            {
                // Execute custom filtering here
            }

            return Task.FromResult(_SaveableEntities.AsEnumerable());
        }

        public Task<IEnumerable<SaveableEntity>> GetResultsAsync(SaveableAggregateRoot requestor1, ObjectWithCollections requestor2)
        {
            // We could also use multiple requestors as part of the query clause:
            if (requestor1 != null && requestor2 != null)
            {
                // Execute custom filtering here
            }

            return Task.FromResult(_SaveableEntities.AsEnumerable());
        }
    }
}