using Autodesk.Revit.DB;

namespace CsharpDemo.Extension
{
    public static class CurveExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Line Faltten(this Line line, double z=0)
        {
            if (line == null) return default;
            if (line.IsBound)
            {
                return Line.CreateBound(line.GetEndPoint(0).Faltten(z), line.GetEndPoint(1).Faltten(z));
            }
            else
            {
                return Line.CreateUnbound(line.Origin.Faltten(z), line.Direction);
            }

        }
    }
}
