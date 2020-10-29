using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using KdAPI_Demo._3_Models;

namespace KdAPI_Demo._6_Common
{
    /// <summary>
    /// 枚举辅助类
    /// </summary>
    public static class EnmHelper
    {
        /// <summary>
        /// 获取枚举值的描述
        /// </summary>
        /// <param name="sourceValue"></param>
        /// <returns></returns>
        public static string GetEnmName(this Enum sourceValue)
        {
            DisplayAttribute[] attributes = null;
            if (sourceValue != null)
            {
                FieldInfo field = sourceValue.GetType().GetField(sourceValue.ToString());
                if (field != null)
                {
                    attributes = field.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                }
            }
            if (attributes == null || attributes.Length < 1) return sourceValue.ToString();
            return attributes[0].Name;
        }

        /// <summary>
        /// 获取枚举集合列表
        /// </summary>
        /// <param name="enmType"></param>
        /// <returns></returns>
        public static List<ModItem> GetEnmList(this Type enmType)
        {
            List<EnmItem> result = new List<EnmItem>();
            Array array = Enum.GetValues(enmType);
            foreach (var item in array)
            {
                DisplayAttribute[] attributes = (DisplayAttribute[])item.GetType().GetField(item.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false);
                EnmItem enmItem = new EnmItem();
                if (attributes.Length > 0)
                {
                    enmItem.Name = attributes[0].Name;
                    enmItem.Value = Convert.ToInt32(item).ToString();
                    enmItem.OrderIndex = attributes[0].GetOrder().GetValueOrDefault(0);
                    result.Add(enmItem);
                }
            }
            return result.OrderBy(x => x.OrderIndex).Select(x => x as ModItem).ToList();
        }

        /// <summary>
        /// 把字符串转换为枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T ConvertToEnm<T>(this string source)
        {
            return (T)ConvertToEnm(source, typeof(T));
        }

        /// <summary>
        /// 把字符串转换为枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static object ConvertToEnm(this string source, Type enmType)
        {
            ModItem mod = enmType.GetEnmList().FirstOrDefault(x => x.Name == source);
            if (mod != null)
            {
                source = mod.Value;
            }
            return Enum.Parse(enmType, source);
        }
    }

    class EnmItem : ModItem
    {
        public int OrderIndex { set; get; }
    }
}
