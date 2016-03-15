<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<%--    <!DOCTYPE html>
<html>
<head>
<script type="text/javascript">
    function change() {
        var t1Val = (document.getElementById("t1")).value;
        (document.getElementById("t2")).value = ((t1Val * 2) / 3);
    };
</script>
</head>
<body>

<input id="t1" type="text" onchange="change()"/>
<input id="t2" type="text"/>

</body>
</html>--%>


    <table>
        <tr>
            <td colspan="2">
                <h1>
                    Registraion From
                </h1>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_name" runat="server" OnTextChanged="txt_name_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="SurName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_surname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="UserName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_username" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_password" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="ConfromPassword"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_confrompassword" runat="server" Height="22px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Gender"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rb_gender" runat="server">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Country"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_country" runat="server">
                    <asp:ListItem>Select</asp:ListItem>
                    <asp:ListItem>India</asp:ListItem>
                    <asp:ListItem>Pakistan</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td>
        Hobby
        </td>
            <td>
                <asp:CheckBoxList ID="cb_hobby" runat="server" DataTextField="hobby" DataValueField="intglcode"
                    RepeatDirection="Horizontal">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btn_submit" runat="server" Text="Submit" OnClick="btn_submit_Click"
                    Width="61px" />
                <asp:Button ID="btn_update" runat="server" Text="update" OnClick="byn_update_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="5" DataKeyNames="code" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing">
                    <Columns>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Button" />
                        <asp:CommandField HeaderText="Edit" ShowEditButton="true" ButtonType="Button" />
                        <asp:BoundField HeaderText="Name" DataField="name" />
                        <asp:BoundField HeaderText="SurName" DataField="surname" />
                        <asp:BoundField HeaderText="UserName" DataField="username" />
                        <asp:BoundField HeaderText="Password" DataField="password" />
                        <asp:BoundField HeaderText="Gender" DataField="gender" />
                        <asp:BoundField HeaderText="Country" DataField="country" />
                        <asp:BoundField HeaderText="Hobby" DataField="hobby" />
                        <asp:BoundField HeaderText="Active" DataField="active" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument='<%#Eval("code") %>'>Active/Deactive</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" DataKeyNames="code">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="name" />
                        <asp:BoundField HeaderText="Password" DataField="password" />
                        <asp:BoundField HeaderText="UserName" DataField="username" />
                        <asp:BoundField HeaderText="Password" DataField="password" />
                        <asp:BoundField HeaderText="Gender" DataField="gender" />
                        <asp:BoundField HeaderText="Country" DataField="country" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <%-- <tr>
            <td>
                <div class="sidebar">
                    <p style="padding-top: 1px; font-weight: bold; color: #c1a775; font-size: 16px;">
                        News
                    </p>
                    <br />
                    <marquee direction="up" behavior="scroll" scrollamount="2" onmouseover="this.stop();"
                        onmouseout="this.start();">
                        <asp:DataList ID="dtlistnews" runat="server" DataKeyField="code" CellSpacing="15">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnk_news" Text='<%#Eval("title") %>' runat="server" OnClick="lnk_news_click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:DataList>
                    </marquee>
                </div>
            </td>
        </tr>--%>
    </table>
</asp:Content>

<%--//---------------------------------------Save Images Print---------------------------------------//--%>

<%-- <td>
                                                <asp:button id="Button1" runat="server" text="Invoice Image" onclientclick="javascript:CallPrint('bill');"
                                                    xmlns:asp="#unknown" />
                                            </td>--%>



 <%--<script language="javascript" type="text/javascript">
     function CallPrint(strid) {
         var prtContent = document.getElementById(strid);
         var WinPrint = window.open('', '', 'letf=0,top=0,width=800,height=1000,toolbar=0,scrollbars=0,status=0,dir=ltr');
         WinPrint.document.write(prtContent.innerHTML);
         WinPrint.document.close();
         WinPrint.focus();
         WinPrint.print();
         WinPrint.close();
         prtContent.innerHTML = strOldOne;
     }
    </script>--%>
<%--//----------------------------------------End----------------------------------------------//--%>





