using System;
using System.Collections; //containers (IEnumerable and IEnumerator)
using System.Collections.Generic;//containers

namespace ConsoleAppUsingIDE
{
   
    class Program
    {
         public static Func<string,bool> CheckStringStartWithGivenParameter(string startsWith)
        {
           // Func<string, bool> _funcObj = (string item) => { return item.StartsWith(startsWith); };
             bool InnerFunction(string item)
            {
                return item.StartsWith(startsWith);
            }
            return InnerFunction;

        }
        public static bool CheckStringEndsWithP(string item)
        {
            return item.EndsWith("P");
        }
        
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Siemens","Python","CSharp"};

            Func<string, bool> _command = CheckStringStartWithGivenParameter("P");
            Query(names, _command);
            _command = CheckStringStartWithGivenParameter("Q");
            Query(names, _command);
            _command = CheckStringStartWithGivenParameter("R");
            Query(names, _command);
            _command = CheckStringStartWithGivenParameter("S");
            Query(names, _command);
            _command = CheckStringStartWithGivenParameter("T");
            Query(names, _command);
            _command = CheckStringStartWithGivenParameter("V");
            Query(names, _command);
        }
        
        /*
         * Functional Programming
         *  Function As an Argument (Command Pattern)
         *  Function As return value (Command Pattern)
         *  Closure
         *  Pure Function
         * Iterator Pattern Interaction (foreach)
         * Parametric Polymorhism (Generics)
         */ 
        static IEnumerable<TSource> Query<TSource>(IEnumerable<TSource> source,
         Func<TSource,bool> filterFunction)
        {
            List<TSource> tempResult = new List<TSource>();

            foreach (TSource item in source)
            {
                if (filterFunction.Invoke(item))
                {
                    tempResult.Add(item);
                }
            }
            return tempResult;

        }

    }

    
}
