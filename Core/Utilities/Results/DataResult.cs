using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result
    {
        private T data;
        public T Data
        {
            get { return data; }
        }

        public DataResult(bool success, string message, T data) : base(success, message)
        {
            this.data = data; 
        }

        public DataResult(bool success, T data) : base(success)
        {
            this.data = data;
        }
    }
}
