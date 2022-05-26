using System;
using System.Threading.Tasks;
					
public class Program
{
	
	public static void Main()
	{
		Console.WriteLine("Main Started..."+System.Threading.Thread.CurrentThread.ManagedThreadId);
		DoSearch("M100");
		Console.WriteLine("Main Completed..."+System.Threading.Thread.CurrentThread.ManagedThreadId);
		while(true){
			System.Threading.Tasks.Task.Delay(2000).Wait();
		}
	}
	public async static void DoSearch(string mrn){
		/*
		Task<string> searchTaskRef=SearchPatientByMrnAsync("M100");
		searchTaskRef.Wait();
		string result=searchTaskRef.Result;
		Task searchResultProcessTask=ProcessSearchResultAsync(result);
		searchResultProcessTask.Wait();
		*/
		
		string result=await SearchPatientByMrnAsync("M100");
		await ProcessSearchResultAsync(result);
		
		
	}
	public static string SearchPatientByMrn(string mrn){
		Console.WriteLine("Search Started......"+System.Threading.Thread.CurrentThread.ManagedThreadId);
		System.Threading.Tasks.Task.Delay(2000).Wait();
		Console.WriteLine("Search Done......"+System.Threading.Thread.CurrentThread.ManagedThreadId);
		return "Search Result For...."+mrn;
		
	}
	
	public static Task<string> SearchPatientByMrnAsync(string mrn){
		return Task<string>.Run(()=>{
										return SearchPatientByMrn(mrn);
	   					
									});
	}
	public static  void ProcessSearchResult(string result){
		
		Console.WriteLine("Search Result Processing Started......"+System.Threading.Thread.CurrentThread.ManagedThreadId);
		System.Threading.Tasks.Task.Delay(2000).Wait();
		Console.WriteLine("Search Result Processing  Done......"+System.Threading.Thread.CurrentThread.ManagedThreadId);
		
	}
	public static  Task ProcessSearchResultAsync(string result){
		return Task.Run(()=>{
		ProcessSearchResult(result);
		});
	}
	
}
