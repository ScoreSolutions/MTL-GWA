<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ucHeader_Page.ascx.vb" Inherits="Template_ucHeader_Page" %>
<script src="../Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
<link href="../css/screen.css" media="screen" rel="stylesheet" type="text/css" />

<body topmargin="15">
<div id="header">
	<div>
	  <tr>
        <td class="Header" align="center" valign="bottom">
          &nbsp;
          </td>
       </tr>
  <ul class="menu1">		 
			<li><a href="http://www.boi.go.th/index.php?page=contactus" target="_blank" class="fontontop">ติดต่อบีโอไอ</a></li>		
	  <li class="dot"></li>	
			<li runat="server" id="linkHelp1"><a href="mannual/user.pdf" target="_blank" class="fontontop">ช่วยเหลือ</a></li>
			
			<%--<li class="dot"></li>
			<li><a href="logout.aspx">Logout</a></li>--%>
		</ul>
		
	</div>
</div>
</body>