using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trucktive.Core.Contracts.Drivers
{
    public record CreateDriverRequest
    (
         string FName,
         string LName,
         string Phone,
         string Address,
         string Email,
         string Password,
         int SupervisorId
    );
}
