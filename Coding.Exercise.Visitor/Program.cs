using System;
using System.Text;

namespace Coding.Exercise.Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new AdditionExpression(
                new Value(1),
                new AdditionExpression(
                    new MultiplicationExpression(
                        new Value(2),
                        new Value(3)),
                new Value(4)));

            var ep = new ExpressionPrinter();
            ep.Visit(e);
            Console.WriteLine(ep);
        }
    }

    public abstract class ExpressionVisitor
    {
        public abstract void Visit(Value ex);
        public abstract void Visit(AdditionExpression ex);
        public abstract void Visit(MultiplicationExpression ex);
    }

    public abstract class Expression
    {
        public abstract void Accept(ExpressionVisitor ev);
    }

    public class Value : Expression
    {
        public readonly int TheValue;

        public Value(int value)
        {
            TheValue = value;
        }

        public override void Accept(ExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class AdditionExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public AdditionExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class MultiplicationExpression : Expression
    {
        public readonly Expression LHS, RHS;

        public MultiplicationExpression(Expression lhs, Expression rhs)
        {
            LHS = lhs;
            RHS = rhs;
        }

        public override void Accept(ExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class ExpressionPrinter : ExpressionVisitor
    {
        private StringBuilder sb = new StringBuilder();

        public override void Visit(Value value)
        {
            sb.Append(value.TheValue);
        }

        public override void Visit(AdditionExpression ae)
        {
            sb.Append("(");
            ae.LHS.Accept(this);
            sb.Append("+");
            ae.RHS.Accept(this);
            sb.Append(")");
        }

        public override void Visit(MultiplicationExpression me)
        {
            me.LHS.Accept(this);
            sb.Append("*");
            me.RHS.Accept(this);
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
}
