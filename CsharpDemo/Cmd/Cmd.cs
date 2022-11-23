using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd
{
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        {
            Uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element);
            throw new System.Exception();
        }
    }
}
