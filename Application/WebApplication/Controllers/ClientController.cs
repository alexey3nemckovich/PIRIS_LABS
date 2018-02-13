using System;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using WebApplication.Models.ViewModels;
using BL.Services.Client;
using Microsoft.Practices.Unity;
using WebApplication.Infrastructure;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace WebApplication.Controllers
{
    public class ClientController : Controller
    {
        [Dependency]
        public IClientService ClientService { get; set; }

        public IMapper Mapper { get; set; }

        public ClientController()
        {
            Mapper = MappingRegistrar.CreareMapper();
        }

        // GET: Client
        public ActionResult Index()
        {
            var clients = ClientService.GetAll();
            return View(clients.Select(e => e.ToClient(ClientService)));
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            var client = ClientService.Get(id);
            return View(client.ToClient(ClientService));
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View(new Client().ToClient(ClientService));
        }

        // POST: Client/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var model = ClientService.Add(client.ToClientModel(ClientService));
                    return RedirectToAction("Details", new {id = model.Id});
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(Mapper.Map<Client, Client>(client));
                }
            }
            return View(Mapper.Map<Client, Client>(client));
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int id)
        {
            var client = ClientService.Get(id);
            return View(client.ToClient(ClientService));
        }

        // POST: Client/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ClientService.Update(client.ToClientModel(ClientService));
                    return RedirectToAction("Details", new {id = client.Id});
                }
                catch (ValidationException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(Mapper.Map<Client, Client>(client));
                }
                catch(Exception)
                {
                    return View("Error");
                }
            }
            return View(client.ToClient(ClientService));
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            var client = ClientService.Get(id);
            return View(client.ToClient(ClientService));
        }

        // POST: Client/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                ClientService.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
