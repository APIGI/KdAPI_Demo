# .Net Core Project By [快递鸟API_Demo](https://github.com/XiaoYong666/KdAPI_Demo)

# 项目描述
KdAPI_Demo 旨在快速对接[快递鸟](http://kdapi.kdniao.com?from=kxzxy)平台各类物流接口，方便调试使用。

## Others
> 项目演示：[在线演示](http://kdn.fuyue.xyz/)  
> 项目教程：[教程](https://www.cnblogs.com/zhangxiaoyong/p/13889901.html)  
> 快递鸟官网：[快递鸟官网](http://kdapi.kdniao.com?from=kxzxy)  
> 快递鸟API接口文档：[API接口文档](http://www.kdniao.com/api-all?from=kxzxy&st=1)  
> 快递鸟官方Demo下载：[官方Demo](http://www.kdniao.com/documents-demo)  

##  Getting started

```
# git clone https://github.com/kuaidi100-api/.net-demo.git
```


#  Use Junit Test
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
namespace KdGoldAPI
{
public  class  KdApiSearchDemo
{
//电商ID
private  string EBusinessID =  "1237100";

//电商加密私钥，快递鸟提供，注意保管，不要泄漏
private  string AppKey =  "518a73d8-1f7f-441a-b644-33e77b49d846";

//请求url
private  string ReqURL =  "https://api.kdniao.cc/Ebusiness/EbusinessOrderHandle.aspx";

  

/// <summary>
/// Json方式 查询订单物流轨迹
/// </summary>
/// <returns></returns>
public  string  getOrderTracesByJson()
{
	string requestData =  "{'OrderCode':'','ShipperCode':'SF','LogisticCode':'589707398027'}";
	Dictionary<string,  string> param = new Dictionary<string,  string>();
	param.Add("RequestData", HttpUtility.UrlEncode(requestData, Encoding.UTF8));
	param.Add("EBusinessID", EBusinessID);
	param.Add("RequestType",  "1002");
	string dataSign =  encrypt(requestData, AppKey,  "UTF-8");
	param.Add("DataSign", HttpUtility.UrlEncode(dataSign, Encoding.UTF8));
	param.Add("DataType",  "2");
	string result =  sendPost(ReqURL, param);

	//根据公司业务处理返回的信息......
	result;
}

 /// <summary>
/// Post方式提交数据，返回网页的源代码
/// </summary>
/// <param  name="url">发送请求的 URL</param>
/// <param  name="param">请求的参数集合</param>
/// <returns>远程资源的响应结果</returns>
private  string  sendPost(string url,  Dictionary<string,  string> param)
{
	string result =  "";
	StringBuilder postData = new StringBuilder();
	if  (param !=  null  && param.Count >  0)
	{
	foreach  (var p in param)
	{
	if  (postData.Length >  0)
	{
	postData.Append("&");
	}
	
	postData.Append(p.Key);
	postData.Append("=");
	postData.Append(p.Value);
	}
	}
	
	byte[] byteData = Encoding.GetEncoding("UTF-8").GetBytes(postData.ToString());
	try
	{  
	HttpWebRequest request =  (HttpWebRequest)WebRequest.Create(url);
	request.ContentType =  "application/x-www-form-urlencoded";
	request.Referer = url;
	request.Accept =  "*/*";
	request.Timeout =  30  *  1000;
	request.UserAgent =  "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)";
	request.Method =  "POST";
	request.ContentLength = byteData.Length;
	Stream stream = request.GetRequestStream();
	stream.Write(byteData,  0, byteData.Length);
	stream.Flush();
	stream.Close();
	HttpWebResponse response =  (HttpWebResponse)request.GetResponse();
	Stream backStream = response.GetResponseStream();
	StreamReader sr = new StreamReader(backStream, Encoding.GetEncoding("UTF-8"));
	result = sr.ReadToEnd();
	sr.Close();
	backStream.Close();
	response.Close();
	request.Abort();
	}
	catch  (Exception ex)
	{
	result = ex.Message;
	}
	return result;
}
///<summary>
///电商Sign签名
///</summary>
///<param  name="content">内容</param>
///<param  name="keyValue">Appkey</param>
///<param  name="charset">URL编码 </param>
///<returns>DataSign签名</returns>
private  string  encrypt(String content,  String keyValue,  String charset)
{
	if(keyValue !=  null)
	{
		return  base64(MD5(content + keyValue, charset), charset);
	}
		return  base64(MD5(content, charset), charset);
}
///<summary>
/// 字符串MD5加密
///</summary>
///<param  name="str">要加密的字符串</param>
///<param  name="charset">编码方式</param>
///<returns>密文</returns>
private  string  MD5(string str,  string charset)
{
  byte[] buffer = System.Text.Encoding.GetEncoding(charset).GetBytes(str);
try
{
  System.Security.Cryptography.MD5CryptoServiceProvider check;
  check = new System.Security.Cryptography.MD5CryptoServiceProvider();
  byte[] somme = check.ComputeHash(buffer);
  string ret =  "";
  foreach  (byte a in somme)
  {
     if  (a <  16)
       ret +=  "0"  + a.ToString("X");
     else
       ret += a.ToString("X");
  }
   return ret.ToLower();
}
catch
  {
   throw;
  }
}

/// <summary>
/// base64编码
/// </summary>
/// <param  name="str">内容</param>
/// <param  name="charset">编码方式</param>
/// <returns></returns>
  private  string  base64(String str,  String charset)
  {
	return Convert.ToBase64String(System.Text.Encoding.GetEncoding(charset).GetBytes(str));
    }
  }
}
```
    

