using CrystalDecisions.CrystalReports.Engine;
using Exercicio05.Data;
using Exercicio05.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Exercicio05.Controllers
{
    public class ProdutosController:Controller
    {
        private readonly FNDataContext _ctx = new FNDataContext();

        public ActionResult Index()
        {
            var produtos = _ctx.Produtos.ToList();
            return View(produtos);
        }

        [HttpGet]
        public ActionResult AddEdit(int? id)
        {
            var produto = new Produto();
            if (id != null)
            {
                produto = _ctx.Produtos.Find(id);
            }
            ViewBag.Tipo = _ctx.TiposDeProdutos.ToList();
            return View(produto);

        }

        [HttpPost]
        public ActionResult AddEdit(Produto produto)
        {
            if (produto.Id == 0)
            {
                _ctx.Produtos.Add(produto);
            }
            else
            {
                _ctx.Entry(produto).State = System.Data.Entity.EntityState.Modified;
            }
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletarProduto(int id)
        {
            var produto = _ctx.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            _ctx.Produtos.Remove(produto);
            _ctx.SaveChanges();
            return null;

        }

        public ActionResult GerarPdf()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "ProdutosReport.rpt"));
            rd.SetDataSource(_ctx.Produtos.ToList());

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            rd.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
            rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(5, 5, 5, 5));
            rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;

            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf");
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }
    }
}
