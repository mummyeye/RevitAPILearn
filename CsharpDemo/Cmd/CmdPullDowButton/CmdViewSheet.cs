using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("创建图纸")]
    [Transaction(TransactionMode.Manual)]
    public class CmdViewSheet : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var titleBlockTypeId = doc.OfClass<FamilySymbol>(BuiltInCategory.OST_TitleBlocks)
                .FirstOrDefault(o => o.Name.Contains("A1"));
            if (titleBlockTypeId == null)
            {
                XmlDoc.Print("获取A1图框类型失败");
                return;
            }
            doc.Transaction(t =>
            {
                var viewsheet = ViewSheet.Create(doc, titleBlockTypeId.Id);
                viewsheet.Name = doc.ActiveView.Name;
                var outline = viewsheet.Outline;
                var center = (outline.Min.ToXYZ() + outline.Max.ToXYZ()) * 0.5;
                Viewport.Create(doc, viewsheet.Id, doc.ActiveView.Id, center);
            }, "创建图纸");
        }
    }
}
