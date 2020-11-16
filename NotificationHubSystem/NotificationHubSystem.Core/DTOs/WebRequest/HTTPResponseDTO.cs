using System;

namespace NotificationHubSystem.Core.DTOs.WebRequest
{
    public class HTTPResponseDTO<T>
    {
        public System.Net.HttpStatusCode HttpStatusCode { get; set; } = System.Net.HttpStatusCode.InternalServerError;
        public T Body { get; set; } = (T)Activator.CreateInstance(typeof(T));
    }
}