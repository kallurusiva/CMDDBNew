<%@ Page Language="C#" MasterPageFile="~/O_MasterBlue.master" AutoEventWireup="true" CodeFile="O_dt_User_EditMobile.aspx.cs" Inherits="O_dt_User_EditMobile" %>
<%@ Register Src="~/O_FooterBlue.ascx" TagPrefix="uc1" TagName="O_FooterBlue" %>
<%@ Register Src="~/O_LeftBlue.ascx" TagPrefix="uc1" TagName="O_LeftBlue" %>
<%@ Register Src="~/O_topBlue.ascx" TagPrefix="uc1" TagName="O_topBlue" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTopMenu" runat="Server">
    <uc1:O_topBlue runat="server" ID="O_topBlue" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderRight" runat="Server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>

    <div class="main" runat="server">
        <div class="container-fluid" runat="server">
            <div class="row" runat="server">
                <div class="col-md-9 col-md-push-3" runat="server">
                    <div class="row">

                            <div class="mb40 visible-xs"></div>
                            <div class="col-sm-12">
                                <h2>Edit Mobile</h2>

                                <div class="table-responsive">
                                    <table class="table table-bordered bankinform-table">
                                        <tbody> 
                                             <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Current Mobile</b></td>
                                                <td class="">
                                                     <asp:Label ID="lblMobile" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:Label>
                                                </td>
                                            </tr>

                                             <tr>
                                                <td class="bg-custom" style="width: 368px"><b>Enter New Mobile</b></td>
                                                <td class="">
                                                    <asp:DropDownList runat="server" ID="ctryCode">
                                                        <asp:ListItem Value="a">a</asp:ListItem>
                                                        <asp:ListItem value="">Select Country</asp:ListItem>
						                                <asp:ListItem value="93">Afghansitan-(93)</asp:ListItem>
						                                <asp:ListItem value="355">Alabana-(355)</asp:ListItem>
						                                <asp:ListItem value="213">Algeria-(213)</asp:ListItem>
						                                <asp:ListItem value="684">American Samoa-(684)</asp:ListItem>
						                                <asp:ListItem value="376">Andorra-(376)</asp:ListItem>
						                                <asp:ListItem value="54">Argentina-(54)</asp:ListItem>
						                                <asp:ListItem value="374">Armenia-(374)</asp:ListItem>
						                                <asp:ListItem value="297">Aruba-(297)</asp:ListItem>
						                                <asp:ListItem value="247">Ascension Land-(247)</asp:ListItem>
						                                <asp:ListItem value="61">Australia-(61)</asp:ListItem>
						                                <asp:ListItem value="43">Austria-(43)</asp:ListItem>
						                                <asp:ListItem value="994">Azerbaijan-(994)</asp:ListItem>
						                                <asp:ListItem value="973">Bahrain-(973)</asp:ListItem>
						                                <asp:ListItem value="880">Bangladesh-(880)</asp:ListItem>
						                                <asp:ListItem value="32">Belgium-(32)</asp:ListItem>
						                                <asp:ListItem value="501">Belize-(501)</asp:ListItem>
						                                <asp:ListItem value="229">Benin-(229)</asp:ListItem>
						                                <asp:ListItem value="975">Bhutan-(975)</asp:ListItem>
						                                <asp:ListItem value="591">Bolivia-(591)</asp:ListItem>
						                                <asp:ListItem value="387">Bosnia-(387)</asp:ListItem>
						                                <asp:ListItem value="267">botswana-(267)</asp:ListItem>
						                                <asp:ListItem value="55">Brazil-(55)</asp:ListItem>
						                                <asp:ListItem value="673">Brunei-(673)</asp:ListItem>
						                                <asp:ListItem value="359">Bulgaria-(359)</asp:ListItem>
						                                <asp:ListItem value="226">Burkina Faso-(226)</asp:ListItem>
						                                <asp:ListItem value="257">Burundi-(257)</asp:ListItem>
						                                <asp:ListItem value="855">Cambodia-(855)</asp:ListItem>
						                                <asp:ListItem value="237">Cameroon-(237)</asp:ListItem>
						                                <asp:ListItem value="235">Chad-(235)</asp:ListItem>
						                                <asp:ListItem value="56">Chile-(56)</asp:ListItem>
						                                <asp:ListItem value="86">China (PRC)-(86)</asp:ListItem>
						                                <asp:ListItem value="269">Colombia-(269)</asp:ListItem>
						                                <asp:ListItem value="242">Congo-(242)</asp:ListItem>
						                                <asp:ListItem value="682">Cook Islands-(682)</asp:ListItem>
						                                <asp:ListItem value="506">Costa Rica-(506)</asp:ListItem>
						                                <asp:ListItem value="385">Croatia-(385)</asp:ListItem>
						                                <asp:ListItem value="53">Cuba-(53)</asp:ListItem>
						                                <asp:ListItem value="357">Cyprus-(357)</asp:ListItem>
						                                <asp:ListItem value="420">Czech Republic-(420)</asp:ListItem>
						                                <asp:ListItem value="246">Deigo Garicia-(246)</asp:ListItem>
						                                <asp:ListItem value="45">Denmark-(45)</asp:ListItem>
						                                <asp:ListItem value="253">Djibouti-(253)</asp:ListItem>
						                                <asp:ListItem value="593">Ecuador-(593)</asp:ListItem>
						                                <asp:ListItem value="20">Egypt-(20)</asp:ListItem>
						                                <asp:ListItem value="503">El Salvador-(503)</asp:ListItem>
						                                <asp:ListItem value="24">Equatorial Guinea-(24)</asp:ListItem>
						                                <asp:ListItem value="291">Eritrea-(291)</asp:ListItem>
						                                <asp:ListItem value="372">Estonia-(372)</asp:ListItem>
						                                <asp:ListItem value="251">Ethiopia-(251)</asp:ListItem>
						                                <asp:ListItem value="298">Faeroe Islands-(298)</asp:ListItem>
						                                <asp:ListItem value="500">Falkland Islands-(500)</asp:ListItem>
						                                <asp:ListItem value="679">Fiji Islands-(679)</asp:ListItem>
						                                <asp:ListItem value="358">Finland-(358)</asp:ListItem>
						                                <asp:ListItem value="33">France-(33)</asp:ListItem>
						                                <asp:ListItem value="594">French Guinana-(594)</asp:ListItem>
						                                <asp:ListItem value="689">French Polynesia-(689)</asp:ListItem>
						                                <asp:ListItem value="241">Gabon-(241)</asp:ListItem>
						                                <asp:ListItem value="220">Gambia-(220)</asp:ListItem>
						                                <asp:ListItem value="995">Georgia-(995)</asp:ListItem>
						                                <asp:ListItem value="49">Germany-(49)</asp:ListItem>
						                                <asp:ListItem value="233">Ghana-(233)</asp:ListItem>
						                                <asp:ListItem value="350">Gibraltar-(350)</asp:ListItem>
						                                <asp:ListItem value="30">Greece-(30)</asp:ListItem>
						                                <asp:ListItem value="299">Greenland-(299)</asp:ListItem>
						                                <asp:ListItem value="224">Guinea (PRP)-(224)</asp:ListItem>
						                                <asp:ListItem value="245">Guinea-Bissau-(245)</asp:ListItem>
						                                <asp:ListItem value="852">HongKong-(852)</asp:ListItem>
						                                <asp:ListItem value="36">Hungary-(36)</asp:ListItem>
						                                <asp:ListItem value="354">Iceland-(354)</asp:ListItem>
						                                <asp:ListItem value="91">India-(91)</asp:ListItem>
						                                <asp:ListItem value="62">Indonesia-(62)</asp:ListItem>
						                                <asp:ListItem value="870">Inmarsat SNAC-(870)</asp:ListItem>
						                                <asp:ListItem value="98">Iran-(98)</asp:ListItem>
						                                <asp:ListItem value="964">Iraq-(964)</asp:ListItem>
						                                <asp:ListItem value="353">Ireland-(353)</asp:ListItem>
						                                <asp:ListItem value="972">Israel-(972)</asp:ListItem>
						                                <asp:ListItem value="39">Italy-(39)</asp:ListItem>
						                                <asp:ListItem value="1876">Jamaica-(1876)</asp:ListItem>
						                                <asp:ListItem value="81">Japan-(81)</asp:ListItem>
						                                <asp:ListItem value="962">Jordan-(962)</asp:ListItem>
						                                <asp:ListItem value="254">Kenya-(254)</asp:ListItem>
						                                <asp:ListItem value="686">Kiribati-(686)</asp:ListItem>
						                                <asp:ListItem value="850">Korea North-(850)</asp:ListItem>
						                                <asp:ListItem value="82">Korea South-(82)</asp:ListItem>
						                                <asp:ListItem value="965">Kuwait-(965)</asp:ListItem>
						                                <asp:ListItem value="856">Laos-(856)</asp:ListItem>
						                                <asp:ListItem value="371">Latvia-(371)</asp:ListItem>
						                                <asp:ListItem value="961">Lebanon-(961)</asp:ListItem>
						                                <asp:ListItem value="266">Lesotho-(266)</asp:ListItem>
						                                <asp:ListItem value="231">Liberia-(231)</asp:ListItem>
						                                <asp:ListItem value="218">Libya-(218)</asp:ListItem>
						                                <asp:ListItem value="423">Liechtenstein-(423)</asp:ListItem>
						                                <asp:ListItem value="370">Lithuania-(370)</asp:ListItem>
						                                <asp:ListItem value="352">Luxembourg-(352)</asp:ListItem>
						                                <asp:ListItem value="853">Macau-(853)</asp:ListItem>
						                                <asp:ListItem value="389">Macedonia-(389)</asp:ListItem>
						                                <asp:ListItem value="261">Madagascar-(261)</asp:ListItem>
						                                <asp:ListItem value="265">Malawi-(265)</asp:ListItem>
						                                <asp:ListItem selected="selected" value="60">Malaysia-(60)</asp:ListItem>
						                                <asp:ListItem value="960">Maldives-(960)</asp:ListItem>
						                                <asp:ListItem value="223">Mali Republic-(223)</asp:ListItem>
						                                <asp:ListItem value="356">Malta-(356)</asp:ListItem>
						                                <asp:ListItem value="596">Martinique-(596)</asp:ListItem>
						                                <asp:ListItem value="222">Marutania-(222)</asp:ListItem>
						                                <asp:ListItem value="230">Mauritius-(230)</asp:ListItem>
						                                <asp:ListItem value="52">Mexico-(52)</asp:ListItem>
						                                <asp:ListItem value="976">Mongolia-(976)</asp:ListItem>
						                                <asp:ListItem value="212">Morocco-(212)</asp:ListItem>
						                                <asp:ListItem value="258">Mozambique-(258)</asp:ListItem>
						                                <asp:ListItem value="95">Myanmar-(95)</asp:ListItem>
						                                <asp:ListItem value="264">Namibia-(264)</asp:ListItem>
						                                <asp:ListItem value="674">Nauru-(674)</asp:ListItem>
						                                <asp:ListItem value="977">Nepal-(977)</asp:ListItem>
						                                <asp:ListItem value="31">Netherlands-(31)</asp:ListItem>
						                                <asp:ListItem value="64">New Zealand-(64)</asp:ListItem>
						                                <asp:ListItem value="505">Nicaragua-(505)</asp:ListItem>
						                                <asp:ListItem value="227">Niger-(227)</asp:ListItem>
						                                <asp:ListItem value="234">Nigeria-(234)</asp:ListItem>
						                                <asp:ListItem value="683">Niue-(683)</asp:ListItem>
						                                <asp:ListItem value="672">Norfolk Island-(672)</asp:ListItem>
						                                <asp:ListItem value="47">Norway-(47)</asp:ListItem>
						                                <asp:ListItem value="968">Oman-(968)</asp:ListItem>
						                                <asp:ListItem value="92">Pakistan-(92)</asp:ListItem>
						                                <asp:ListItem value="680">Palau-(680)</asp:ListItem>
						                                <asp:ListItem value="970">Palestine-(970)</asp:ListItem>
						                                <asp:ListItem value="507">Panama-(507)</asp:ListItem>
						                                <asp:ListItem value="595">Paraguay-(595)</asp:ListItem>
						                                <asp:ListItem value="51">Peru-(51)</asp:ListItem>
						                                <asp:ListItem value="63">Philippines-(63)</asp:ListItem>
						                                <asp:ListItem value="48">Poland-(48)</asp:ListItem>
						                                <asp:ListItem value="351">Portugal-(351)</asp:ListItem>
						                                <asp:ListItem value="974">Qatar-(974)</asp:ListItem>
						                                <asp:ListItem value="262">Reunion Island-(262)</asp:ListItem>
						                                <asp:ListItem value="40">Romania-(40)</asp:ListItem>
						                                <asp:ListItem value="7">Russia-(7)</asp:ListItem>
						                                <asp:ListItem value="250">Rwanda-(250)</asp:ListItem>
						                                <asp:ListItem value="378">San Marino-(378)</asp:ListItem>
						                                <asp:ListItem value="966">Saudi Arabia-(966)</asp:ListItem>
						                                <asp:ListItem value="221">Senegal-(221)</asp:ListItem>
						                                <asp:ListItem value="248">Seychelles Islands-(248)</asp:ListItem>
						                                <asp:ListItem value="232">Sierra Leone-(232)</asp:ListItem>
						                                <asp:ListItem value="65">Singapore-(65)</asp:ListItem>
						                                <asp:ListItem value="421">Slovak Republic-(421)</asp:ListItem>
						                                <asp:ListItem value="386">Slovenia-(386)</asp:ListItem>
						                                <asp:ListItem value="677">Soloman Islands-(677)</asp:ListItem>
						                                <asp:ListItem value="252">Somalia-(252)</asp:ListItem>
						                                <asp:ListItem value="27">South Africa-(27)</asp:ListItem>
						                                <asp:ListItem value="34">Spain-(34)</asp:ListItem>
						                                <asp:ListItem value="94">Sri Lanka-(94)</asp:ListItem>
						                                <asp:ListItem value="249">Sudan-(249)</asp:ListItem>
						                                <asp:ListItem value="597">Suriname-(597)</asp:ListItem>
						                                <asp:ListItem value="268">Swaziland-(268)</asp:ListItem>
						                                <asp:ListItem value="46">Sweden-(46)</asp:ListItem>
						                                <asp:ListItem value="41">Switzerland-(41)</asp:ListItem>
						                                <asp:ListItem value="963">Syria-(963)</asp:ListItem>
						                                <asp:ListItem value="886">Taiwan-(886)</asp:ListItem>
						                                <asp:ListItem value="992">Tajikistan-(992)</asp:ListItem>
						                                <asp:ListItem value="255">Tanzania-(255)</asp:ListItem>
						                                <asp:ListItem value="66">Thailand-(66)</asp:ListItem>
						                                <asp:ListItem value="676">Tonga Islands-(676)</asp:ListItem>
						                                <asp:ListItem value="228">Toto-(228)</asp:ListItem>
						                                <asp:ListItem value="216">Tunisia-(216)</asp:ListItem>
						                                <asp:ListItem value="90">Turkey-(90)</asp:ListItem>
						                                <asp:ListItem value="993">Turkmeistan-(993)</asp:ListItem>
						                                <asp:ListItem value="688">Tuvalu-(688)</asp:ListItem>
						                                <asp:ListItem value="971">UAE-(971)</asp:ListItem>
						                                <asp:ListItem value="256">Uganda-(256)</asp:ListItem>
						                                <asp:ListItem value="380">Ukraine-(380)</asp:ListItem>
						                                <asp:ListItem value="44">United Kingdom-(44)</asp:ListItem>
						                                <asp:ListItem value="598">Uruguay-(598)</asp:ListItem>
						                                <asp:ListItem value="1">USA-(1)</asp:ListItem>
						                                <asp:ListItem value="998">Uzbekistan-(998)</asp:ListItem>
						                                <asp:ListItem value="678">Vanuatu-(678)</asp:ListItem>
						                                <asp:ListItem value="58">Venezuela-(58)</asp:ListItem>
						                                <asp:ListItem value="84">Vietnam-(84)</asp:ListItem>
						                                <asp:ListItem value="685">Western Samoa-(685)</asp:ListItem>
						                                <asp:ListItem value="967">Yemen-(967)</asp:ListItem>
						                                <asp:ListItem value="381">Yugoslavia-(381)</asp:ListItem>
						                                <asp:ListItem value="260">Zambia-(260)</asp:ListItem>
						                                <asp:ListItem value="263">Zimbabwe-(263)</asp:ListItem>
                                                    </asp:DropDownList>
                                                     <asp:TextBox ID="txtcMobile" runat="server" CssClass="form-control input-sm" ValidationGroup="VgCheck"></asp:TextBox>
                                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtcMobile" ValidationGroup="VgCheck"  runat="server" CssClass="text-custom" ErrorMessage="Mobile cannot be Empty" style="color: #CC0000"></asp:RequiredFieldValidator>

                                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator5" Display="Dynamic" CssClass="text-custom" 
                          runat="server" ValidationExpression="^[1-9]\d*$" ControlToValidate="txtcMobile" ValidationGroup="VgCheck" 
                          ErrorMessage=" <br/>Invalid Mobile No. format. <br/>Cannot start with zero or (+) Plus sign." style="color: #CC0000"></asp:RegularExpressionValidator>
                                                    <br />
                                                    <span style="color: #0000FF">Cannot start with zero <br />
                                                    Country Code No need to Enter<br /><br />

                                                    Example : If Malaysia  - MobileNo is 0162531066  - Enter  162531066<br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Indonesia – Mobile No is 08168888 888   Enter 8168888 888   <br />
                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Singapore – Mobile No is 97366823  Enter 97366823   <br /><br />  

                                                    Note - No need to enter CountryCode - Just select your country</span>
                                                </td>
                                            </tr>

                                             
                                        </tbody>

                                    </table>
                                </div>
                            </div>
                        </div>
                    <div class="row">
                            <div class="col-xs-12 col-lg-12">

                                <div class="text-right">

                                    <asp:Button ID="BtnSubmit" runat="server" ValidationGroup="VgCheck" CssClass="btn btn-custom min-width" Text="Update Now" OnClick="BtnSubmit_Click" />
                                    
                                </div>
                            </div>
                        </div>
                </div>

                

                <div class="mb30 visible-sm visible-xs clearfix" runat="server"></div>
                <uc1:O_LeftBlue runat="server" ID="O_LeftBlue" />
            </div>            
        </div>
        <div class="mb170 mb50-sm" runat="server"></div>
    </div>
    <uc1:O_FooterBlue runat="server" ID="O_FooterBlue" />
                                                
</asp:Content>

