﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Assembly.Metro.Controls.PageTemplates.Games.Components.MetaData
{
    public enum EnumType
    {
        Enum8,
        Enum16,
        Enum32
    }

    public class EnumData : ValueField
    {
        private EnumType _type;
        private int _value;
        private EnumValue _selectedValue = null;

        public EnumData(string name, uint offset, uint address, EnumType type, int value, uint pluginLine)
            : base(name, offset, address, pluginLine)
        {
            _type = type;
            _value = value;
            Values = new ObservableCollection<EnumValue>();
        }

        public EnumType Type
        {
            get { return _type; }
            set { _type = value; NotifyPropertyChanged("Type"); NotifyPropertyChanged("TypeStr"); }
        }

        public string TypeStr
        {
            get { return _type.ToString().ToLower(); }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged("Value"); }
        }

        public EnumValue SelectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; NotifyPropertyChanged("SelectedValue"); Value = value.Value; }
        }

        public ObservableCollection<EnumValue> Values { get; private set; }

        public override void Accept(IMetaFieldVisitor visitor)
        {
            visitor.VisitEnum(this);
        }

        public override MetaField CloneValue()
        {
            EnumData result = new EnumData(Name, Offset, FieldAddress, _type, _value, base.PluginLine);
            foreach (EnumValue option in Values)
            {
                EnumValue copiedValue = new EnumValue(option.Name, option.Value);
                result.Values.Add(copiedValue);
                if (_selectedValue != null && copiedValue.Value == _selectedValue.Value)
                    result._selectedValue = copiedValue;
            }
            return result;
        }
    }

    public class EnumValue : PropertyChangeNotifier
    {
        private string _name;
        private int _value;

        public EnumValue(string name, int value)
        {
            _name = name;
            _value = value;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyPropertyChanged("Name"); }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; NotifyPropertyChanged("Value"); }
        }
    }
}
