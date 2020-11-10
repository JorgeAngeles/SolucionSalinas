using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
//using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net.Http.Headers;
using ML;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PL.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult GetAll()
        {
            ML.Result resultado = new ML.Result(); //BL.Usuario.GetAll();
            ML.Usuario usuario = new ML.Usuario();
            //usuario.Usuarios = new List<object>();
            //usuario.Usuarios = result.Objects;
            //return View(usuario);
            resultado.Objects = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44394/api/Usuario");

                var responseTask = client.GetAsync("Usuario");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Usuario resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Usuario>(resultItem.ToString());
                        resultado.Objects.Add(resultItemList);
                    }
                }

            }
            usuario.Usuarios = new List<Object>();
            usuario.Usuarios = resultado.Objects;
            // Sino devuelve null
            return View(usuario);
        }


        [HttpGet]
        public ActionResult Form(int? IdUsuario = 0)
        {
            ML.Usuario usuario = new ML.Usuario();
            if (IdUsuario == 0)
            {
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetById(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                    usuario.NombreUsuario = ((ML.Usuario)result.Object).NombreUsuario;
                    usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                    usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                    usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                    usuario.Edad = ((ML.Usuario)result.Object).Edad;
                    usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                    usuario.Email = ((ML.Usuario)result.Object).Email;

                }
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Success", usuario);
            else
                return View(usuario);
        }
        public ActionResult Success(ML.Usuario usuario)
        {
            ML.Result result = BL.Usuario.Add(usuario);

            return PartialView("ValidationModal");
        }
    }
}