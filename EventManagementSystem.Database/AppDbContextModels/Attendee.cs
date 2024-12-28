using System;
using System.Collections.Generic;

namespace EventManagementSystem.Database.AppDbContextModels;

public partial class Attendee
{
    public int AttendeeId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();
}
