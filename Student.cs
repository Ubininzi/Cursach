using System;
using System.Collections.Generic;

namespace cursach;

public partial class Student
{
    public int Id { get; set; }

    public string? Surname { get; set; }

    public string? Name { get; set; }

    public string? Patronymic { get; set; }

    public string? Group { get; set; }

    public virtual ICollection<Testresult> Testresults { get; set; } = new List<Testresult>();
}
