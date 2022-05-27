using System;
using System.Collections.Generic;
				
public class Environment{
	
	public string Name{get;set;}
}
public class Program
{
	
	static Dictionary<string,Action> _depolyStatergies=new  Dictionary<string,Action>();
	static Program(){
		
		_depolyStatergies.Add("Test",new Action(TestDeploy));
		_depolyStatergies.Add("Production",new Action(ProductionDeploy));
		_depolyStatergies.Add("QA",new Action(QADeploy));
	}
	public static void Main()
	{
		//out variables
		Console.WriteLine("Hello World");
		string data="1234";
		//preDeclare variable
		//int targetValue;
		ConvertToInt(data,out int targetValue,out int code); // C# 7.0
		ConvertToInt(data,out var _targetValue,out _); 
		
		object obj=GetObject();
		if(obj is null){
			Console.WriteLine("Obj is Null");
		}
		
		else if(obj is Program){
			Console.WriteLine("Obj is of Type Program");
		}
		else if(obj is int x){
			//int x=(int)obj;
			Console.WriteLine($"Obj is of Type Integer and value is {x}" );
		}
		
		/* Is Expressions with Patterns - C# 7.0
		if(obj is int i || obj is string s && 
		*/
		
		Environment _env=new Environment(){ Name="Test"};
		Deploy(_env);
		_env.Name="Production";
		Deploy(_env);
		_env.Name="QA";
		Deploy(_env);
	}
	
	public static bool ConvertToInt(string input,out int convertedValue,out int code){
		
		convertedValue=0;
		code=0;
		return true;
	}
	
	public static object GetObject(){
		return 10;
	}
	
	
	
	public static void Deploy(Environment env){
		switch(env.Name){
				
			case string s when(s == "Test"):Console.WriteLine($"Test Env Deploy" );break;
			
		}
		
		//_depolyStatergies[env.Name].Invoke();
		
		
	}
	
	public static void TestDeploy(){
	Console.WriteLine($"Test Env Deploy" );
	}
	public static void ProductionDeploy(){
	Console.WriteLine($"Production Env Deploy" );
	}
	public static void QADeploy(){
	Console.WriteLine($"QA Env Deploy" );
	}
	
}

//Day-5

public class Patient{

	public string MRN{get;set;}
	/*
	public Patient(string mrn){
	
		if(mrn==null){
			throw new ArgumentNullException(nameof(MRN) + " cannot be null");
		}
	}*/
	//Throw Expressions
	public Patient(string mrn)=> MRN=mrn ?? throw new ArgumentNullException(nameof(MRN) + " cannot be null");
}
public class Program
{
	public static void Main()
	{
		int[] numbers={1,2,345,5,9,7,8};
		ref int result=ref searchNumber(numbers,345);//result->pointer->numbers[2]
		Console.WriteLine("Result : "+result);
		result=1000;
		Console.WriteLine("Change in Result : "+result);
		for(int i=0;i<numbers.Length;i++){
			Console.WriteLine(numbers[i]);
		}
		
	}
	//ref returns 
	static ref int searchNumber(int[] source,int number){
		
		for(int i=0;i<source.Length;i++){
			if(source[i]==number){
				
				return ref source[i];//value type
			}
		}
		throw new Exception("Element Not Foud");
	}
}
