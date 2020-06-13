using Microsoft.VisualBasic;
using MIndBoxTest;
using MIndBoxTest.Figures;
using System;
using Xunit;
using Xunit.Abstractions;
using System.Linq;

namespace MindBoxTestUnitTest
{
    public class UnitTest
    {
        #region CircleTests
        [Fact]
        public void GetCircleArea()
        {
            //Arrange
            double rad = 4;
            Circle circ = new Circle(rad);
            //Act
            double area = circ.GetArea();
            double controlArea = Math.PI * Math.Pow(rad, 2);
            //Assert
            Assert.Equal(controlArea, area);
            
        }
        [Fact]
        public void CircleRadiusNotValidValue()
        {
            //Arrange
            double rad = -3;
            //Assert
            Assert.Throws<Exception>(() => new Circle(rad));
        }
        #endregion


        #region TriangleTests
        [Fact]
        public void GetTriangleArea()
        {
            //Arrange
            double s1 = 1;
            double s2 = 2;
            double s3 = 3;
            Triangle tri = new Triangle(s1, s2, s3);
            //Act
            double area = tri.GetArea();
            double controlHalfPerimeter = (s1+ s2 + s3) / 2;
            double controlArea = Math.Sqrt(controlHalfPerimeter * (controlHalfPerimeter - s1) * (controlHalfPerimeter - s2) * (controlHalfPerimeter - s3));
            //Assert
            Assert.Equal(controlArea, area);
        }
        [Fact]
        public void TriangleSidesNotValidValues()
        {
            //Arrange
            double wrongside = -3;
            double rightside = 3;
            //Assert
            Assert.Throws<Exception>(() => new Triangle(wrongside, rightside, rightside));
            Assert.Throws<Exception>(() => new Triangle(rightside, rightside, wrongside));
            Assert.Throws<Exception>(() => new Triangle(wrongside, wrongside, rightside));
        }
        [Fact]
        public void TriangleIsRight()
        {
            //Arrange
            double s1 = 3;
            double s2 = 4;
            double s3 = 5;
            Triangle tri = new Triangle(s1, s2, s3);
            //Act
            bool isRight = tri.IsRight();
            bool controlIsRight = (
                       (Math.Pow(s1, 2) == (Math.Sqrt(Math.Pow(s2, 2)) + Math.Sqrt(Math.Pow(s3, 2))))
                    || (Math.Pow(s2, 2) == (Math.Sqrt(Math.Pow(s1, 2)) + Math.Sqrt(Math.Pow(s3, 2))))
                    || (Math.Pow(s3, 2) == (Math.Sqrt(Math.Pow(s2, 2)) + Math.Sqrt(Math.Pow(s1, 2))))
                     );
            //Assert
            Assert.Equal(controlIsRight, isRight);

        }
        [Fact]
        public void TriangleIsNotRight()
        {
            //Arrange
            double s1 = 1;
            double s2 = 2;
            double s3 = 3;
            Triangle tri = new Triangle(s1, s2, s3);
            //Act
            bool isRight = tri.IsRight();
            bool controlIsRight = (
                       (Math.Pow(s1, 2) == (Math.Sqrt(Math.Pow(s2, 2)) + Math.Sqrt(Math.Pow(s3, 2))))
                    || (Math.Pow(s2, 2) == (Math.Sqrt(Math.Pow(s1, 2)) + Math.Sqrt(Math.Pow(s3, 2))))
                    || (Math.Pow(s3, 2) == (Math.Sqrt(Math.Pow(s2, 2)) + Math.Sqrt(Math.Pow(s1, 2))))
                     );
            //Assert
            Assert.Equal(controlIsRight, isRight);

        }
        #endregion 
    }
}
