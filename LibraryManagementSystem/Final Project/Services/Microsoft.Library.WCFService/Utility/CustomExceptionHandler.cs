//---------------------------------------------------------------------
// <copyright file="CustomExceptionHandler.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//    Contains the Custom Exception Handler class fro FCD
// </summary>
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.LibraryService.Utility
{

    /// <summary>
    /// A class that defines Custom Exception Handler Methods for FCD
    /// </summary>
    [Serializable]
    public sealed class CustomExceptionHandler : Exception
    {

        #region CustomExceptionHandler Cunstructor

        /// <summary>
        /// Throw exception with out message
        /// </summary>
        /// <example>throw new CustomException()</example>
        public CustomExceptionHandler()
            : base() { }

        /// <summary>
        /// Throw exception with simple message
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <example>throw new CustomException(message)</example>
        public CustomExceptionHandler(string message)
            : base(message) { }

        /// <summary>
        /// Throw exception with message format and parameters
        /// </summary>
        /// <param name="format">Exception message format</param>
        /// <param name="args">argument array</param>
        /// <example>throw new CustomException("Exception with parameter value '{0}'", param)</example>
        public CustomExceptionHandler(string format, params object[] args)
            : base(string.Format(format, args)) { }

        /// <summary>
        /// Throw exception with simple message and inner exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">inner Exception message</param>
        /// <example>throw new CustomException(message, innerException)</example>
        public CustomExceptionHandler(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Throw exception with message format and inner exception. 
        /// Note that, the variable length params are always floating.
        /// </summary>
        /// <param name="format">Exception message format</param>
        /// <param name="innerException">inner Exception message</param>
        /// <param name="args">argument array</param>
        /// <example>throw new CustomException("Exception with parameter value '{0}'", innerException, param)</example>
        public CustomExceptionHandler(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }

        /// <summary>
        /// Constructor is used during exception serialization/deserialization. 
        /// </summary>
        /// <param name="info">info</param>
        /// <param name="context">context</param>
        protected CustomExceptionHandler(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        #endregion

    }
}
