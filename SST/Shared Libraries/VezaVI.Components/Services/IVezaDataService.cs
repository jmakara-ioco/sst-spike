using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{


    public interface IVezaDataService<TEntity> where TEntity : class, IVezaVIRecordBase
    {
        Task<PaginatedList<TEntity>> GetAllAsync(string sortField);
        Task<PaginatedList<TEntity>> GetAllAsync(string sortField, IList<VezaVIGridFilter> gridFilter);
        Task<PaginatedList<TEntity>> GetListAsync(IList<VezaVIGridFilter> gridFilter, int pageIndex, int? pageSize, string sortField, string sortOrder, string searchText);
        Task<TEntity> GetAsync(object id);
        Task<VezaAPISubmitResult> AddAsync(TEntity item);
        Task<VezaAPISubmitResult> UpdateAsync(TEntity item);
        Task<VezaAPISubmitResult> DeleteAsync(object id);
        Task<VezaAPISubmitResult> ImportAsync(string importFileBase64);
        public string APIRootPath { get; }
    }
}
