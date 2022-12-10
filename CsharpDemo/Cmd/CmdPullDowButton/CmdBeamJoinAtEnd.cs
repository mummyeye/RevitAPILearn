using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("梁端点连接")]
    [Transaction(TransactionMode.Manual)]
    public class CmdBeamJoinAtEnd : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var beams = doc.OfClass<FamilyInstance>(BuiltInCategory.OST_StructuralFraming);
            doc.Transaction(t =>
            {
                foreach (var beam in beams)
                {
                    StructuralFramingUtils.DisallowJoinAtEnd(beam, 0);
                    StructuralFramingUtils.DisallowJoinAtEnd(beam, 1);
                    //StructuralFramingUtils.AllowJoinAtEnd(beam, 0);
                    //StructuralFramingUtils.AllowJoinAtEnd(beam, 1);
                }
            }, "梁端点连接");
        }
    }
}
