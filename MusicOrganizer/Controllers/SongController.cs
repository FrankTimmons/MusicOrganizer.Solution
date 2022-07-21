using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class SongController : Controller
  {

    [HttpGet("/artists/{artistId}/songs/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);
      return View(artist);
    }

    [HttpPost("/songs/delete")]
    public ActionResult DeleteAll()
    {
      Song.ClearAll();
      return View();
    }

    [HttpGet("/artists/{artistId}/songs/{songId}")]
    public ActionResult Show(int artistId, int songId)
    {
      Song song = Song.Find(songId);
      Artist artist = Artist.Find(artistId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("song", song);
      model.Add("artist", artist);
      return View(model);
    }
  }
}