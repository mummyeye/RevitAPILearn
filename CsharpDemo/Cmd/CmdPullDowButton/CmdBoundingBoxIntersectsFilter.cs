using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Xml("Box过滤器")]
    [Transaction(TransactionMode.Manual)]
    public class CmdBoundingBoxIntersectsFilter : RevitCommand
    {
        public override void Action()
        {
            // 	Autodesk.Revit.DB.BoundingBoxIntersectsFilter Constructor (Outline)
            var doc = Uidoc.Document;
            var sel = Uidoc.Selection;
            var r = sel.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element,
                doc.FilterElement(o => o is Floor));
            var floor = r.GetElement(doc) as Floor;
            var walls = doc.TBoundingBoxIntersectsFilter<Wall>(floor, BuiltInCategory.OST_Walls);
            doc.Transaction(t => walls.ForEach(w => JoinTwoElement(doc, floor, w)), "自动连接");
        }

        /// <summary>
        /// 两个对象进行连接
        /// </summary>
        /// <param name="eleA">对象A 主要</param>
        /// <param name="eleB">对象B 次要</param>
        /// <returns>是否成功连接</returns>
        public bool JoinTwoElement(Document doc, Element eleA, Element eleB)
        {
            if (JoinGeometryUtils.AreElementsJoined(doc, eleA, eleB))
            {
                if (!JoinGeometryUtils.IsCuttingElementInJoin(doc, eleA, eleB))
                {
                    JoinGeometryUtils.SwitchJoinOrder(doc, eleA, eleB);
                    return true;
                }
            }
            else
            {
                JoinGeometryUtils.JoinGeometry(doc, eleA, eleB);
                if (!JoinGeometryUtils.IsCuttingElementInJoin(doc, eleA, eleB))
                {
                    JoinGeometryUtils.SwitchJoinOrder(doc, eleA, eleB);
                }
                return true;
            }
            return false;
        }
    }
}
