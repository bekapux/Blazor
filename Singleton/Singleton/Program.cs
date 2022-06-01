using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using static System.Console;

namespace DotNetDesignPatternDemos.Creational.Singleton
{
    public interface IRenderer
    {
        void RenderCircle(float radius);
    }

    public class VectorRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing a circle of radius {radius}");
        }
    }

    public class RasterRenderer : IRenderer
    {
        public void RenderCircle(float radius)
        {
            WriteLine($"Drawing Pixels for circle of radius {radius}");
        }

    }

    public abstract class Shape
    {
        protected IRenderer renderer;
        public Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract void Draw();
        public abstract void Resize(float factor);
    }

    public class Circle : Shape
    {
        float radius;
        public Circle(IRenderer renderer, float radius) : base(renderer)
        {
            this.radius = radius;
        }

        public override void Draw()
        {
            renderer.RenderCircle(radius);
        }

        public override void Resize(float factor)
        {
            radius = factor;
        }
    }

    public class Demo
    {

        static void Main()
        {
            IRenderer renderer = new RasterRenderer();
            var circle = new Circle(renderer, 5);
            circle.Draw();
            circle.Resize(2);
            circle.Draw();
        }
    }
}
