using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Windows.Controls;
using TextBox = System.Windows.Controls.TextBox;
//using Microsoft.Office.Interop.Excel;

namespace wfApp
{
    [Designer(typeof(ControlDesigner))]
    //[DesignerSerializer("System.Windows.Forms.Design.ControlCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    class SpellBox : ElementHost
    {
        [System.ComponentModel.Browsable(true)]
        public System.Windows.Forms.AutoCompleteStringCollection AutoCompleteCustomSource { get; set; }
        [System.ComponentModel.Browsable(true)]
        public System.Windows.Forms.AutoCompleteMode AutoCompleteMode { get; set; }
        [System.ComponentModel.Browsable(true)]
        public System.Windows.Forms.AutoCompleteSource AutoCompleteSource { get; set; }
        public SpellBox()
        {
            box = new TextBox();
            
            base.Child = box;
            box.TextChanged += (s, e) => OnTextChanged(EventArgs.Empty);
            box.SpellCheck.IsEnabled = true;
            box.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            box.AutoWordSelection = true;
            this.Size = new System.Drawing.Size(100, 20);
        }

       
        public override string Text
        {
            get { return box.Text; }
            set { box.Text = value; }
        }

       

        [DefaultValue(false)]
        public bool Multiline
        {
            get { return box.AcceptsReturn; }
            set { box.AcceptsReturn = value; }
        }
        [DefaultValue(false)]
        public bool WordWrap
        {
            get { return box.TextWrapping != TextWrapping.NoWrap; }
            set { box.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new System.Windows.UIElement Child
        {
            get { return base.Child; }
            set { /* Do nothing to solve a problem with the serializer !! */ }
        }
        private TextBox box;
    }
}
