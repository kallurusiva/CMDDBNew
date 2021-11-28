<%


 Set objCDOSYSMail = Server.CreateObject("CDO.Message") 

 Set objCDOSYSCon = Server.CreateObject ("CDO.Configuration") 

 

 objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserver ") = "127.0.0.1" 

 objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport ") = 25 

 objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing ") = 2 

 objCDOSYSCon.Fields("http://schemas.microsoft.com/cdo/configuration/smtpconnectiontimeout ") = 60 

 objCDOSYSCon.Fields.Update 

 

 Set objCDOSYSMail.Configuration = objCDOSYSCon 

' objCDOSYSMail.From = "you@yourdomain.com"
 objCDOSYSMail.From = "msri_hari@yahoo.com"

 objCDOSYSMail.To = "hari.meena@gmail.com"

 objCDOSYSMail.Subject = "This is my subject for my test message"

 objCDOSYSMail.HTMLBody = "This is the body "

 objCDOSYSMail.Send 

 

 Set objCDOSYSMail = Nothing 

 Set objCDOSYSCon = Nothing 

Response.Write("Email Sent")



 %>