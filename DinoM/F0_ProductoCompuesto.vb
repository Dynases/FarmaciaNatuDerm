﻿Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Imports UTILITIES
Public Class F0_ProductoCompuesto
#Region "Variables"
    Dim IdProducto As Integer
    Dim OcultarFact As Integer = 0
    Dim NombreFormulario As String = "PRODUCTOS COMPUESTOS"
    Dim Modificado As Boolean = False
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
    Dim G_Lote As Boolean = False
    Dim _idOriginal As Integer
    Dim _idVenta As Integer
    Dim _Pos As Integer
    Dim _Nuevo As Boolean
    Public _IdCliente As Integer = 0
    Dim FilaSelectLote As DataRow = Nothing
    Dim grup1 As String = " "
    Dim grup2 As String = " "
    Public Tipo As Integer = 0
    Public _idProcucto As Integer = 0
#End Region
#Region "Eventos del formulario"

    Private Sub F0_ProductoCompuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MP_Iniciar()
            MSuperTabControl.SelectedTabIndex = 0
        Catch ex As Exception
            MostrarMensajeError(ex.Message)
        End Try
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        MP_PrimerRegistro()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        MP_AnteriorRegistro()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        MP_SiguienteRegistro()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        MP_PUltimoRegistro()
    End Sub
    Private Sub Dgv_Busqueda_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Busqueda.KeyDown
        If e.KeyData = Keys.Enter Then
            MSuperTabControl.SelectedTabIndex = 0
            Dgv_Detalle.Focus()
        End If
    End Sub
    Private Sub Dgv_Busqueda_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_Busqueda.SelectionChanged
        If Dgv_Busqueda.Row >= 0 And Dgv_Busqueda.RowCount >= 0 Then
            MP_MostrarRegistros(Dgv_Busqueda.Row)
        End If
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        MP_Nuevo()
        _Nuevo = True
    End Sub
    Private Sub Dgv_Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgv_Busqueda.EditingCell
        e.Cancel = True
    End Sub
    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If MP_ValidarCampos() = False Then
            Exit Sub
        End If
        If btnGrabar.Enabled = False Then
            Exit Sub
        End If
        If _Nuevo Then
            MP_NuevoRegistro()
        Else
            MP_ModificarRegistro()
        End If
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        _Nuevo = False
        MP_Modificar()
    End Sub

    Private Sub Dgv_Detalle_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Dgv_Detalle.KeyDown
        If tb_Descripcion.Text = String.Empty Then
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Por Favor intrudusca una descripcion".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            tb_Descripcion.Focus()
        End If
        If e.KeyData = Keys.Enter Then
            'GPanelProductos.Height = 530
            'GPanelProductos.Visible = True
            'If _IdCliente = 0 Then
            '    _prAddDetalleProductosCompuesntos()
            '    _HabilitarProductos()
            '    Dgv_Productos.Focus()
            'Else
            '    _HabilitarProductos()
            '    Dgv_Productos.Focus()
            'End If

            Dim f, c As Integer
            c = Dgv_Detalle.Col
            f = Dgv_Detalle.Row

            If (Dgv_Detalle.Col = Dgv_Detalle.RootTable.Columns("pdeti").Index Or Dgv_Detalle.Col = Dgv_Detalle.RootTable.Columns("pdPorc").Index Or Dgv_Detalle.Col = Dgv_Detalle.RootTable.Columns("pdcant").Index) Then
                If (Dgv_Detalle.GetValue("pdeti") <> String.Empty) Then
                    _prAddDetalleProductosCompuesntos()
                    _HabilitarProductos()
                Else
                    ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
                End If

            End If
            'If (Dgv_Detalle.Col = Dgv_Detalle.RootTable.Columns("pdPorc").Index) Then
            '    If (Dgv_Detalle.GetValue("pdeti") <> String.Empty) Then
            '        _prAddDetalleProductosCompuesntos()
            '        _HabilitarProductos()
            '    Else
            '        ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
            '    End If

            'End If
            'If (Dgv_Detalle.Col = Dgv_Detalle.RootTable.Columns("pdcant").Index) Then
            '    If (Dgv_Detalle.GetValue("pdeti") <> String.Empty) Then
            '        _prAddDetalleProductosCompuesntos()
            '        _HabilitarProductos()
            '    Else
            '        ToastNotification.Show(Me, "Seleccione un Producto Por Favor", My.Resources.WARNING, 3000, eToastGlowColor.Red, eToastPosition.TopCenter)
            '    End If

            'End If
        End If
        If (e.KeyData = Keys.Control + Keys.Enter And Dgv_Detalle.Row >= 0 And
            Dgv_Detalle.Col = Dgv_Detalle.RootTable.Columns("pdeti").Index) Then
            Dim indexfil As Integer = Dgv_Detalle.Row
            Dim indexcol As Integer = Dgv_Detalle.Col
            _HabilitarProductos()
        End If
        If (e.KeyData = Keys.Escape And Dgv_Detalle.Row >= 0) Then
            _prEliminarFila()
        End If
    End Sub

    Private Sub Dgv_Detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgv_Detalle.EditingCell
        If (tb_Id.ReadOnly = False) Then
            If (e.Column.Index = Dgv_Detalle.RootTable.Columns("pdeti").Index Or
                e.Column.Index = Dgv_Detalle.RootTable.Columns("pdcant").Index Or
                e.Column.Index = Dgv_Detalle.RootTable.Columns("pdPorc").Index Or
                e.Column.Index = Dgv_Detalle.RootTable.Columns("Jarabe").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Dgv_Productos_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Productos.KeyDown
        Try
            If e.KeyData = Keys.Enter Then
                Dim idProducto, Etiqueda, idUnidad, Unidad, costo As String
                'Dim Bin As New MemoryStream
                'Dim img As New Bitmap(My.Resources.delete, 28, 28)
                'img.Save(Bin, Imaging.ImageFormat.Png)

                idProducto = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yfnumi").Value)
                Etiqueda = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yfcdprod1").Value)
                idUnidad = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yfumin").Value)
                Unidad = Convert.ToString(Dgv_Productos.CurrentRow.Cells("UnidMin").Value)
                costo = Convert.ToString(Dgv_Productos.CurrentRow.Cells("pcos").Value)
                'Dim nuevaFila As DataRow = CType(Dgv_Detalle.DataSource, DataTable).NewRow()

                'nuevaFila(0) = 0
                'nuevaFila(1) = idProducto
                'nuevaFila(2) = _fnSiguienteNumi() + 1
                'nuevaFila(3) = Etiqueda
                'nuevaFila(4) = ""
                'nuevaFila(5) = idUnidad
                'nuevaFila(6) = Unidad
                'nuevaFila(7) = "0.00"
                'nuevaFila(8) = "0.00"
                'nuevaFila(9) = "100"
                'nuevaFila(10) = "1000"
                'nuevaFila(11) = False
                'nuevaFila(12) = "0.0000"
                'nuevaFila(13) = costo
                'nuevaFila(14) = "0.00"
                'nuevaFila(15) = 0
                'nuevaFila(16) = Bin.GetBuffer


                'CType(Dgv_Detalle.DataSource, DataTable).Rows.Add(nuevaFila)
                'GPanelProductos.Height = 80
                'GPanelProductos.Visible = False
                'Dgv_Detalle.Focus()
                'Dgv_Detalle.Row = Dgv_Detalle.Row - 1
                Dim pos As Integer = -1
                'Dgv_Detalle.Row = Dgv_Detalle.RowCount - 1
                _fnObtenerFilaDetalle(pos, Dgv_Detalle.GetValue("id"))
                If (Not _fnExisteProducto(idProducto)) Then
                    'b.yfcdprod1, a.iclot, a.icfven, a.iccven
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("idProducto") = idProducto
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("pdeti") = Etiqueda
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("IdUnidad") = idUnidad
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("UnidadMin") = Unidad
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("pdprec") = costo
                    tb_Total.Value = Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns("pdtotal"), AggregateFunction.Sum)
                    _DesHabilitarProductos()
                Else
                    Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
                    ToastNotification.Show(Me, "El producto ya existe modifique su cantidad".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                End If
            End If
            If e.KeyData = Keys.Escape Then
                _DesHabilitarProductos()
                FilaSelectLote = Nothing
            End If
        Catch ex As Exception
            MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub _prAddDetalleProductosCompuesntos()
        '   a.tbnumi ,a.tbtv1numi ,a.tbty5prod ,b.yfcdprod1 as producto,a.tbest ,a.tbcmin ,a.tbumin ,Umin .ycdes3 as unidad,a.tbpbas ,a.tbptot ,a.tbobs ,
        'a.tbpcos,a.tblote ,a.tbfechaVenc , a.tbptot2, a.tbfact ,a.tbhact ,a.tbuact,1 as estado,Cast(null as Image) as img
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        CType(Dgv_Detalle.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, 0, "", "", 0, "", 0.00, 0.000, 100, 1000, False, 0, 0, 0, 0, Bin.GetBuffer)
    End Sub

    Private Sub Dgv_Detalle_CellEdited(sender As Object, e As ColumnActionEventArgs) Handles Dgv_Detalle.CellEdited
        Try
            Dim cantidad, porcentaje, valor, precio, total, valor1, valor2 As Double
            porcentaje = Dgv_Detalle.CurrentRow.Cells("pdPorc").Value
            precio = Dgv_Detalle.CurrentRow.Cells("pdprec").Value
            cantidad = Dgv_Detalle.CurrentRow.Cells("pdcant").Value
            valor1 = Dgv_Detalle.CurrentRow.Cells("pdValor1").Value
            valor2 = Dgv_Detalle.CurrentRow.Cells("pdValor2").Value
            If Dgv_Detalle.CurrentRow.Cells("Jarabe").Value = False Then
                If (IsNumeric(Dgv_Detalle.GetValue("pdPorc")) And IsNumeric(Dgv_Detalle.GetValue("pdcant"))) Then
                    valor = (cantidad / valor1) * porcentaje
                    total = valor * precio
                    Dgv_Detalle.CurrentRow.Cells("pdvalor").Value = valor
                    Dgv_Detalle.CurrentRow.Cells("pdtotal").Value = total
                    Dgv_Detalle.CurrentRow.Cells("pdeticant").Value = porcentaje.ToString() + "%"
                    MP_PonerTotal()
                Else
                    If Not IsNumeric(Dgv_Detalle.GetValue("pdcant")) Then
                        Dgv_Detalle.CurrentRow.Cells("pdcant").Value = 0
                    ElseIf Not IsNumeric(Dgv_Detalle.GetValue("pdPorc")) Then
                        Dgv_Detalle.CurrentRow.Cells("pdPorc").Value = 0
                    End If
                End If
            Else
                ' If (e.Column.Index = Dgv_Detalle.RootTable.Columns("Jarabe").Index And Dgv_Detalle.CurrentRow.Cells("Jarabe").Value) Then
                If (IsNumeric(Dgv_Detalle.GetValue("pdPorc")) And IsNumeric(Dgv_Detalle.GetValue("pdcant"))) Then
                    valor = (cantidad * 100) / porcentaje
                    valor = valor / valor2
                    total = valor * precio
                    Dgv_Detalle.CurrentRow.Cells("pdvalor").Value = valor
                    Dgv_Detalle.CurrentRow.Cells("pdtotal").Value = total
                    Dgv_Detalle.CurrentRow.Cells("pdeticant").Value = porcentaje.ToString() + "%"
                    MP_PonerTotal()
                Else
                    If Not IsNumeric(Dgv_Detalle.GetValue("pdcant")) Then
                        Dgv_Detalle.CurrentRow.Cells("pdcant").Value = 0
                    ElseIf Not IsNumeric(Dgv_Detalle.GetValue("pdPorc")) Then
                        Dgv_Detalle.CurrentRow.Cells("pdPorc").Value = 0
                    End If
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        MP_EliminarRegistro()
    End Sub
#End Region
#Region "Metodos privados"
    Private Sub MP_PonerTotal()
        If Dgv_Detalle.Row < Dgv_Detalle.RowCount Then
            Dim lin As Integer = Dgv_Detalle.GetValue("id")
            Dim pos As Integer = -1
            _fnObtenerFilaDetalle(pos, lin)
            Dim estado As Integer = CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("estado")
            If (estado = 1) Then
                CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("estado") = 2
            End If
            tb_Total.Value = Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns("pdtotal"), AggregateFunction.Sum)
        End If
    End Sub
    Private Sub MP_Iniciar()

        If Tipo = 1 Then ' Inicia desde la venta
            MP_ValidarLote()
            MP_CargarComboLibreriaSucursal(cbSucursal)
            cbSucursal.Value = 1
            MP_MostrarGrillaEncabezado()
            MP_Habilitar()
            MP_IniciarMenu()
        Else
            Me.Text = NombreFormulario
            MP_ValidarLote()

            MP_AsignarPermisos()
            MP_MostrarGrillaEncabezado()
            MP_CargarComboLibreriaSucursal(cbSucursal)
            MP_InHabilitar()
            'Fechas
            tb_Fecha.Value = Now.Date
            tb_FechaFabrica.Value = Now.Date
            tb_FechaVencimieto.Value = DateAdd("m", 6, Now.Date)
            cbSucursal.Value = 1

        End If
    End Sub
    Private Sub MP_IniciarMenu()
        btnModificar.Visible = False
        btnEliminar.Visible = False
        btnNuevo.Enabled = False
        btnGrabar.Enabled = True
    End Sub
    Private Sub MP_MostrarGrillaEncabezado()
        Dim dt As New DataTable
        If Tipo = 0 Then
            dt = L_fnProductoCompuestoTraerGeneral()
        Else
            'Cuando se incia desde venta
            dt = L_fnProductoCompuestoTraerGeneral2(_idProcucto)
        End If

        Dgv_Busqueda.DataSource = dt
        Dgv_Busqueda.RetrieveStructure()
        Dgv_Busqueda.AlternatingColors = True
        With Dgv_Busqueda.RootTable.Columns(0)
            .Key = "id"
            .Visible = False
        End With
        With Dgv_Busqueda.RootTable.Columns(1)
            .Key = "pccod"
            .Caption = "pccod"
            .Visible = False
        End With
        With Dgv_Busqueda.RootTable.Columns(2)
            .Key = "pcfech"
            .Caption = "Fecha"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Busqueda.RootTable.Columns(3)
            .Key = "pcdesc"
            .Caption = "Descripción"
            .Width = 400
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Busqueda.RootTable.Columns(4)
            .Key = "pcobser"
            .Caption = "Observación"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns(5)
            .Visible = True
            .Key = "pctotal"
            .Caption = "Total"
            .Width = 250
            .FormatString = "0.00"
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With Dgv_Busqueda.RootTable.Columns(6)
            .Key = "Estado"
            .Caption = "Estado"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = False
        End With
        'Habilitar Filtradores
        With Dgv_Busqueda
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            '.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown
        End With
        'diseño de la grilla
        Dgv_Busqueda.VisualStyle = VisualStyle.Office2007
        If (dt.Rows.Count <= 0) Then
            MP_MostrarGrillaDetalle(-1)
        End If
    End Sub
    Private Sub MP_MostrarGrillaDetalle(_N As Integer)
        Dim dt As New DataTable
        dt = L_fnProductoCompuestoTraerDetalleXId(_N)
        Dgv_Detalle.DataSource = dt
        Dgv_Detalle.RetrieveStructure()
        Dgv_Detalle.AlternatingColors = True
        With Dgv_Detalle.RootTable.Columns(0)
            .Key = "id"
            .Visible = False
            .Position = 0
        End With
        With Dgv_Detalle.RootTable.Columns(1)
            .Key = "idProducto"
            .Caption = "Cod."
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
            .Position = 1
        End With
        With Dgv_Detalle.RootTable.Columns(2)
            .Key = "idProductoCompuesto"
            .Visible = False
            .Position = 2
        End With
        With Dgv_Detalle.RootTable.Columns(3)
            .Key = "pdeti"
            .Caption = "Etiqueta"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 3
        End With

        With Dgv_Detalle.RootTable.Columns(4)
            .Key = "pdeticant"
            .Caption = "Eti"
            .Visible = False
            .Position = 4
        End With

        With Dgv_Detalle.RootTable.Columns(5)
            .Key = "IdUnidad"
            .Visible = False
            .Position = 5
        End With
        With Dgv_Detalle.RootTable.Columns(6)
            .Visible = True
            .Key = "UnidadMin"
            .Caption = "Unidad"
            .Width = 70
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Position = 6
        End With
        With Dgv_Detalle.RootTable.Columns(7)
            .Key = "pdPorc"
            .Caption = "Porcentaje(%)"
            .FormatString = "0.00"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 7
        End With
        With Dgv_Detalle.RootTable.Columns(8)
            .Key = "pdcant"
            .Caption = "Cantidad"
            .FormatString = "0.000"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 8
        End With
        With Dgv_Detalle.RootTable.Columns(9)
            .Key = "pdValor1"
            .Caption = "Valor1"
            .FormatString = "0.00"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 9
        End With
        With Dgv_Detalle.RootTable.Columns(10)
            .Key = "pdValor2"
            .Caption = "Valor2"
            .FormatString = "0.00"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 10
        End With
        With Dgv_Detalle.RootTable.Columns(11)
            .Key = "Jarabe"
            .Caption = "Jarabe"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 12
        End With
        With Dgv_Detalle.RootTable.Columns(12)
            .Key = "pdvalor"
            .Caption = "Valor Total"
            .FormatString = "0.0000"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 12
        End With
        With Dgv_Detalle.RootTable.Columns(13)
            .Key = "pdprec"
            .Caption = "Precio"
            .FormatString = "0.00"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 13
        End With
        With Dgv_Detalle.RootTable.Columns(14)
            .Key = "pdtotal"
            .Caption = "Total"
            .FormatString = "0.00"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 14
        End With
        With Dgv_Detalle.RootTable.Columns(15)
            .Key = "Estado"
            .Visible = False
            .Position = 15
        End With
        With Dgv_Detalle.RootTable.Columns(16)
            .Key = "img"
            .Width = 80
            .Caption = "Eliminar".ToUpper
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = False
            .Position = 16
        End With
        'Habilitar Filtradores
        With Dgv_Detalle
            '.DefaultFilterRowComparison = FilterConditionOperator.Contains
            ' .FilterMode = FilterMode.Automatic
            '.FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            '.FilterRowButtonStyle = FilterRowButtonStyle.ConditionOperatorDropDown
        End With
        'diseño de la grilla
        Dgv_Detalle.VisualStyle = VisualStyle.Office2007
    End Sub
    Private Sub MP_Habilitar()
        btnNuevo.Enabled = False
        btnModificar.Enabled = False
        btnEliminar.Enabled = False
        btnGrabar.Enabled = True

        sw_ProductoCompuesto.IsReadOnly = False
        tb_Id.ReadOnly = False
        tb_CodProductoCom.ReadOnly = False
        tb_Descripcion.ReadOnly = False
        tb_Observacion.ReadOnly = False
        tb_Fecha.IsInputReadOnly = False
        tb_FechaFabrica.IsInputReadOnly = False
        tb_FechaVencimieto.IsInputReadOnly = False

        If (tb_Id.Text.Length > 0) Then
            cbSucursal.ReadOnly = True
        Else
            cbSucursal.ReadOnly = False

        End If
        Dgv_Detalle.Enabled = True
    End Sub
    Private Sub MP_InHabilitar()
        btnNuevo.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnGrabar.Enabled = False
        sw_ProductoCompuesto.IsReadOnly = True
        tb_Id.ReadOnly = True
        tb_CodProductoCom.ReadOnly = True
        tb_Descripcion.ReadOnly = True
        tb_Observacion.ReadOnly = True
        tb_Fecha.IsInputReadOnly = True
        tb_FechaFabrica.IsInputReadOnly = True
        tb_FechaVencimieto.IsInputReadOnly = True

        Dgv_Detalle.RootTable.Columns("img").Visible = False
        If (GPanelProductos.Visible = True) Then
            _DesHabilitarProductos()
        End If
        Dgv_Detalle.Enabled = False
    End Sub
    Private Sub MP_Limpiar()
        sw_ProductoCompuesto.IsReadOnly = False
        tb_Id.Clear()
        tb_CodProductoCom.Clear()
        tb_Descripcion.Clear()
        tb_Observacion.Clear()
        tb_Fecha.Value = Now.Date
        tb_FechaFabrica.Value = Now.Date
        tb_FechaVencimieto.Value = DateAdd("m", 6, Now.Date)
        MP_MostrarGrillaDetalle(-1)
        With Dgv_Detalle.RootTable.Columns("img")
            .Width = 80
            .Caption = "Eliminar"
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = True
        End With
        _prAddDetalleProductosCompuesntos()
        If (GPanelProductos.Visible = True) Then
            GPanelProductos.Visible = False
            PanelTotal.Visible = True
            PanelInferior.Visible = True
        End If

        tb_Total.Value = 0
        tb_Descripcion.Focus()
        FilaSelectLote = Nothing
        'MP_AddDetalle()
    End Sub
    Public Function _fnExisteProducto(idprod As Integer) As Boolean
        For i As Integer = 0 To CType(Dgv_Detalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _idprod As Integer = CType(Dgv_Detalle.DataSource, DataTable).Rows(i).Item("idProducto")
            Dim estado As Integer = CType(Dgv_Detalle.DataSource, DataTable).Rows(i).Item("estado")
            If (_idprod = idprod And estado >= 0) Then

                Return True
            End If
        Next
        Return False
    End Function
    Private Sub _DesHabilitarProductos()
        GPanelProductos.Visible = False
        PanelTotal.Visible = True
        PanelInferior.Visible = True

        Dgv_Detalle.Select()
        Dgv_Detalle.Col = 3
        Dgv_Detalle.Row = Dgv_Detalle.RowCount - 1

    End Sub
    Private Sub _HabilitarProductos()
        GPanelProductos.Height = 530
        GPanelProductos.Visible = True
        'PanelTotal.Visible = False
        'PanelInferior.Visible = False
        MP_CargarProductos()
        Dgv_Productos.Focus()
        Dgv_Productos.MoveTo(Dgv_Productos.FilterRow)
        Dgv_Productos.Col = 2
    End Sub

    Private Sub MP_MostrarRegistros(_N As Integer)
        Dgv_Busqueda.Row = _N
        With Dgv_Busqueda
            _idOriginal = .GetValue("id")
            Dim _tablaEncabezado As DataTable = L_fnProductoCompuestoTraerGeneralXId(_idOriginal)
            tb_Id.Text = _tablaEncabezado.Rows(0).Item("id")
            tb_CodProductoCom.Text = _tablaEncabezado.Rows(0).Item("pccod")
            tb_Descripcion.Text = _tablaEncabezado.Rows(0).Item("pcdesc").ToString()
            tb_Observacion.Text = _tablaEncabezado.Rows(0).Item("pcobser").ToString()
            tb_Fecha.Value = _tablaEncabezado.Rows(0).Item("pcfech").ToString()
            tb_FechaFabrica.Value = _tablaEncabezado.Rows(0).Item("pcffab").ToString()
            tb_FechaVencimieto.Value = _tablaEncabezado.Rows(0).Item("pcfven").ToString()
            tb_Total.Value = _tablaEncabezado.Rows(0).Item("pctotal").ToString()
            'CARGAR DETALLE 
            MP_MostrarGrillaDetalle(_idOriginal)
        End With
        LblPaginacion.Text = Str(_N + 1) + "/" + Dgv_Busqueda.RowCount.ToString
    End Sub
    Private Sub MP_PrimerRegistro()
        If Dgv_Busqueda.RowCount > 0 Then
            _Pos = 0
            MP_MostrarRegistros(_Pos)
        End If
    End Sub
    Private Sub MP_AnteriorRegistro()
        If _Pos > 0 And Dgv_Busqueda.RowCount > 0 Then
            _Pos = _Pos - 1
            MP_MostrarRegistros(_Pos)
        End If
    End Sub
    Private Sub MP_SiguienteRegistro()
        If _Pos < Dgv_Busqueda.RowCount - 1 And _Pos >= 0 Then
            _Pos = _Pos + 1
            MP_MostrarRegistros(_Pos)
        End If
    End Sub
    Private Sub MP_PUltimoRegistro()
        If Dgv_Busqueda.RowCount > 0 Then
            _Pos = Dgv_Busqueda.RowCount - 1
            MP_MostrarRegistros(_Pos)
        End If
    End Sub
    Public Sub MP_ValidarLote()
        Dim dt As DataTable = L_fnPorcUtilidad()
        If (dt.Rows.Count > 0) Then
            Dim lot As Integer = dt.Rows(0).Item("VerLote")
            OcultarFact = dt.Rows(0).Item("VerFactManual")
            If (lot = 1) Then
                G_Lote = True
            Else
                G_Lote = False
            End If

        End If
    End Sub
    Public Function MP_ValidarCampos() As Boolean
        Dim _ok As Boolean = True
        If tb_Descripcion.Text = String.Empty Then
            tb_Descripcion.BackColor = Color.Red
            MEP.SetError(tb_Descripcion, "ingrese el una descripcion!".ToUpper)
            _ok = False
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "Ingrese un descripcion para efectuar la grabación".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
        Else
            tb_Descripcion.BackColor = Color.White
            MEP.SetError(tb_Descripcion, "")
        End If

        If (Dgv_Detalle.RowCount = 1) Then
            If (Dgv_Detalle.RowCount > 0) Then
                Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
                ToastNotification.Show(Me, "Por Favor ingrese un detalle".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                _ok = False
            End If
        End If
        Return True
    End Function
    Public Sub _fnObtenerFilaDetalle(ByRef pos As Integer, numi As Integer)
        For i As Integer = 0 To CType(Dgv_Detalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim _numi As Integer = CType(Dgv_Detalle.DataSource, DataTable).Rows(i).Item("id")
            If (_numi = numi) Then
                pos = i
                Return
            End If
        Next

    End Sub
    Private Sub MP_AsignarPermisos()
        If Tipo = 0 Then
            Dim dtRolUsu As DataTable = L_prRolDetalleGeneral(gi_userRol, _nameButton)
            Dim show As Boolean = dtRolUsu.Rows(0).Item("ycshow")
            Dim add As Boolean = dtRolUsu.Rows(0).Item("ycadd")
            Dim modif As Boolean = dtRolUsu.Rows(0).Item("ycmod")
            Dim del As Boolean = dtRolUsu.Rows(0).Item("ycdel")
            If add = False Then
                btnNuevo.Visible = False
            End If
            If modif = False Then
                btnModificar.Visible = False
            End If
            If del = False Then
                btnEliminar.Visible = False
            End If
        End If
    End Sub
    Private Sub MP_Nuevo()
        MP_Habilitar()
        'btnNuevo.Enabled = True
        MP_Limpiar()
        tb_Id.Focus()
        _Nuevo = True
    End Sub
    Private Sub MP_Modificar()
        MP_Habilitar()
        'btnNuevo.Enabled = False
        'btnModificar.Enabled = False
        'btnEliminar.Enabled = False
        'btnGrabar.Enabled = True
        '_Nuevo = False
        tb_Descripcion.Focus()
        'PanelNavegacion.Enabled = False
        _prCargarIconELiminar()
    End Sub
    Public Sub _prCargarIconELiminar()
        For i As Integer = 0 To CType(Dgv_Detalle.DataSource, DataTable).Rows.Count - 1 Step 1
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)
            CType(Dgv_Detalle.DataSource, DataTable).Rows(i).Item("img") = Bin.GetBuffer
            Dgv_Detalle.RootTable.Columns("img").Visible = True
        Next
    End Sub
    Private Sub MP_CargarComboLibreriaSucursal(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo)
        Dim dt As New DataTable
        dt = L_fnListarSucursales()
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("aanumi").Width = 60
            .DropDownList.Columns("aanumi").Caption = "COD"
            .DropDownList.Columns.Add("aabdes").Width = 500
            .DropDownList.Columns("aabdes").Caption = "SUCURSAL"
            .ValueMember = "aanumi"
            .DisplayMember = "aabdes"
            .DataSource = dt
            .Refresh()
        End With
    End Sub

    Private Sub MP_CargarProductos()
        Dim dtname As DataTable = L_fnNameLabel()
        Dim dt As New DataTable
        dt = L_fnListarProductosCompuestos(cbSucursal.Value)  ''1=Almacen
        If dt.Rows.Count > 0 Then
            Dgv_Productos.DataSource = dt
            Dgv_Productos.RetrieveStructure()
            Dgv_Productos.AlternatingColors = True        '    
            With Dgv_Productos.RootTable.Columns("yfnumi")
                .Width = 100
                .Caption = "CODIGO"
                .Visible = False

            End With
            With Dgv_Productos.RootTable.Columns("yfcprod")
                .Width = 120
                .Caption = "CÓDIGO"
                .Visible = True
            End With
            With Dgv_Productos.RootTable.Columns("yfcbarra")
                .Width = 100
                .Caption = "COD. BARRA"
                .Visible = gb_CodigoBarra
            End With
            With Dgv_Productos.RootTable.Columns("yfcdprod1")
                .Width = 270
                .Visible = True
                .Caption = "DESCRIPCIÓN"
            End With
            With Dgv_Productos.RootTable.Columns("yfcdprod2")
                .Width = 150
                .Visible = False
                .Caption = "Descripcion Corta"
            End With


            With Dgv_Productos.RootTable.Columns("yfgr1")
                .Width = 160
                .Visible = False
            End With
            If (dtname.Rows.Count > 0) Then

                With Dgv_Productos.RootTable.Columns("grupo1")
                    .Width = 150
                    .Caption = dtname.Rows(0).Item("Grupo 1").ToString
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = True
                End With
                With Dgv_Productos.RootTable.Columns("grupo2")
                    .Width = 150
                    .Caption = dtname.Rows(0).Item("Grupo 2").ToString
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = True
                End With

                With Dgv_Productos.RootTable.Columns("grupo3")
                    .Width = 120
                    .Caption = dtname.Rows(0).Item("Grupo 3").ToString
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = False
                End With
                With Dgv_Productos.RootTable.Columns("grupo4")
                    .Width = 120
                    .Caption = dtname.Rows(0).Item("Grupo 4").ToString
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = False
                End With
            Else
                With Dgv_Productos.RootTable.Columns("grupo1")
                    .Width = 120
                    .Caption = "Grupo 1"
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = True
                End With
                With Dgv_Productos.RootTable.Columns("grupo2")
                    .Width = 120
                    .Caption = "Grupo 2"
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = True
                End With
                With Dgv_Productos.RootTable.Columns("grupo3")
                    .Width = 120
                    .Caption = "Grupo 3"
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = False
                End With
                With Dgv_Productos.RootTable.Columns("grupo4")
                    .Width = 120
                    .Caption = "Grupo 4"
                    .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                    .Visible = False
                End With
            End If


            With Dgv_Productos.RootTable.Columns("yfgr2")
                .Width = 50
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = False
            End With

            With Dgv_Productos.RootTable.Columns("yfgr3")
                .Width = 50
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = False
            End With

            With Dgv_Productos.RootTable.Columns("yfgr4")
                .Width = 50
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = False
            End With


            With Dgv_Productos.RootTable.Columns("yfumin")
                .Width = 50
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = False
            End With
            With Dgv_Productos.RootTable.Columns("UnidMin")
                .Width = 120
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = False
                .Caption = "Unidad Min."
            End With

            With Dgv_Productos.RootTable.Columns("pcos")
                .Width = 150
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = False
                .Caption = "Precio Costo"
                .FormatString = "0.00"
            End With
            With Dgv_Productos.RootTable.Columns("stock")
                .Width = 90
                .FormatString = "0.00"
                .Visible = False
                .Caption = "STOCK"
            End With

            With Dgv_Productos
                .DefaultFilterRowComparison = FilterConditionOperator.Contains
                .FilterMode = FilterMode.Automatic
                .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
                .GroupByBoxVisible = False
                'diseño de la grilla
                .VisualStyle = VisualStyle.Office2007
            End With
        End If
        'MP_AplicarCondiccionJanusSinLote()
    End Sub
    'Public Sub MP_AplicarCondiccionJanusSinLote()
    '    Dim fc As GridEXFormatCondition
    '    fc = New GridEXFormatCondition(Dgv_Productos.RootTable.Columns("stock"), ConditionOperator.Between, -9998 And 0)
    '    fc.FormatStyle.ForeColor = Color.Red    '
    '    Dgv_Productos.RootTable.FormatConditions.Add(fc)
    '    Dim fr As GridEXFormatCondition
    '    fr = New GridEXFormatCondition(Dgv_Productos.RootTable.Columns("stock"), ConditionOperator.Equal, -9999)
    '    fr.FormatStyle.ForeColor = Color.BlueViolet
    '    Dgv_Productos.RootTable.FormatConditions.Add(fr)
    'End Sub
    Public Sub MP_ActualizarSaldo(ByRef dt As DataTable, CodProducto As Integer)
        Dim _detalle As DataTable = CType(Dgv_Detalle.DataSource, DataTable)
        For i As Integer = 0 To dt.Rows.Count - 1 Step 1
            Dim lote As String = dt.Rows(i).Item("iclot")
            Dim FechaVenc As Date = dt.Rows(i).Item("icfven")
            Dim sum As Integer = 0
            For j As Integer = 0 To _detalle.Rows.Count - 1
                Dim estado As Integer = _detalle.Rows(j).Item("estado")
                If (estado = 0) Then
                    If (lote = _detalle.Rows(j).Item("tblote") And
                        FechaVenc = _detalle.Rows(j).Item("tbfechaVenc") And CodProducto = _detalle.Rows(j).Item("tbty5prod")) Then
                        sum = sum + _detalle.Rows(j).Item("tbcmin")
                    End If
                End If
            Next
            dt.Rows(i).Item("iccven") = dt.Rows(i).Item("iccven") - sum
        Next
    End Sub
    Private Sub MP_CargarLotesDeProductos(CodProducto As Integer, nameProducto As String)
        If (cbSucursal.SelectedIndex < 0) Then
            Return
        End If
        Dim dt As New DataTable
        GPanelProductos.Text = nameProducto
        dt = L_fnListarLotesPorProductoVenta(cbSucursal.Value, CodProducto)  ''1=Almacen
        MP_ActualizarSaldo(dt, CodProducto)
        Dgv_Productos.DataSource = dt
        Dgv_Productos.RetrieveStructure()
        Dgv_Productos.AlternatingColors = True
        With Dgv_Productos.RootTable.Columns("yfcdprod1")
            .Width = 150
            .Visible = False

        End With
        'b.yfcdprod1 ,a.iclot ,a.icfven  ,a.iccven 
        With Dgv_Productos.RootTable.Columns("iclot")
            .Width = 150
            .Caption = "LOTE"
            .Visible = True

        End With
        With Dgv_Productos.RootTable.Columns("icfven")
            .Width = 160
            .Caption = "FECHA VENCIMIENTO"
            .FormatString = "yyyy/MM/dd"
            .Visible = True

        End With

        With Dgv_Productos.RootTable.Columns("iccven")
            .Width = 150
            .Visible = True
            .Caption = "Stock"
            .FormatString = "0.00"
            .AggregateFunction = AggregateFunction.Sum
        End With


        With Dgv_Productos
            .DefaultFilterRowComparison = FilterConditionOperator.Contains
            .FilterMode = FilterMode.Automatic
            .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
            .GroupByBoxVisible = False
            'diseño de la grilla
            .TotalRow = InheritableBoolean.True
            .TotalRowFormatStyle.BackColor = Color.Gold
            .TotalRowPosition = TotalRowPosition.BottomFixed
            .VisualStyle = VisualStyle.Office2007
        End With
        MP_AplicarCondiccionJanusLote()

    End Sub
    Public Sub MP_AplicarCondiccionJanusLote()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(Dgv_Productos.RootTable.Columns("iccven"), ConditionOperator.Equal, 0)
        fc.FormatStyle.BackColor = Color.Gold
        fc.FormatStyle.FontBold = TriState.True
        fc.FormatStyle.ForeColor = Color.White
        Dgv_Productos.RootTable.FormatConditions.Add(fc)

        Dim fc2 As GridEXFormatCondition
        fc2 = New GridEXFormatCondition(Dgv_Productos.RootTable.Columns("icfven"), ConditionOperator.LessThanOrEqualTo, Now.Date)
        fc2.FormatStyle.BackColor = Color.Red
        fc2.FormatStyle.FontBold = TriState.True
        fc2.FormatStyle.ForeColor = Color.White
        Dgv_Productos.RootTable.FormatConditions.Add(fc2)
    End Sub
    Private Sub MP_AddDetalle()
        Dim Bin As New MemoryStream
        Dim img As New Bitmap(My.Resources.delete, 28, 28)
        img.Save(Bin, Imaging.ImageFormat.Png)
        CType(Dgv_Detalle.DataSource, DataTable).Rows.Add(_fnSiguienteNumi() + 1, 0, 0, 0, "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, Bin.GetBuffer, 0)
    End Sub
    Public Function _fnSiguienteNumi()
        Dim dt As DataTable = CType(Dgv_Detalle.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("id=MAX(id)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("id")
        End If
        Return 1
    End Function
    Public Sub _prEliminarFila()
        If (Dgv_Detalle.Row >= 0) Then
            If (Dgv_Detalle.RowCount >= 2) Then
                Dim estado As Integer = Dgv_Detalle.GetValue("estado")
                Dim pos As Integer = -1
                Dim lin As Integer = Dgv_Detalle.GetValue("Id")
                _fnObtenerFilaDetalle(pos, lin)
                If (estado = 0) Then
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("estado") = -2

                End If
                If (estado = 1) Then
                    CType(Dgv_Detalle.DataSource, DataTable).Rows(pos).Item("estado") = -1
                End If
                Dgv_Detalle.RootTable.ApplyFilter(New Janus.Windows.GridEX.GridEXFilterCondition(Dgv_Detalle.RootTable.Columns("estado"), Janus.Windows.GridEX.ConditionOperator.GreaterThanOrEqualTo, 0))
                tb_Total.Value = Dgv_Detalle.GetTotal(Dgv_Detalle.RootTable.Columns("pdtotal"), AggregateFunction.Sum)
                Dgv_Detalle.Select()
                Dgv_Detalle.Col = 3
                Dgv_Detalle.Row = Dgv_Detalle.RowCount - 1
            End If
        End If
        Dgv_Detalle.Refetch()
        Dgv_Detalle.Refresh()
    End Sub

    Private Sub MP_Salir()
        MP_InHabilitar()
        MP_Filtrar(1)
    End Sub
    Private Sub MP_Filtrar(tipo As Integer)
        MP_MostrarGrillaEncabezado()
        If Dgv_Busqueda.RowCount > 0 Then
            _Pos = 0
            MP_MostrarRegistros(IIf(tipo = 1, _Pos, Dgv_Busqueda.RowCount - 1))
        Else
            MP_Limpiar()
            LblPaginacion.Text = "0/0"
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        If btnGrabar.Enabled = True Then
            MP_Salir()
        Else
            If _idProcucto = 0 Then
                _tab.Close()
                _modulo.Select()
            Else
                Me.Close()
            End If

        End If

    End Sub
    Private Sub MostrarMensajeError(mensaje As String)
        ToastNotification.Show(Me,
                               mensaje.ToUpper,
                               My.Resources.WARNING,
                               ENMensaje.MEDIANO,
                               eToastGlowColor.Red,
                               eToastPosition.TopCenter)

    End Sub
    Private Sub MostrarMensajeOk(mensaje As String)
        ToastNotification.Show(Me,
                               mensaje.ToUpper,
                               My.Resources.OK,
                               ENMensaje.MEDIANO,
                               eToastGlowColor.Green,
                               eToastPosition.TopCenter)
    End Sub
    Private Sub MP_NuevoRegistro2()
        Try
            Dim id As String
            ' L_ProductoCompuestoCabecera_Grabar(id, tb_CodProductoCom.Text, ENEstadoProductoCompuesto.Habilitado, tb_Descripcion.Text, tb_Observacion.Text, tb_Fecha.Value, tb_FechaFabrica.Value, tb_FechaVencimieto.Value, cbSucursal.Value, tb_Total.Value)
        Catch ex As Exception
            MostrarMensajeError(ex.Message)
        End Try

    End Sub
    Public Sub MP_NuevoRegistro()
        Try
            Dim id As String = ""
            Dim res As Boolean = L_ProductoCompuestoCabecera_Grabar(id, tb_CodProductoCom.Text, ENEstadoProductoCompuesto.Habilitado, tb_Descripcion.Text, tb_Observacion.Text, tb_Fecha.Value, tb_FechaFabrica.Value, tb_FechaVencimieto.Value, tb_Total.Value, CType(Dgv_Detalle.DataSource, DataTable))
            If res Then
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                ToastNotification.Show(Me, "Código de producto compuesto ".ToUpper + id.ToString() + " Grabado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter
                                          )
                MP_MostrarGrillaEncabezado()
                MP_Limpiar()
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "El producto compuesto no pudo ser insertado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

            End If
        Catch ex As Exception
            MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Public Sub MP_ModificarRegistro()
        Try
            Dim id As String = ""
            Dim res As Boolean = L_ProductoCompuestoCabecera_Modificar(tb_Id.Text, tb_CodProductoCom.Text, ENEstadoProductoCompuesto.Habilitado, tb_Descripcion.Text, tb_Observacion.Text, tb_Fecha.Value, tb_FechaFabrica.Value, tb_FechaVencimieto.Value, tb_Total.Value, CType(Dgv_Detalle.DataSource, DataTable))
            If res Then
                Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                ToastNotification.Show(Me, "Código de producto compuesto ".ToUpper + id.ToString() + " Modificado con Exito.".ToUpper,
                                          img, 2000,
                                          eToastGlowColor.Green,
                                          eToastPosition.TopCenter
                                          )
                MP_InHabilitar()
                MP_Filtrar(1)
            Else
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "El producto compuesto no pudo ser modificada".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)

            End If
        Catch ex As Exception
            MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Public Sub MP_EliminarRegistro()
        Try
            Dim ef = New Efecto
            ef.tipo = 2
            ef.Context = "¿esta seguro de eliminar el registro?".ToUpper
            ef.Header = "mensaje principal".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                Dim mensajeError As String = ""
                Dim res As Boolean = L_ProductoCompuestoCabecera_Eliminar(tb_Id.Text, mensajeError)
                If res Then
                    Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)

                    ToastNotification.Show(Me, "Código de producto compuesto ".ToUpper + tb_Id.Text + " eliminado con Exito.".ToUpper,
                                              img, 2000,
                                              eToastGlowColor.Green,
                                              eToastPosition.TopCenter)

                    MP_Filtrar(1)

                Else
                    Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                    ToastNotification.Show(Me, mensajeError, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                End If
            End If
        Catch ex As Exception
            MostrarMensajeError(ex.Message)
        End Try
    End Sub

    Private Sub tb_FechaVencimieto_Click(sender As Object, e As EventArgs) Handles tb_FechaVencimieto.Click

    End Sub

#End Region
End Class