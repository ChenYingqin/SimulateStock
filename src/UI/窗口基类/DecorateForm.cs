using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace UI
{   
    /// <summary>
    /// 修饰窗口,所有窗口的基类
    /// </summary>
    /// <author>宋佳恒</author>
    /// <date>2017-04-05</date>
    public partial class DecorateForm : Form
    {
        public string FormID { get; set; }
        /// <summary>
        /// BaseForm的构造函数
        /// </summary>
        /// <author>宋佳恒</author>
        /// <date>2017-03-30</date>
        /// 
        new public void Show()
        {
            base.Show();
        }
        public DecorateForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 通过xml修改窗口的公共样式
        /// </summary>
        /// <returns>是否修改成功</returns>
        /// <author>宋佳恒</author>
        /// <date>2017-03-30</date>
        
        protected bool Decorate(string xmlName)
        {   
            //获取当前窗口类的类型
            Type realType=this.GetType();
            try
            {   
                //读取xml
                XmlDocument xmlDoc = XmlLoader.GetXml(xmlName);
                //遍历窗口类中所有的字段
                foreach (FieldInfo field in realType.GetFields(System.Reflection.BindingFlags.NonPublic
                                                                | System.Reflection.BindingFlags.Instance
                                                                | System.Reflection.BindingFlags.IgnoreCase))
                {   
                    //根据字段名获取控件
                    Control obj = this.Controls[field.Name];  
                    //未获取到控件则continue
                    if(null==obj)
                    {
                        continue;
                    }

                    string fieldType = field.FieldType.ToString();//字段的完整类路径，例如：System.Windows.Forms.Button
                    string fieldShortType=fieldType.Substring(fieldType.LastIndexOf(".")+1);//字段的类名，例如：Button                 
                    
                    XmlNode node=xmlDoc.SelectSingleNode("/Form/"+fieldShortType);   //根据字段类名获取xml中的node,例如<Button width="100"></Button>                    
                    if(node!=null)
                    {
                        XmlElement xmlElement = (XmlElement)node;
                        //遍历xmlElement中的属性
                        foreach(XmlAttribute attr in xmlElement.Attributes)
                        {                              
                            try
                            {   
                                //根据属性名获取控件的属性特性
                                PropertyInfo pro=obj.GetType().GetProperty(attr.Name);
                                //根据属性特性获取属性的实际类型
                                Type t = pro.PropertyType;
                                //修改控件的属性值
                                pro.SetValue(obj, ConvertValueType(attr.Value, t), null);
                            }
                            catch(InvalidCastException ex)
                            {
                                Console.WriteLine(attr);
                                Console.WriteLine(ex.Message);
                            }
                        }
                       
                    }                        
                }
            }
            catch(XmlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;           
        }

        /// <summary>
        /// 参数类型转换函数，将参数转换成目标类型的值。
        /// 由于.net自带的参数转换函数不支持某些类型的转换，所以重写了该方法。
        /// </summary>
        /// <param name="value">待转换的值</param>
        /// <param name="targetType">目标类型</param>
        /// <returns>目标类型的值</returns>
        /// <author>宋佳恒</author>
        /// <date>2017-03-29</date>
        /// <exception cref="System.InvalidCastException">类型转换异常</exception>               
        protected static object ConvertValueType(object value,Type targetType)
        {   
            //转换后的值
            object transValue=null;
            try
            {   
                if(null==value)
                {
                    throw new InvalidCastException("待转换的值为空");
                }
                if(null==targetType)
                {
                    throw new InvalidCastException("目标类型为空");
                }  
                string bathPath=AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                switch(targetType.ToString())
                {
                    case "System.Drawing.Color": transValue = System.Drawing.ColorTranslator.FromHtml((string)value); break;                                                                                     
                    case "System.Drawing.Bitmap": transValue = Image.FromFile(bathPath +"\\"+ (string)value); break;
                    case "System.Drawing.Image": transValue = Image.FromFile(bathPath + "\\" + (string)value); break;
                    case "System.Windows.Forms.ImageLayout": transValue = (ImageLayout)Enum.Parse(typeof(ImageLayout), (string)value); break;
                    case "System.Drawing.Font": FontConverter fc=new FontConverter();
                                                transValue = fc.ConvertFromInvariantString((string)value);break;
                    default: transValue = Convert.ChangeType(value, targetType) ; break;
                }
            }
            catch(InvalidCastException ex)
            {
                throw new InvalidCastException("值"+value+"转换为"+targetType+"失败");
            }
            return transValue;
        }
      

    }

}
