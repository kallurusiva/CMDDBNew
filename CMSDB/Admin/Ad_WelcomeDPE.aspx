<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster_DIY.master" AutoEventWireup="true" CodeFile="Ad_WelcomeDPE.aspx.cs" Inherits="Ad_WelcomeDPE" %>
<%@ Register Assembly="System.Web.DataVisualization,Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register src="../SuperAdmin/MyBarChart.ascx" tagname="MyBarChart" tagprefix="uc1" %>
<%@ Register src="LeftMenu_Welcome.ascx" tagname="LeftMenu_Welcome" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        
.RowHead1          {height:18px;  FONT-SIZE: 12px; text-decoration: underline; COLOR: #ED3B05; padding-left:30px; FONT-FAMILY: Arial, Helvetica, sans-serif; font-weight:bold;}
.RowContent1       {height:18px;  FONT-SIZE: 12px; COLOR: #ED3B05; padding-left:30px; FONT-FAMILY: Arial, Helvetica, sans-serif;}


.fntHeader		 {background-color: #C4E4C9; border-bottom: solid 1pt #D4DFAA; FONT-FAMILY: "Trebuchet MS",Helvetica, Verdana, Arial;
              		   color: #3F424E; font-size: 12px; padding-left: 10px; height:20px; 
              		   }
.fntValue		 {background-color: #F8F8D3; font-size: 14px; FONT-FAMILY: "Trebuchet MS",Helvetica, Verdana, Arial;  color: #4E5163;
         		  padding-left: 10px; height:27px; font-weight: bolder;
}

section {
            width: 100%;
            margin: auto;
            
           /* height: 200px;
            background: aqua;
            padding: 10px;*/
            
        }
        div#one {
            width: 20%;
            float: left;
             /*height: 200px;
            background: red; */
        }
        div#two {
            margin-left: 24%;
           /* height: 200px;
            background: black;*/
        }
        
        
                
      .dvQImages	 
      {
      	            padding: 5px; margin: 10px;
      	             border: solid 1px #CCCCCC;
      	              min-height: 75px; min-width: 100px;
                	  max-height: 100px; max-width:100px; vertical-align:middle;
              	   -webkit-border-radius: 8px;
				   -moz-border-radius: 8px;
				   border-radius: 8px;
				   background-color: #F6F0EC;
				     -moz-box-shadow:  2px 2px rgba(0, 0, 0, 0.3);
					-webkit-box-shadow: 2px 2px rgba(0, 0, 0, 0.3);
					box-shadow: 2px 2px rgba(0, 0, 0, 0.3);
				  
				   
			   }
			   
        .dvQImages img 
        {
        	display: block;
    margin-left: auto;
    margin-right: auto;}
    
			   
	.dvQImagesInfo	{ overflow:hidden; padding: 5px; margin: 10px;  border: solid 1px #CCCCCC; max-height: 100px; max-width: 100px; vertical-align: baseline;
	   -webkit-border-radius: 5px;
	   -moz-border-radius: 5px;
	   border-radius: 5px;
	   text-align: center;
	    background-color: #F6F0EC;
				     -moz-box-shadow:  2px 2px rgba(0, 0, 0, 0.3);
					-webkit-box-shadow: 2px 2px rgba(0, 0, 0, 0.3);
					box-shadow: 2px 2px rgba(0, 0, 0, 0.3);
	  
	}
	
        
        .stdtableborder1   {/* background-color:#F8FAFA;
                              border-radius: 9px;    -moz-border-radius: 9px; 	-webkit-border-radius: 9px;
                               BORDER-BOTTOM: #b8e0fb 1px solid; BORDER-LEFT: #b8e0fb 1px solid; BORDER-RIGHT: #b8e0fb 1px solid; BORDER-TOP: #b8e0fb 1px solid ;*/
                    		  FONT-SIZE: 12px; COLOR: #333333; FONT-FAMILY: Arial,Verdana, Helvetica, sans-serif;
                    		  }   
                    		  


        .style2
        {
            height: 17px;
        }
                    		  


        </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentLeftMenu" Runat="Server">
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    
    <script language="javascript" type="text/javascript">

    function fnOpenFPwindow(url, width, height) {
        //var width = "400";
        //var height = "300";

        var parameters = "width=" + width + ",height=" + height;
        //alert(parameters);
        parameters = parameters + "resizable=no,titlebar=no,locationbar=no,dependent=yes,left=150,top=150";
        window.open(url, "winFP", parameters);


    }
    
</script>
    <form id="form1" runat="server">
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
              
        <tr>
            <td align="center">
    <table cellpadding="0" cellspacing="0" border="0" width="98%">
        <tr>
            <td align="center">
                 <table cellpadding="0" cellspacing="0" width="98%" class="tblSubHeader">
                  <tr>
                        
                        <td width="96%" align="left" class="subHeaderFontGrad">
                            &nbsp; 
                            </td>
                        
                    </tr>
                 </table>
            </td>
        </tr>
        <tr>
            <td align="center">
           <table cellpadding="0" cellspacing="3" id="tblPlan" class="stdtableBorder_Main" width="100%" runat="server">
            <tr>
            <td width="2%"></td>
            <td width="96%"></td>
            <td width="2%"></td>
            </tr> 
           <%-- <tr>
            <td width="2%">&nbsp;</td>
            <td width="96%" class="subHeaderFontGrad">
                <asp:Literal ID="LtrWelcomePageTitle" runat="server" Text=""></asp:Literal> </td>
            <td width="2%">&nbsp;</td>
            </tr> --%>
            <tr>
            <td width="2%">&nbsp;</td>
            <td width="96%" class="">
              <section>
            <div id="one">
            
            <table cellpadding="1" cellspacing="1" class="stdtableborder1" width="100%">
            <tr>
                        <td width="1%">
                            &nbsp;</td>
                        <td width="32%" valign="top" align="left">
                           &nbsp;</td>
                        <td width="2%">
                            &nbsp;</td>
                    </tr>

                    
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td valign="top" align="left">
                            
                       <div id="dvProfile" style="overflow:hidden; min-width:240px;"  class="SummaryBoxCssWidth">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                        <%--  <asp:Button ID="btnDeleteAll" CssClass="stdbuttonAction" runat="server" OnClick="btnDeleteAll_Click" 
                                Text="Deleted Selected" />--%>
                        <td>
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="ltrWEB" Text="Profile" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td width="40%" >&nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td align="center" >
                             <asp:Image ID="ImgContact" BorderWidth="1px" BorderColor="#ACA9A9" Width="200" Height="200" runat="server" /> 
                         </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td>&nbsp;</td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td align="left" class="RowHead1">Login ID</td>
                    </tr>
                    
                    <tr >
                    <td class="RowContent1" align="left">
                            <asp:Label ID="lblLoginID" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                   
                    
                    <tr >
                    <td align="left">&nbsp;</td>
                    </tr>
                    
                   
                    
                    <tr >
                    <td class="RowHead1" align="left">Created Date</td>
                    </tr>
                    
                   
                    
                 <%--   <tr>
                    <td class="RowHead" align="left">User Type</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblUserType" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    
                    
                    <tr>
                    <td class="RowContent1" align="left">
                            <asp:Label ID="lblCreatedDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    
                    
                    <tr>
                    <td align="left">&nbsp;</td>
                    </tr>
                    
                    
                    <tr>
                    <td class="RowHead1" align="left">Mobile Number</td>
                    </tr>
                    <%--<tr>
                    <td class="RowHead" align="left">Domains</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <div id="dvOwnDomain" runat="server">
                            <span class="font_12Normal">OwnDomain :&nbsp;&nbsp;&nbsp; </span>
                            <br class="style2" />
                            <asp:Label ID="lblOwnDomainName" runat="server"></asp:Label>
                            <br />
                            <span class="font_12Normal">Domain Expiry Date :&nbsp;&nbsp;&nbsp; </span>
                            <br class="style2" />
                            <asp:Label ID="lblOwnDomainExpiryDate" CssClass="links_DomainName" runat="server"></asp:Label>
                            <br />
                            <br />
                            </div>
                            
                            <span class="font_12Normal">SubDomains:-</span><br />
                            <asp:Label ID="lblSubDomainName1" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblSubDomainName2" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td class="RowHead" align="left">Activated Pin No</td>
                    <td class="RowContent"> : </td>
                    <td class="RowContent" align="left">
                            <asp:Label ID="lblActivatedPinNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    --%>
                    <tr >
                    <td class="RowContent1" align="left">
                            <asp:Label ID="lblMobileNo" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                   
                    
                      </table>
         
        </div>
                            
                            
                           </td>
                        <td >
                            &nbsp;</td>
                    </tr>
                    

                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            &nbsp;</td>
                    </tr>
                 
                    
                </table>
            
            </div>
            <div id="two">
            <table cellpadding="1" cellspacing="1" class="stdtableborder1" width="100%">
 
                    
                    <tr>
                        <td width="1%">
                            &nbsp;</td>
                        <td width="32%" valign="top">
                            &nbsp;</td>
                        <td width="1%" valign="top">
                            &nbsp;</td>
                    </tr>

                    
                    <tr>
                        <td >
                            &nbsp;</td>
                        <td  valign="top" align="left">
                        
                    <%-- Quick Links --%>
                            
                    <div id="dvQuicklinks" style="overflow:hidden; min-width:100%;  min-height: 150px;"  class="SummaryBoxCssWidth">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
                       
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal3" Text="Quick Links" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td colspan="3" align="center">
            
                  
                  
                  <table border="0" cellpadding="0" cellspacing="0" class="stdtableborder1" >
                        <tr>
                        <td>
                            <asp:DataList ID="DLImageGallery" runat="server" RepeatColumns="6" 
                                RepeatDirection="Horizontal" Width="100%" >
                                
                                
                                 <ItemTemplate>
                                  
                                        <div id="dvgiImage" class="dvQImages"> 
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%# Eval("LinkURL")%>' runat="server">
                                        
                                            <asp:Image ID="Image1" runat="server" CssClass="giImage" ImageUrl = '<%# Eval("ImageURL")%>'                                            />
                                            </asp:HyperLink> 
                                            <%--<br />--%>
                                        </div>
                                        <div id="dvgiImageInfo" class="dvQImagesInfo">
                                            <asp:HyperLink ID="HyperLink1" CssClass="links_FuncLinks" Text='<%# Eval("LinkName")%>' NavigateUrl='<%# Eval("LinkURL")%>' runat="server"></asp:HyperLink> 
                                        </div>
                                           
                                           
                                           
                                        </div>
                                        
                                </ItemTemplate>
                                
                            </asp:DataList>
                        
                        </td>
                        </tr>
                        
                        </table>
                        
                        
                    
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
        
        <br />
          <%-- WebSite StatisTics Links --%>
                            
                    <div id="dvStatistics" style="overflow:hidden; min-width:100%"  class="SummaryBoxCssWidth">
        
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="loginBkg">
                    <tr>
               
                        <td colspan="3">
                        <div class="SummaryBoxheadOren">
                                    <div class="sideBoxheadText"> 
                                    <asp:Literal ID="Literal1" Text="Website Statistics" runat="server"></asp:Literal> </div>
                                </div>
                                </td>
                    </tr>
                    
                    <tr style="vertical-align:baseline;">
                    <td  align="center" colspan="3">
                    
                        <table id="tblChart">
                        <tr>
                        <td width="60%">&nbsp;</td>
                        <td width="40%">&nbsp;</td>
                        </tr>
                        
                        <tr>
                        <td>
                        
                            <asp:Chart ID="Chart1" runat="server" BackColor="WhiteSmoke" Palette="BrightPastel" ImageType="Png" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" Width="500px">
                               <titles>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Monthly Web Statistics" Alignment="MiddleCenter" ForeColor="26, 59, 105" Name="Title1"></asp:title>
								<asp:title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 7.25pt, style=Bold" ShadowOffset="3" Text="Shown for the last six months" Alignment="MiddleCenter" ForeColor="26, 59, 105" Name="Title2"></asp:title>
							</titles>
							<legends>
								<asp:legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" TitleFont="Microsoft Sans Serif, 8pt, style=Bold"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
                                <borderskin skinstyle="Emboss"></borderskin>
                                <Series>
                                    <asp:Series Name="Default" IsValueShownAsLabel="True" BorderColor="180, 26, 59, 105" CustomProperties="DrawingStyle=Cylinder">
                                    
                                    </asp:Series>
                                </Series>
                                <ChartAreas>
                                    <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White" BackColor="Gainsboro" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                                        <area3dstyle Enable3D="true" Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
                                        
									<%--<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>--%>
                                    </asp:ChartArea>
                                </ChartAreas>
                            </asp:Chart>
                        
                        </td>
                        <td style="vertical-align: top;">
                        
                       
                            <table style="width: 250px; padding-left: 20px;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="fntHeader">
                                        Total Visits till date</td>
                                </tr>
                                <tr>
                                    <td class="fntValue">
                                        <asp:Label ID="lblTotalVisits" CssClass="fntValue" runat="server" Text="Label"></asp:Label>
                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                
                                <tr>
                                    <td class="fntHeader">
                                        <asp:Literal ID="ltrThisMonthVisits" Text="" runat="server"></asp:Literal> </td>
                                </tr>
                                <tr>
                                    <td class="fntValue">
                                        <asp:Label ID="lblThisMonthVisits" CssClass="fntValue" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                 <tr>
                                    <td class="fntHeader">
                                        Last Logged in</td>
                                </tr>
                                <tr>
                                    <td class="fntValue">
                                        <asp:Label ID="lblLastLogin" CssClass="fntValue" runat="server" Text="Label"></asp:Label>
                                    
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        
                        
                        
                        
                        
                        </td>
                        </tr>
                        
                        <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        </tr>
                        
                        </table>
                    
                     
                        
                        
                        
                    </td>
                    </tr>
                    
                                        
                      </table>
         
        </div>
                            
                            
                            </td>
                        <td  valign="top" align="left">
                            
                            &nbsp;</td>
                    </tr>

                    

                
                    
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                        <td align="left">
                            &nbsp;</td>
                    </tr>
                 
                    
                </table>
            
            
            
            </div>
            </section>
            
          
            
            </td>
            <td width="2%">&nbsp;</td>
            </tr> 
            <tr>
                <td>&nbsp;</td>
             <td>
                
             </td>
             <td>&nbsp;</td>
             </tr>
            <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            </tr>
             </table>
             
             
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            </tr>
        </table>
                
        </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    
    
    
    </form>
</asp:Content>

