using System.ServiceModel.Web;
using System.ServiceModel;
using System;
using System.Collections.Generic;
using System.Threading;

public class Site {
	public string Name {get;set;}
}

[ServiceContract]
public class SOM {
	
	[WebGet(UriTemplate = "sites", ResponseFormat=WebMessageFormat.Json)]
	[OperationContract]
	List<Site > GetSites() {
	
		return new List<Site > { 
				new Site { Name = "First" },
				new Site { Name = "Second" },
				new Site { Name = "Third" }
			};
			
	}
	
}

public class Application {

	public static void Main() {
	
		var host = new WebServiceHost( typeof (SOM), new Uri("http://spb9503:8080/som") );
		host.Open();
	
		Thread.Sleep( 60 * 60 * 1000 ); 
	
	}
	
}