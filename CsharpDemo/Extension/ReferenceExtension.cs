using Autodesk.Revit.DB;

namespace CsharpDemo.Extension
{
    public static class ReferenceExtension
    {
        /// <summary>
        /// reference 2 element
        /// </summary>
        /// <param name="reference"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
    }
}
