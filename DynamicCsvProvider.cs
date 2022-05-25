using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
					
public class CsvLineInfo:DynamicObject{
    public string header,lineContent;
	
	public override string ToString(){
		
		//string objectString=string.Format("{0},{1},{2},{3},{4}",null,null,null,null,null);
		return lineContent;
	}
	
	public override  bool TryGetMember (System.Dynamic.GetMemberBinder binder, out object result){
	
		result=null;
		string propertyName=binder.Name;
		int indexOfProperty=header.Split(',').ToList().IndexOf(propertyName);
		if(indexOfProperty < 0){
			return false;
		}
		result=lineContent.Split(',')[indexOfProperty];
		
		return true;
	}
}

public class CSVDataProvider{
	
	string filePath;
	public string FilePath{ set { this.filePath=value;}}
	public IEnumerable<CsvLineInfo> GetAllRecords(){
		
		//Parse the File 
		//Etract Lini By Line
		//Construct CsvLineInfo Object
		CsvLineInfo _line1=new CsvLineInfo(){header="MRN,NAME,AGE,CONTACTNUMBER,CITY", lineContent="M100,Tom,30,98456783,BLR"};
		CsvLineInfo _line2=new CsvLineInfo(){header="MRN,NAME,AGE,CONTACTNUMBER,CITY", lineContent="M101,Hary,32,98456783,BLR"};
		CsvLineInfo _line3=new CsvLineInfo(){header="MRN,NAME,AGE,CONTACTNUMBER,CITY", lineContent="M102,Jack,33,98456783,CHN"};
		CsvLineInfo _line4=new CsvLineInfo(){header="MRN,NAME,AGE,CONTACTNUMBER,CITY", lineContent="M103,James,40,98456783,CHN"};
		List<CsvLineInfo> _objectList=new  List<CsvLineInfo>();
		_objectList.AddRange(new CsvLineInfo[]{_line1,_line2,_line3,_line4});
		return _objectList;
	}
		
	
}
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		CSVDataProvider _provider=new CSVDataProvider();
		_provider.FilePath="patients.csv";
		IEnumerable<CsvLineInfo> patients=_provider.GetAllRecords();
		
		IEnumerable<dynamic> result=Query(patients, (dynamic patient)=>{  return patient.CITY=="BLR";});
		foreach(dynamic patient in result){
			Console.WriteLine(patient.ToString());
		}
	}
	public static IEnumerable<TSource> Query<TSource>(IEnumerable<TSource> source,Func<TSource,bool> filterFunction)
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
