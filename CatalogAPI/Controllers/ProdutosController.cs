﻿using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get() {
            try
            {
                var produtos = _context.Produtos.AsNoTracking().ToList();
                if (produtos is null)
                {
                    return NotFound("Produto não localizado...");
                }
                return produtos;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar sua solicitação");

            }
            
        }

        [HttpGet("{id:int}", Name = "ObterProduto")]

        public ActionResult<Produto> Get(int id) {
            try
            {
                var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
                if (produto is null)
                {
                    return NotFound("Id do produto não foi localizado...");
                }
                return produto;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                  "Ocorreu um problema ao tratar sua solicitação");

            }
            
        }

        [HttpPost]

        public ActionResult Post(Produto produto) {
            if (produto is null)
            {
                return BadRequest("Dados Invalidos");
            }

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto",
                new { id = produto.ProdutoId }, produto);
        }


        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Produto produto) {
            if (id != produto.ProdutoId)
            {
                return BadRequest("Dados Invalidos");
            }

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);


        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound($"Id {id} do produto não foi localizado...");
            }
            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return Ok(produto);

        }



    }
}
