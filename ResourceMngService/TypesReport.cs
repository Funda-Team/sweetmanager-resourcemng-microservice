using System;
using System.Collections.Generic;

namespace ResourceMngService;

public partial class TypesReport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
