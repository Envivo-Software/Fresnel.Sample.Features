// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    /// <summary>
    /// An example of a simple in-memory Repository
    /// </summary>
    public class SaveableEntityRepository : IRepository<SaveableEntity>
    {
        private readonly InMemoryRepository<SaveableEntity> _InMemoryRepository = new(BuildSaveableEntitiesForDemo());

        private static List<SaveableEntity> BuildSaveableEntitiesForDemo()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new SaveableEntity
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableEntity)} {i}",
                    Description = $"This is the description for item {i}"
                })
                .ToList();

            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public Task DeleteAsync(SaveableEntity aggregateRoot)
        {
            return _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<SaveableEntity> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<SaveableEntity> LoadAsync(Guid id)
        {
            return _InMemoryRepository.LoadAsync(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public Task<IAggregateLock> LockAsync(SaveableEntity aggregateRoot)
        {
            return _InMemoryRepository.LockAsync(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <param name="newObjects"></param>
        /// <param name="modifiedObjects"></param>
        /// <param name="deletedObjects"></param>
        /// <returns></returns>
        public Task<int> SaveAsync(SaveableEntity aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UnlockAsync(SaveableEntity aggregateRoot)
        {
            return Task.CompletedTask;
        }
    }
}
