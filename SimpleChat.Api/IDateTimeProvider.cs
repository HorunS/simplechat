using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChat.Api
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
