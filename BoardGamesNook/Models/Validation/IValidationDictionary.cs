using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesNook.Models.Validation
{
    public interface IValidationDictionary
    {
        void AddError(string key, Exception errorException);
        void AddError(string key, string errorMessage);
        void AddError(Exception errorException);
        void AddError(string errorMessage);
        bool IsValid { get; }
    }
}
