Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Imports UTILITIES
Imports System.Drawing.Printing
Public Class F0_FormulaProduccion
#Region "Variables"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False
#End Region


#Region "Metodos"
    Private Sub MP_Iniciar()
        MP_CargarComboLibreriaSucursal(cbSucursal)
        MP_CargarComboLibreria(cb_Estado, 8, 1)
        cbSucursal.Value = 2
        cb_Estado.Value = CType(ENEstadoProductoCompuestoVenta.PENDIENTE, Integer)
        tb_FechaDe.Value = Now.Date.ToString("yyyy/MM/dd")
        tb_FechaHasta.Value = Now.Date.ToString("yyyy/MM/dd")
        MP_MostrarGrillaEncabezado()
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
    Private Sub MP_CargarComboLibreria(mCombo As Janus.Windows.GridEX.EditControls.MultiColumnCombo, cod1 As String, cod2 As String)
        Dim dt As New DataTable
        dt = L_prLibreriaClienteLGeneral(cod1, cod2)
        With mCombo
            .DropDownList.Columns.Clear()
            .DropDownList.Columns.Add("yccod3").Width = 70
            .DropDownList.Columns("yccod3").Caption = "COD"
            .DropDownList.Columns.Add("ycdes3").Width = 200
            .DropDownList.Columns("ycdes3").Caption = "DESCRIPCION"
            .ValueMember = "yccod3"
            .DisplayMember = "ycdes3"
            .DataSource = dt
            .Refresh()
        End With
    End Sub
    Private Sub MP_MostrarGrillaEncabezado()
        MP_Busqueda()
    End Sub
    Private Function MP_ExisteStockProducto() As Boolean
        Dim cantidadDetalle, stock As Decimal
        For Each fila As GridEXRow In Dgv_Detalle.GetRows()
            cantidadDetalle = fila.Cells("pdValor").Value
            stock = fila.Cells("stock").Value
            If (cantidadDetalle > stock) Then
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub MP_Busqueda()
        Try
            Dim dt As New DataTable
            dt = L_FormulaProduccion_Buscar(cbSucursal.Value, tb_FechaDe.Value.ToString("yyyy/MM/dd"), tb_FechaHasta.Value.ToString("yyyy/MM/dd"), cb_Estado.Value)
            Dgv_Busqueda.DataSource = dt
            Dgv_Busqueda.RetrieveStructure()
            Dgv_Busqueda.AlternatingColors = True
            With Dgv_Busqueda.RootTable.Columns("Id")
                .Caption = "Id"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            With Dgv_Busqueda.RootTable.Columns("Codigo")
                .Caption = "Codigo"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            With Dgv_Busqueda.RootTable.Columns("ProductoTerminado")
                .Caption = "ProductoTerminado"
                .Width = 300
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            With Dgv_Busqueda.RootTable.Columns("Cantidad")
                .Caption = "Cantidad"
                .Width = 250
                .FormatString = "0.00"
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            With Dgv_Busqueda.RootTable.Columns("Fecha")
                .Caption = "Fecha"
                .Width = 250
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            With Dgv_Busqueda.RootTable.Columns("Estado")
                .Caption = "Estado"
                .Width = 200
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            Dgv_Busqueda.RootTable.Columns.Add(New GridEXColumn("Seleccionar"))
            With Dgv_Busqueda.RootTable.Columns("Seleccionar")
                .Caption = "Seleccionar"
                .Width = 80
                .ShowRowSelector = True
                .UseHeaderSelector = True
                .FilterEditType = Janus.Windows.GridEX.FilterEditType.NoEdit
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
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub MP_MostrarGrillaDetalle(_N As Integer)
        Dim dt As New DataTable
        dt = L_fnProductoCompuestoTraerDetalleXId_Stock(_N, ENAlmacen.Almacen_MateriPrima)
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
            .FormatString = "0.00000"
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
            .FormatString = "0.00000"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 14
        End With
        With Dgv_Detalle.RootTable.Columns(15)
            .Key = "stock"
            .Caption = "Stock"
            .FormatString = "0.00"
            .Width = 110
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
            .Position = 15
        End With
        'Habilitar Filtradores
        With Dgv_Detalle
            .GroupByBoxVisible = False
        End With
        'diseño de la grilla
        Dgv_Detalle.VisualStyle = VisualStyle.Office2007



    End Sub
    Private Sub MP_MostrarMensajeError(mensaje As String)
        ToastNotification.Show(Me,
                               mensaje.ToUpper,
                               My.Resources.WARNING,
                               ENMensaje.MEDIANO,
                               eToastGlowColor.Red,
                               eToastPosition.TopCenter)
    End Sub

    Private Sub MP_MostrarMensajeOk(mensaje As String)
        ToastNotification.Show(Me,
                               mensaje.ToUpper,
                               My.Resources.OK,
                               ENMensaje.MEDIANO,
                               eToastGlowColor.Green,
                               eToastPosition.TopCenter)
    End Sub
#End Region

#Region "Eventos"
    Private Sub F0_Formula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MP_Iniciar()
    End Sub
    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        Try
            If L_FnProductoCompuesto_VeridicarEstado(Dgv_Busqueda.GetValue("Id"), ENEstadoProductoCompuestoVenta.COMPLETADO) Then
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "El producto compuesto se encuentra completado, no se puede modificar".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                Exit Sub
            End If
            Dim frm As F0_ProductoCompuesto = New F0_ProductoCompuesto()
            frm.Tipo = 3
            frm._Modificar = True
            frm._idProcuctoCompuesto = Dgv_Busqueda.GetValue("Id")
            frm.ShowDialog()
            MP_Busqueda()
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click
        Try
            Imprimir()
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try

    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        Try
            MP_Busqueda()
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Imprimir()
        Try
            Dim ef = New Efecto
            ef.tipo = 2
            ef.Context = "MENSAJE PRINCIPAL".ToUpper
            ef.Header = "¿desea imprimir la etiqueta?".ToUpper
            ef.ShowDialog()
            Dim bandera As Boolean = False
            bandera = ef.band
            If (bandera = True) Then
                If Not IsNothing(P_Global.Visualizador) Then
                    P_Global.Visualizador.Close()
                End If

                Dim idVenta = Dgv_Busqueda.GetValue("Id")
                Dim tEtiqueta = L_fnProductoCompuesto_Produccion_Etiqueta(idVenta)
                If tEtiqueta.Rows.Count = 0 Then
                    Throw New Exception("Formula no completada")
                End If
                Dim objrep As New R_EtiquetaFormula
                objrep.SetDataSource(tEtiqueta)
                Dim _DsRutaImpresora = L_ObtenerRutaImpresora("1") ' Datos de Impresion de Facturación
                If (_DsRutaImpresora.Tables(0).Rows(0).Item("cbvp")) Then 'Vista Previa de la Ventana de Vizualización 1 = True 0 = False
                    P_Global.Visualizador = New Visualizador
                    P_Global.Visualizador.CrGeneral.ReportSource = objrep
                    P_Global.Visualizador.ShowDialog()
                    P_Global.Visualizador.BringToFront()
                Else
                    Dim pd As New PrintDocument()
                    pd.PrinterSettings.PrinterName = "EPSON LX-350 ESC/P"
                    If (Not pd.PrinterSettings.IsValid) Then
                        ToastNotification.Show(Me, "La Impresora ".ToUpper + "EPSON LX-350 ESC/P" + "No Existe".ToUpper,
                                               My.Resources.WARNING, 5 * 1000,
                                               eToastGlowColor.Blue, eToastPosition.BottomRight)
                    Else
                        objrep.PrintOptions.PrinterName = "EPSON LX-350 ESC/P" '_Ds3.Tables(0).Rows(0).Item("cbrut").ToString 
                        objrep.PrintToPrinter(1, False, 1, 1)
                    End If
                End If

            End If

        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Dgv_Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgv_Busqueda.EditingCell

        Try
            If (e.Column.Index = Dgv_Busqueda.RootTable.Columns("Seleccionar").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub Dgv_Detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgv_Detalle.EditingCell
        e.Cancel = True
    End Sub

    Private Sub Dgv_Busqueda_SelectionChanged(sender As Object, e As EventArgs) Handles Dgv_Busqueda.SelectionChanged
        Try
            Dim idFormula = 0
            If (Dgv_Busqueda.GetRows().Count > 0) Then
                idFormula = Convert.ToInt32(Dgv_Busqueda.CurrentRow.Cells("Id").Value)
            End If
            MP_MostrarGrillaDetalle(idFormula)
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub

    Private Sub btn_Confirmar_Click(sender As Object, e As EventArgs) Handles btn_Confirmar.Click
        Try
            Dim listResult As Boolean = False
            If Dgv_Busqueda.RowCount < 0 Then
                Throw New Exception("No se encontraron registros")
            End If
            If L_FnProductoCompuesto_VeridicarEstado(Dgv_Busqueda.GetValue("Id"), ENEstadoProductoCompuestoVenta.COMPLETADO) Then
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "Producto completado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                Exit Sub
            End If
            Dim checks = Me.Dgv_Busqueda.GetCheckedRows()
            Dim listIdFormula = checks.Select(Function(a) Convert.ToInt32(a.Cells("Id").Value)).ToList()
            If listIdFormula.Count = 1 Then
                For Each idFormula As Integer In listIdFormula
                    'listResult = L_FnProductoCompuesto_ModificarEstado(idFormula, ENEstadoProductoCompuestoVenta.COMPLETADO)
                    'Verificar existencia de stock de los productos
                    If MP_ExisteStockProducto() Then
                        listResult = L_FnProductoCompuesto_ModificarEstado(idFormula, ENEstadoProductoCompuestoVenta.COMPLETADO)
                    End If
                    If (listResult = False) Then
                        Throw New Exception("No existe Stock para algun producto.")
                    End If
                    Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
                    ToastNotification.Show(Me, "Estado de la Formula ".ToUpper + idFormula.ToString() + " Modificado con Exito.".ToUpper,
                                              img, 2000,
                                              eToastGlowColor.Green,
                                              eToastPosition.TopCenter
                                              )
                    Imprimir()
                    MP_MostrarGrillaEncabezado()
                Next

            Else
                Throw New Exception("Debe seleccionar 1 registro.")
            End If

        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub

    Private Sub TimerActualizar_Tick(sender As Object, e As EventArgs) Handles TimerActualizar.Tick
        MP_MostrarGrillaEncabezado()
    End Sub
#End Region

End Class