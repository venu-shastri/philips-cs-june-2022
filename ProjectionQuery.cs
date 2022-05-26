using System;
using System.Collections.Generic;
using System.Linq;
			

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

/*public class ProjectionResult{
	
	public string MRN{get;set;}
	public string Name{get;set;}
}*/
public class Program
{
	public static void Main()
	{
		List<PatientInfo> patientList=new List<PatientInfo>();
		//Object Initializer
		PatientInfo _patient_one=new PatientInfo{ MRN="M100", Name="Tom1", Age=34,ContactNumber="1234",City="BLR"};
		PatientInfo _patient_two=new PatientInfo{ MRN="M101", Name="Tom2", Age=33,ContactNumber="1234",City="BLR"};
		PatientInfo _patient_three=new PatientInfo{ MRN="M102", Name="Tom3", Age=35,ContactNumber="1234",City="CHN"};
		PatientInfo _patient_four=new PatientInfo{ MRN="M103", Name="Tom4", Age=36,ContactNumber="1234",City="HYD"};
		patientList.AddRange(new PatientInfo[]{_patient_one,_patient_two,_patient_three,_patient_four});
		
		//"Select MRN,Name from patientList where City=="BLR";
		//"Select MRN as MedicalRecordNumber,Name from patientList where City=="BLR";
		//"Select MRN,Name,Age from patientList where City=="BLR";
		//"Select MRN,Name as PatientName from patientList where City=="BLR";
	IEnumerable<PatientInfo> _result=	System.Linq.Enumerable.Where(patientList,(PatientInfo patient)=>{return patient.City=="BLR"; });
		//Projection
		var _projectionResult= System.Linq.Enumerable.Select(_result,(PatientInfo patient)=>{
			return new {MRN=patient.MRN,Name=patient.Name}; });
		foreach(var pr in _projectionResult){
			Console.WriteLine("{0},{1}",pr.MRN,pr.Name);
		}
		
	}
}
