using PagedList;
using ProjectBancoItau.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectBancoItau.MVC.Controllers
{
    public class RelatoriosController : Controller
    {/*
        // GET: Relatorios
        public ActionResult RelatorioExtrato(int? pagina, Boolean? pdf, PagedList<ClienteContaTransLogTransViewModel> clienteContaTransLogTransViewModel)
        {
            if (pdf != true)
            {
                int numeroRegistros = 3;
                int numeroPagina = (pagina ?? 1);
                return View(clienteContaTransLogTransViewModel.ToPagedList(numeroPagina, numeroRegistros));
            }
            else
            {
                int pagNumero = 1;

                var relatorioPDF = new ViewAsPdf
                {
                    ViewName = "EXTRATO",
                    IsGrayScale = true,
                    Model = clienteContaTransLogTransViewModel.ToPagedList(pagNumero, clienteContaTransLogTransViewModel.coi)
                };
                return relatorioPDF;
            }
        }*/
    }
}