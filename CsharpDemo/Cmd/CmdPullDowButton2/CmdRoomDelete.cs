using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("清理房间")]
    [Transaction(TransactionMode.Manual)]
    public class CmdRoomDelete : RevitCommand
    {
        public override void Action()
        {
            // 已删除的房间 排除了未闭合的房间
            var ids = Doc.OfClass<SpatialElement>(BuiltInCategory.OST_Rooms).Cast<Room>()
                .Where(o => o.Area == 0 && o.UnboundedHeight == 0)
                .Select(o => o.Id).ToList();
            Doc.Transaction(t => Doc.Delete(ids), "清理房间");
        }
    }
}
