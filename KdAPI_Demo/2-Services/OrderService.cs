using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using KdAPI_Demo._1_Interfaces;
using KdAPI_Demo._3_Models;
using KdAPI_Demo._6_Common;
using KdAPI_Demo._6_Common.Enums;
using KdAPI_Demo.Model;
using Newtonsoft.Json;
using static KdAPI_Demo.Extensions.ConfigurationExtension;

namespace KdAPI_Demo._2_Services
{
	public class OrderService : IOrderService
	{
		/// <summary>
		/// 服务实现
		/// </summary>
		/// <returns></returns>
		public async Task<string> getOrderTracesByJson(string expressNumber, string expressCode,string sfNumber, QueryType queryType = QueryType.MonitorQuery)
		{
			var type = typeof(QueryType).GetEnmList().FirstOrDefault(m => m.Name == queryType.GetEnmName())?.Value;
			return await Task.Run(async () =>
			{
				string requestData = expressCode != "SF"
					? "{'OrderCode':'','ShipperCode':'" + expressCode + "','LogisticCode':'" + expressNumber + "'}"
					: "{'OrderCode':'','ShipperCode':'" + expressCode + "','LogisticCode':'" + expressNumber +
					  "','CustomerName':'" + sfNumber + "'}";
				
				var result = await BaseAction(requestData,type);
				return result;
			});
		}

		public async Task<RecognitionModel> getExpressCompany(string expressNumber)
		{
			string requestData = "{'LogisticCode':'"+expressNumber+"'}";
			var result= await BaseAction(requestData, ((int)QueryType.ExpressRecognition).ToString());
			return result == null ? new RecognitionModel() : JsonConvert.DeserializeObject<RecognitionModel>(result);
		}

		public async Task<string> BaseAction(string requestData,string type)
		{
			return await Task.Run(() =>
			{
				Dictionary<string, string> param = new Dictionary<string, string>
				{
					{"RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8)},
					{"EBusinessID", expressConfig.BusinessID},
					{"RequestType", type}
				};
				string dataSign = Encryption.encrypt(requestData, expressConfig.AppKey, "UTF-8");
				param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
				param.Add("DataType", "2");
				string result = HttpHelper.sendPost(apiConfig.Logistics_Trajectory_API, param);
				return result;
			});
		}
	}
}
