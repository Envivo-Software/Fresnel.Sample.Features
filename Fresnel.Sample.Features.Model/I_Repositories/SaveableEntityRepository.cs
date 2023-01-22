// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.I_Repositories
{
    /// <summary>
    /// An example of a simple in-memory Repository
    /// </summary>
    public class SaveableEntityRepository : IRepository<SaveableEntity>
    {
        private static readonly InMemoryRepository<SaveableEntity> _InMemoryRepository = new(BuildSaveableEntitiesForDemo());

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
        /// <returns></returns>
        public IQueryable<SaveableEntity> GetAll()
        {
            return _InMemoryRepository.GetAll();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public SaveableEntity? Load(Guid id)
        {
            return _InMemoryRepository.Load(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Save(SaveableEntity aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.Save(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Delete(SaveableEntity aggregateRoot)
        {
            _InMemoryRepository.Delete(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IAggregateLock? Lock(SaveableEntity aggregateRoot)
        {
            return _InMemoryRepository.Lock(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Unlock(SaveableEntity aggregateRoot)
        {
            _InMemoryRepository.Unlock(aggregateRoot);
        }
    }
}
