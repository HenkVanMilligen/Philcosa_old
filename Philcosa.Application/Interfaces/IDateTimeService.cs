using System;
using System.Collections.Generic;
using System.Text;

namespace Philcosa.Application.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
