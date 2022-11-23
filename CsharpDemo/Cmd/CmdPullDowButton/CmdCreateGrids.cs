using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Transaction(TransactionMode.Manual)]
    public class CmdCreateGrids : IExternalCommand
    {
        [Xml("创建轴网")]
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;
            var p0 = XYZ.Zero;
            doc.Transaction(t =>
            {
                var p1 = new XYZ(30000 / 304.8, 0, 0);
                for (int i = 0; i < 10; i++)
                {
                    var di = XYZ.BasisY * i * 3000 / 304.8;
                    var line = Line.CreateBound(p0 + di, p1 + di);
                    var g = Grid.Create(doc, line);
                    g.Name = "1";
                }
                var p2 = new XYZ(0, 30000 / 304.8, 0);
                for (int i = 0; i < 10; i++)
                {
                    var di = XYZ.BasisX * i * 3000 / 304.8;
                    var line = Line.CreateBound(p0 + di, p2 + di);
                    var g = Grid.Create(doc, line);
                    g.Name = "A";
                }
            }, "Csharp grid");
            return Result.Succeeded;
        }
    }
}
