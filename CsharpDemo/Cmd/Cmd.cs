using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd
{
    [Xml("创建图纸视图")]
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var titleBlockType = doc.OfClass<FamilySymbol>(BuiltInCategory.OST_TitleBlocks)
                .FirstOrDefault(o => o.Name.Contains("A1"));
            if (titleBlockType != null)
            {
                ViewSheet viewsheet = default;
                doc.Transaction(t =>
                {
                    viewsheet = ViewSheet.Create(doc, titleBlockType.Id);
                    viewsheet.Name = doc.ActiveView.Name;
                    var outline = viewsheet.Outline;
                    var center = (outline.Min.ToXYZ() + outline.Max.ToXYZ()) * 0.5;
                    Viewport.Create(doc, viewsheet.Id, doc.ActiveView.Id, center);
                }, "创建图纸视图");
                Uidoc.ActiveView = viewsheet;
            }
            else
            {
                XmlDoc.Print("图纸名称包含A1的类型不存在");
            }
        }
    }
}
