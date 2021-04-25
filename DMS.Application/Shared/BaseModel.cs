using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Application.Shared
{
    public abstract class BaseModel
    {
        [JsonIgnore]
        protected ModelState modelState;


        protected void Validate()
        {
            modelState = new ModelState();
            ValidationContext context = new ValidationContext(this);

            modelState.IsValid = Validator.TryValidateObject(this, context, modelState.ValidationResults, true);
        }

        [IgnoreDataMember]
        public virtual ModelState ValidationState
        {
            get
            {
                Validate();

                return modelState;
            }
        }
    }
}