using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DesafioAltudo.Domain.Features.Page;

namespace DesafioAltudo.Application.Features.Pages
{
    public class UrlViewModel
    {
        [Key]
        public string Url { get; set; }
    }
}
