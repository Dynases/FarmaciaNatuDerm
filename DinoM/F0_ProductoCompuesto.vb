Imports Logica.AccesoLogica
Imports DevComponents.DotNetBar
Imports Janus.Windows.GridEX
Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.Controls
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
#End Region
#Region "Eventos del formulario"

    Private Sub F0_ProductoCompuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MP_Iniciar()
        MSuperTabControl.SelectedTabIndex = 0
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
    End Sub
    Private Sub Dgv_Busqueda_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgv_Busqueda.EditingCell
        e.Cancel = True
    End Sub

#End Region
#Region "Metodos privados"
    Private Sub MP_Iniciar()
        Me.Text = NombreFormulario
        MP_ValidarLote()
        MP_InHabilitar()
        MP_AsignarPermisos()
        MP_MostrarGrillaEncabezado()
        MP_CargarComboLibreriaSucursal(cbSucursal)
        'Fechas
        tb_Fecha.Value = Now.Date
        tb_FechaFabrica.Value = Now.Date
        tb_FechaVencimieto.Value = DateAdd("m", 6, Now.Date)
        cbSucursal.Value = 1
    End Sub
    Private Sub MP_MostrarGrillaEncabezado()
        Dim dt As New DataTable
        dt = L_fnProductoCompuestoTraerGeneral()
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
            .Key = "Tipo"
            .Caption = "Tipo"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns(3)
            .Key = "pcfech"
            .Caption = "Fecha"
            .Width = 120
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Busqueda.RootTable.Columns(4)
            .Key = "pcdesc"
            .Caption = "Descripción"
            .Width = 350
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Busqueda.RootTable.Columns(5)
            .Key = "pcobser"
            .Caption = "Observación"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Busqueda.RootTable.Columns(6)
            .Visible = True
            .Key = "pctotal"
            .Caption = "Total"
            .Width = 200
            .FormatString = "0.00"
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With Dgv_Busqueda.RootTable.Columns(7)
            .Key = "Estado"
            .Caption = "Estado"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
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
        End With
        'With Dgv_Detalle.RootTable.Columns(1)
        '.Key = "idProducto"
        '.Visible = False
        'End With
        With Dgv_Detalle.RootTable.Columns(1)
            .Key = "idProducto"
            .Caption = "Cod. Producto"
            .Width = 90
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .Visible = True
        End With
        With Dgv_Detalle.RootTable.Columns(2)
            .Key = "idProductoCompuesto"
            .Visible = False
        End With
        With Dgv_Detalle.RootTable.Columns(3)
            .Key = "pdest"
            .Visible = False
        End With
        With Dgv_Detalle.RootTable.Columns(4)
            .Key = "pdeti"
            .Caption = "Etiqueta"
            .Width = 300
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With

        With Dgv_Detalle.RootTable.Columns(5)
            .Key = "pdeticant"
            .Caption = "Eti"
            .Visible = False
        End With

        With Dgv_Detalle.RootTable.Columns(6)
            .Key = "IdUnidad"
            .Visible = False
        End With
        With Dgv_Detalle.RootTable.Columns(7)
            .Visible = True
            .Key = "UnidadMin"
            .Caption = "Unidad"
            .Width = 80
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
        End With
        With Dgv_Detalle.RootTable.Columns(8)
            .Key = "pdPorc"
            .Caption = "Porcentaje(%)"
            .FormatString = "0.00"
            .Width = 130
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Detalle.RootTable.Columns(9)
            .Key = "pdcant"
            .Caption = "Cantidad"
            .FormatString = "0.000"
            .Width = 130
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Detalle.RootTable.Columns(10)
            .Key = "pdvalor"
            .Caption = "Valor"
            .FormatString = "0.0000"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Detalle.RootTable.Columns(11)
            .Key = "pdprec"
            .Caption = "Precio"
            .FormatString = "0.00"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Detalle.RootTable.Columns(12)
            .Key = "pdtotal"
            .Caption = "Total"
            .FormatString = "0.00"
            .Width = 150
            .HeaderAlignment = Janus.Windows.GridEX.TextAlignment.Center
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Far
            .CellStyle.FontSize = gi_fuenteTamano
            .AllowSort = False
            .Visible = True
        End With
        With Dgv_Detalle.RootTable.Columns(13)
            .Key = "pdPCos"
            .Visible = False
        End With
        With Dgv_Detalle.RootTable.Columns(14)
            .Key = "Estado"
            .Visible = False
        End With
        With Dgv_Detalle.RootTable.Columns(15)
            .Key = "img"
            .Width = 80
            .Caption = "Eliminar".ToUpper
            .CellStyle.ImageHorizontalAlignment = ImageHorizontalAlignment.Center
            .Visible = False
        End With
        With Dgv_Detalle.RootTable.Columns(16)
            .Key = "stock"
            .Visible = False
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
        tb_IdProducto.ReadOnly = False
        tb_IdPro.ReadOnly = False
        tb_Descripcion.ReadOnly = False
        tb_Observacion.ReadOnly = False
        tb_Fecha.IsInputReadOnly = False
        tb_FechaFabrica.IsInputReadOnly = False
        tb_FechaVencimieto.IsInputReadOnly = False
        sw_Tipo.IsReadOnly = False

        Dgv_Detalle.Enabled = True
    End Sub
    Private Sub MP_InHabilitar()
        btnNuevo.Enabled = True
        btnModificar.Enabled = True
        btnEliminar.Enabled = True
        btnGrabar.Enabled = False
        sw_ProductoCompuesto.IsReadOnly = True
        tb_IdProducto.ReadOnly = True
        tb_IdPro.ReadOnly = True
        tb_Descripcion.ReadOnly = True
        tb_Observacion.ReadOnly = True
        tb_Fecha.IsInputReadOnly = True
        tb_FechaFabrica.IsInputReadOnly = True
        tb_FechaVencimieto.IsInputReadOnly = True
        sw_Tipo.IsReadOnly = True

        Dgv_Detalle.Enabled = False
    End Sub
    Private Sub MP_Limpiar()
        sw_ProductoCompuesto.IsReadOnly = False
        tb_IdProducto.Clear()
        tb_IdPro.Clear()
        tb_Descripcion.Clear()
        tb_Observacion.Clear()
        tb_Fecha.Value = Now.Date
        tb_FechaFabrica.Value = Now.Date
        tb_FechaVencimieto.Value = DateAdd("m", 6, Now.Date)
        sw_Tipo.IsReadOnly = False
        'MP_MostrarGrillaDetalle(-1)
        CType(Dgv_Detalle.DataSource, DataTable).Clear()
        tb_Total.Value = 0
        'MP_AddDetalle()
    End Sub
    Private Sub MP_MostrarRegistros(_N As Integer)
        With Dgv_Busqueda
            _idOriginal = .GetValue("id")
            Dim _tablaEncabezado As DataTable = L_fnProductoCompuestoTraerGeneralXId(_idOriginal)
            _idVenta = _tablaEncabezado.Rows(0).Item("idVenta")
            tb_IdPro.Text = _tablaEncabezado.Rows(0).Item("pccod")
            tb_Descripcion.Text = _tablaEncabezado.Rows(0).Item("pcdesc").ToString()
            tb_Observacion.Text = _tablaEncabezado.Rows(0).Item("pcobser").ToString()
            tb_Fecha.Value = _tablaEncabezado.Rows(0).Item("pcfech").ToString()
            tb_FechaFabrica.Value = _tablaEncabezado.Rows(0).Item("pcffab").ToString()
            tb_FechaVencimieto.Value = _tablaEncabezado.Rows(0).Item("pcfven").ToString()
            sw_Tipo.Value = IIf(_tablaEncabezado.Rows(0).Item("pctipo").ToString() = 1, True, False)
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
        If _Pos > 0 Then
            _Pos = _Pos - 1
            MP_MostrarRegistros(_Pos)
        End If
    End Sub
    Private Sub MP_SiguienteRegistro()
        If _Pos < Dgv_Busqueda.RowCount - 1 Then
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
    Private Sub MP_AsignarPermisos()

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
    End Sub
    Private Sub MP_Nuevo()
        MP_Habilitar()
        'btnNuevo.Enabled = True
        MP_Limpiar()
        tb_IdProducto.Focus()
        _Nuevo = True
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

    Private Sub MP_CargarProductos(_cliente As String)
        Dim dtname As DataTable = L_fnNameLabel()
        Dim dt As New DataTable
        If (G_Lote = True) Then
            dt = L_fnListarProductos(cbSucursal.Value, _cliente)  ''1=Almacen
            'Table_Producto = dt.Copy
        Else
            dt = L_fnListarProductosSinLote(cbSucursal.Value, _cliente, CType(Dgv_Detalle.DataSource, DataTable))  ''1=Almacen
            'Table_Producto = dt.Copy
        End If
        ''  actualizarSaldoSinLote(dt)
        Dgv_Productos.DataSource = dt
        Dgv_Productos.RetrieveStructure()
        Dgv_Productos.AlternatingColors = True
        '      a.yfnumi ,a.yfcprod ,a.yfcdprod1,a.yfcdprod2 ,a.yfgr1,gr1.ycdes3 as grupo1,a.yfgr2
        ',gr2.ycdes3 as grupo2 ,a.yfgr3,gr3.ycdes3 as grupo3,a.yfgr4 ,gr4 .ycdes3 as grupo4,a.yfumin ,Umin .ycdes3 as UnidMin
        ' ,b.yhprecio 
        With Dgv_Productos.RootTable.Columns("yfnumi")
            .Width = 100
            .Caption = "CODIGO"
            .Visible = False

        End With
        With Dgv_Productos.RootTable.Columns("yfcprod")
            .Width = 60
            .Caption = "CÓDIGO"
            .Visible = True
        End With
        With Dgv_Productos.RootTable.Columns("yfcbarra")
            .Width = 100
            .Caption = "COD. BARRA"
            .Visible = gb_CodigoBarra
        End With
        With Dgv_Productos.RootTable.Columns("yfcdprod1")
            .Width = 250
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
                .Width = 120
                .Caption = dtname.Rows(0).Item("Grupo 1").ToString
                .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
                .Visible = True
            End With
            With Dgv_Productos.RootTable.Columns("grupo2")
                .Width = 120
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
        With Dgv_Productos.RootTable.Columns("yhprecio")
            .Width = 90
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = True
            .Caption = "PRECIO"
            .FormatString = "0.00"
        End With
        With Dgv_Productos.RootTable.Columns("pcos")
            .Width = 120
            .CellStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Near
            .Visible = False
            .Caption = "Precio Costo"
            .FormatString = "0.00"
        End With
        With Dgv_Productos.RootTable.Columns("stock")
            .Width = 90
            .FormatString = "0.00"
            .Visible = True
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
        MP_AplicarCondiccionJanusSinLote()
    End Sub
    Public Sub MP_AplicarCondiccionJanusSinLote()
        Dim fc As GridEXFormatCondition
        fc = New GridEXFormatCondition(Dgv_Productos.RootTable.Columns("stock"), ConditionOperator.Between, -9998 And 0)
        fc.FormatStyle.ForeColor = Color.Red    '
        Dgv_Productos.RootTable.FormatConditions.Add(fc)
        Dim fr As GridEXFormatCondition
        fr = New GridEXFormatCondition(Dgv_Productos.RootTable.Columns("stock"), ConditionOperator.Equal, -9999)
        fr.FormatStyle.ForeColor = Color.BlueViolet
        Dgv_Productos.RootTable.FormatConditions.Add(fr)
    End Sub
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
        Dim dt As DataTable = CType(Dgv_Busqueda.DataSource, DataTable)
        Dim rows() As DataRow = dt.Select("id=MAX(id)")
        If (rows.Count > 0) Then
            Return rows(rows.Count - 1).Item("id")
        End If
        Return 1
    End Function

    Private Sub Dgv_Detalle_KeyDown_1(sender As Object, e As KeyEventArgs) Handles Dgv_Detalle.KeyDown
        If e.KeyData = Keys.Enter Then
            GPanelProductos.Height = 530
            GPanelProductos.Visible = True
            If _IdCliente = 0 Then
                MP_CargarProductos(2)
                Dgv_Productos.Focus()
            Else
                MP_CargarProductos(2)
                Dgv_Productos.Focus()
            End If
        End If
    End Sub

    Private Sub Dgv_Detalle_EditingCell(sender As Object, e As EditingCellEventArgs) Handles Dgv_Detalle.EditingCell
        If (tb_IdProducto.ReadOnly = False) Then
            If (e.Column.Index = Dgv_Detalle.RootTable.Columns("pdeti").Index Or
                e.Column.Index = Dgv_Detalle.RootTable.Columns("pdcant").Index Or
                e.Column.Index = Dgv_Detalle.RootTable.Columns("pdPorc").Index) Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub Dgv_Productos_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv_Productos.KeyDown
        If e.KeyData = Keys.Enter Then
            Dim idProducto, Etiqueda, idUnidad, Unidad, precio, costo, stock As String
            Dim Bin As New MemoryStream
            Dim img As New Bitmap(My.Resources.delete, 28, 28)
            img.Save(Bin, Imaging.ImageFormat.Png)

            idProducto = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yfnumi").Value)
            Etiqueda = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yfcdprod1").Value)
            idUnidad = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yfumin").Value)
            Unidad = Convert.ToString(Dgv_Productos.CurrentRow.Cells("UnidMin").Value)
            precio = Convert.ToString(Dgv_Productos.CurrentRow.Cells("yhprecio").Value)
            costo = Convert.ToString(Dgv_Productos.CurrentRow.Cells("pcos").Value)
            stock = Convert.ToString(Dgv_Productos.CurrentRow.Cells("stock").Value)

            Dim nuevaFila As DataRow = CType(Dgv_Detalle.DataSource, DataTable).NewRow()

            nuevaFila(0) = 0
            nuevaFila(1) = idProducto
            nuevaFila(2) = _fnSiguienteNumi() + 1
            nuevaFila(3) = 0
            nuevaFila(4) = Etiqueda
            nuevaFila(5) = ""
            nuevaFila(6) = idUnidad
            nuevaFila(7) = Unidad
            nuevaFila(8) = "0.00"
            nuevaFila(9) = "0.00"
            nuevaFila(10) = "0.00"
            nuevaFila(11) = precio
            nuevaFila(12) = "0.00"
            nuevaFila(13) = costo
            nuevaFila(14) = 0
            nuevaFila(15) = Bin.GetBuffer
            nuevaFila(16) = stock

            CType(Dgv_Detalle.DataSource, DataTable).Rows.Add(nuevaFila)

            GPanelProductos.Height = 80
            GPanelProductos.Visible = False
            Dgv_Detalle.Focus()
            'Dgv_Detalle.Row = Dgv_Detalle.Row - 1
        End If
    End Sub

    Private Sub Dgv_Detalle_UpdatingCell(sender As Object, e As UpdatingCellEventArgs) Handles Dgv_Detalle.UpdatingCell
        Dim cantidad, porcentaje, valor, precio, total As Double
        If (e.Column.Index = Dgv_Detalle.RootTable.Columns("pdPorc").Index) Then
            porcentaje = e.Value
            precio = Dgv_Detalle.CurrentRow.Cells("pdprec").Value
            cantidad = Dgv_Detalle.CurrentRow.Cells("pdcant").Value
            valor = (cantidad / 100) * porcentaje
            total = valor * precio
            Dgv_Detalle.CurrentRow.Cells("pdvalor").Value = valor
            Dgv_Detalle.CurrentRow.Cells("pdtotal").Value = total
            Dgv_Detalle.CurrentRow.Cells("pdeticant").Value = porcentaje.ToString() + "%"
        End If
        If (e.Column.Index = Dgv_Detalle.RootTable.Columns("pdcant").Index) Then
            cantidad = e.Value
            precio = Dgv_Detalle.CurrentRow.Cells("pdprec").Value
            porcentaje = Dgv_Detalle.CurrentRow.Cells("pdPorc").Value
            valor = (cantidad / 100) * porcentaje
            total = valor * precio
            Dgv_Detalle.CurrentRow.Cells("pdvalor").Value = valor
            Dgv_Detalle.CurrentRow.Cells("pdtotal").Value = total
            Dgv_Detalle.CurrentRow.Cells("pdeticant").Value = porcentaje.ToString() + "%"
        End If

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
            MP_Habilitar()
            MP_Salir()
            ' _PMPrimerRegistro() Nohay un Grilla para recorrer los datos
        Else
            Me.Close()
        End If

    End Sub
#End Region
End Class