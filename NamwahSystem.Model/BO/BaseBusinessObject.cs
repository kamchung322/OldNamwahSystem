using System;
using System.Collections.Generic;
using System.Linq;

namespace NamwahSystem.Model.BO
{
    public abstract class BaseBusinessObject
    {
        private string _CreatedBy = "";
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private DateTime _CreatedDate = DateTime.Now;
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private DateTime _LastModifiedDate = DateTime.Now;
        public DateTime LastModifiedDate
        {
            get { return _LastModifiedDate; }
            set { _LastModifiedDate = value; }
        }
    }
}
