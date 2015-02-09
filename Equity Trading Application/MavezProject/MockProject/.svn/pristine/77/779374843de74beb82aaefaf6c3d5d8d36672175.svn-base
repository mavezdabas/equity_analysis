using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace ExecutionTraderMainWindow.Views
{
     public class Element
        {
            #region Fields
            bool isDragging = false;
            IInputElement inputElement = null;
            double x, y = 0;
            #endregion
            #region Constructor
            public Element() { }
            #endregion
            #region Properties
            public IInputElement InputElement
            {
                get { return this.inputElement; }
                set
                {
                    this.inputElement = value;
                    /* every time inputElement resets, the draggin stops (you actually don't even need to track it, but it made things easier in the begining, I'll change it next time I get to play with it. */
                    this.isDragging = false;

                }

            }

            public double X
            {
                get { return this.x; }
                set { this.x = value; }
            }

            public double Y
            {
                get { return this.y; }
                set { this.y = value; }
            }

            public bool IsDragging
            {
                get { return this.isDragging; }
                set { this.isDragging = value; }
            }

            #endregion

        }
    }

