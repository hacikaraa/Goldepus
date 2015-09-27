using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOLDEPUS.Bll
{
    public class ResultObject<T> where T : class
    {
        private bool result;
        private string message;
        private T value;

        public ResultObject()
        {
            this.result = false;
            this.message = string.Empty;
            this.value = null;
        }

        public bool Result
        {
            get { return this.result; }
            set { this.result = value; }
        }

        public string Message
        {
            get { return this.message; }
            set { this.message = value; }
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
