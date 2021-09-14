Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
Imports UTILITIES
Imports System.Drawing.Printing

Public Class F0_Formula
#Region "Variables"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False
#End Region

#Region "Eventos"
    Private Sub F0_Formula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MP_Iniciar()
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

                Dim idVenta = Dgv_Busqueda.GetValue("IdFormula")
                Dim tEtiqueta = L_fnProductoCompuesto_Etiqueta(idVenta)
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
    Private Sub Btn_Imprimir_Click(sender As Object, e As EventArgs) Handles Btn_Imprimir.Click
        Try
            Imprimir()
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub

    Private Sub btn_Buscar_Click(sender As Object, e As EventArgs) Handles btn_Buscar.Click
        MP_Busqueda()
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
                idFormula = Convert.ToInt32(Dgv_Busqueda.CurrentRow.Cells("IdFormula").Value)
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
            If L_FnProductoCompuesto_VeridicarEstado(Dgv_Busqueda.GetValue("IdFormula"), ENEstadoProductoCompuestoVenta.COMPLETADO) Then
                Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
                ToastNotification.Show(Me, "Producto completado".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
                Exit Sub
            End If
            Dim checks = Me.Dgv_Busqueda.GetCheckedRows()
            Dim listIdFormula = checks.Select(Function(a) Convert.ToInt32(a.Cells("IdFormula").Value)).ToList()
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
#End Region

#Region "Metodos"
    Private Sub MP_Iniciar()
        MP_CargarComboLibreriaSucursal(cbSucursal)
        MP_CargarComboLibreria(cb_Tipo, 7, 1)
        MP_CargarComboLibreria(cb_Estado, 8, 1)
        cbSucursal.Value = 1
        cb_Estado.Value = CType(ENEstadoProductoCompuestoVenta.PENDIENTE, Integer)
        cb_Tipo.Value = CType(ENEstadoProductoCompuesto.MAGISTRAL, Integer)
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
        Dim cantidadEncabezado = Convert.ToDecimal(Dgv_Busqueda.GetValue("Cantidad"))
        For Each fila As GridEXRow In Dgv_Detalle.GetRows()
            cantidadDetalle = fila.Cells("pdValor").Value * cantidadEncabezado
            stock = fila.Cells("stock").Value
            If (cantidadDetalle > stock) Then
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub MP_Busqueda()
        Dim dt As New DataTable
        dt = L_fnProductoCompuesto_Buscar(cbSucursal.Value, tb_FechaDe.Value.ToString("yyyy/MM/dd"), tb_FechaHasta.Value.ToString("yyyy/MM/dd"), cb_Tipo.Value, cb_Estado.Value)
        Dgv_Busqueda.DataSource = dt
        Dgv_Busqueda.RetrieveStructure()
        Dgv_Busqueda.AlternatingColors = True
        With Dgv_Busqueda.RootTable.Columns("IdVenta")
            .Caption = "Id Venta"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns("cliente")
            .Caption = "Cliente"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Busqueda.RootTable.Columns("IdFormula")
            .Caption = "Id Formula"
            .Width = 100
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Busqueda.RootTable.Columns("Producto")
            .Caption = "Producto"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns("Cantidad")
            .Caption = "Cantidad"
            .Width = 200
            .FormatString = "0.00"
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns("Fecha")
            .Caption = "Fecha"
            .Width = 200
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns("Estado")
            .Caption = "Estado"
            .Width = 150
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
    End Sub
    Private Sub MP_MostrarGrillaDetalle(_N As Integer)
        Try
            Dim dt As New DataTable
            dt = L_fnProductoCompuestoTraerDetalleXId_StockVenta(_N, ENAlmacen.Almacen_MateriPrima)
            Dgv_Detalle.DataSource = dt
            Dgv_Detalle.RetrieveStructure()
            Dgv_Detalle.AlternatingColors = True
            With Dgv_Detalle.RootTable.Columns("id")
                .Key = "id"
                .Visible = False

            End With
            With Dgv_Detalle.RootTable.Columns("idProducto")
                .Key = "idProducto"
                .Caption = "Cod."
                .Width = 80
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("idProductoCompuesto")
                .Key = "idProductoCompuesto"
                .Visible = False

            End With
            With Dgv_Detalle.RootTable.Columns("pdeti")
                .Key = "pdeti"
                .Caption = "Etiqueta"
                .Width = 170
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdeticant")
                .Key = "pdeticant"
                .Caption = "Eti"
                .Visible = False

            End With

            With Dgv_Detalle.RootTable.Columns("IdUnidad")
                .Key = "IdUnidad"
                .Visible = False

            End With
            With Dgv_Detalle.RootTable.Columns("UnidadMin")
                .Visible = True
                .Key = "UnidadMin"
                .Caption = "Unidad"
                .Width = 70
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False

            End With
            With Dgv_Detalle.RootTable.Columns("pdPorc")
                .Key = "pdPorc"
                .Caption = "Porcentaje(%)"
                .FormatString = "0.00"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdcant")
                .Key = "pdcant"
                .Caption = "Cantidad"
                .FormatString = "0.000"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdValor1")
                .Key = "pdValor1"
                .Caption = "Valor1"
                .FormatString = "0.00"
                .Width = 90
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdValor2")
                .Key = "pdValor2"
                .Caption = "Valor2"
                .FormatString = "0.00"
                .Width = 90
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdJarabe")
                .Caption = "Jarabe"
                .Width = 80
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdvalor")
                .Key = "pdvalor"
                .Caption = "Valor"
                .FormatString = "0.0000"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdprec")
                .Key = "pdprec"
                .Caption = "Precio"
                .FormatString = "0.00000"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdtotal")
                .Key = "pdtotal"
                .Caption = "Total"
                .FormatString = "0.00000"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("stock")
                .Key = "stock"
                .Caption = "Stock"
                .FormatString = "0.0000"
                .Width = 100
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True

            End With
            With Dgv_Detalle.RootTable.Columns("pdvalorTotal")
                .Caption = "Valor Total"
                .Width = 100
                .FormatString = "0.0000"
                .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                .CellStyle.FontSize = gi_fuenteTamano
                .AllowSort = False
                .Visible = True
            End With
            'Habilitar Filtradores
            With Dgv_Detalle
                .GroupByBoxVisible = False
            End With
            'diseño de la grilla
            Dgv_Detalle.VisualStyle = VisualStyle.Office2007
            CalcularValorTotal()
        Catch ex As Exception
            MP_MostrarMensajeError(ex.Message)
        End Try
    End Sub
    Private Sub CalcularValorTotal()
        Dim cantidad = Dgv_Busqueda.GetValue("Cantidad")
        If Dgv_Detalle.RowCount > 0 Then
            Dim dt As DataTable = CType(Dgv_Detalle.DataSource, DataTable)
            For i As Integer = 0 To dt.Rows.Count - 1 Step 1
                ' If (dt.Rows(i).Item("estado") >= 0) Then
                CType(Dgv_Detalle.DataSource, DataTable).Rows(i).Item("pdvalorTotal") = cantidad * dt.Rows(i).Item("pdvalor")
                'End If
            Next
        End If
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

    Private Sub btn_Modificar_Click(sender As Object, e As EventArgs) Handles btn_Modificar.Click
        If L_FnProductoCompuesto_VeridicarEstado(Dgv_Busqueda.GetValue("IdFormula"), ENEstadoProductoCompuestoVenta.COMPLETADO) Then
            Dim img As Bitmap = New Bitmap(My.Resources.cancel, 50, 50)
            ToastNotification.Show(Me, "El producto compuesto se encuentra completado, no se puede modificar".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.BottomCenter)
            Exit Sub
        End If
        Dim frm As F0_ProductoCompuesto = New F0_ProductoCompuesto()
        frm.Tipo = 1
        frm._Modificar = True
        frm._idProcuctoCompuesto = Dgv_Busqueda.GetValue("IdFormula")
        frm.ShowDialog()
    End Sub

    Private Sub TimerActualizar_Tick(sender As Object, e As EventArgs) Handles TimerActualizar.Tick
        MP_MostrarGrillaEncabezado()
    End Sub
#End Region

#Region "Metodos Heredados"
#End Region

End Class