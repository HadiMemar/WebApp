using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        #region Private Variables
        private string _message = String.Empty;
        private Dictionary<string, string> _parameters;

        public Dictionary<string, string> Parameters
        {
            get
            {
                return _parameters;
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Create custom not found exception
        /// </summary>
        /// <param name="message">Custom message as it is</param>
        public NotFoundException(string message) : base(message)
        {
            //TODO: get the real message from resource files
            _message = message;
        }

        /// <summary>
        /// Create custom not found exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        public NotFoundException(string message, string code) : base(message, code)
        {
        }

        /// <summary>
        /// Create custom not found exception with parameters
        /// </summary>
        /// <param name="message"></param>
        /// <param name="code"></param>
        /// <param name="parameters"></param>
        public NotFoundException(string message, string code, Dictionary<string, string> parameters) : base(message, code)
        {
            _parameters = parameters;
        }
        #endregion
    }
}
