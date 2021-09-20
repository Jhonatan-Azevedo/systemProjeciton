using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace systemProjection.Data
{
	public class Pessoa
	{
		public int Id { get; set; }
		public string NomeRazaoSocial { get; set; }
		public string NomeFantasia { get; set; }
		public string CpfCnpj { get; set; }
		public char Tipo { get; set; }
		public string CelularTelefone { get; set; }
		public string Email { get; set; }
	}
}
