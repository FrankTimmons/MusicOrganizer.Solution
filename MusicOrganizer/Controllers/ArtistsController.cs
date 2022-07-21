using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class ArtistsController : Controller
  {

    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Artist.GetAll();
      return View(allArtists);
    }

    [HttpGet("/artists/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/artists")]
    public ActionResult Create(string artistName)
    {
      Artist newArtist = new Artist(artistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Song> artistSongs = selectedArtist.Songs;
      model.Add("artist", selectedArtist);
      model.Add("songs", artistSongs);
      return View(model);
    }


    // This one creates new Items within a given Category, not new Categories:

    [HttpPost("/artists/{artistId}/songs")]
    public ActionResult Create(int artistId, string songName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist foundArtist = Artist.Find(artistId);
      Song newSong = new Song(songName);
      foundArtist.AddSong(newSong);
      List<Song> artistSongs = foundArtist.Songs;
      model.Add("songs", artistSongs);
      model.Add("artist", foundArtist);
      return View("Show", model);
    }
  }
}