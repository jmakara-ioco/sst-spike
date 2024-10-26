using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VezaVI.Light.Components
{
    public class MaintenanceGridBase : ComponentBase, ISortable
    {
        [Parameter]
        public string DefautSortField { get; set; } = string.Empty;
        [Parameter]
        public bool SortDesending { get; set; } = false;


        public int PageNumber { get; set; } = 1;

        private string _currentSortField = null;
        public string CurrentSortField
        {
            get
            {
                if (_currentSortField == null)
                    _currentSortField = DefautSortField;
                return _currentSortField;
            }
            set
            {
                _currentSortField = value;
            }
        }

        private string _currentSortOrder = null;
        public string CurrentSortOrder
        {
            get
            {
                if (_currentSortOrder == null)
                    _currentSortOrder = (SortDesending ? "Desc" : "Asc") ;
                return _currentSortOrder;
            }
            set
            {
                _currentSortOrder = value;
            }
        }
        
        [Parameter]
        public DisplayAs DisplayAs { get; set; } = DisplayAs.Grid;

        public virtual void AddColumn(MaintenanceGridColumn column)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveColumn(MaintenanceGridColumn column)
        {
            throw new NotImplementedException();
        }

        public virtual Task SortAsync(string sortField)
        {
            throw new NotImplementedException();
        }

        public virtual string SortIndicator(string sortField)
        {
            throw new NotImplementedException();
        }
    }
}
