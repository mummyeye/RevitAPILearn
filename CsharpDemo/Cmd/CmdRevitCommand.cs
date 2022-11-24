using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd
{
    [Transaction(TransactionMode.Manual)]
    public class CmdRevitCommand : RevitCommand
    {
        [Xml("API教程")]
        public override void Action()
        {
            System.Diagnostics.Process.Start("https://space.bilibili.com/81888284/channel/collectiondetail?sid=805053");
        }
    }
}
