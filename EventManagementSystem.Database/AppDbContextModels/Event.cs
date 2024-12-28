using System;
using System.Collections.Generic;

namespace EventManagementSystem.Database.AppDbContextModels;

public partial class Event
{
    public int EventId { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime Date { get; set; }

    public string? Location { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
