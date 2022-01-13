
Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls

Public Class F1_CompraDetallada
    Dim _Inter As Integer = 0
#Region "Variables Locales"
    Dim RutaGlobal As String = gs_CarpetaRaiz
    Dim RutaTemporal As String = "C:\Temporal"
    Dim Modificado As Boolean = False
    Dim nameImg As String = "Default.jpg"
    Public _nameButton As String
    Public _tab As SuperTabItem
    Public _modulo As SideNavItem
    Public Limpiar As Boolean = False  'Bandera para indicar si limpiar todos los datos o mantener datos ya registrados
#End Region
#Region "Metodos Privados"
    Private Sub _prIniciarTodo()
        Me.Text = "COMPRA DETALLADA PARA EXPORTAR"
        tbFechaI.Value = Now.Date
        tbFechaF.Value = Now.Date

        Dim blah As New Bitmap(New Bitmap(My.Resources.producto), 20, 20)
        Dim ico As Icon = Icon.FromHandle(blah.GetHicon())
        Me.Icon = ico

        btnImprimir.Visible = False
    End Sub



    Private Sub _prCrearCarpetaTemporal()

        If System.IO.Directory.Exists(RutaTemporal) = False Then
            System.IO.Directory.CreateDirectory(RutaTemporal)
        Else
            Try
                My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory(RutaTemporal)
                'My.Computer.FileSystem.DeleteDirectory(RutaTemporal, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin)
                'System.IO.Directory.CreateDirectory(RutaTemporal)

            Catch ex As Exception

            End Try
        End If
    End Sub


    Private Sub _prCrearCarpetaReportes()
        Dim rutaDestino As String = RutaGlobal + "\Reporte\Reporte Compras\"

        If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Compras\") = False Then
            If System.IO.Directory.Exists(RutaGlobal + "\Reporte") = False Then
                System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte")
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Compras") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte Compras")
                End If
            Else
                If System.IO.Directory.Exists(RutaGlobal + "\Reporte\Reporte Compras") = False Then
                    System.IO.Directory.CreateDirectory(RutaGlobal + "\Reporte\Reporte Compras")

                End If
            End If
        End If
    End Sub
    Private Sub _prCargarVenta()
        Dim fechaDesde As DateTime = tbFechaI.Value.ToString("yyyy/MM/dd")
        Dim fechaHasta As DateTime = tbFechaF.Value.ToString("yyyy/MM/dd")
        Dim dt As DataTable = L_ComprasDetallado(fechaDesde, fechaHasta)

        If dt.Rows.Count > 0 Then
            JGrM_Buscador.DataSource = dt
            JGrM_Buscador.RetrieveStructure()
            JGrM_Buscador.AlternatingColors = True


            With JGrM_Buscador.RootTable.Columns("CodigoCompra")
                .Width = 100
                .Caption = "COD. COMPRA"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("FechaCompra")
                .Width = 90
                .Visible = True
                .Caption = "FECHA"
            End With
            With JGrM_Buscador.RootTable.Columns("caalm")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("Almacen")
                .Width = 100
                .Caption = "ALMACEN"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("caty4prov")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("ydcod")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("Proveedor")
                .Width = 100
                .Caption = "PROVEEDOR"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("Nit")
                .Width = 100
                .Caption = "NIT"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("catven")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("TipoCompra")
                .Width = 100
                .Caption = "TIPO COMPRA"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("FechaVenc")
                .Width = 100
                .Caption = "FECHA VENC."
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("caest")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("Observacion")
                .Width = 130
                .Caption = "OBSERVACIÓN"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("caemision")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("Emision")
                .Width = 100
                .Caption = "EMISIÓN"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("NroFacturaRecibo")
                .Width = 100
                .Caption = "NRO. FACT/RECIBO"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("caconsigna")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("caretenc")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("CodProd")
                .Width = 100
                .Caption = "COD. PROD."
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("Producto")
                .Width = 130
                .Caption = "PRODUCTO"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("Cantidad")
                .Width = 90
                .Caption = "CANTIDAD"
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With

            With JGrM_Buscador.RootTable.Columns("PrecioUnitario")
                .Width = 120
                .Caption = "PRECIO UN."
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With JGrM_Buscador.RootTable.Columns("Lote")
                .Width = 100
                .Caption = "LOTE"
                .Visible = True
            End With
            With JGrM_Buscador.RootTable.Columns("FechaVencProd")
                .Width = 100
                .Caption = "FECHAVENC.PROD."
                .Visible = True
            End With

            With JGrM_Buscador.RootTable.Columns("Subtotal")
                .Width = 120
                .Caption = "SUBTOTAL"
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With JGrM_Buscador.RootTable.Columns("PrecioVenta")
                .Width = 100
                .Caption = "PRECIO VENTA"
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            End With
            With JGrM_Buscador.RootTable.Columns("SubTotalCompra")
                .Width = 120
                .Caption = "SUBTOTAL COMPRA"
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                '.AggregateFunction = AggregateFunction.Sum
            End With
            With JGrM_Buscador.RootTable.Columns("DescuentoCompra")
                .Width = 120
                .Caption = "DESCTO. COMPRA"
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                '.AggregateFunction = AggregateFunction.Sum
            End With
            With JGrM_Buscador.RootTable.Columns("TotalCompra")
                .Width = 120
                .Caption = "TOTAL COMPRA"
                .Visible = True
                .FormatString = "0.00"
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
                '.AggregateFunction = AggregateFunction.Sum
            End With
            With JGrM_Buscador.RootTable.Columns("cafact")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("cahact")
                .Visible = False
            End With
            With JGrM_Buscador.RootTable.Columns("cauact")
                .Visible = False
            End With

            With JGrM_Buscador.RootTable.Columns("NroComprobante")
                .Width = 120
                .Visible = True
                .Caption = "NRO. COMPROBANTE"
            End With

            With JGrM_Buscador
                .DefaultFilterRowComparison = FilterConditionOperator.Contains
                .FilterMode = FilterMode.Automatic
                .FilterRowUpdateMode = FilterRowUpdateMode.WhenValueChanges
                .GroupByBoxVisible = False
                '.TotalRow = InheritableBoolean.True
                '.TotalRowFormatStyle.BackColor = Color.Gold
                '.TotalRowPosition = TotalRowPosition.BottomFixed

                'diseño de la grilla
            End With

        Else
            JGrM_Buscador.ClearStructure()
            Dim img As Bitmap = New Bitmap(My.Resources.mensaje, 50, 50)
            ToastNotification.Show(Me, "No existe datos para mostrar".ToUpper, img, 2000, eToastGlowColor.Red, eToastPosition.TopCenter)
        End If

    End Sub
#End Region

    Private Sub F1_Productos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _prIniciarTodo()
    End Sub


    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btExcel.Click
        _prCrearCarpetaReportes()
        Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
        If (P_ExportarExcel(RutaGlobal + "\Reporte\Reporte Compras")) Then
            ToastNotification.Show(Me, "EXPORTACIÓN DE COMPRAS DETALLADA EXITOSA..!!!",
                                       img, 2000,
                                       eToastGlowColor.Green,
                                       eToastPosition.BottomCenter)
        Else
            ToastNotification.Show(Me, "FALLÓ AL EXPORTACIÓN DE COMPRAS DETALLADA..!!!",
                                       My.Resources.WARNING, 2000,
                                       eToastGlowColor.Red,
                                       eToastPosition.BottomLeft)
        End If
    End Sub


    Public Function P_ExportarExcel(_ruta As String) As Boolean
        Dim _ubicacion As String
        'Dim _directorio As New FolderBrowserDialog

        If (1 = 1) Then 'If(_directorio.ShowDialog = Windows.Forms.DialogResult.OK) Then
            '_ubicacion = _directorio.SelectedPath
            _ubicacion = _ruta
            Try
                Dim _stream As Stream
                Dim _escritor As StreamWriter
                Dim _fila As Integer = JGrM_Buscador.GetRows.Length
                Dim _columna As Integer = JGrM_Buscador.RootTable.Columns.Count
                Dim _archivo As String = _ubicacion & "\CompraDetallada_" & Now.Date.Day &
                    "." & Now.Date.Month & "." & Now.Date.Year & "_" & Now.Hour & "." & Now.Minute & "." & Now.Second & ".csv"
                Dim _linea As String = ""
                Dim _filadata = 0, columndata As Int32 = 0
                File.Delete(_archivo)
                _stream = File.OpenWrite(_archivo)
                _escritor = New StreamWriter(_stream, System.Text.Encoding.UTF8)

                For Each _col As GridEXColumn In JGrM_Buscador.RootTable.Columns
                    If (_col.Visible) Then
                        _linea = _linea & _col.Caption & ";"
                    End If
                Next
                _linea = Mid(CStr(_linea), 1, _linea.Length - 1)
                _escritor.WriteLine(_linea)
                _linea = Nothing

                'Pbx_Precios.Visible = True
                'Pbx_Precios.Minimum = 1
                'Pbx_Precios.Maximum = Dgv_Precios.RowCount
                'Pbx_Precios.Value = 1

                For Each _fil As GridEXRow In JGrM_Buscador.GetRows
                    For Each _col As GridEXColumn In JGrM_Buscador.RootTable.Columns
                        If (_col.Visible) Then
                            Dim data As String = CStr(_fil.Cells(_col.Key).Value)
                            data = data.Replace(";", ",")
                            _linea = _linea & data & ";"
                        End If
                    Next
                    _linea = Mid(CStr(_linea), 1, _linea.Length - 1)
                    _escritor.WriteLine(_linea)
                    _linea = Nothing
                    'Pbx_Precios.Value += 1
                Next
                _escritor.Close()
                'Pbx_Precios.Visible = False
                Try
                    Dim ef = New Efecto
                    ef._archivo = _archivo

                    ef.tipo = 1
                    ef.Context = "Su archivo ha sido Guardado en la ruta: " + _archivo + vbLf + "DESEA ABRIR EL ARCHIVO?"
                    ef.Header = "PREGUNTA"
                    ef.ShowDialog()
                    Dim bandera As Boolean = False
                    bandera = ef.band
                    If (bandera = True) Then
                        Process.Start(_archivo)
                    End If

                    'If (MessageBox.Show("Su archivo ha sido Guardado en la ruta: " + _archivo + vbLf + "DESEA ABRIR EL ARCHIVO?", "PREGUNTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    '    Process.Start(_archivo)
                    'End If
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End If
        Return False
    End Function





    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        _Inter = _Inter + 1
        If _Inter = 1 Then
            Me.WindowState = FormWindowState.Normal

        Else
            Me.Opacity = 100
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs) Handles btnGenerar.Click
        _prCargarVenta()
    End Sub

    Private Sub btnExportarExcel_Click(sender As Object, e As EventArgs) Handles btnExportarExcel.Click
        _prCrearCarpetaReportes()
        Dim img As Bitmap = New Bitmap(My.Resources.checked, 50, 50)
        If (P_ExportarExcel(RutaGlobal + "\Reporte\Reporte Compras")) Then
            ToastNotification.Show(Me, "EXPORTACIÓN DE COMPRAS DETALLADAS EXITOSA..!!!",
                                       img, 2000,
                                       eToastGlowColor.Green,
                                       eToastPosition.BottomCenter)
        Else
            ToastNotification.Show(Me, "FALLÓ LA EXPORTACIÓN DE COMPRAS DETALLADAS..!!!",
                                       My.Resources.WARNING, 2000,
                                       eToastGlowColor.Red,
                                       eToastPosition.BottomLeft)
        End If
    End Sub
End Class