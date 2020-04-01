using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
	public class Response<T>
	{
		public int SatusCode { get; set; }
		public string Message { get; set; }
		public T Data { get; set; }
	}
}
