using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace systemProjection.Data
{
	public class ContratoItem
	{
		public int Id { get; set; }
		public int IdContrato { get; set; }
		public int IdProduto { get; set; }
		public double ValorHonorario { get; set; }

	}
}
