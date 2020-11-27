using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CsharpSyntax
{
    class syn_lambda4_ExpTree
    {
    }
    class Program
    {
        static void Main(string[] args)
        {
            Expression<Func<int, int, int>> exp = (a, b) => a + b;

            BinaryExpression opPlus = exp.Body as BinaryExpression;
            Console.WriteLine(opPlus.NodeType);

            ParameterExpression left = opPlus.Left as ParameterExpression;
            Console.WriteLine(left.NodeType + ": " + left.Name);

            ParameterExpression right = opPlus.Right as ParameterExpression;
            Console.WriteLine(right.NodeType + ": " + right.Name);

            Func<int, int, int> func = exp.Compile();
            Console.WriteLine(func(10, 2));

            Console.WriteLine();
            Console.WriteLine();
            ParameterExpression leftExp = Expression.Parameter(typeof(int), "a");
            ParameterExpression rightExp = Expression.Parameter(typeof(int), "b");
            BinaryExpression addExp = Expression.Add(leftExp, rightExp);

            Expression<Func<int, int, int>> addLambda = 
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>
                    (addExp, new ParameterExpression[] { leftExp, rightExp });
            Console.WriteLine(addLambda.ToString());

            Func<int, int, int> addFunc = addLambda.Compile();
            Console.WriteLine(addFunc(20, 345));



        }
    }
}
