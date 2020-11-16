Imports System.Data
Imports System.IO
Imports System.Data.SqlClient

Partial Class _Default
    Inherits System.Web.UI.Page

    Public listaNombres As New List(Of String)
    Public resto As Integer
    Public caracteres As String
    Public listaFilas As New List(Of String)

    Private Property Ficha As Integer
        Get
            Return (CType(Me.ViewState("Ficha"), Integer?)).GetValueOrDefault()
        End Get
        Set(ByVal value As Integer)
            Me.ViewState("Ficha") = value
        End Set
    End Property

    Private Property FichaSQL As Integer
        Get
            Return (CType(Me.ViewState("FichaSQL"), Integer?)).GetValueOrDefault()
        End Get
        Set(ByVal value As Integer)
            Me.ViewState("FichaSQL") = value
        End Set
    End Property

    Private Property Imagen As Integer
        Get
            Return (CType(Me.ViewState("Imagen"), Integer?)).GetValueOrDefault()
        End Get
        Set(value As Integer)
            Me.ViewState("Imagen") = value
        End Set
    End Property

    Private Property ImagenSQL As Integer
        Get
            Return (CType(Me.ViewState("ImagenSQL"), Integer?)).GetValueOrDefault()
        End Get
        Set(value As Integer)
            Me.ViewState("ImagenSQL") = value
        End Set
    End Property

    Private Property variableAnterior As Integer
        Get
            Return (CType(Me.ViewState("variableAnterior"), Integer?)).GetValueOrDefault()
        End Get
        Set(value As Integer)
            Me.ViewState("variableAnterior") = value
        End Set
    End Property

    Private Property variableAnteriorSQL As Integer
        Get
            Return (CType(Me.ViewState("variableAnteriorSQL"), Integer?)).GetValueOrDefault()
        End Get
        Set(value As Integer)
            Me.ViewState("variableAnteriorSQL") = value
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

        Try
            Using connection As New SqlConnection("Data Source=DESKTOP-KK3SAOI;Initial Catalog=ejercicios;User ID=ejercicios;Password=Becario2020")
                Dim insertStatement As String = "INSERT INTO tabla_formularios (Nombre, Apellidos, Dni, Telefono, Comunidad, Email)" _
         & "Values( @Nombre, @Apellidos, @Dni, @Telefono, @Comunidad, @Email) "
                Using insertcommand As New SqlCommand(insertStatement, connection)
                    connection.Open()
                    insertcommand.Parameters.AddWithValue("@Nombre", txt_nombre.Text)
                    insertcommand.Parameters.AddWithValue("@Apellidos", txt_apellidos.Text)
                    insertcommand.Parameters.AddWithValue("@Dni", txt_dni.Text & lb_letra.Text)
                    insertcommand.Parameters.AddWithValue("@Telefono", txt_telefono.Text)
                    insertcommand.Parameters.AddWithValue("@Comunidad", lista_comunidades.SelectedValue.ToString)
                    insertcommand.Parameters.AddWithValue("@Email", txt_email.Text)
                    insertcommand.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error mientras se insertaba valores en la tabla..." & ex.Message)
        End Try

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

        MsgBox("Se ha generado el txt")
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
                CType(ctrl, DropDownList).SelectedItem.Text = "Andalucía"
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
        If variableAnterior = 1 Then
            Me.Imagen = Me.Imagen + 1
            mostrarImagen(Me.Imagen)

            variableAnterior = 0
        End If

        Dim lineas As String() = File.ReadAllLines("C:\Users\Javi\Desktop\archivoprueba2.txt")
        Try
            txt_nombre.Text = lineas(Me.Ficha).Replace("Nombre: ", "")
            txt_apellidos.Text = lineas(Me.Ficha + 1).Replace("Apellidos: ", "")
            txt_dni.Text = lineas(Me.Ficha + 2).Replace("Dni: ", "")
            txt_telefono.Text = lineas(Me.Ficha + 3).Replace("Telefono: ", "")
            lista_comunidades.SelectedItem.Text = lineas(Me.Ficha + 4).Replace("Comunidad: ", "")
            txt_email.Text = lineas(Me.Ficha + 5).Replace("Email: ", "")


            Me.Ficha = Me.Ficha + 7
            If variableAnterior = 0 Then
                mostrarImagen(Me.Imagen)
                Me.Imagen = Me.Imagen + 1

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub btn_anterior_Click(sender As Object, e As EventArgs) Handles btn_anterior.Click
        Dim lineas As String() = File.ReadAllLines("C:\Users\Javi\Desktop\archivoprueba2.txt")
        Try
            If (Me.Ficha > 0) Then

                If variableAnterior = 0 Then
                    Me.Imagen = Me.Imagen - 2
                    variableAnterior = 1
                Else
                    Me.Imagen = Me.Imagen - 1
                End If

                If Me.Imagen < 0 Then
                    Me.Imagen = 0
                End If

                txt_nombre.Text = lineas(Me.Ficha - 14).Replace("Nombre: ", "")
                txt_apellidos.Text = lineas(Me.Ficha - 13).Replace("Apellidos: ", "")
                txt_dni.Text = lineas(Me.Ficha - 12).Replace("Dni: ", "")
                txt_telefono.Text = lineas(Me.Ficha - 11).Replace("Telefono: ", "")
                lista_comunidades.SelectedItem.Text = lineas(Me.Ficha - 10).Replace("Comunidad: ", "")
                txt_email.Text = lineas(Me.Ficha - 9).Replace("Email: ", "")
                mostrarImagen(Me.Imagen)

                Me.Ficha = Me.Ficha - 7

            End If
        Catch ex As Exception

        End Try
    End Sub


    Protected Sub btn_anteriorbbdd_Click(sender As Object, e As EventArgs) Handles btn_anteriorbbdd.Click
        Dim conexion As New SqlConnection("Data Source=DESKTOP-KK3SAOI;Initial Catalog=ejercicios;User ID=ejercicios;Password=Becario2020")
        conexion.Open()

        Dim cmd As New SqlCommand("Select Nombre, Apellidos, Dni, Telefono, Comunidad, Email From tabla_formularios Where (ID = " & (Me.FichaSQL) - 1 & ")", conexion)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Dim i As Integer = 0
        While dt.Columns.Count > i
            Try
                listaFilas.Add(dt.Rows(0).Item(i).ToString().Trim())
                Select Case i
                    Case 0
                        txt_nombre.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 1
                        txt_apellidos.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 2
                        txt_dni.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 3
                        txt_telefono.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 4
                        lista_comunidades.SelectedItem.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 5
                        txt_email.Text = dt.Rows(0).Item(i).ToString().Trim()
                End Select
                i = i + 1
            Catch ex As Exception
                MsgBox(ex.Message)
                Return
            End Try
        End While

        If variableAnteriorSQL = 0 Then
            Me.ImagenSQL = Me.ImagenSQL - 2
            variableAnteriorSQL = 1
        Else
            Me.ImagenSQL = Me.ImagenSQL - 1
        End If

        If Me.ImagenSQL < 0 Then
            Me.ImagenSQL = 0
        End If
        mostrarImagen(Me.ImagenSQL)

        Me.FichaSQL = Me.FichaSQL - 1

        conexion.Close()
    End Sub

    Protected Sub btn_siguientebbdd_Click(sender As Object, e As EventArgs) Handles btn_siguientebbdd.Click
        If variableAnteriorSQL = 1 Then
            Me.ImagenSQL = Me.ImagenSQL + 1
            mostrarImagen(Me.ImagenSQL)

            variableAnteriorSQL = 0
        End If

        Dim conexion As New SqlConnection("Data Source=DESKTOP-KK3SAOI;Initial Catalog=ejercicios;User ID=ejercicios;Password=Becario2020")
        conexion.Open()

        Dim cmd As New SqlCommand("Select Nombre, Apellidos, Dni, Telefono, Comunidad, Email From tabla_formularios Where (ID = " & (Me.FichaSQL) + 1 & ")", conexion)
        Dim dt As New DataTable
        dt.Load(cmd.ExecuteReader)
        Dim i As Integer = 0
        While dt.Columns.Count > i
            Try
                listaFilas.Add(dt.Rows(0).Item(i).ToString().Trim())
                Select Case i
                    Case 0
                        txt_nombre.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 1
                        txt_apellidos.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 2
                        txt_dni.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 3
                        txt_telefono.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 4
                        lista_comunidades.SelectedItem.Text = dt.Rows(0).Item(i).ToString().Trim()
                    Case 5
                        txt_email.Text = dt.Rows(0).Item(i).ToString().Trim()
                End Select
                i = i + 1
            Catch ex As Exception
                MsgBox("No hay más filas en la tabla de la base de datos")
                Return
            End Try
        End While
        If variableAnteriorSQL = 0 Then
            mostrarImagen(Me.ImagenSQL)
            Me.ImagenSQL = Me.ImagenSQL + 1

        End If

        Me.FichaSQL = Me.FichaSQL + 1

        conexion.Close()
    End Sub

    Protected Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        calcularLetraDni(CType(txt_dni.Text, Integer))

        Try
            Using connection As New SqlConnection("Data Source=DESKTOP-KK3SAOI;Initial Catalog=ejercicios;User ID=ejercicios;Password=Becario2020")
                Dim updateStatement As String = "UPDATE tabla_formularios SET Nombre = " & "'" & txt_nombre.Text & "', Apellidos = " & "'" & txt_apellidos.Text &
                    "', Dni = " & "'" & txt_dni.Text & lb_letra.Text & "', Telefono = " & "'" & txt_telefono.Text & "', Comunidad = " & "'" & lista_comunidades.SelectedItem.Text & "', Email = " & "'" & txt_email.Text & "' WHERE ID = " & (Me.FichaSQL) & "; "

                Using insertcommand As New SqlCommand(updateStatement, connection)
                    connection.Open()
                    insertcommand.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error mientras se insertaba valores en la tabla..." & ex.Message)
        End Try
    End Sub

    Protected Sub btn_gridview_Click(sender As Object, e As EventArgs) Handles btn_gridview.Click
        Response.Redirect("PaginaGridView.aspx")
    End Sub

    Protected Sub btn_upload_Click(sender As Object, e As EventArgs) Handles btn_upload.Click
        If FileUpload1.HasFile Then
            FileUpload1.SaveAs("C:\Users\Javi\source\repos\PracticaMasterPage\PracticaMasterPage\Images\" & FileUpload1.FileName)
            LabelUpload.Text = "Archivo subido: " & FileUpload1.FileName
        Else
            LabelUpload.Text = "No se ha subido ningún archivo."
        End If
    End Sub

    Protected Sub mostrarImagen(ByVal posicion As Integer)
        Dim dirs As String() = Directory.GetFiles("C:\Users\Javi\source\repos\PracticaMasterPage\PracticaMasterPage\Images\")
        Try
            Dim virtualPath As String = GetVirtualPath(dirs(posicion))
            Image2.ImageUrl = ResolveClientUrl(virtualPath)
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetVirtualPath(ByVal physicalPath As String) As String
        If Not physicalPath.StartsWith(HttpContext.Current.Request.PhysicalApplicationPath) Then
            Throw New InvalidOperationException("Physical path is not within the application root")
        End If

        Return "~/" & physicalPath.Substring(HttpContext.Current.Request.PhysicalApplicationPath.Length).Replace("\", "/")
    End Function
End Class
