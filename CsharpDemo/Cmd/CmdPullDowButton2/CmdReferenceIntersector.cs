using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd.CmdPullDowButton2
{
    [Xml("射线查找")]
    [Transaction(TransactionMode.Manual)]
    public class CmdReferenceIntersector : RevitCommand
    {
        public override void Action()
        {
            if (!(Uidoc.ActiveGraphicalView is View3D view3D))
            {
                XmlDoc.Print("请打开三维视图运行功能");
                return;
            }
            var filter = new ElementClassFilter(typeof(Floor));
            var referenceIntersector = new ReferenceIntersector(filter, FindReferenceTarget.Face, view3D);
            var beams = Doc.OfClass<FamilyInstance>(BuiltInCategory.OST_StructuralFraming);
            Doc.Transaction(t =>
            {
                foreach (var item in beams)
                {
                    SetBeamOffset(referenceIntersector, item, 0);
                    SetBeamOffset(referenceIntersector, item, 1);
                }
            }, "射线查找");
        }

        private void SetBeamOffset(ReferenceIntersector referenceIntersector, FamilyInstance beam, int index)
        {
            var curve = (beam.Location as LocationCurve).Curve;
            var origin = curve.GetEndPoint(index);
            var refer = referenceIntersector.FindNearest(origin, XYZ.BasisZ)?.GetReference();
            if (refer == null) return;
            var pnt = refer.GlobalPoint;
            var offset = pnt.Z - origin.Z;
            var parameterName = index == 0 ? "起点标高偏移" : "终点标高偏移";
            var p = beam.LookupParameter(parameterName);
            p?.Set(p.AsDouble() + offset);
        }

    }
}
