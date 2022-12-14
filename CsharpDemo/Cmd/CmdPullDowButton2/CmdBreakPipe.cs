using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("打断管线")]
    [Transaction(TransactionMode.Manual)]
    public class CmdBreakPipe : RevitCommand
    {
        public override void Action()
        {
            //PlumbingUtils.BreakCurve
            var doc = Uidoc.Document;
            var sel = Uidoc.Selection;
            var center = default(XYZ);
            doc.Transaction(t =>
            {
                var ref1 = sel.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, doc.FilterElement(e => e is Pipe));
                var pipe1 = doc.GetElement(ref1) as Pipe;
                var p1Id = PlumbingUtils.BreakCurve(doc, pipe1.Id, ref1.GlobalPoint);
            });
        }
    }
}
