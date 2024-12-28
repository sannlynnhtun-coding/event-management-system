using System;
using System.Collections.Generic;

namespace EventManagementSystem.Database.AppDbContextModels;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int? EventId { get; set; }

    public int? AttendeeId { get; set; }

    public virtual Attendee? Attendee { get; set; }

    public virtual Event? Event { get; set; }
}
