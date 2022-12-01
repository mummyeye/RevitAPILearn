using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.IO;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("链接DWG")]
    [Transaction(TransactionMode.Manual)]
    public class CmdLinkDwg : RevitCommand
    {
        public override void Action()
        {
            //  Autodesk.Revit.DB.Document.Link Method (String, DWGImportOptions, View, ElementId)
            var res = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "dwg files|*.dwg",
                Multiselect = true
            };
            if (res.ShowDialog().Value)
            {
                var opt = new DWGImportOptions()
                {
                    Unit = ImportUnit.Millimeter
                };
                var doc = Uidoc.Document;
                var planViews = doc.OfClass<ViewPlan>(BuiltInCategory.OST_Views).Where(o => !o.IsTemplate).ToList();
                doc.Transaction(t =>
                {
                    foreach (var file in res.FileNames)
                    {
                        var filename = Path.GetFileNameWithoutExtension(file);
                        var view = planViews.FirstOrDefault(o => filename.Contains(o.Name));
                        if (view != null)
                        {
                            doc.Link(file, opt, view, out _);
                        }
                    }

                }, "链接图纸");
            }
        }
    }
}
