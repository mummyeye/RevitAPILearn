using Autodesk.Revit.DB;

namespace CsharpDemo.Extension
{
    public static class XYZExtension
    {
        /// <summary>
        /// 设置z值默认为0
        /// </summary>
        /// <param name="xyz"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static XYZ Faltten(this XYZ xyz, double z = 0)
        {
            return new XYZ(xyz.X, xyz.Y, z);
        }

    }
}
