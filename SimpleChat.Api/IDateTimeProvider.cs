using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api
{
    // Used to unify access to current time
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
