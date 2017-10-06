using EntityFramework.Core.Generic;
using System;

namespace JwDelivery.Data.SqlServer.Models
{
    public abstract class AuditableEntity : IEntity
    {
        public string AuditUser { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
