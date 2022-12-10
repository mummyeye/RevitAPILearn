using Autodesk.Revit.DB;
using System.Collections.Generic;
using System.Linq;

namespace CsharpDemo.Extension
{
    public static class MEPCurveExtension
    {
        /// <summary>
        /// 获取管线全部连接器
        /// </summary>
        /// <param name="mepcurve"></param>
        /// <returns></returns>
        public static List<Connector> GetConnectors(this MEPCurve mepcurve)
        {
            return mepcurve.ConnectorManager.Connectors.Cast<Connector>().ToList();
        }

        /// <summary>
        /// 获取管线未使用的连接器
        /// </summary>
        /// <param name="mepcurve"></param>
        /// <returns></returns>
        public static List<Connector> GetUnusedConnectors(this MEPCurve mepcurve)
        {
            return mepcurve.ConnectorManager.UnusedConnectors.Cast<Connector>().ToList();
        }
    }
}
