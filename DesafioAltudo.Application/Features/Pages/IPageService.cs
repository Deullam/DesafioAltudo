using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioAltudo.Application.Features.Pages
{
    public interface IPageService
    {

        public PageViewModel GetPageDetails(string url);

    }
}
