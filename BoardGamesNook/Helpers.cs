using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BoardGamesNook
{
    internal static class Helpers
    {
        internal static string GetErrorMessages(ICollection<ModelState> modelStates)
        {
            return string.Join(" ",
                modelStates.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)));
        }
    }
}