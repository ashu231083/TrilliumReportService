using TriliumAgent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriliumAgent.Services.Interfaces
{
    interface IInstanceQuery
    {
        List<Dictionary<string, object>> Execute(string studyUid, Query query);
        List<Dictionary<string, object>> Execute(string studyUid, string seriesUid, Query query);
    }
}
