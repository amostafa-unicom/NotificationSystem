using NotificationHubSystem.SharedKernal.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationHubSystem.SharedKernal.Helper
{
    [Serializable]
    public abstract class CommonException : Exception
    {
        public HttpEnum.ResponseStatus Result { get; private set; }
        public List<string> Errors { get; private set; }
        public CommonException(string message) : base(message)
        {
        }
        public CommonException(HttpEnum.ResponseStatus result, string message, List<string> errors) : this(message)
        {
            this.Result = result;
            this.Errors = errors;
        }
    }
    [Serializable]
    public class ValidationException : CommonException
    {
        public ValidationException(string message) : base(message)
        {
        }
        public ValidationException(HttpEnum.ResponseStatus result, string message, List<string> errors) : base(result, message, errors)
        {
        }
    }
    [Serializable]
    public class PermissionException : CommonException
    {
        public PermissionException(string message) : base(message)
        {
        }
        public PermissionException(HttpEnum.ResponseStatus result, string message, List<string> errors) : base(result, message, errors)
        {
        }
    }
    [Serializable]
    public class BusinessException : CommonException
    {
        public BusinessException(string message) : base(message)
        {
        }
        public BusinessException(HttpEnum.ResponseStatus result, string message, List<string> errors) : base(result, message, errors)
        {
        }
    }
    [Serializable]
    public class RepositoryException : CommonException
    {
        public RepositoryException(string message) : base(message)
        {
        }
        public RepositoryException(HttpEnum.ResponseStatus result, string message, List<string> errors) : base(result, message, errors)
        {
        }
    }
}
