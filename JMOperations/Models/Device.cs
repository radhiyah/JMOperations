using System;
using System.Collections.Generic;

namespace JMOperations.Models;

public partial class Device
{
    public int DeviceId { get; set; }

    public string? Name { get; set; }

    public string? DeviceType { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateUpdated { get; set; }

    public virtual ICollection<Operation> Operations { get; } = new List<Operation>();
}
