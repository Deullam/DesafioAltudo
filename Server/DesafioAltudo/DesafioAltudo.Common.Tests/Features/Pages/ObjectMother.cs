using DesafioAltudo.Domain.Features;
using System.Collections.Generic;

namespace DesafioAltudo.Common.Tests.Features.ObjectMother
{
    public class ObjectMother
    {

        public static Page GetNewEmptyPage()
        {
            return new Page()
            {
                Url = "",
                LinksImages = new List<string>(),
                WordsList = ""
            };
        }

        public static Page GetNewValidPage()
        {
            return new Page()
            {
                Url = "https://g1.globo.com/sc/santa-catarina/noticia/2021/07/20/sc-amanhece-com-temperaturas-negativas-nesta-terca-feira.ghtml",
                LinksImages = new List<string>(),
                WordsList = ""
            }; 
        }

    }
}
