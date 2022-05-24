using System;
using System.Collections; //containers (IEnumerable and IEnumerator)
using System.Collections.Generic;//containers

namespace ConsoleAppUsingIDE
{
    public interface IStringFilter
    {
        bool Filter(string item);
    }
    //public class StartWithStringFilter:IStringFilter
    //{
    //    public string StartsWith { get; set; }
    //    public bool Filter(string item)
    //    {
    //        return item.StartsWith(this.StartsWith);
    //    }

    //}
    //public class EndsWithStringFilter : IStringFilter
    //{
    //    public string EndsWith { get; set; }
    //    public bool Filter(string item)
    //    {
    //        return item.EndsWith(this.EndsWith);
    //    }

    //}

    //public class BoolStringArgumentCommand
    //{
    //    System.Object _classType;
    //    string methodName;
    //    public BoolStringArgumentCommand(System.Object target,string methodName)
    //    {
    //        this._classType = target;
    //        this.methodName = methodName;
    //    }
    //    //Delegate
    //    public bool Invoke(string item)
    //    {
    //        //Delegation
    //        //Reflection
    //        return default(bool);


    //    }

    //}
    class Program
    {
        public static bool CheckStringStartsWithP(string item)
        {
            return item.StartsWith("P");
        }
        public static bool CheckStringEndsWithP(string item)
        {
            return item.EndsWith("P");
        }
        
        static void Main(string[] args)
        {
            string[] names = { "Philips", "Siemens","Python","CSharp"};
            //IStringFilter _filter = new StartWithStringFilter() { StartsWith = "P" };
            //List<string> result= FilterStringUsingFilterStatergyUsingRuntimePolymrphism(names,_filter);
            //_filter = new EndsWithStringFilter() { EndsWith = "P" };
            //result = FilterStringUsingFilterStatergyUsingRuntimePolymrphism(names, _filter);

            Func<string, bool> _command = new Func<string, bool>(Program.CheckStringStartsWithP);
            FilterStringUsingFilterStatergyUsingFunctionAsArgumnet(names, _command);
            _command = new Func<string, bool>(Program.CheckStringEndsWithP);
            FilterStringUsingFilterStatergyUsingFunctionAsArgumnet(names, _command);
        }
        //Reusability - Object Orientation
        static List<string> FilterStringUsingFilterStatergyUsingRuntimePolymrphism(string[] source,IStringFilter filterLogic)
        {
            List<string> tempResult = new List<string>();
           
            for (int i = 0; i < source.Length; i++)
            {
                if (filterLogic.Filter(source[i]))
                {
                    tempResult.Add(source[i]);
                }
            }
            return tempResult;

        }
        static List<string> FilterStringUsingFilterStatergyUsingFunctionAsArgumnet(string[] source,
         Func<string,bool> filterFunction)
        {
            List<string> tempResult = new List<string>();

            for (int i = 0; i < source.Length; i++)
            {
                if (filterFunction.Invoke( source[i]))
                {
                    tempResult.Add(source[i]);
                }
            }
            return tempResult;

        }

    }

    
}
