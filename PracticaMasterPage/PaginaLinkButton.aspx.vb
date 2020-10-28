
Partial Class PaginaLinkButton
    Inherits System.Web.UI.Page

    Private Sub PaginaLinkButton_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.Master.Label = Request.QueryString("valorlabel")
            Label3.Text = Now
        End If


        Me.Master.ImageButton.Visible = False
        Me.Master.LinkButton.Visible = False
        Me.Master.Button.Visible = False

    End Sub
End Class
