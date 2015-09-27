using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.Tool
{
    class LibraryContainer
    {
        private string errorLogConnectionString;

        public LibraryContainer() 
        {
            this.errorLogConnectionString = @"Server=95.173.180.170; Database=ErrorLogDB;User Id=ERRLogUser;Password=ERRLogUser1456;";
        }

        public string ErrorLogConnectionString
        {
            get { return errorLogConnectionString; }
        }

    }
}
