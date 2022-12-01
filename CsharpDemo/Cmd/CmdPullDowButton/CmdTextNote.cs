using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Reflection;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("文字注释")]
    [Transaction(TransactionMode.Manual)]
    public class CmdTextNote : RevitCommand
    {
        public override void Action()
        {
            // 	Autodesk.Revit.DB.TextNote.Create(Document, ElementId, XYZ, String, ElementId)
            var doc = Uidoc.Document;
            var pnt = Uidoc.Selection.PickPoint("请点击创建文字的定位点");
            doc.Transaction(t =>
            {
                var text = "都让开,我要学习API了";
                var deftypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
                var textNote = TextNote.Create(doc, doc.ActiveView.Id, pnt, text, deftypeId);
            }, typeof(CmdTextNote).GetCustomAttribute<XmlAttribute>().Name);
        }
    }
}
