using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stx.Shared.Api.Services
{
    /// <summary>
    /// Represents the contents of a blob stored in Azure Storage
    /// </summary>
    public class BlobModel
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public Stream Content { get; set; }

    }
}
