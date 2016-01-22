<%@ Page Language="VB" MasterPageFile="~/Template/ContentMasterPage.master" AutoEventWireup="false" CodeFile="frmClaimHealthClaim.aspx.vb" Inherits="WebApp_frmClaimHealthClaim" title="สินไหมประกันสุขภาพ(Health Claim)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table width="100%" border="0" cellpadding="2" cellspacing="0" >
        <tr>
            <td colspan="4" align="center" >
            <div class="mh">
            <div class="wrapFrameContent blue" id="line_actived">
                <table width="100%" border="0" cellpadding="0" cellspacing="0" height="300" >
                    <tr >
                        <td  colspan="4" align="center"  >
                            <asp:Label ID="lblFileList" runat="server" ></asp:Label>
                        </td>
                    </tr>
                    <tr><td colspan="4">&nbsp;</td></tr>
                </table> 
                  </div>
			</div>
            </td>
        </tr>
     </table>   
       
</asp:Content>