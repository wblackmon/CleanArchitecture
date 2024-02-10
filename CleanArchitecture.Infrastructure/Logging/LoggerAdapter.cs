using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Infrastructure.Logging
{
    public class LoggerAdapter<T> : IAppLogger<T>
    {
        public void LogInformation(string message, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
