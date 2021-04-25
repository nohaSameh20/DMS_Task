using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.Application.Data
{
    public class ServerResponse<T>
    {
        public T Result { set; get; }
        public ServerResponse()
        {
            Result = default(T);
        }
        public ServerResponse(T resultObject) : this()
        {
            Result = resultObject;
        }
        public static implicit operator ServerResponse<T>(T result)
        {
            return new ServerResponse<T>() { Result = result };
        }

    }

    public class DMSResponse : ServerResponse<object>
    {
        public static DMSResponse Void
        {
            get
            {
                return new DMSResponse();
            }
        }

        public DMSResponse()
        {
            Result = null;
        }
    }
}
