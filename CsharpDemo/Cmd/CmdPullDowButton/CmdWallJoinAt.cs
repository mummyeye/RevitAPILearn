using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("墙端点连接")]
    [Transaction(TransactionMode.Manual)]
    class CmdWallJoinAt : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var walls = doc.OfClass<Wall>();
            doc.Transaction(t =>
            {
                foreach (var wall in walls)
                {
                    JoinAt(wall, 0);
                    JoinAt(wall, 1);
                }
            }, "墙端点连接");
        }

        /// <summary>
        /// 墙端部连接状态
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="index"></param>
        private static void JoinAt(Wall wall, int index)
        {
            if (WallUtils.IsWallJoinAllowedAtEnd(wall, index))
            {
                WallUtils.DisallowWallJoinAtEnd(wall, index);
            }
            else
            {
                WallUtils.AllowWallJoinAtEnd(wall, index);
            }
        }
    }
}
