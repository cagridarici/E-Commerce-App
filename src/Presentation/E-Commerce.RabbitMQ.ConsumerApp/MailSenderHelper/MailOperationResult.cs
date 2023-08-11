using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.RabbitMQ.ConsumerApp
{
    public class MailOperationResult
    {
        public MailOperationResult()
        {
            IsSuccess = true;
        }

        public void SetError(string errorMessage)
        {
            ErrorMessage = errorMessage;
            IsSuccess = false;
        }

        public void SetError(Exception ex)
        {
            Exception = ex;
            ErrorMessage = ex.Message;
            IsSuccess = false;
        }

        public bool IsSuccess
        {
            get;
            private set;
        }

        public string ErrorMessage
        {
            get;
            private set;
        }

        public string SuccessMessage
        {
            get;
            set;
        }

        public Exception Exception
        {
            get;
            private set;
        }
    }
}
