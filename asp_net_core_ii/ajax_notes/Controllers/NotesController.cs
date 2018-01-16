using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DbConnection;
using System.Text.RegularExpressions;

namespace ajax_notes.Controllers
{
    public class NotesController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Notes = DbConnection.DbConnector.Query("SELECT * FROM `notes`;");
            return View();
        }

        [HttpPost]
        [Route("AddNote")]
        public IActionResult AddNote(string title)
        {
            if (title != null)
            {
                DbConnector.Execute($"INSERT INTO notes (title, description) VALUES ('{Regex.Escape(title)}', '');");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Delete")]
        public void DeleteNote(int id)
        {
            Console.WriteLine(DbConnector.Query($"SELECT * FROM notes WHERE id = {id}").Count > 0);
            DbConnector.Execute($"DELETE FROM notes WHERE id = {id}");
        }

        [HttpPost]
        [Route("Update")]
        public void Update(string field, string text, int id)
        {
            DbConnector.Execute($"UPDATE notes SET {field}='{Regex.Escape(text)}' WHERE id={id};");
            Console.WriteLine($"Successfully updated {field} for record {id}");
            // return RedirectToAction("Index");
        }
    }
}
