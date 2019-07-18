<%@ Page Language="c#"  AutoEventWireup="false" %>
<%@ Import Namespace="WebTracker" %>
<%
    string connectionString = "Dsn=myodbc;database=website_tracker;option=0;port=0;server=192.168.9.206;uid=tracker_bot";
    HttpRequest request = Request;
    HttpResponse response = Response;
    
    Tracker TrackIt = new Tracker(connectionString, false);

    if (TrackIt.Track(ref request, ref response))
    {
        Response.Write("alert(1);");
    }
    else
    {
        string fileName = Server.MapPath("log.txt");
        System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(fileName, true);
        streamWriter.WriteLine("Log Added On: " + System.DateTime.Now.ToString());
        streamWriter.WriteLine("===============================================");
        streamWriter.WriteLine(TrackIt.ErrorMessage); 
        streamWriter.WriteLine("-----------------------------------------------");
        streamWriter.WriteLine();
        streamWriter.Close();
        
       Response.Write("alert(0);");
    }
%>