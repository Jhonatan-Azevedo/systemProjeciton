using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace systemProjection.Data
{
	public class ContratoItemParceiro
	{
		public int Id { get; set; }
		public int IdContratoItem { get; set; }
		public int IdFaturamento { get; set; }
		public  double ValorPorcentagemDist { get; set; }
		public double ValorDistribudo { get; set; }
	}
}
