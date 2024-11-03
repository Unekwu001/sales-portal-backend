using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos
{
    public class PdfMailDto
    {
        public string Email { get; set; }
        public IFormFile PdfFile { get; set; }

    }

}
