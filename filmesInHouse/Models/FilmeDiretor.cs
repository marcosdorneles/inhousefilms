using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace filmesInHouse.Models
{
	public class FilmeDiretor
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey("Filme")]
		public int IdFilme { get; set; }

		[ForeignKey("Diretor")]
		public int IdDiretor { get; set; }

		public Diretor Diretor { get; set; }
		public Filme Filme { get; set; }
	}
}

