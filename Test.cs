using System;
using System.Collections.Generic;

namespace cursach;

public partial class Test
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Testresult> Testresults { get; set; } = new List<Testresult>();
}
