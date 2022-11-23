using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using CsharpDemo.Extension;
using System.Windows;

namespace CsharpDemo.Cmd
{
    [Transaction(TransactionMode.Manual)]
    class Cmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var uidoc = commandData.Init();
            MessageBox.Show(uidoc.GetHashCode().ToString());
            return Result.Succeeded;
        }
    }
}
