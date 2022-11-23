﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;
using CsharpDemo.Extension;
using CsharpDemo.Attributes;

namespace CsharpDemo.Cmd.CmdPullDowButton
{
    [Transaction(TransactionMode.Manual)]
    public class CmdCreateRoof : IExternalCommand
    {
        [Xml("幕墙屋顶")]
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;

            var level = doc.OfClass<Level>().FirstOrDefault(o => o.Name == "标高 1");
            var type = doc.OfClass<RoofType>().FirstOrDefault(o => o.Name == "常规 - 400mm");
            CurveArray curveArray = new CurveArray();
            var p0 = new XYZ(0, 0, 0);
            var p1 = new XYZ(5000 / 304.8, 0, 0);
            var p2 = new XYZ(5000 / 304.8, 5000 / 304.8, 0);
            var p3 = new XYZ(0, 5000 / 304.8, 0);
            var line1 = Line.CreateBound(p0, p1);
            var line2 = Line.CreateBound(p1, p2);
            var line3 = Line.CreateBound(p2, p3);
            var line4 = Line.CreateBound(p3, p0);
            curveArray.Append(line1);
            curveArray.Append(line2);
            curveArray.Append(line3);
            curveArray.Append(line4);
            doc.Transaction(t =>
            {
                ModelCurveArray footPrintToModelCurveMapping = new ModelCurveArray();
                doc.Create.NewFootPrintRoof(curveArray, level, type, out footPrintToModelCurveMapping);
            }, "c# roof");
            return Result.Succeeded;
        }
    }
}
