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
    [Xml("自动连管")]
    [Transaction(TransactionMode.Manual)]
    public class CmdElbowFitting : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var groups = doc.OfClass<Pipe>(doc.ActiveView).GroupBy(o => o.MEPSystem.GetTypeId());
            doc.Transaction(t =>
            {
                foreach (var g in groups)
                {
                    var pipes = g.ToList();
                    foreach (var pipe in pipes)
                    {
                        var connectors = pipe.GetUnusedConnectors();
                        foreach (var connector in connectors)
                        {
                            LinkConnector(connector, pipes);
                        }
                    }
                }
            }, "自动连管");
        }

        /// <summary>
        /// 连接管线
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="pipes"></param>
        /// <param name="i"> 相对距离系数和自身长度有关</param>
        private void LinkConnector(Connector connector, List<Pipe> pipes, double i = 0.35)
        {
            var connector2 = default(Connector);
            var mindistance = (connector.Owner.Location as LocationCurve).Curve.Length * i;
            foreach (var item in pipes)
            {
                if (item.Id == connector.Owner.Id) continue;
                var connectors = item.GetUnusedConnectors();
                foreach (var conn in connectors)
                {
                    var dist = conn.Origin.DistanceTo(connector.Origin);
                    if (dist < mindistance)
                    {
                        mindistance = dist;
                        connector2 = conn;
                    }
                }
            }
            if (connector2 != null)
            {
                connector.Owner.Document.Create.NewElbowFitting(connector, connector2);
            }
        }
    }
}
