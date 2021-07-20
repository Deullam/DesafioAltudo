using AutoMapper;
using DesafioAltudo.Domain.Features;
using System;
using System.Threading.Tasks;

namespace DesafioAltudo.Application.Features.Pages
{
    public class PageService : IPageService
    {
        private readonly IMapper _mapper;

        public PageService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public PageViewModel GetPageDetails(string url)
        {
            try
            {
                Page page = new Page()
                { Url = url
                };

                page.Validate();
                var doc =  page.LoadUrl(page.Url);
                 page.GetImages(doc);
                string words = page.GetAllWords(doc);
                page.MostUsedWords = page.GetTenMostUsedWords(words);

                return _mapper.Map<PageViewModel>(page);
            }catch (Exception e)
            {
                throw e;
            }

        }
    }
}
