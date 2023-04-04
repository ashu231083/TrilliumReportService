using TriliumAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Services.Interfaces
{
    interface IStudyQuery
    {
        List<Dictionary<string, object>> Execute(Query query);
    }
}
