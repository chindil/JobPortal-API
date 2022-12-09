using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stx.Shared.Api.InternalConfig
{
    public class SwaggerDocs
    {
        /// <summary>
        /// Unlist ATS Api from the Swagger documentation
        /// </summary>
        public const bool IsHideAtsApi = true;
        /// <summary>
        /// Unlist CRM Api from the Swagger documentation
        /// </summary>
        public const bool IsHideCrmApi = true;
        /// <summary>
        /// Unlist Legal/IP/TM Api from the Swagger documentation
        /// </summary>
        public const bool IsHideLegalApi = false;
        /// <summary>
        /// Unlist Account/Login/Signup Api from the Swagger documentation
        /// </summary>
        public const bool IsHideAccountApi = true;
        /// <summary>
        /// Unlist Internal Api from the Swagger documentation
        /// </summary>
        public const bool IsHideInternalApi = true;
    }
}
