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
    public class SaveableAggregateRootRepository : IRepository<SaveableAggregateRoot>
    {
        private static readonly InMemoryRepository<SaveableAggregateRoot> _InMemoryRepository = new InMemoryRepository<SaveableAggregateRoot>(BuildSaveableAggregateRootsForDemo());

        private static List<SaveableAggregateRoot> BuildSaveableAggregateRootsForDemo()
        {
            var results =
                Enumerable.Range(1, 10)
                .Select(i => new SaveableAggregateRoot
                {
                    Id = Guid.NewGuid(),
                    Name = $"{nameof(SaveableAggregateRoot)} {i}",
                    Description = $"This is the description for item {i}"
                })
                .ToList();

            return results;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IQueryable<SaveableAggregateRoot> GetAll()
        {
            return _InMemoryRepository.GetAll();
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public SaveableAggregateRoot? Load(Guid id)
        {
            return _InMemoryRepository.Load(id);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public int Save(SaveableAggregateRoot aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return _InMemoryRepository.Save(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Delete(SaveableAggregateRoot aggregateRoot)
        {
            _InMemoryRepository.Delete(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public IAggregateLock? Lock(SaveableAggregateRoot aggregateRoot)
        {
            return _InMemoryRepository.Lock(aggregateRoot);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public void Unlock(SaveableAggregateRoot aggregateRoot)
        {
            _InMemoryRepository.Unlock(aggregateRoot);
        }
    }
}
