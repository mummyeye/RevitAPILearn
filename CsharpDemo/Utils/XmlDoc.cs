using Autodesk.Revit.UI;
using System;
using System.Windows;

namespace CsharpDemo.Utils
{
    internal class XmlDoc
    {
        #region 饿汉式单例
        private XmlDoc() { }
        private static readonly XmlDoc Global = new XmlDoc();
        public static XmlDoc Instance => Global ?? new XmlDoc();

        #endregion

        /// <summary>
        /// uidoc
        /// </summary>
        public UIDocument UIdoc { get; set; }

        /// <summary>
        /// IExternalEventHandler
        /// </summary>
        public RevitTask Task { get; set; }

        #region 方法

        /// <summary>
        /// 弹窗提示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static MessageBoxResult Print<T>(T msg,
            MessageBoxButton button = MessageBoxButton.OK,
            MessageBoxImage image = MessageBoxImage.Information)
        {
            return MessageBox.Show($"{msg}", "提示", button, image);
        }

        #endregion
    }
}
