using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static DesafioAltudo.Domain.Features.Page;

namespace DesafioAltudo.Application.Features.Pages
{
    public class PageViewModel
    {
        [Key]
        public string Url { get; set; }
        public IEnumerable<string> LinksImages { get; set; }
        public string WordsList { get; set; }
        public List<Word> MostUsedWords { get; set; }
    }
}
