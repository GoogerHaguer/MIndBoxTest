using System;



namespace MIndBoxTest.Figures
{
    public class Triangle : Figure 
    {
        #region Fields
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;
        public double FirstSide 
                                {
                                    set
                                    {
                                        if (value < 0)
                                        {
                                            throw new Exception("Длина не может быть меньше нуля");
                                        }
                                        _firstSide = value;
                                    }
                                    get => _firstSide;
                                  }
        public double SecondSide 
                                { 
                                    set 
                                    {
                                        if (value < 0)
                                        {
                                            throw new Exception("Длина не может быть меньше нуля");
                                        }
                                        _secondSide = value;
                                    }
                                    get =>  _secondSide;
                                }

        public double ThirdSide 
                                { 
                                    set
                                    {
                                        if (value < 0)
                                        {
                                            throw new Exception("Длина не может быть меньше нуля");
                                        }
                                        _thirdSide = value;
                                    }
                                    get => _thirdSide;
                                }
        #endregion

        #region Constructors
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            this.FirstSide = firstSide;
            this.SecondSide = secondSide;
            this.ThirdSide = thirdSide;
        }
        #endregion

        #region Methods
        public override double GetArea()
        {

            double halfPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - FirstSide) * (halfPerimeter - SecondSide) * (halfPerimeter - ThirdSide));
            return area;
        }
        public bool IsRight()
        {
            bool PythagorasTheorem(double side1,double side2, double side3)
            {
                return Math.Pow(side1, 2) == (Math.Sqrt(Math.Pow(side2, 2)) + Math.Sqrt(Math.Pow(side3, 2)));
            }
            return (
                    PythagorasTheorem(FirstSide, SecondSide, ThirdSide) || PythagorasTheorem( SecondSide, FirstSide, ThirdSide) || PythagorasTheorem( ThirdSide, FirstSide, SecondSide)
                   ); 
        }
        #endregion
    }
}
