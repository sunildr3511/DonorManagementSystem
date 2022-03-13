using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DMS.Services.Application.Common
{
   public static class Utilities
    {
        public static byte[] GetDocumentDataInBytes(IFormFile document)
        {
            if (document == null)
                return null;

            byte[] documentData;

            using (MemoryStream ms = new MemoryStream())
            {
                document.CopyToAsync(ms);
                documentData = ms.ToArray();
            }

            return documentData;
        }
    }
}
