using System;
using System.Collections.Generic;
using System.Text;

namespace VezaVI.Light.Shared
{
    public enum ChangeType
    {
        Insert,
        Update,
        Delete
    }
    public class AuditLog : VezaVIGuidRecordBase
    {
        public Guid? UserID { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string TableName { get; set; }
        public string Column { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public ChangeType ChangeType { get; set; }
    }
}
