using DesafioAltudo.Common.Tests.Features.ObjectMother;
using DesafioAltudo.Domain.Exceptions;
using DesafioAltudo.Domain.Features;
using FluentAssertions;
using HtmlAgilityPack;
using NUnit.Framework;
using System;

namespace DesafioAltudo.Domain.Tests.Features.Pages
{
    [TestFixture]
    public class PageTests
    {
        private Page _page;

        [SetUp]
        public void Initalize()
        {
            _page = new Page();
        }
        [Test]
        public void Test_Page_LoadUrl_ShouldBeOk()
        {
            string url = "https://www.google.com.br";
            _page = ObjectMother.GetNewEmptyPage();

            HtmlDocument document = _page.LoadUrl(url);

            document.Should().NotBeNull();
            _page.Url.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void Test_Page_GetImageFromUrl_ShouldBeOk()
        {
            _page = ObjectMother.GetNewValidPage();

            var document = _page.LoadUrl(_page.Url);
            _page.GetImages(document);


            _page.LinksImages.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void Test_Page_GetAllWordsFromUrl_ShouldBeOk()
        {
            _page = ObjectMother.GetNewValidPage();

            var document = _page.LoadUrl(_page.Url);
            _page.GetAllWords(document);

            _page.WordsList.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void Test_Page_GetTenMostUsedWords_ShouldBeOk()
        {
            string text = "O Teste é Muito importante, por isso teste a aplicação";
            var words = _page.GetTenMostUsedWords(text);

            _page.Should().NotBeNull();
            words.Should().NotBeEmpty();
            words.Should().HaveCount(6);
            words[0].word.Should().Be("teste");
            words[0].Occurrences.Should().Be(2);
            words[1].word.Should().Be("muito");
            words[1].Occurrences.Should().Be(1);
        }

        [Test]
        public void Test_Page_GetTenMostUsedWords_WithLink_ShouldBeOk()
        {
            _page = ObjectMother.GetNewValidPage();

            var document = _page.LoadUrl(_page.Url);
            var words = _page.GetAllWords(document);
            var tenWords = _page.GetTenMostUsedWords(words);

            _page.Should().NotBeNull();
            words.Should().NotBeEmpty();
            tenWords.Should().NotBeEmpty();
            tenWords.Should().HaveCount(10);
        }

        [Test]
        public void Test_Page_GetTenMostUsedWords_ThrowException()
        {
            string text = "";
            Action comparation = () => _page.GetTenMostUsedWords(text);
            comparation.Should().Throw<PageWordsListUninformedException>();
        }

        [Test]
        public void Test_Page_PageEmpty_ThrowException()
        {
            _page = ObjectMother.GetNewEmptyPage();
            string text = "";
            Action comparation = () => _page.Validate();
            comparation.Should().Throw<PageUrlUninformedException>();
        }
    }
}