using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KdAPI_Demo._6_Common.Enums
{
	public enum QueryType
	{
		/// <summary>
		/// 快递查询
		/// </summary>
		[Display(Name = "快递查询")]
		ExpressQuery = 8002,

		/// <summary>
		/// 即时查询
		/// </summary>
		[Display(Name = "即时查询")]
		ImmediatelyQuery = 1002,

		/// <summary>
		/// 物流跟踪
		/// </summary>
		[Display(Name = "物流跟踪")]
		LogisticsTrackingQuery = 1008,

		/// <summary>
		/// 在途监控
		/// </summary>
		[Display(Name = "在途监控")]
		MonitorQuery = 8001,

		/// <summary>
		/// 单号识别
		/// </summary>
		[Display(Name = "单号识别")]
		ExpressRecognition = 2002
	}
}
