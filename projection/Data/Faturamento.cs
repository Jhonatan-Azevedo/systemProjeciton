using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace systemProjection.Data
{
	public class Faturamento
	{
		public int Id { get; set; }
		public int IdContrato { get; set; }
		public double valorCompesado { get; set; }
	}
}
