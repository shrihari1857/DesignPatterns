using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reference - www.dofactory.com
            var factory1 = new ConcreteFactory1();
            var client1 = new Client(factory1);
            client1.Run();

            var factory2 = new ConcreteFactory2();
            var client2 = new Client(factory2);
            client2.Run();

            Console.ReadLine();

        }
    }

    abstract class AbstractProductA
    {

    }

    abstract class AbstractProductB
    {
        public abstract void Interacts(AbstractProductA productA);
    }

    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }

    class ProductA1 : AbstractProductA
    {

    }

    class ProductB1 : AbstractProductB
    {
        public override void Interacts(AbstractProductA productA) => Console.WriteLine(this.GetType().Name 
            + " interacts with " + productA.GetType().Name);
    }

    class ProductA2 : AbstractProductA
    {

    }
    class ProductB2 : AbstractProductB
    {
        public override void Interacts(AbstractProductA productA) => Console.WriteLine(this.GetType().Name
            + " interacts with " + productA.GetType().Name);
    }

    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    class Client
    {
        private readonly AbstractFactory _abstractFactory;
        private AbstractProductA _abstractProductA;
        private AbstractProductB _abstractProductB;

        public Client(AbstractFactory abstractFactory)
        {
            _abstractFactory = abstractFactory;
            
        }

        public void Run()
        {
            _abstractProductA = _abstractFactory.CreateProductA();
            _abstractProductB = _abstractFactory.CreateProductB();
            _abstractProductB.Interacts(_abstractProductA);
        }
    }
}
