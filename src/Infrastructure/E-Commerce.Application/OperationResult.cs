using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application
{
    /// <summary>
    /// Servis Tarafinda Yapilan Operasyonların Hatalı veya Başarılı İşlemlerini İşlemek İcin Kullanılmaktadır...
    /// </summary>
    public class OperationResult
    {
        public OperationResult()
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

        public Exception Exception
        {
            get;
            private set;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Value { get; set; }

        public void SetValue(T value)
        {
            Value = value;
        }

        public T GetValue()
        {
            return Value;
        }
    }
}
