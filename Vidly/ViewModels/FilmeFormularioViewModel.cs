using System;
using Vidly.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
    public class FilmeFormularioViewModel
    {
        public IEnumerable<Genero> Generos { get; set; }

        public int? Id { get; set; }

        [Required, StringLength(255)]
        public string Nome { get; set; }

        [Required, Display(Name = "Gênero")]
        public int? GeneroId { get; set; }

        [Required, Display(Name = "Data de Lançamento")]
        public DateTime? DataDeLancamento { get; set; }

        [Required, Display(Name = "Número em Estoque"), Range(1, 20)]
        public int? NumeroEmEstoque { get; set; }

        public string Titulo => Id != 0 ? "Editar Filme" : "Novo Filme";

        public FilmeFormularioViewModel()
        {
            Id = 0;
        }

        public FilmeFormularioViewModel(Filme filme)
        {
            Id = filme.Id;
            Nome = filme.Nome;
            DataDeLancamento = filme.DataDeLancamento;
            NumeroEmEstoque = filme.NumeroEmEstoque;
            GeneroId = filme.GeneroId;
        }
    }
}