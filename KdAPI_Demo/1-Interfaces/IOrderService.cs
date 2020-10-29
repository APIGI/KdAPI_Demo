using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KdAPI_Demo._3_Models;
using KdAPI_Demo._6_Common.Enums;

namespace KdAPI_Demo._1_Interfaces
{
	public interface IOrderService
	{
		Task<string> getOrderTracesByJson(string expressNumber, string expressCode,string sfNumber, QueryType queryType = QueryType.MonitorQuery);

		Task<RecognitionModel> getExpressCompany(string expressNumber);
	}
}
