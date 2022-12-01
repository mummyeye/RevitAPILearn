using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpDemo.Cmd.CmdPullDowButton
{

    [Xml("详图线")]
    [Transaction(TransactionMode.Manual)]
    public class CmdDetailCurve : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            doc.Transaction(t =>
            {
                var p0 = new XYZ(0, 0, 0);
                var p1 = new XYZ(5000 / 304.8, 0, 0);
                var p2 = new XYZ(5000 / 304.8, 5000 / 304.8, 0);
                var p3 = new XYZ(0, 5000 / 304.8, 0);
                var line1 = Line.CreateBound(p0, p1);
                var line2 = Line.CreateBound(p1, p2);
                var line3 = Line.CreateBound(p2, p3);
                var line4 = Line.CreateBound(p3, p0);

                doc.Create.NewDetailCurve(doc.ActiveView, line1);
                doc.Create.NewDetailCurve(doc.ActiveView, line2);
                doc.Create.NewDetailCurve(doc.ActiveView, line3);
                doc.Create.NewDetailCurve(doc.ActiveView, line4);
            }, "详图线api");
        }
    }
}
