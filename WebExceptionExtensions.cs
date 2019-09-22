using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Net;
using System.Text;

namespace Penguin.Net.Extensions
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public static class WebExceptionExtensions
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        /// <summary>
        /// Gets the response body of a webexception
        /// </summary>
        /// <param name="ex">The webexception to get the response body of </param>
        /// <returns>The response body of the request that threw the exception</returns>
        public static string GetBody(this WebException ex)
        {
            Contract.Requires(ex != null);

            if (!(ex.Response.GetResponseStream() is MemoryStream responseStream))
            {
                return null;
            }

            byte[] responseBytes = responseStream.ToArray();

            string responseString = Encoding.UTF8.GetString(responseBytes);

            return responseString;
        }
    }
}
