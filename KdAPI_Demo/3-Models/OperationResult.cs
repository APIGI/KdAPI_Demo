using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KdAPI_Demo.Models
{
	public class OperationResult
	{
		/// <summary>
		/// 默认操作成功
		/// </summary>
		public OperationResult()
		{
			IsSuccess = true;
		}

		/// <summary>
		/// 以操作失败信息实例操作结果
		/// </summary>
		/// <param name="failMessage">操作失败信息</param>
		public OperationResult(string failMessage)
		{
			IsSuccess = false;
			FailMessage = failMessage;
		}

		/// <summary>
		/// 业务操作是否成功
		/// </summary>
		public bool IsSuccess
		{
			set;
			get;
		}

		/// <summary>
		/// 业务如果操作失败，失败信息
		/// </summary>
		public string FailMessage
		{
			get;
			set;
		}

		/// <summary>
		/// 业务操作返回的额外数据
		/// </summary>
		public object result { set; get; }
	}
}
