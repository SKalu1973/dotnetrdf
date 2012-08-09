/*

Copyright dotNetRDF Project 2009-12
dotnetrdf-develop@lists.sf.net

------------------------------------------------------------------------

This file is part of dotNetRDF.

dotNetRDF is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

dotNetRDF is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with dotNetRDF.  If not, see <http://www.gnu.org/licenses/>.

------------------------------------------------------------------------

dotNetRDF may alternatively be used under the LGPL or MIT License

http://www.gnu.org/licenses/lgpl.html
http://www.opensource.org/licenses/mit-license.php

If these licenses are not suitable for your intended use please contact
us at the above stated email address to discuss alternative
terms.

*/

using System;
using VDS.Web.Logging;

namespace VDS.Web.Modules
{
    /// <summary>
    /// Module using to perform request logging
    /// </summary>
    public class LoggingModule
        : IHttpListenerModule
    {
        /// <summary>
        /// Process a request by asking each logger registered on the server to log it
        /// </summary>
        /// <param name="context">Server Context</param>
        /// <returns></returns>
        public bool ProcessRequest(HttpServerContext context)
        {
            foreach (IHttpLogger logger in context.Server.Loggers)
            {
                try
                {
                    logger.LogRequest(context);
                }
                catch (Exception ex)
                {
                    context.Server.LogErrors(ex);
                }
            }

            //Logging Module always returns true to allow other Modules to execute
            return true;
        }
    }
}