using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("导出图片")]
    [Transaction(TransactionMode.Manual)]
    public class CmdExportImage : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var opt = new ImageExportOptions();
            opt.FilePath = "F:\\CmdExportImage0.jpg";
            doc.ExportImage(opt);
            opt.FilePath = "F:\\CmdExportImage1.jpg";
            opt.Zoom = 100;
            opt.ZoomType = ZoomFitType.FitToPage;
            opt.PixelSize = 1920;
            opt.ImageResolution = ImageResolution.DPI_300;
            doc.ExportImage(opt);
        }
    }
}
