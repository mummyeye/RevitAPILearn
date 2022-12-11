using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("梁端部不允许连接")]
    [Transaction(TransactionMode.Manual)]
    public class CmdBeamJoinAtEnd : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var beams = doc.OfClass<FamilyInstance>(doc.ActiveView);
            if (beams.Any())
            {
                doc.Transaction(t =>
                {
                    foreach (var item in beams)
                    {
                        StructuralFramingUtils.DisallowJoinAtEnd(item, 0);
                        StructuralFramingUtils.DisallowJoinAtEnd(item, 1);
                    }
                }, "梁端部不允许连接");
            }
        }
    }
}
