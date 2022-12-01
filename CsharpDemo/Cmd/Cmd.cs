using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using CsharpDemo.Attributes;
using CsharpDemo.Extension;
using CsharpDemo.Utils;
using System;

namespace CsharpDemo.Cmd
{
    [Xml("名称")]
    [Transaction(TransactionMode.Manual)]
    class Cmd : RevitCommand
    {
        public override void Action()
        { 

        }
    }
}
