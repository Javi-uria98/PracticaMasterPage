
Partial Class MasterPage
    Inherits System.Web.UI.MasterPage

    Public Property Label() As String
        Get
            Return Label1.Text

        End Get
        Set(ByVal value As String)
            Label1.Text = value

        End Set
    End Property

    Public ReadOnly Property ImageButton() As ImageButton
        Get
            Return ImageButton1
        End Get

    End Property

    Public ReadOnly Property LinkButton() As LinkButton
        Get
            Return LinkButton1
        End Get

    End Property

    Public ReadOnly Property Button() As Button
        Get
            Return Button1
        End Get
    End Property

End Class

