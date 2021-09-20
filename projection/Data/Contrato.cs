using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace systemProjection.Data
{
	public class Contrato
	{
		public int Id { get; set; }
		public char Tipo { get; set; }
		public DateTime DtCadastro { get; set; }
		public DateTime DtAlteracao { get; set; }
		public DateTime DtEncerramento{ get; set; }
		public int Ativo { get; set; }
	}
}
