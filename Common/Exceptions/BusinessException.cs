using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common.Exceptions
{
    public class BusinessException : BaseException
    {
        private Dictionary<string, string> _parameters;

        public Dictionary<string, string> Parameters
        {
            get
            {
                return _parameters;
            }
        }

        #region Constructors
        /// <summary>
        /// Create custom business exception
        /// </summary>
        /// <param name="message">Custom message as it is</param>
        public BusinessException(string message) : base(message)
        {
        }

        /// <summary>
        /// Create custom business exception
        /// </summary>
        /// <param name="message">Custom message as it is</param>
        /// <param name="code">Exception code</param>
        public BusinessException(string message, string code) : base(message, code)
        {
        }

        /// <summary>
        /// Create custom business exception
        /// </summary>
        /// <param name="message">Custom message as it is</param>
        /// <param name="code">Exception code</param>
        /// <param name="parameters"></param>
        public BusinessException(string message, string code, Dictionary<string, string> parameters) : base(message, code)
        {
            _parameters = parameters;
        }
        #endregion
    }
}
