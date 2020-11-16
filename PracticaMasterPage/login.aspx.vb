
Partial Class login
    Inherits System.Web.UI.Page


    Protected Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If tb_usuario.Text = "" Or tb_contra.Text = "" Then
            lb_estado.Text = "Inténtelo de nuevo"
        Else
            FormsAuthentication.RedirectFromLoginPage(tb_usuario.Text, chk_recordar.Checked)
        End If
    End Sub
End Class
