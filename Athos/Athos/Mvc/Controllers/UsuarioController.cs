using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Mvc.Models;
namespace Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            IEnumerable<mvcUsuarioModel> usuList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Usuario").Result;
            usuList = response.Content.ReadAsAsync<IEnumerable<mvcUsuarioModel>>().Result;
            return View(usuList);

        }


        public ActionResult AddOrEdit(int id)
        {
            if (id == 0)
                return View(new mvcUsuarioModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Usuario/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcUsuarioModel>().Result);
            }
        }

        

        [HttpPost] //POST
        public ActionResult AddOrEdit(mvcUsuarioModel usuario)
        {
            if (usuario.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Usuario", usuario).Result;
                TempData["SuccessMessage"] = "Usuário Salvo";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Usuario/" + usuario.Id, usuario).Result;
                TempData["SuccessMessage"] = "Alteração Realizada";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Usuario/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Usuário Deletado";
            return RedirectToAction("Index");
        }
    }
}