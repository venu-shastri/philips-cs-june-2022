using System;
using System.Collections.Generic;
					
public class PatientInfo{

	public string MRN{get;set;}
	public string Name{get;set;}
	public int Age{get;set;}
	public string ContactNumber{get;set;}
	public string City{get;set;}
	public override string ToString(){
		
		string objectString=string.Format("{0},{1},{2},{3},{4}",this,MRN,this.Name,this.Age,this.ContactNumber,this.City);
		return objectString;
	}
}

public class CSVDataProvider{
	
	string filePath;
	public string FilePath{ set { this.filePath=value;}}
	public IEnumerable<PatientInfo> GetAllPatientRecords(){
		
		//Parse the File 
		//Etract Lini By Line
		//Construct PatientInfo Object
		List<PatientInfo> _patientList=new  List<PatientInfo>();
		return _patientList;
	}
		
	
}
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		CSVDataProvider _provider=new CSVDataProvider();
		_provider.FilePath="patients.csv";
		IEnumerable<PatientInfo> patients=_provider.GetAllPatientRecords();
		
		IEnumerable<PatientInfo> result=Query(patients, (PatientInfo patient)=>{  return patient.City=="BLR";});
		foreach(PatientInfo patient in result){
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
