using System;
using System.Collections.Generic;

namespace JMOperations.Models;

public partial class Operation
{
    public int OperationId { get; set; }

    public string? Name { get; set; }

    public int? OperationOrder { get; set; }

    public byte[]? ImageData { get; set; }

    public int? DeviceId { get; set; }
    
    public bool? IsDeleted { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public virtual Device Device { get; set; }
}
