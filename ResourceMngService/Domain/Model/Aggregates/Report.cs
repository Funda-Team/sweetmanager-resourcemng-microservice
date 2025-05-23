﻿using ResourceMngService.Domain.Model.Entities;

namespace ResourceMngService.Domain.Model.Aggregates;

public partial class Report
{
    public int Id { get; set; }

    public int TypesReports { get; set; }

    public int? AdminsId { get; set; }

    public int? WorkersId { get; set; }

    public string? FileUrl { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public virtual TypesReport TypesReportsNavigation { get; set; } = null!;
}
