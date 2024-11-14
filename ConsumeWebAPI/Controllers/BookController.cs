using ConsumeWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace ConsumeWebAPI.Controllers
{
    public class BookController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7080/api");
        private readonly HttpClient _client;

        public BookController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<BookViewModel> bookList = new List<BookViewModel>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/Get").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                bookList = JsonConvert.DeserializeObject<List<BookViewModel>>(data);
            }

            return View(bookList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Book/Post", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Livro Criado";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                BookViewModel book = new BookViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<BookViewModel>(data);
                }
                return View(book);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Book/Put", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }

            return View();


        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                BookViewModel book = new BookViewModel();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Book/Get/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content?.ReadAsStringAsync().Result;
                    book = JsonConvert.DeserializeObject<BookViewModel>(data);
                }

                return View(book);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Book/Delete/" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return View();
        }

    }
}
