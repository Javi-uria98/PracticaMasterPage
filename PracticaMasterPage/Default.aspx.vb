Imports System.Data
Imports System.IO

Partial Class _Default
    Inherits System.Web.UI.Page

    Public listaNombres As New List(Of String)
    Public resto As Integer
    Public caracteres As String
    Public listaComunidadesFichero As New List(Of String)

    Private Property Ficha As Integer
        Get
            Return (CType(Me.ViewState("Ficha"), Integer?)).GetValueOrDefault()
        End Get
        Set(ByVal value As Integer)
            Me.ViewState("Ficha") = value
        End Set
    End Property


    Private Sub _Default_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Me.Master.Label = Now
        End If

        AddHandler(Master.ImageButton.Click), AddressOf ImageButton_Click

        AddHandler(Master.LinkButton.Click), AddressOf LinkButton_Click

        AddHandler(Master.Button.Click), AddressOf Button_Click

    End Sub

    Protected Sub ImageButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Image1.Width = 600
        If Image1.Visible = False Then
            Image1.Visible = True
        Else
            Image1.Visible = False
        End If

    End Sub

    Protected Sub LinkButton_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("PaginaLinkButton.aspx?valorlabel=" + Me.Master.Label)
    End Sub

    Protected Sub Button_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Label2.Text = Master.Label
        If Panel1.Visible = False Then
            Panel1.Visible = True
        Else
            Panel1.Visible = False
        End If
    End Sub


    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        calcularLetraDni(CType(txt_dni.Text, Integer))

        MsgBox("Se ha generado el txt")

        Using sw As StreamWriter = New StreamWriter("C:\Users\Javi\Desktop\archivoprueba2.txt", True)
            Dim nombre As String = "Nombre: " & txt_nombre.Text
            Dim apellidos As String = "Apellidos: " & txt_apellidos.Text
            Dim dni As String = "Dni: " & txt_dni.Text & lb_letra.Text
            Dim telefono As String = "Telefono: " & txt_telefono.Text
            Dim comunidad As String = "Comunidad: " & lista_comunidades.SelectedValue.ToString
            Dim email As String = "Email: " & txt_email.Text

            Dim final() As String = {nombre & " ", apellidos & " ", dni & " ", telefono & " ", comunidad & " ", email}

            For i = 0 To UBound(final)
                sw.WriteLine(final.GetValue(i))
            Next
            sw.WriteLine()
        End Using
    End Sub

    Public Sub calcularLetraDni(ByVal dni As Integer)
        caracteres = "TRWAGMYFPDXBNJZSQVHLCKE"
        resto = dni Mod 23
        lb_letra.Text = caracteres.Chars(resto)

    End Sub

    Protected Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        ClearTextBox(Me)
    End Sub

    Public Sub ClearTextBox(ByVal root As Control)
        For Each ctrl As Control In root.Controls
            ClearTextBox(ctrl)
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            ElseIf TypeOf ctrl Is DropDownList Then
                CType(ctrl, DropDownList).SelectedIndex = 0
            ElseIf TypeOf ctrl Is Label Then
                If ctrl Is lb_letra Then
                    lb_letra.Text = ""
                End If
            End If
        Next ctrl
    End Sub

    Protected Sub btn_listado_Click(sender As Object, e As EventArgs) Handles btn_listado.Click
        Dim table1 As HtmlTable = New HtmlTable()

        table1.Border = 1
        table1.CellPadding = 3
        table1.CellSpacing = 3
        table1.BorderColor = "red"

        Dim lineas As String() = File.ReadAllLines("C:\Users\Javi\Desktop\archivoprueba2.txt")

        For i = 0 To UBound(lineas)
            If lineas(i).StartsWith("Nombre: ") Then
                listaNombres.Add(lineas(i) + " " + (lineas(i + 1)))
            End If
        Next


        Dim row As HtmlTableRow
        Dim cella As HtmlTableCell
        Dim cellb As HtmlTableCell

        Dim cont As Integer = 0


        For Each x As String In listaNombres
            cont = cont + 1
            row = New HtmlTableRow()

            cella = New HtmlTableCell()
            cellb = New HtmlTableCell()
            cella.InnerText = cont
            If (x.StartsWith("Nombre")) Then
                cellb.InnerText = x.Replace("Nombre:", "").Replace("Apellidos:", "")
            End If

            row.Cells.Add(cella)
            row.Cells.Add(cellb)

            table1.Rows.Add(row)
        Next

        Me.Controls.Add(table1)
    End Sub

    Protected Sub btn_siguiente_Click(sender As Object, e As EventArgs) Handles btn_siguiente.Click
        Dim lineas As String() = File.ReadAllLines("C:\Users\Javi\Desktop\archivoprueba2.txt")
        Try
            txt_nombre.Text = lineas(Me.Ficha).Replace("Nombre: ", "")
            txt_apellidos.Text = lineas(Me.Ficha + 1).Replace("Apellidos: ", "")
            txt_dni.Text = lineas(Me.Ficha + 2).Replace("Dni: ", "")
            txt_telefono.Text = lineas(Me.Ficha + 3).Replace("Telefono: ", "")
            lista_comunidades.SelectedItem.Text = lineas(Me.Ficha + 4).Replace("Comunidad: ", "")
            txt_email.Text = lineas(Me.Ficha + 5).Replace("Email: ", "")

            Me.Ficha = Me.Ficha + 7
        Catch ex As Exception

        End Try


    End Sub

    Protected Sub btn_anterior_Click(sender As Object, e As EventArgs) Handles btn_anterior.Click
        Dim lineas As String() = File.ReadAllLines("C:\Users\Javi\Desktop\archivoprueba2.txt")
        Try
            If (Me.Ficha > 0) Then
                txt_nombre.Text = lineas(Me.Ficha - 14).Replace("Nombre: ", "")
                txt_apellidos.Text = lineas(Me.Ficha - 13).Replace("Apellidos: ", "")
                txt_dni.Text = lineas(Me.Ficha - 12).Replace("Dni: ", "")
                txt_telefono.Text = lineas(Me.Ficha - 11).Replace("Telefono: ", "")
                lista_comunidades.SelectedItem.Text = lineas(Me.Ficha - 10).Replace("Comunidad: ", "")
                txt_email.Text = lineas(Me.Ficha - 9).Replace("Email: ", "")

                Me.Ficha = Me.Ficha - 7
            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
