using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aybala.DTO.Log
{
    public class ErrorLogObject
    {
        private int id;
        private int projectId;
        private string projectName;
        private string module;
        private string className;
        private string function;
        private string exceptionCode;
        private string exceptionMessage;
        private string note;
        private string description;
        private string device;
        private string userIp;
        private DateTime date;
        public ErrorLogObject()
        {
            this.id = 0;
            this.projectId = 0;
            this.projectName = string.Empty;
            this.module = string.Empty;
            this.className = string.Empty;
            this.function = string.Empty;
            this.exceptionCode = string.Empty;
            this.exceptionMessage = string.Empty;
            this.note = string.Empty;
            this.description = string.Empty;
            this.device = string.Empty;
            this.userIp = string.Empty;
            this.date = DateTime.Now;
        }

        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public int ProjectID
        {
            get { return this.projectId; }
            set { this.projectId = value; }
        }

        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        public string Module
        {
            get { return this.module; }
            set { this.module = value; }
        }

        public string ClassName
        {
            get { return this.className; }
            set { this.className = value; }
        }

        public string Function
        {
            get { return this.function; }
            set { this.function = value; }
        }

        public string ExceptionCode
        {
            get { return this.exceptionCode; }
            set { this.exceptionCode = value; }
        }

        public string ExceptionMessage
        {
            get { return this.exceptionMessage; }
            set { this.exceptionMessage = value; }
        }

        public string Note
        {
            get { return this.note; }
            set { this.note = value; }
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        public string Device
        {
            get { return this.device; }
            set { this.device = value; }
        }

        public string UserIp
        {
            get { return this.userIp; }
            set { this.userIp = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }
    }
}
