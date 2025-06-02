<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewFeedback.aspx.cs" Inherits="paperlab.ViewFeedback" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Feedback</title>
    <style>
        body {
            font-family: Arial;
            padding: 20px;
        }
        h2 {
            color: #333;
        }
        .grid-container {
            margin-top: 20px;s
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Submitted Feedback</h2>
        <div class="grid-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true"
                BorderColor="#CCCCCC" BorderStyle="Solid" GridLines="Both"
                CellPadding="6" HeaderStyle-BackColor="#f0f0f0" Width="100%">
            </asp:GridView>
                               <asp:Button ID="Edit" runat="server" Text="Edit Feedback" 
OnClick="btnViewEdit_Click" />

                               <asp:Button ID="Delete" runat="server" Text="Delete Feedback" 
OnClick="btnDelete_Click" />
        </div>
    </form>
</body>
</html>
