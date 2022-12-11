using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System.Linq;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("墙端部连接")]
    [Transaction(TransactionMode.Manual)]
    class CmdWallJoinAt : RevitCommand
    {
        public override void Action()
        {
            var doc = Uidoc.Document;
            var walls = doc.OfClass<Wall>(doc.ActiveView);
            if (walls.Any())
            {
                doc.Transaction(t =>
                {
                    foreach (var item in walls)
                    {
                        JoinAt(item, 0);
                        JoinAt(item, 1);
                    }
                }, "墙端部连接");
            }
        }

        /// <summary>
        /// 反转墙端部连接属性
        /// </summary>
        /// <param name="wall"></param>
        /// <param name="index"></param>
        private void JoinAt(Wall wall, int index)
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
