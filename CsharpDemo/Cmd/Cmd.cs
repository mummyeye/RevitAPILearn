using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd
{
    [Xml("墙端部连接")]
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;

        }
    }
}
