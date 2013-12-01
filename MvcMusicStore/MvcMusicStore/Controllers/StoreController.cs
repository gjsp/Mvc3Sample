using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
       MusicStoreEntities storeDB = new MusicStoreEntities();
        //
        // GET: /Store/
        public ActionResult Index()
        {
            //return "Hello from Store.Index()";

            //var genres = new List<Models.Genre>
            //{
            //    new Models.Genre{Name = "Rock"},
            //    new Models.Genre{Name = "ลูกทุง"},
            //    new Models.Genre{Name = "หมอลำ"}
            //};
            //return View(genres);
            var genres = storeDB.Genres.ToList();
            return View(genres);
        }
        //
        // GET: /Store/Browse
        public ActionResult Browse(string genre)
        {
            //string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
            //return message;


            //var genreModel = new Models.Genre { Name = genre };
            //return View(genreModel);

            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }
        //
        // GET: /Store/Details
        public ActionResult Details(int id)
        {
            //var album = new Album { Tetle = "Album" + id };
            //string msg ="store.Details, ID=" +  id;
            
            var album = new Models.Album { Title = "Ablum " + id };
            return View(album);
        }


    }
}
