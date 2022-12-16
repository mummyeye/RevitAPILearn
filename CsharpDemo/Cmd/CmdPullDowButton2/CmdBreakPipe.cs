using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("打断管线")]
    [Transaction(TransactionMode.Manual)]
    public class CmdBreakPipe : RevitCommand
    {
        public override void Action()
        {
            //PlumbingUtils.BreakCurve

        }
    }
}
