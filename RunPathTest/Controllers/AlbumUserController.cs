using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Runpath.services.Interfaces;

namespace RunPathTest.Controllers
{
    [Route("api/[controller]")]
    public class AlbumUserController : Controller
    {
        private IAlbumService _albumService;

        public AlbumUserController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet]
        public string Get()
        {
            return "ok";
        }
        // GET api/albumUser/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(_albumService.GetAlbumByUser(id));
        }

    }
}
