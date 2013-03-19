using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        //
        // GET: /Store/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public string Index()
        //{
        //    return "Hello from Store.Index()";
        //}

        public ActionResult Index()
        {
            //var genres = new List<Genre>
            //{
            //    new Genre {Name = "Disco"},
            //    new Genre {Name = "Jazz"},
            //    new Genre {Name = "Rock"}
            //};
            //return View(genres);

            var genres = storeDB.Genres.ToList();
            return View(genres);
        }

        ////
        //// GET: /Store/Browse
        //public string Browse()
        //{
        //    return "Hello from Store.Browse()";
        //}

        ////
        //// GET: /Store/Browse?genre=Disco
        //public string Browse(string genre)
        //{
        //    string message = HttpUtility.HtmlEncode("Store.Browse, Genre = " + genre);
        //    return message;
        //}

        public ActionResult Browse(string genre)
        {
            //var genreModel = new Genre { Name = genre };
            //return View(genreModel);

            // Retrieve Genre and its Associated Albums from database
            var genreModel = storeDB.Genres.Include("Albums")
            .Single(g => g.Name == genre);
            return View(genreModel);
        }



        ////
        //// GET: /Store/Details
        ////public string Details()
        ////{
        ////    return "Hello from Store.Details()";
        ////}
        ////
        //// GET: /Store/Details/5
        //public string Details(int id)
        //{
        //    string message = "Store.Details, ID = " + id;
        //    return message;
        //}


           // GET: /Store/Details/5
        public ActionResult  Details(int id)
        {
            //var album = new Album { Title = "Album " + id };
            //return View(album);

            var album = storeDB.Albums.Find(id);
            return View(album);
        }


        // GET: /Store/Test
        public string Test(int id)
        {
            string message = "Store.Test, ID = " + id;
            message += Environment.NewLine + "<h3>H3 string: abcdefghijklmnopqrstuvwxyz</h3>";

            return message;
        }

        // GET: /Store/TestAction
        public ActionResult TestAction( )
        {
            return View();
        }

    }
}
