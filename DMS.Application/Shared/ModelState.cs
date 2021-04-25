using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Shared
{
    public class ModelState
    {
        public bool IsValid { set; get; }
        public List<ValidationResult> ValidationResults { set; get; }

        public ModelState()
        {
            ValidationResults = new List<ValidationResult>();
        }
    }
}