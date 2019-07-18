<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

<xsl:output method="html"/>
    <xsl:template match="/">

	<xsl:variable name='WebServicesList' />
	<xsl:variable name='DesktopApplicationList'/>
<html>
<head>
<title>Untitled Document</title>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2"/>
<style type="text/css">

body {
	background-color: #FFFFFF;
	margin-left: 0px;
	margin-top: 0px;
	margin-right: 0px;
	margin-bottom: 0px;
}
.style1 {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
}
.style2 {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 18px;
}
.style6 {font-size: 12px}
.style11 {
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 12px;
}

.data   { font-family: verdana; font-size: 9pt; text-decoration: none; }

.user-data   { font-family: verdana; font-size: 10pt; text-decoration: none; }

.user-data-column { font-family: verdana; font-size: 10pt; text-decoration: none; font-weight: bold; }

</style>
</head>

<body>
<table width="778" height="100%" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#4074AD" >
  <tr>
    <td height="154" align="left" valign="top"><table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td colspan="3" bgcolor="#4074AD"></td>
      </tr>
      <tr>
        <td colspan="3" bgcolor="#9FC0DF"><div align="center"><span class="main_logo style2"><strong>Accounts Centre</strong></span></div></td>
      </tr>
      <tr>
        <td width="3%" valign="top"></td>
        <td width="95%" valign="top"><table width="100%"  border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td valign="top" class="data">Dear Customer <span class="user-data-column"><xsl:value-of select='/EmailTemplate/Name'></xsl:value-of></span></td>
          </tr>
          <tr>
            <td class="data">Thank you for subscription/renewal for the valuable service(s) with Accounts Centre.<br/></td>
          </tr>
	<tr>
	  <td class="data">Service provided to you by formationshouse. <br/>
	</td>
	</tr>
          <br/>
          <!--WEB SERVICES-->
          <xsl:if test="$WebServicesList != '' "> <br/>
          <tr>
            <td class="data"> This is to inform you that following service(s) has been enabled to your company by Accounts Centre:<br/>
                <br/>
            </td>
          </tr>
          <tr>
            <td class="user-data-column"> <xsl:for-each select='//EmailTemplate/WebApplication/List'> 
              <li><xsl:value-of select="."></xsl:value-of></li>
              <br/>
              </xsl:for-each> <br/>
            </td>
          </tr>
          <tr>
            <td class="data">
              <!--Login-->
				To access your subscribed web service(s) please click <br/>
                <br/>
                <a href="https://www.accountscentre.com/account/signin.aspx" >https://www.accountscentre.com/account/signin.aspx</a><br/>
                <br/>
            </td>
          </tr>
          </xsl:if>
          
          
           <xsl:if test="$DesktopApplicationList != '' ">
          
          <tr>
            <td>
				<xsl:for-each select='//EmailTemplate/DesktopApplication/List'> <b>
				<li><xsl:value-of select="."></xsl:value-of></li>
				</b><br/>
				</xsl:for-each>
			 </td>
				<br/>
          </tr>
          <tr>
            <td>
				 <!--DESKTOP SERVICES-->
				<br/>
				 To download desktop application, please click the link below;<br/>
				<br/>
				<a href ="https://www.accountscentre.com/members/downloads.aspx">http://www.accountscentre.com/members/downloads.aspx</a> <br/>
				<br/>
            </td>
		</tr>
          </xsl:if>
      
          <tr>
            <td>
              <table border ="1" bordercolor ="Black" width ="100%" id="table4" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                <tr>
                  <td bgcolor ="#D4D0C8">
                    <table width="50%" align="left">
                      <tr>
                        <td width="21%" class="user-data-column">Name:</td>
                        <td width="79%" class="user-data"><xsl:value-of select='/EmailTemplate/Name'></xsl:value-of></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td bgcolor ="#D4D0C8">
                    <table width="50%" align="left">
                      <tr>
                        <td width="21%" class="user-data-column">User ID:</td>
                        <td width="79%" class="user-data"><xsl:value-of select='/EmailTemplate/LoginID'></xsl:value-of></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td bgcolor ="#D4D0C8">
                    <table width="50%" align="left">
                      <tr>
                        <td width="21%" class="user-data-column">Password:</td>
                        <td width="79%" class="user-data"><xsl:value-of select='/EmailTemplate/Password'></xsl:value-of></td>
                      </tr>
                  </table></td>
                </tr>
                <tr>
                  <td bgcolor ="#D4D0C8">
                    <table width="50%" align="left">
                      <xsl:for-each select='//EmailTemplate/Address/List'>
                      <tr> <xsl:if test="position() = 1 " >
                        <td width ="21%"><span class="user-data-column">Address:</span></td>
                        <td width="79%" class="user-data"><xsl:value-of select='.'></xsl:value-of></td>
                        </xsl:if> <xsl:if test="position() > 1 " >
                        <td width ="21%"></td>
                        <td width="79%" class="user-data"><xsl:value-of select='.'></xsl:value-of></td>
                      </xsl:if> </tr>
                      </xsl:for-each>
                  </table></td>
                </tr>
                <tr>
                  <td bgcolor ="#D4D0C8">
                    <table width="50%" align="left">
                      <tr>
                        <td width="21%" class="user-data-column">Phone No:</td>
                        <td width="79%" class="user-data"><xsl:value-of select='/EmailTemplate/Phone'></xsl:value-of></td>
                      </tr>
                  </table></td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <td>
              <table id="table5">
                <tr>
                  <td class="data"><br/>
                    <!--Footer-->
            For further information and assistance regarding our service(s)<br/>
                                                <br/>
            email: support@accountscentre.com

                  </td>
                </tr>
            </table></td>
          </tr>
          <tr>
            <td valign="top"></td>
          </tr>
          <tr>
            <td valign="top"></td>
          </tr>
          <tr>
            <td valign="top"></td>
          </tr>
        </table></td>
        <td width="2%" valign="top"></td>
      </tr>
    </table></td>
  </tr>
</table>
</body>
</html>
    </xsl:template>
</xsl:stylesheet>
