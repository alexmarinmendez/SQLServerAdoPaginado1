using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebApplication1.Models;
using WebApplication1.Dao;

namespace WebApplication1.Controllers
{
    public class ClientesController : Controller
    {
        ClientesDao clientesDao = new ClientesDao();
        // GET: Clientes

        public ActionResult PaginadoClientes(int paginaActual = 1)
        {
            int totalRegistros = clientesDao.ListarClientes().Count();
            int cantidadPorPagina = 15;

            int cantidadPaginas = totalRegistros % cantidadPorPagina == 0
                                    ? totalRegistros / cantidadPorPagina
                                    : totalRegistros / cantidadPorPagina + 1;

            ViewBag.cantidadPaginas = cantidadPaginas;

            return View("ListadoClientes", clientesDao.ListarClientes()
                            .Skip(cantidadPorPagina * (paginaActual-1))
                            .Take(cantidadPorPagina));
        }
    }
}