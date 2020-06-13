using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using MIndBoxTest.Interface;

namespace MIndBoxTest.Figures
{
    public abstract class Figure : IFigure
    {
        public abstract double GetArea();

    }
}
