Imports DevComponents.DotNetBar.Controls
Imports DevComponents.DotNetBar
Imports Logica.AccesoLogica
Imports Janus.Windows.GridEX


Public Class F1_Cantidad

    Public Cantidad As Decimal
    Public Impresora As Integer
    Public bandera As Boolean


    Private Sub F_Cantidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _prCargarImpresoras(cbImpresora)
        tbCantidad.Value = Cantidad
    End Sub

    Private Sub _prCargarImpresoras(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As DataTable

        dt = L_prCargarImpresoras()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("cbnumi").Width = 60
            .DropDownList.Columns("cbnumi").Caption = "COD"
            .DropDownList.Columns.Add("cbdesc").Width = 500
            .DropDownList.Columns("cbdesc").Caption = "IMPRESORA"
            .ValueMember = "cbnumi"
            .DisplayMember = "cbdesc"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub tbCantidad_Enter(sender As Object, e As EventArgs)

    End Sub




    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        bandera = False
        Me.Close()
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Cantidad = tbCantidad.Value
        Impresora = cbImpresora.Value
        bandera = True
        Me.Close()
    End Sub

    Private Sub tbCantidad_ValueChanged(sender As Object, e As EventArgs) Handles tbCantidad.ValueChanged
        If Not IsNumeric(tbCantidad.Text) And tbCantidad.Value <= 1 Then
            tbCantidad.Value = 1
            ToastNotification.Show(Me, "Ingrese una cantidad valida".ToUpper,
                                              My.Resources.WARNING, 5 * 1000,
                                              eToastGlowColor.Blue, eToastPosition.TopCenter)
        End If
    End Sub
End Class