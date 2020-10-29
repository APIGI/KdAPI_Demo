using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KdAPI_Demo._1_Interfaces;
using KdAPI_Demo._3_Models;
using KdAPI_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KdAPI_Demo.Controllers
{
	/// <summary>
	/// 增值类接口
	/// </summary>
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class AppreciationController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public AppreciationController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		/// <summary>
		/// 自动识别快递单号
		/// </summary>
		/// <param name="expressNumber"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<RecognitionModel> GetExpressCompany(string expressNumber)
		{
			
			if (string.IsNullOrEmpty(expressNumber))
			{
				return new RecognitionModel();
			}
			
			return await _orderService.getExpressCompany(expressNumber); ;
		}
	}
}
