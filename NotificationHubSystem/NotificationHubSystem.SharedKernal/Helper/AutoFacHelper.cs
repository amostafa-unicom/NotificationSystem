using Microsoft.Extensions.DependencyInjection;
using System;

namespace NotificationHubSystem.SharedKernal.Helper
{
    public static class AutoFacHelper
    {
        public static IServiceProvider Container { get; set; }
    }
}
