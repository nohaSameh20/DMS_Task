using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common
{
    public class LookupDescriptionValueObject : IValueObject
    {
        public LookupDescriptionValueObject()
        {

        }

        public LookupDescriptionValueObject(string name, Language language)
        {
            Language = language;
            Name = name;
        }

        public Language Language { set; get; }
        public string Name { set; get; }
    }
}
