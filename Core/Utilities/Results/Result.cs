using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result
    {
		private bool success;
		public bool Success
		{
			get { return success; }
		}

		private string message;
		public string Message
		{
			get { return message; }
		}

        public Result(bool success, string message) : this(success)
        {
            this.message = message;
        }

        public Result(bool success)
        {
            this.success = success;
        }
    }
}
