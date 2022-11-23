using System;

namespace CsharpDemo.Attributes
{
    internal class XmlAttribute : Attribute
    {
        /// <summary>
        /// 功能名称 
        /// => 32x32 功能名称.png
        /// => 16x16 功能名称_16.png
        /// => 32x32 功能名称_355.png
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 提示
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// 长提示
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tooltip"></param>
        public XmlAttribute(string name, string tooltip = "qq交流群:17075104", string description="微信:zedmoster")
        {
            Name = name;
            ToolTip = tooltip;
            Description = description;
        }
    }
}
