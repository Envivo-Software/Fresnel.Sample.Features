using Envivo.Fresnel.ModelTypes;
using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Envivo.Fresnel.Sample.Features.Model.E_Methods
{
    public class ExamplesOfConfirmationDialogsRepository : IRepository<ExamplesOfConfirmationDialogs>
    {
        private readonly InMemoryRepository<ExamplesOfConfirmationDialogs> _InMemoryRepository = new();

        public async Task DeleteAsync(ExamplesOfConfirmationDialogs aggregateRoot)
        {
            await _InMemoryRepository.DeleteAsync(aggregateRoot);
        }

        public IQueryable<ExamplesOfConfirmationDialogs> GetQuery()
        {
            return _InMemoryRepository.GetQuery();
        }

        public async Task<ExamplesOfConfirmationDialogs> LoadAsync(Guid id)
        {
            return await _InMemoryRepository.LoadAsync(id);
        }

        public async Task<int> SaveAsync(ExamplesOfConfirmationDialogs aggregateRoot, IEnumerable<object> newObjects, IEnumerable<object> modifiedObjects, IEnumerable<object> deletedObjects)
        {
            return await _InMemoryRepository.SaveAsync(aggregateRoot, newObjects, modifiedObjects, deletedObjects);
        }
    }
}
