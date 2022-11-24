using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using CommunityToolkit.Mvvm.DependencyInjection;
using CsharpDemo.Utils;
using System.Text;
using System.Windows;

namespace CsharpDemo.Cmd
{
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        {
            var uidoc = Uidoc;
            var doc = Uidoc.Document;

            Reference r = uidoc.Selection.PickObject(ObjectType.Element);
            Element element = doc.GetElement(r);
            Element elementType = doc.GetElement(element.GetTypeId());
            Parameter parameter = element.get_Parameter(BuiltInParameter.ALL_MODEL_MARK);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Element Name:{element.Name}-ID:{element.Id}");
            sb.AppendLine($"Total Parameter Instance: {element.Parameters.Size}");
            sb.AppendLine($"Total Parameter Type: {elementType.Parameters.Size}");
            sb.AppendLine($"Parameter Name: {parameter.Definition.Name}");
            sb.AppendLine($"Parameter Group: {parameter.Definition.ParameterGroup}");
            sb.AppendLine($"Parameter Type: {parameter.Definition.ParameterType}");
            sb.AppendLine($"Parameter StorageType: {parameter.StorageType}");
            sb.AppendLine($"Parameter Id: {parameter.Id}");
            sb.AppendLine($"Parameter IsShared: {parameter.IsShared}");
            MessageBox.Show(sb.ToString());
        }
    }
}
