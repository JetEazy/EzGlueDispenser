﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace JetEazy.BasicSpace
{
    class JzPlugClass
    {
    }
    public class XProp
    {
        private string theCategory = "";
        private string theName = "";
        private string theDescription = "";
        private object theValue = null;
        private string theReleateName = "";

        object _editor = null;
        TypeConverter _converter = null;

        public string Category
        {
            get { return theCategory; }
            set { theCategory = value; }
        }

        public string Name
        {
            get
            {
                return theName;
            }
            set
            {
                theName = value;
            }
        }
        public string ReleateName
        {
            get
            {
                return theReleateName;
            }
            set
            {
                theReleateName = value;
            }
        }

        public object Value
        {
            get { return theValue; }
            set { theValue = value; }
        }

        public string Description
        {
            get { return theDescription; }
            set { theDescription = value; }
        }

        public TypeConverter Converter  //类型转换器，我们在制作下拉列表时需要用到  
        {
            get
            {
                return _converter;
            }
            set
            {
                _converter = value;
            }
        }

        public virtual object Editor   //属性编辑器  
        {
            get
            {
                return _editor;
            }
            set
            {
                _editor = value;
            }
        }
    }

    public class XPropDescriptor : PropertyDescriptor
    {
        private XProp theProp;

        public XPropDescriptor(XProp prop, Attribute[] attrs) : base(prop.Name, attrs)
        {
            theProp = prop;
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override System.Type ComponentType
        {
            get { return this.GetType(); }
        }

        public override object GetValue(object component)
        {
            return theProp.Value;
        }

        public override string Category
        {
            get
            {
                return theProp.Category;
            }
        }

        public override string Description
        {
            get
            {
                return theProp.Description;
            }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override System.Type PropertyType
        {
            get { return theProp.Value.GetType(); }
        }

        public override void ResetValue(object component)
        {

        }

        public override void SetValue(object component, object value)
        {
            theProp.Value = value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }

        //public override object GetEditor(Type editorBaseType)
        //{
        //    return base.GetEditor(typeof(GetPlugsPropertyEditor));
        //}

        public override TypeConverter Converter
        {
            get
            {
                return theProp.Converter;
            }
        }

        public override object GetEditor(Type editorBaseType)
        {
            return theProp.Editor == null ? base.GetEditor(editorBaseType) : theProp.Editor;
        }
    }



    public class XProps : List<XProp>, ICustomTypeDescriptor
    {
        #region   overloads

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] filter)
        {
            PropertyDescriptor[] newProps = new PropertyDescriptor[Count];

            for (int i = 0; i < Count; i++)
            {
                newProps[i] = new XPropDescriptor(this[i], filter);

            }

            return new PropertyDescriptorCollection(newProps);
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        { return TypeDescriptor.GetClassName(this, true); }

        string ICustomTypeDescriptor.GetComponentName()
        { return TypeDescriptor.GetComponentName(this, true); }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        { return TypeDescriptor.GetConverter(this, true); }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        { return TypeDescriptor.GetDefaultEvent(this, true); }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(System.Attribute[] attributes)
        { return TypeDescriptor.GetEvents(this, attributes, true); }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        { return TypeDescriptor.GetEvents(this, true); }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        { return TypeDescriptor.GetDefaultProperty(this, true); }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        { return TypeDescriptor.GetProperties(this, true); }

        object ICustomTypeDescriptor.GetEditor(System.Type editorBaseType)
        {

            return TypeDescriptor.GetEditor(this, editorBaseType, true);
            //return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(System.ComponentModel.PropertyDescriptor pd)
        { return this; }

        #endregion

        public override string ToString()
        {
            StringBuilder sbld = new StringBuilder();
            return sbld.ToString();
        }
    }
}
