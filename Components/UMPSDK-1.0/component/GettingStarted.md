Unvired Mobile Platform SDK

Sample Application Quickstart

Follow these steps to run the sample app included. Additional samples are available in the Github Unvired repository.

1. Start by registering for a free trial account of the Unvired Mobile Platform Cloud Edition. Register here http://unvired.com/free-trial/.  In the application requirements please mention access to Xamarin required.
2. Once you have the trial, open the sample in the Xamarin Studio.
3. Compile the application and run it.
4. In the Login screen enter the credentials received as part of the trial cloud account registration.
5. On successful login the Hello World screen is displayed.
6. More samples with SAP and other systems are being published to the Unvired Github repository.  You can download the other samples from Github and run them with the Xamarin studio.


Start coding to Login to the Unvired Mobile Platform and work with the application

      private void OnAppStart()
	  {
            //Set required parameters for initializing Unvired Mobile Framework
			LoginParameters.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().ToString();
			
			//Set app name as defined in Metadata.xml
			LoginParameters.AppName = "UNVIRED_HELLO_WORLD";
			
            LoginParameters.Protocol = LoginParameters.PROTOCOL.https;
            LoginParameters.Url = "live.unvired.io/UNI";
            
            // Set any other special parameters to control the login process
			........
            
            //Now call Unvired Authentication service
            AuthenticationService.Login();

            .........
            // Handle the login results and do something great in the App!
	 }
	 
	 

    