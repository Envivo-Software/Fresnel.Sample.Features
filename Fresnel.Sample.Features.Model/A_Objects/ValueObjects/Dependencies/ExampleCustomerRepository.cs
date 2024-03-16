using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.ValueObjects.Dependencies
{
    public class ExampleCustomerRepository : IRepository<ExampleCustomer>
    {
        private readonly InMemoryRepository<ExampleCustomer> _InMemoryRepository = new();

        /// <inheritdoc/>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        public async Task DeleteAsync(ExampleCustomer aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        /// <inheritdoc/>
        public IQueryable<ExampleCustomer> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        /// <inheritdoc/>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ExampleCustomer> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        /// <inheritdoc/>
        /// <param name="aggregateRoot"></param>
        /// <param name="newObjects"></param>
        /// <param name="modifiedObjects"></param>
        /// <param name="deletedObjects"></param>
        /// <returns></returns>
        public async Task<int> SaveAsync(ExampleCustomer aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }
    }
}
