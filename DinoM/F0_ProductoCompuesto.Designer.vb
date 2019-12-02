<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F0_ProductoCompuesto
    'Inherits System.Windows.Forms.Form
    Inherits Modelo.ModeloF0
    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_ProductoCompuesto))
        Dim cbSucursal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.PanelContentSup = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GPanelProductos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Dgv_Productos = New Janus.Windows.GridEX.GridEX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.cbSucursal = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.sw_Tipo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
        Me.sw_ProductoCompuesto = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.tb_IdProducto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tb_FechaVencimieto = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tb_FechaFabrica = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.tb_Fecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.tb_Observacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tb_Descripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.tb_IdPro = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel4 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Dgv_Detalle = New Janus.Windows.GridEX.GridEX()
        Me.PanelTotal = New System.Windows.Forms.Panel()
        Me.tb_Total = New DevComponents.Editors.DoubleInput()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.BUSCAR = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Dgv_Busqueda = New Janus.Windows.GridEX.GridEX()
        Me.PanelSuperior.SuspendLayout()
        Me.PanelInferior.SuspendLayout()
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelToolBar1.SuspendLayout()
        Me.PanelToolBar2.SuspendLayout()
        Me.PanelPrincipal.SuspendLayout()
        Me.PanelUsuario.SuspendLayout()
        Me.PanelNavegacion.SuspendLayout()
        Me.MPanelUserAct.SuspendLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContent.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MSuperTabControlPanel1.SuspendLayout()
        CType(Me.MSuperTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MSuperTabControl.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelContentSup.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GPanelProductos.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.Dgv_Productos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.cbSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_FechaVencimieto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_FechaFabrica, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_Fecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.Dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTotal.SuspendLayout()
        CType(Me.tb_Total, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv_Busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelSuperior.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PanelSuperior.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PanelSuperior.Style.BackgroundImage = CType(resources.GetObject("PanelSuperior.Style.BackgroundImage"), System.Drawing.Image)
        Me.PanelSuperior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelSuperior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelSuperior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelSuperior.Style.GradientAngle = 90
        Me.PanelSuperior.StyleMouseDown.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PanelSuperior.StyleMouseDown.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PanelSuperior.StyleMouseOver.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PanelSuperior.StyleMouseOver.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.PanelSuperior.StyleMouseOver.BackgroundImage = CType(resources.GetObject("PanelSuperior.StyleMouseOver.BackgroundImage"), System.Drawing.Image)
        '
        'PanelInferior
        '
        Me.PanelInferior.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelInferior.Style.BackColor1.Color = System.Drawing.Color.Transparent
        Me.PanelInferior.Style.BackColor2.Color = System.Drawing.Color.Transparent
        Me.PanelInferior.Style.BackgroundImage = CType(resources.GetObject("PanelInferior.Style.BackgroundImage"), System.Drawing.Image)
        Me.PanelInferior.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelInferior.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelInferior.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelInferior.Style.GradientAngle = 90
        '
        'BubbleBarUsuario
        '
        '
        '
        '
        Me.BubbleBarUsuario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BackColor = System.Drawing.Color.Transparent
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderBottomWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderLeftWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderRightWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.BorderTopWidth = 1
        Me.BubbleBarUsuario.ButtonBackAreaStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingBottom = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingLeft = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingRight = 3
        Me.BubbleBarUsuario.ButtonBackAreaStyle.PaddingTop = 3
        Me.BubbleBarUsuario.MouseOverTabColors.BorderColor = System.Drawing.SystemColors.Highlight
        Me.BubbleBarUsuario.SelectedTabColors.BorderColor = System.Drawing.Color.Black
        '
        'TxtNombreUsu
        '
        Me.TxtNombreUsu.ReadOnly = True
        Me.TxtNombreUsu.Text = "DEFAULT"
        '
        'btnSalir
        '
        '
        'btnNuevo
        '
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelInferior, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelUsuario, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.PanelSuperior, 0)
        Me.PanelPrincipal.Controls.SetChildIndex(Me.Panel1, 0)
        '
        'btnUltimo
        '
        '
        'btnSiguiente
        '
        '
        'btnAnterior
        '
        '
        'btnPrimero
        '
        '
        'MRlAccion
        '
        '
        '
        '
        Me.MRlAccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'PanelContent
        '
        Me.PanelContent.Controls.Add(Me.GroupPanel4)
        Me.PanelContent.Controls.Add(Me.PanelTotal)
        Me.PanelContent.Controls.Add(Me.PanelContentSup)
        '
        'MSuperTabControl
        '
        '
        '
        '
        '
        '
        '
        Me.MSuperTabControl.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.MSuperTabControl.ControlBox.MenuBox.Name = ""
        Me.MSuperTabControl.ControlBox.Name = ""
        Me.MSuperTabControl.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.MSuperTabControl.ControlBox.MenuBox, Me.MSuperTabControl.ControlBox.CloseBox})
        Me.MSuperTabControl.Controls.Add(Me.SuperTabControlPanel1)
        Me.MSuperTabControl.SelectedTabIndex = 1
        Me.MSuperTabControl.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BUSCAR})
        Me.MSuperTabControl.Controls.SetChildIndex(Me.SuperTabControlPanel1, 0)
        Me.MSuperTabControl.Controls.SetChildIndex(Me.MSuperTabControlPanel1, 0)
        '
        'PanelContentSup
        '
        Me.PanelContentSup.BackColor = System.Drawing.Color.White
        Me.PanelContentSup.Controls.Add(Me.GroupPanel1)
        Me.PanelContentSup.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelContentSup.Location = New System.Drawing.Point(0, 0)
        Me.PanelContentSup.Name = "PanelContentSup"
        Me.PanelContentSup.Size = New System.Drawing.Size(951, 211)
        Me.PanelContentSup.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.GPanelProductos)
        Me.GroupPanel1.Controls.Add(Me.Panel2)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(951, 211)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 228
        Me.GroupPanel1.Text = "DATOS GENERALES"
        '
        'GPanelProductos
        '
        Me.GPanelProductos.CanvasColor = System.Drawing.SystemColors.Control
        Me.GPanelProductos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GPanelProductos.Controls.Add(Me.Panel7)
        Me.GPanelProductos.DisabledBackColor = System.Drawing.Color.Empty
        Me.GPanelProductos.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GPanelProductos.Location = New System.Drawing.Point(189, -22)
        Me.GPanelProductos.Name = "GPanelProductos"
        Me.GPanelProductos.Size = New System.Drawing.Size(720, 40)
        '
        '
        '
        Me.GPanelProductos.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.GPanelProductos.Style.BackColorGradientAngle = 90
        Me.GPanelProductos.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.GPanelProductos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPanelProductos.Style.BorderBottomWidth = 1
        Me.GPanelProductos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GPanelProductos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPanelProductos.Style.BorderLeftWidth = 1
        Me.GPanelProductos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPanelProductos.Style.BorderRightWidth = 1
        Me.GPanelProductos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GPanelProductos.Style.BorderTopWidth = 1
        Me.GPanelProductos.Style.CornerDiameter = 4
        Me.GPanelProductos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GPanelProductos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GPanelProductos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GPanelProductos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GPanelProductos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GPanelProductos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GPanelProductos.TabIndex = 235
        Me.GPanelProductos.Text = "PRODUCTOS"
        Me.GPanelProductos.Visible = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.Dgv_Productos)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(714, 17)
        Me.Panel7.TabIndex = 0
        '
        'Dgv_Productos
        '
        Me.Dgv_Productos.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
        Me.Dgv_Productos.BackColor = System.Drawing.Color.GhostWhite
        Me.Dgv_Productos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Productos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Productos.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Productos.HeaderFormatStyle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(49, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Dgv_Productos.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Productos.Name = "Dgv_Productos"
        Me.Dgv_Productos.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.Dgv_Productos.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.Dgv_Productos.Size = New System.Drawing.Size(714, 17)
        Me.Dgv_Productos.TabIndex = 0
        Me.Dgv_Productos.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.LabelX17)
        Me.Panel2.Controls.Add(Me.cbSucursal)
        Me.Panel2.Controls.Add(Me.sw_Tipo)
        Me.Panel2.Controls.Add(Me.LabelX19)
        Me.Panel2.Controls.Add(Me.sw_ProductoCompuesto)
        Me.Panel2.Controls.Add(Me.LabelX18)
        Me.Panel2.Controls.Add(Me.tb_IdProducto)
        Me.Panel2.Controls.Add(Me.LabelX7)
        Me.Panel2.Controls.Add(Me.LabelX2)
        Me.Panel2.Controls.Add(Me.LabelX4)
        Me.Panel2.Controls.Add(Me.tb_FechaVencimieto)
        Me.Panel2.Controls.Add(Me.tb_FechaFabrica)
        Me.Panel2.Controls.Add(Me.tb_Fecha)
        Me.Panel2.Controls.Add(Me.LabelX6)
        Me.Panel2.Controls.Add(Me.tb_Observacion)
        Me.Panel2.Controls.Add(Me.LabelX1)
        Me.Panel2.Controls.Add(Me.tb_Descripcion)
        Me.Panel2.Controls.Add(Me.LabelX3)
        Me.Panel2.Controls.Add(Me.tb_IdPro)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(945, 188)
        Me.Panel2.TabIndex = 234
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(450, 158)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX17.Size = New System.Drawing.Size(129, 23)
        Me.LabelX17.TabIndex = 374
        Me.LabelX17.Text = "Sucursal:"
        '
        'cbSucursal
        '
        cbSucursal_DesignTimeLayout.LayoutString = resources.GetString("cbSucursal_DesignTimeLayout.LayoutString")
        Me.cbSucursal.DesignTimeLayout = cbSucursal_DesignTimeLayout
        Me.cbSucursal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSucursal.Location = New System.Drawing.Point(591, 158)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbSucursal.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbSucursal.SelectedIndex = -1
        Me.cbSucursal.SelectedItem = Nothing
        Me.cbSucursal.Size = New System.Drawing.Size(164, 22)
        Me.cbSucursal.TabIndex = 373
        Me.cbSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'sw_Tipo
        '
        '
        '
        '
        Me.sw_Tipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sw_Tipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sw_Tipo.Location = New System.Drawing.Point(591, 130)
        Me.sw_Tipo.Name = "sw_Tipo"
        Me.sw_Tipo.OffBackColor = System.Drawing.Color.LawnGreen
        Me.sw_Tipo.OffText = "UNICA"
        Me.sw_Tipo.OnBackColor = System.Drawing.Color.Gold
        Me.sw_Tipo.OnText = "ESTANDAR"
        Me.sw_Tipo.Size = New System.Drawing.Size(136, 22)
        Me.sw_Tipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sw_Tipo.TabIndex = 5
        Me.sw_Tipo.Value = True
        Me.sw_Tipo.ValueObject = "Y"
        '
        'LabelX19
        '
        '
        '
        '
        Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX19.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX19.Location = New System.Drawing.Point(447, 129)
        Me.LabelX19.Name = "LabelX19"
        Me.LabelX19.Size = New System.Drawing.Size(115, 23)
        Me.LabelX19.TabIndex = 372
        Me.LabelX19.Text = "Tipo de formula:"
        '
        'sw_ProductoCompuesto
        '
        '
        '
        '
        Me.sw_ProductoCompuesto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sw_ProductoCompuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sw_ProductoCompuesto.Location = New System.Drawing.Point(150, 7)
        Me.sw_ProductoCompuesto.Name = "sw_ProductoCompuesto"
        Me.sw_ProductoCompuesto.OffBackColor = System.Drawing.Color.LawnGreen
        Me.sw_ProductoCompuesto.OffText = "NO"
        Me.sw_ProductoCompuesto.OnBackColor = System.Drawing.Color.Gold
        Me.sw_ProductoCompuesto.OnText = "SI"
        Me.sw_ProductoCompuesto.Size = New System.Drawing.Size(68, 22)
        Me.sw_ProductoCompuesto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sw_ProductoCompuesto.TabIndex = 241
        Me.sw_ProductoCompuesto.Value = True
        Me.sw_ProductoCompuesto.ValueObject = "Y"
        '
        'LabelX18
        '
        Me.LabelX18.AutoSize = True
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX18.Location = New System.Drawing.Point(11, 13)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX18.Size = New System.Drawing.Size(109, 16)
        Me.LabelX18.TabIndex = 240
        Me.LabelX18.Text = "Cod. de Producto"
        '
        'tb_IdProducto
        '
        Me.tb_IdProducto.BackColor = System.Drawing.Color.LightGray
        '
        '
        '
        Me.tb_IdProducto.Border.Class = "TextBoxBorder"
        Me.tb_IdProducto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_IdProducto.Enabled = False
        Me.tb_IdProducto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_IdProducto.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tb_IdProducto.Location = New System.Drawing.Point(225, 7)
        Me.tb_IdProducto.Name = "tb_IdProducto"
        Me.tb_IdProducto.PreventEnterBeep = True
        Me.tb_IdProducto.Size = New System.Drawing.Size(112, 22)
        Me.tb_IdProducto.TabIndex = 239
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX7.Location = New System.Drawing.Point(447, 94)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX7.Size = New System.Drawing.Size(80, 23)
        Me.LabelX7.TabIndex = 231
        Me.LabelX7.Text = "Fecha Venc.:"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX2.Location = New System.Drawing.Point(447, 61)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX2.Size = New System.Drawing.Size(129, 23)
        Me.LabelX2.TabIndex = 231
        Me.LabelX2.Text = "Fecha Fabrica:"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(447, 34)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX4.Size = New System.Drawing.Size(129, 23)
        Me.LabelX4.TabIndex = 231
        Me.LabelX4.Text = "Fecha:"
        '
        'tb_FechaVencimieto
        '
        '
        '
        '
        Me.tb_FechaVencimieto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tb_FechaVencimieto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaVencimieto.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tb_FechaVencimieto.ButtonDropDown.Visible = True
        Me.tb_FechaVencimieto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_FechaVencimieto.IsPopupCalendarOpen = False
        Me.tb_FechaVencimieto.Location = New System.Drawing.Point(591, 95)
        '
        '
        '
        '
        '
        '
        Me.tb_FechaVencimieto.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaVencimieto.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tb_FechaVencimieto.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tb_FechaVencimieto.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaVencimieto.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tb_FechaVencimieto.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tb_FechaVencimieto.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tb_FechaVencimieto.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaVencimieto.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tb_FechaVencimieto.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaVencimieto.MonthCalendar.TodayButtonVisible = True
        Me.tb_FechaVencimieto.Name = "tb_FechaVencimieto"
        Me.tb_FechaVencimieto.Size = New System.Drawing.Size(120, 22)
        Me.tb_FechaVencimieto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tb_FechaVencimieto.TabIndex = 4
        '
        'tb_FechaFabrica
        '
        '
        '
        '
        Me.tb_FechaFabrica.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tb_FechaFabrica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaFabrica.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tb_FechaFabrica.ButtonDropDown.Visible = True
        Me.tb_FechaFabrica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_FechaFabrica.IsPopupCalendarOpen = False
        Me.tb_FechaFabrica.Location = New System.Drawing.Point(591, 62)
        '
        '
        '
        '
        '
        '
        Me.tb_FechaFabrica.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaFabrica.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tb_FechaFabrica.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tb_FechaFabrica.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaFabrica.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tb_FechaFabrica.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tb_FechaFabrica.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tb_FechaFabrica.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaFabrica.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tb_FechaFabrica.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaFabrica.MonthCalendar.TodayButtonVisible = True
        Me.tb_FechaFabrica.Name = "tb_FechaFabrica"
        Me.tb_FechaFabrica.Size = New System.Drawing.Size(120, 22)
        Me.tb_FechaFabrica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tb_FechaFabrica.TabIndex = 4
        '
        'tb_Fecha
        '
        '
        '
        '
        Me.tb_Fecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tb_Fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Fecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tb_Fecha.ButtonDropDown.Visible = True
        Me.tb_Fecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Fecha.IsPopupCalendarOpen = False
        Me.tb_Fecha.Location = New System.Drawing.Point(591, 35)
        '
        '
        '
        '
        '
        '
        Me.tb_Fecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Fecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tb_Fecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tb_Fecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Fecha.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tb_Fecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tb_Fecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tb_Fecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_Fecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tb_Fecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Fecha.MonthCalendar.TodayButtonVisible = True
        Me.tb_Fecha.Name = "tb_Fecha"
        Me.tb_Fecha.Size = New System.Drawing.Size(120, 22)
        Me.tb_Fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tb_Fecha.TabIndex = 4
        '
        'LabelX6
        '
        Me.LabelX6.AutoSize = True
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX6.Location = New System.Drawing.Point(13, 43)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX6.Size = New System.Drawing.Size(129, 16)
        Me.LabelX6.TabIndex = 224
        Me.LabelX6.Text = "Cód. de Producto C.:"
        '
        'tb_Observacion
        '
        Me.tb_Observacion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tb_Observacion.Border.Class = "TextBoxBorder"
        Me.tb_Observacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Observacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Observacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tb_Observacion.Location = New System.Drawing.Point(150, 130)
        Me.tb_Observacion.Multiline = True
        Me.tb_Observacion.Name = "tb_Observacion"
        Me.tb_Observacion.PreventEnterBeep = True
        Me.tb_Observacion.Size = New System.Drawing.Size(249, 52)
        Me.tb_Observacion.TabIndex = 3
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(13, 126)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(90, 23)
        Me.LabelX1.TabIndex = 226
        Me.LabelX1.Text = "Observación:"
        '
        'tb_Descripcion
        '
        Me.tb_Descripcion.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.tb_Descripcion.Border.Class = "TextBoxBorder"
        Me.tb_Descripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Descripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Descripcion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tb_Descripcion.Location = New System.Drawing.Point(150, 72)
        Me.tb_Descripcion.Multiline = True
        Me.tb_Descripcion.Name = "tb_Descripcion"
        Me.tb_Descripcion.PreventEnterBeep = True
        Me.tb_Descripcion.Size = New System.Drawing.Size(249, 52)
        Me.tb_Descripcion.TabIndex = 2
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(13, 68)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX3.Size = New System.Drawing.Size(90, 23)
        Me.LabelX3.TabIndex = 226
        Me.LabelX3.Text = "Descripción:"
        '
        'tb_IdPro
        '
        '
        '
        '
        Me.tb_IdPro.Border.Class = "TextBoxBorder"
        Me.tb_IdPro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_IdPro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_IdPro.ForeColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.tb_IdPro.Location = New System.Drawing.Point(150, 41)
        Me.tb_IdPro.Name = "tb_IdPro"
        Me.tb_IdPro.PreventEnterBeep = True
        Me.tb_IdPro.Size = New System.Drawing.Size(85, 22)
        Me.tb_IdPro.TabIndex = 0
        Me.tb_IdPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupPanel4
        '
        Me.GroupPanel4.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel4.Controls.Add(Me.Panel5)
        Me.GroupPanel4.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel4.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel4.Location = New System.Drawing.Point(0, 211)
        Me.GroupPanel4.Name = "GroupPanel4"
        Me.GroupPanel4.Size = New System.Drawing.Size(951, 209)
        '
        '
        '
        Me.GroupPanel4.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel4.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel4.Style.BackColorGradientAngle = 90
        Me.GroupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderBottomWidth = 1
        Me.GroupPanel4.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderLeftWidth = 1
        Me.GroupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderRightWidth = 1
        Me.GroupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel4.Style.BorderTopWidth = 1
        Me.GroupPanel4.Style.CornerDiameter = 4
        Me.GroupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel4.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel4.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel4.TabIndex = 2
        Me.GroupPanel4.Text = "DETALLE DE PRODUCTOS COMPUESTOS"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.Dgv_Detalle)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(945, 186)
        Me.Panel5.TabIndex = 0
        '
        'Dgv_Detalle
        '
        Me.Dgv_Detalle.BackColor = System.Drawing.Color.GhostWhite
        Me.Dgv_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Detalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Detalle.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Detalle.Name = "Dgv_Detalle"
        Me.Dgv_Detalle.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.Dgv_Detalle.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.Dgv_Detalle.Size = New System.Drawing.Size(945, 186)
        Me.Dgv_Detalle.TabIndex = 4
        Me.Dgv_Detalle.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'PanelTotal
        '
        Me.PanelTotal.AutoScroll = True
        Me.PanelTotal.BackColor = System.Drawing.Color.SlateGray
        Me.PanelTotal.BackgroundImage = Global.DinoM.My.Resources.Resources.fondo1
        Me.PanelTotal.Controls.Add(Me.tb_Total)
        Me.PanelTotal.Controls.Add(Me.LabelX11)
        Me.PanelTotal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelTotal.Location = New System.Drawing.Point(0, 420)
        Me.PanelTotal.Name = "PanelTotal"
        Me.PanelTotal.Size = New System.Drawing.Size(951, 30)
        Me.PanelTotal.TabIndex = 3
        '
        'tb_Total
        '
        '
        '
        '
        Me.tb_Total.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tb_Total.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_Total.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.tb_Total.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_Total.Increment = 1.0R
        Me.tb_Total.Location = New System.Drawing.Point(843, 0)
        Me.tb_Total.MinValue = 0R
        Me.tb_Total.Name = "tb_Total"
        Me.tb_Total.Size = New System.Drawing.Size(89, 21)
        Me.tb_Total.TabIndex = 4
        Me.tb_Total.WatermarkAlignment = DevComponents.Editors.eTextAlignment.Right
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.White
        Me.LabelX11.Location = New System.Drawing.Point(758, 3)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX11.Size = New System.Drawing.Size(75, 18)
        Me.LabelX11.TabIndex = 38
        Me.LabelX11.Text = "Total Neto:"
        '
        'BUSCAR
        '
        Me.BUSCAR.AttachedControl = Me.SuperTabControlPanel1
        Me.BUSCAR.GlobalItem = False
        Me.BUSCAR.Name = "BUSCAR"
        Me.BUSCAR.Text = "BUSCAR"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.GroupPanel2)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(951, 450)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.BUSCAR
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Panel3)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(951, 450)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(72, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 3
        Me.GroupPanel2.Text = "BUSQUEDA DE PRODUCTOS COMPUESTOS"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.Dgv_Busqueda)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(945, 427)
        Me.Panel3.TabIndex = 0
        '
        'Dgv_Busqueda
        '
        Me.Dgv_Busqueda.BackColor = System.Drawing.Color.GhostWhite
        Me.Dgv_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Busqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Busqueda.HeaderFormatStyle.Font = New System.Drawing.Font("Georgia", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv_Busqueda.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Busqueda.Name = "Dgv_Busqueda"
        Me.Dgv_Busqueda.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.Dgv_Busqueda.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.Dgv_Busqueda.Size = New System.Drawing.Size(945, 427)
        Me.Dgv_Busqueda.TabIndex = 0
        Me.Dgv_Busqueda.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'F0_ProductoCompuesto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 561)
        Me.Name = "F0_ProductoCompuesto"
        Me.Text = "PRODUCTOS COMPUESTOS"
        Me.Controls.SetChildIndex(Me.PanelPrincipal, 0)
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelInferior.ResumeLayout(False)
        CType(Me.BubbleBarUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelToolBar1.ResumeLayout(False)
        Me.PanelToolBar2.ResumeLayout(False)
        Me.PanelPrincipal.ResumeLayout(False)
        Me.PanelUsuario.ResumeLayout(False)
        Me.PanelUsuario.PerformLayout()
        Me.PanelNavegacion.ResumeLayout(False)
        Me.MPanelUserAct.ResumeLayout(False)
        Me.MPanelUserAct.PerformLayout()
        CType(Me.MEP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContent.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.MSuperTabControlPanel1.ResumeLayout(False)
        CType(Me.MSuperTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MSuperTabControl.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelContentSup.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GPanelProductos.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        CType(Me.Dgv_Productos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.cbSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_FechaVencimieto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_FechaFabrica, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_Fecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        CType(Me.Dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTotal.ResumeLayout(False)
        CType(Me.tb_Total, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.Dgv_Busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelContentSup As Panel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents sw_Tipo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
    Friend WithEvents sw_ProductoCompuesto As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tb_IdProducto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tb_Fecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tb_Descripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel4 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Dgv_Detalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents PanelTotal As Panel
    Friend WithEvents tb_Total As DevComponents.Editors.DoubleInput
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tb_IdPro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Dgv_Busqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents BUSCAR As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents tb_Observacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tb_FechaVencimieto As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents tb_FechaFabrica As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GPanelProductos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Dgv_Productos As Janus.Windows.GridEX.GridEX
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbSucursal As Janus.Windows.GridEX.EditControls.MultiColumnCombo
End Class
