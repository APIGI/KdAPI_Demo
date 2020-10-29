using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using KdAPI_Demo._1_Interfaces;
using KdAPI_Demo.Model;
using KdAPI_Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static KdAPI_Demo.Extensions.ConfigurationExtension;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace KdAPI_Demo.Controllers
{
	/// <summary>
	/// 下单类接口
	/// </summary>
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

	}
}
