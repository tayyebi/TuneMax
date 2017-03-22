using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuneMax.Models
{
    public interface DollarRepository_
    {
        IEnumerable<Dollar> GetDollars();
        List<string> GetInstructor();
        Dollar GetDollarByID(int id);
    }
}