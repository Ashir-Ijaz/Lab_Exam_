<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="paperlab.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback Form</title>
    <style>
        .form-row {
            margin-bottom: 10px;
        }
        .label {
            display: inline-block;
            width: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 20px; max-width: 600px;">
            <h2>Feedback Form</h2>

            <div class="form-row">
                <asp:Label ID="Label1" runat="server" CssClass="label" Text="Feedback ID:" />
                <asp:TextBox ID="txtFeedbackID" runat="server" />
            </div>

            <div class="form-row">
                <asp:Label ID="Label5" runat="server" CssClass="label" Text="Student Name:" />
                <asp:TextBox ID="txtStudentName" runat="server" />
            </div>

            <div class="form-row">
                <asp:Label ID="Label2" runat="server" CssClass="label" Text="Course Name:" />
                <asp:TextBox ID="txtCourseName" runat="server" />
            </div>

            <div class="form-row">
                <asp:Label ID="Label7" runat="server" CssClass="label" Text="Comments:" />
                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="3" Columns="30" />
            </div>

            <div class="form-row">
                <asp:Label ID="Label6" runat="server" CssClass="label" Text="Phone:" />
                <asp:TextBox ID="txtPhone" runat="server" />
            </div>

            <div class="form-row">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="176px" OnClick="btnSubmit_Click" />
            </div>

            
           <asp:Button ID="btnViewFeedback" runat="server" Text="View Feedback" 
    OnClick="btnViewFeedback_Click" />

                   

        </div>
    </form>
</body>
</html>
