using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace systemProjection.Data
{
	public class Usuario
	{
		public int Id { get; set; }
		public int IdPessoa { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string Setor { get; set; }
		public int Permissao { get; set; }
	}
}
