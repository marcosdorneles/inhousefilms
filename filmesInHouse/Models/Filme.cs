using System;
using System.ComponentModel.DataAnnotations;

namespace filmesInHouse.Models
{
	public class Filme
	{
		
		public int Id { get; set; }

		[Required(ErrorMessage ="Nome obrigatório")]
		[MaxLength(200, ErrorMessage ="o campo nome não pode exceder 200 caracteres")]
		public string Nome { get; set; }

		[Required(ErrorMessage ="O campo Diretor é obrigatório")]
		public string Diretor { get; set; }

		[Required(ErrorMessage ="O campo Genero é obrigatório")]
		public string Genero { get; set; }

		[Required(ErrorMessage ="O campo Duração é obrigatório")]
		public int Duracao { get; set; }
	}
}

