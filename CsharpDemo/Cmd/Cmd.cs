using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Utils;

namespace CsharpDemo.Cmd
{
    [Xml("test")]
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        {
            
        }
    }
}
