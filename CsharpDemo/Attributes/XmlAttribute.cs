using System;

namespace CsharpDemo.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class XmlAttribute : Attribute
    {
        /// <summary>
        /// 功能名称 
        /// => 32x32 功能名称.png
        /// => 16x16 功能名称_16.png
        /// => 355x355 功能名称_355.png
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 提示
        /// </summary>
        public string ToolTip { get; }

        /// <summary>
        /// 长提示
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="name">功能名称</param>
        /// <param name="tooltip">功能提示</param>
        /// <param name="description">功能长提示</param>
        public XmlAttribute(string name, string tooltip = "qq群:17075104", string description = "微信:zedmoster")
        {
            Name = name;
            ToolTip = tooltip;
            Description = description;
        }
    }
}
