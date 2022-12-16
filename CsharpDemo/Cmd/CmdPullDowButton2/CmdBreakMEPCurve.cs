using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("打断管线")]
    [Transaction(TransactionMode.Manual)]
    public class CmdBreakMEPCurve : RevitCommand
    {
        public override void Action()
        {
            //PlumbingUtils.BreakCurve
            //MechanicalUtils.BreakCurve
            var doc = Uidoc.Document;
            var sel = Uidoc.Selection;
            var p0 = sel.PickPoint();
            var p1 = sel.PickPoint();
            var line = Line.CreateBound(p0, p1).Faltten();
            var meps = doc.OfClass<MEPCurve>(doc.ActiveView).Where(o => o is Pipe || o is Duct).ToList();
            doc.Transaction(t =>
            {
                foreach (var mep in meps)
                {
                    var mepLine = (mep.Location as LocationCurve).Curve as Line;
                    var result = mepLine.Faltten().Intersect(line, out var resultArray);
                    if (result == SetComparisonResult.Overlap)
                    {
                        var pnt = mepLine.Project(resultArray.get_Item(0).XYZPoint).XYZPoint;
                        if (mep is Pipe)
                        {
                            PlumbingUtils.BreakCurve(doc, mep.Id, pnt);
                        }
                        else if (mep is Duct)
                        {
                            MechanicalUtils.BreakCurve(doc, mep.Id, pnt);
                        }
                    }
                }
            }, "打断管线");
        }
    }
}
