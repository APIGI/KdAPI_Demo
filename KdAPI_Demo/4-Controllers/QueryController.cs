using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using KdAPI_Demo._1_Interfaces;
using KdAPI_Demo._3_Models;
using KdAPI_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KdAPI_Demo.Controllers
{
	/// <summary>
	/// 查询类接口
	/// </summary>
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class QueryController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public QueryController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		/// <summary>
		/// 即时查询
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<OperationResult> Immediately(string expressNumber,string expressCode,string sfNumber)
		{
			OperationResult result = new OperationResult
			{
				result = await _orderService.getOrderTracesByJson(expressNumber, expressCode, sfNumber)
			};
			return result;
		}
	}
}
