using System;
using System.Dynamic;
using System.Collections.Generic;

					
public class DataModel:DynamicObject{
	
	Dictionary<string,object> _propertyBag=new  Dictionary<string,object>();
	public override bool TrySetMember (System.Dynamic.SetMemberBinder binder, object value){
		
		_propertyBag[binder.Name]=value;
		return true;
	}
	public override  bool TryGetMember (System.Dynamic.GetMemberBinder binder, out object result){
	
		result=null;
		if(_propertyBag.ContainsKey(binder.Name)){
			result=_propertyBag[binder.Name];
		return true;
		}
		
		return false;
	}
	
}
public class Program
{
	public static void Main()
	{
		dynamic obj=new DataModel();
		obj.Name="Tom";//Property Access, set 
		string name=obj.Name;
		System.Console.WriteLine(name);
		
		dynamic objRef=GetData();
		objRef.Name="Hary";
		name=objRef.Name;
		System.Console.WriteLine(name);
	
	}
	
	public static object GetData(){
		return new DataModel();
	}
}
