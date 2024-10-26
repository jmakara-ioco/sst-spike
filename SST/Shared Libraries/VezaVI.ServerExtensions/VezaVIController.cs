using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using VezaVI.Light.Shared;

namespace VezaVI.Light.ServerExtensions
{
    public class VezaVIController<TEntity> : ControllerBase where TEntity : class, IVezaVIRecordBase, new()
    {

        public readonly DbContext _context;

        public VezaVIController(DbContext context)
        {
            _context = context;
        }

        public virtual IQueryable<TEntity> FilteredData(IList<VezaVIGridFilter> filters)
        {
            return _context.Set<TEntity>().FilteredData<TEntity>(filters);
        }

        [HttpPost]
        [Route("GetList")]
        public virtual async Task<ActionResult<PaginatedList<TEntity>>> GetList([FromBody] IList<VezaVIGridFilter> filter, [FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 50, [FromQuery] string sortField = "", [FromQuery] string sortOrder = "", [FromQuery] string searchText = "", [FromQuery] bool ReturnAll = false)
        {
            try
            {
                if (ReturnAll)
                {
                    var items = await FilteredData(filter).AsNoTracking().OrderByDynamic(sortField, sortOrder.ToUpper()).ToListAsync();
                    var count = items.Count;
                    return new PaginatedList<TEntity>(items, count, 1, count);
                }
                else
                {
                    var filteredItems = FilteredData(filter).AsNoTracking().SearchedData(searchText);
                    var items = await (string.IsNullOrEmpty(sortField) ?
                        filteredItems.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync() :
                        filteredItems.OrderByDynamic(sortField, sortOrder.ToUpper()).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync());
                    var count = await filteredItems.CountAsync();
                    return new PaginatedList<TEntity>(items, count, pageIndex, pageSize);
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message,ex.InnerException);
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TEntity>> GetByID(string id)
        {
            var item = await _context.Set<TEntity>().FindAsync(new Guid(id));
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost("Update/{id}")]
        [Authorize]
        public virtual async Task<VezaAPISubmitResult> Put(string id, [FromBody] TEntity item)
        {
            try
            {
                /*User*/
                var userID = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                if (id != item.GetID().ToString())
                {
                    return VezaAPISubmitResult.Failed("Cannot Save as ID's are different.");
                }
                TEntity entity = await _context.Set<TEntity>().FindAsync(item.GetID());
                if (entity == null)
                    return VezaAPISubmitResult.Failed("Entity not found.");
                _context.Entry(entity).CurrentValues.SetValues(item);
                //_context.Set<TEntity>().Update(item);
                try
                {
                    if (_context is IDBContextUserSaveChanges)
                        await (_context as IDBContextUserSaveChanges).SaveChangesAsync(userID);
                    else
                        await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    try
                    {
                        foreach (var entry in ex.Entries)
                        {
                            if (entry is TEntity)
                            {
                                var databaseValues = await entry.GetDatabaseValuesAsync();
                                entry.OriginalValues.SetValues(databaseValues);
                            }
                        }
                        if (_context is IDBContextUserSaveChanges)
                            await (_context as IDBContextUserSaveChanges).SaveChangesAsync(userID);
                        else
                            await _context.SaveChangesAsync();
                    }
                    catch (Exception nex)
                    {
                        throw nex;
                    }
                }
                return VezaAPISubmitResult.Succeeded(item.GetID());
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed(ex.Message);
            }
        }

        public async Task<bool> RecordExists(Guid id)
        {
            var item = await _context.Set<TEntity>().FindAsync(id);
            return (item != null);
        }

        [HttpPost]
        public virtual async Task<VezaAPISubmitResult> Post([FromBody] TEntity item)
        {
            try
            {
                /*User*/
                var userClaim = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
                Guid? userID = (userClaim != null) ? 
                    (Guid?)new Guid(userClaim.Value) :
                    (Guid?)null;
                _context.Set<TEntity>().Add(item);
                if (_context is IDBContextUserSaveChanges)
                    await (_context as IDBContextUserSaveChanges).SaveChangesAsync(userID);
                else
                    await _context.SaveChangesAsync();
                return VezaAPISubmitResult.Succeeded(item.GetID());
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed(ex.Message);
            }
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [Authorize]
        public virtual async Task<VezaAPISubmitResult> Delete(string id)
        {
            try
            {
                /*User*/
                var userID = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);

                var item = await _context.Set<TEntity>().FindAsync(new Guid(id));
                if (item == null)
                {
                    return VezaAPISubmitResult.Failed("Could not locate record.");
                }
                _context.Set<TEntity>().Remove(item);
                if (_context is IDBContextUserSaveChanges)
                    await (_context as IDBContextUserSaveChanges).SaveChangesAsync(userID);
                else
                    await _context.SaveChangesAsync();

                return VezaAPISubmitResult.Succeeded(item.GetID());
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed(ex.Message);
            }
        }

        [NonAction]
        public virtual void BeforeSaveObject(TEntity entity, DataRow row, string additionalInfo)
        {
            
        }

        [HttpPost]
        [Route("Import")]
        [Route("Import/{additionalInfo}")]
        [Authorize]
        public virtual async Task<VezaAPISubmitResult> Import(string additionalInfo, [FromBody] string fileBase64)
        {
            try
            {
                var userId = new Guid(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                //var companyId = new Guid(User.Claims.FirstOrDefault(x => x.Type == "CompanyID").Value);

                var bytes = Convert.FromBase64String(fileBase64);
                MemoryStream stream = new MemoryStream(bytes);
                var dt = VezaVICSVImporter.ReadCSVFile(stream);
                List<string> errors = new List<string>();
                List<string> lineErrors = new List<string>();
                int rowNumber = 0;
                foreach (DataRow row in dt.Rows)
                {
                    rowNumber++;
                    TEntity entity = new TEntity();
                    BeforeSaveObject(entity, row, additionalInfo);
                    var result = await Post(entity);
                    if (!result.Successful)
                        lineErrors.Add($"Line {rowNumber}: {result.Errors.FirstOrDefault()}.");
                }
                return new VezaAPISubmitResult { Successful = (errors.Count == 0), Errors = lineErrors };
            }
            catch (Exception ex)
            {
                return VezaAPISubmitResult.Failed(ex.Message);
            }
        }


        [HttpGet]
        [Route("ImportStructure")]
        [Route("ImportStructure/{additionalInfo}")]
        public async Task<IActionResult> ImportStructure(string additionalInfo)
        {
            StringBuilder builder = new StringBuilder();
            string separator = ";";
            try
            {
                int counter = 0;
                foreach (string p in GetAllowedImportProperties(additionalInfo))
                {
                    if (counter > 0)
                        builder.Append(separator);
                    builder.Append(p);
                    counter++;
                }
                builder.Append(Environment.NewLine);
                byte[] fileData = Encoding.UTF8.GetBytes(builder.ToString());
                
                return File(fileData, "application/octet-stream", $"{GetImportName(additionalInfo)} Import.csv");
            }
            catch (Exception ex)
            {
                byte[] fileData = Encoding.UTF8.GetBytes(ex.Message);
                return File(fileData, "application/octet-stream", $"Error.txt");
            }
        }

        [NonAction]
        public virtual string[] GetAllowedImportProperties(string additionalInfo)
        {
            return new string[0];
        }

        [NonAction]
        public virtual string GetImportName(string additionalInfo)
        {
            TEntity t = new TEntity();
            return t.GetType().Name;
        }

    }
}
