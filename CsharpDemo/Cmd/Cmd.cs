using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CsharpDemo.Cmd
{
    [Xml("自动链接管道系统")]
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var groupPipes = doc.OfClass<Pipe>(doc.ActiveView)
                .GroupBy(o => o.MEPSystem.GetTypeId());
            if (groupPipes.Any())
            {
                doc.Transaction(t =>
                {
                    foreach (var item in groupPipes)
                    {
                        var pipes = item.ToList();
                        foreach (var pipe in pipes)
                        {
                            var connectors = pipe.GetUnusedConnectors();
                            foreach (var connector1 in connectors)
                            {
                                var connector2 = GetMinDistnaceConnector(connector1, pipes);
                                if (connector2 != null)
                                {
                                    doc.Create.NewElbowFitting(connector1, connector2);
                                }
                            }
                        }
                    }
                }, "自动链接管道系统");
            }
        }

        /// <summary>
        /// 获取同系统管线最近的管线连接件
        /// </summary>
        /// <param name="connector1"></param>
        /// <param name="pipes"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        private Connector GetMinDistnaceConnector(Connector connector1, List<Pipe> pipes, double s = 0.5)
        {
            var connector2 = default(Connector);
            var mindist = (connector1.Owner.Location as LocationCurve).Curve.Length * s;
            foreach (var item in pipes)
            {
                if (item.Id == connector1.Owner.Id) continue;
                var conns = item.GetUnusedConnectors();
                foreach (var connector in conns)
                {
                    var distance = connector.Origin.DistanceTo(connector1.Origin);
                    if (distance < mindist)
                    {
                        mindist = distance;
                        connector2 = connector;
                    }
                }
            }
            return connector2;
        }
    }
}
