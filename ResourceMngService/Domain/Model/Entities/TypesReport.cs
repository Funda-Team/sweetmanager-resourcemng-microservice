using ResourceMngService.Domain.Model.Aggregates;

namespace ResourceMngService.Domain.Model.Entities;

public partial class TypesReport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
