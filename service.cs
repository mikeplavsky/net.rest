using System.ServiceModel.Web;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Threading;

public class Site {
	public string Name {get;set;}
	public int Id {get;set;}
}

[ServiceContract]
public class SOM {
	
	[WebGet(UriTemplate = "sites", ResponseFormat=WebMessageFormat.Json)]
	[OperationContract]
	List<Site > GetSites() {
	
		return new List<Site > { 
				new Site { Name = "First", Id = 3 },
				new Site { Name = "Second", Id = 4 },
				new Site { Name = "Third", Id = 2 }
			};
			
	}
	
	[WebGet(UriTemplate = "site/{name}?id={id}", ResponseFormat=WebMessageFormat.Json)]
	[OperationContract]
	Site GetSite(string name, int id) {
		return new Site { Name = name, Id = id };
	}
	
}

public class Application {

	public static void Main() {
	
		var host = new WebServiceHost( typeof (SOM), new Uri("http://spb9503:8080/som") );
		host.Open();
	
		Thread.Sleep( 60 * 60 * 1000 ); 
	
	}
	
}