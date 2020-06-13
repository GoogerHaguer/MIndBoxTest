using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;
using MIndBoxTest.Interface;

namespace MIndBoxTest.Figures
{
    public class Circle : Figure
    {
        #region Fields
        private double _radius;
        public double Radius
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("Радиус не может быть меньше нуля");
                }
                _radius = value;
            }
            get => _radius;
        }
        #endregion
       
        
        
        #region Constructors
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        #endregion
        
        
        #region Methods
        public override double GetArea()
        {
          
            double area =  Math.PI * Math.Pow(Radius,2);

            return area;
        }
        #endregion
    }
}

