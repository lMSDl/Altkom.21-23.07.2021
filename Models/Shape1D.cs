using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Shape1D : Shape
    {
        //public int Width { get; set; }

        private int _width;

        protected Shape1D() //: this("Some shape 1d")
        {
        }

        protected Shape1D(string name) : base(name)
        {
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        //public void SetWidth(int value)
        //{
        //    _width = value;
        //}

        //public int GetWidth()
        //{
        //    return _width;
        //}
    }
}
