using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Components
{
    public interface ISortable
    {
        int PageNumber { get; set; }
        string CurrentSortField { get; set; }
        string CurrentSortOrder { get; set; }
        DisplayAs DisplayAs { get; set; }

        Task SortAsync(string sortField);
        string SortIndicator(string sortField);

        void AddColumn(MaintenanceGridColumn column);

        void RemoveColumn(MaintenanceGridColumn column);
    }
}
