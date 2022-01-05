using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Common.Exceptions
{
    public class BaseException : Exception
    {
        #region Fields
        private string _code;
        private string _message;
        #endregion

        #region Properties
        public string Code
        {
            get
            {
                return this._code;
            }
        }
        #endregion

        #region Constructors
        public BaseException()
        {

        }
        /// <summary>
        /// Create custom exception
        /// </summary>
        /// <param name="message">Custom message as it is</param>
        public BaseException(string message) : base(message)
        {
            //TODO: get the real message from resource files
            this._message = message;
        }

        /// <summary>
        /// Create custom exception
        /// </summary>
        /// <param name="message">Custom message as it is</param>
        /// <param name="code">Exception code</param>
        public BaseException(string message, string code) : this(message)
        {
            this._code = code;
        }
        #endregion
    }
}
