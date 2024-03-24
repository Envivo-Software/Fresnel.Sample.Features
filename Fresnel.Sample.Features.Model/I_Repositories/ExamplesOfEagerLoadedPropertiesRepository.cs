// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.RelationshipExamples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    /// <summary>
    /// An example of a simple in-memory Repository
    /// </summary>
    public class ExamplesOfEagerLoadedPropertiesRepository : IRepository<ExamplesOfEagerLoadedProperties>
    {
        private readonly InMemoryRepository<ExamplesOfEagerLoadedProperties> _InMemoryRepository = new();

        /// <inheritdoc/>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task DeleteAsync(ExamplesOfEagerLoadedProperties aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <inheritdoc/>
        public IQueryable<ExamplesOfEagerLoadedProperties> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <inheritdoc/>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExamplesOfEagerLoadedProperties> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        /// <inheritdoc/>
        /// <param name="aggregateRoot"></param>
        /// <param name="newObjects"></param>
        /// <param name="modifiedObjects"></param>
        /// <param name="deletedObjects"></param>
        /// <returns></returns>
        public async Task<int> SaveAsync(ExamplesOfEagerLoadedProperties aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }
    }
}
