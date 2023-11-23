using System;
using System.Collections.Generic;

namespace cursach;

public partial class Testresult
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? TestId { get; set; }

    public int? Mark { get; set; }

    public virtual Student? Student { get; set; }

    public virtual Test? Test { get; set; }
}
