using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Collections.Generic;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("批注云线")]
    [Transaction(TransactionMode.Manual)]
    public class CmdRevisionCloud : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var sel = Uidoc.Selection;
            while (true)
            {
                try
                {
                    var box = sel.PickBox(Autodesk.Revit.UI.Selection.PickBoxStyle.Directional, "框选云线范围");
                    doc.Transaction(t =>
                    {
                        var curves = new List<Curve>();
                        var p0 = box.Min;
                        var p1 = new XYZ(box.Min.X, box.Max.Y, box.Min.Z);
                        var p2 = box.Max;
                        var p3 = new XYZ(box.Max.X, box.Min.Y, box.Min.Z);
                        curves.Add(Line.CreateBound(p0, p1).CreateReversed());
                        curves.Add(Line.CreateBound(p1, p2).CreateReversed());
                        curves.Add(Line.CreateBound(p2, p3).CreateReversed());
                        curves.Add(Line.CreateBound(p3, p0).CreateReversed());
                        var revision = doc.OfClass<Revision>().FirstOrDefault();
                        RevisionCloud.Create(doc, doc.ActiveView, revision.Id, curves);
                    }, "批注云线");
                }
                catch
                {
                    break;
                }
            }
        }
    }
}
