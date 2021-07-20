﻿using DesafioAltudo.Application.Features.Pages;
using DesafioAltudo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAltudo.API.Controllers
{
    [Produces("application/json;")]
    public class HomeController : Controller
    {
        private readonly IPageService _pageService;


        public HomeController(IPageService pageService)
        {
            _pageService = pageService;
        }


        [HttpPost]
        [Route("page")]
        public async Task<IActionResult> GetPage([FromBody] PageViewModel link)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState.Values.SelectMany(e => e.Errors));
                PageViewModel page = _pageService.GetPageDetails(link.Url);

                return Json(page);
            }
            catch (PageUrlUninformedException puu)
            {
                return Unauthorized(puu.Message);
            }
            catch (NotFoundException nfe)
            {
                return NotFound(nfe.Message);
            }
            catch (ArgumentNullException ane)
            {
                return BadRequest(ane.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
