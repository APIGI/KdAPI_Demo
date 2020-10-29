using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KdAPI_Demo._3_Models
{
	public class RecognitionModel
	{
		/// <summary>
		/// 用户Id
		/// </summary>
		public string EBusinessID { get; set; }

		/// <summary>
		/// 物流单号
		/// </summary>
		public string LogisticCode { get; set; }

		/// <summary>
		/// 成功与否
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// 失败原因
		/// </summary>
		public string Code { get; set; }

		/// <summary>
		/// 快递公司
		/// </summary>
		public List<_Shipper> Shippers { get; set; }
	}

	public class _Shipper
	{
		public string ShipperCode { get; set; }

		public string ShipperName { get; set; }
	}
}
