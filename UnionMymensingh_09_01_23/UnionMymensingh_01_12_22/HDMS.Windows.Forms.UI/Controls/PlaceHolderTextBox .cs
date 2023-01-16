﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HDMS.Windows.Forms.UI.Controls
{
   public  class PlaceHolderTextBox : TextBox
   {
       bool isPlaceHolder = true;
       string _placeHolderText;
       public string PlaceHolderText
       {
           get { return _placeHolderText; }
           set
           {
               _placeHolderText = value;
               setPlaceholder();
           }
       }

       //when the control loses focus, the placeholder is shown
       private void setPlaceholder()
       {
           if (string.IsNullOrEmpty(this.Text))
           {
               this.Text = PlaceHolderText;
               this.ForeColor = Color.Gray;
               this.Font = new Font(this.Font, FontStyle.Italic);
               isPlaceHolder = true;
           }
       }

       //when the control is focused, the placeholder is removed
       private void removePlaceHolder()
       {

           if (isPlaceHolder)
           {
               this.Text = "";
               this.ForeColor = System.Drawing.SystemColors.WindowText;
               this.Font = new Font(this.Font, FontStyle.Regular);
               isPlaceHolder = false;
           }
       }
       public PlaceHolderTextBox()
       {
           GotFocus += removePlaceHolder;
           LostFocus += setPlaceholder;
       }

       private void setPlaceholder(object sender, EventArgs e)
       {
           setPlaceholder();
       }

       private void removePlaceHolder(object sender, EventArgs e)
       {
           removePlaceHolder();
       }
 
   }
}
