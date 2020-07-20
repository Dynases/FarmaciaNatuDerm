<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class F0_FormulaProduccion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim cb_Estado_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F0_FormulaProduccion))
        Dim cbSucursal_DesignTimeLayout As Janus.Windows.GridEX.GridEXLayout = New Janus.Windows.GridEX.GridEXLayout()
        Me.PanelSuperior = New System.Windows.Forms.Panel()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.cb_Estado = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.tb_FechaHasta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tb_FechaDe = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
        Me.cbSucursal = New Janus.Windows.GridEX.EditControls.MultiColumnCombo()
        Me.btn_Buscar = New DevComponents.DotNetBar.ButtonX()
        Me.btn_Modificar = New DevComponents.DotNetBar.ButtonX()
        Me.btn_Confirmar = New DevComponents.DotNetBar.ButtonX()
        Me.Btn_Imprimir = New DevComponents.DotNetBar.ButtonX()
        Me.PanelProducto = New System.Windows.Forms.Panel()
        Me.Dgv_Detalle = New Janus.Windows.GridEX.GridEX()
        Me.PanelPedido = New System.Windows.Forms.Panel()
        Me.Dgv_Busqueda = New Janus.Windows.GridEX.GridEX()
        Me.TimerActualizar = New System.Windows.Forms.Timer(Me.components)
        Me.PanelSuperior.SuspendLayout()
        CType(Me.cb_Estado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_FechaHasta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tb_FechaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cbSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelProducto.SuspendLayout()
        CType(Me.Dgv_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPedido.SuspendLayout()
        CType(Me.Dgv_Busqueda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelSuperior
        '
        Me.PanelSuperior.Controls.Add(Me.LabelX3)
        Me.PanelSuperior.Controls.Add(Me.cb_Estado)
        Me.PanelSuperior.Controls.Add(Me.LabelX1)
        Me.PanelSuperior.Controls.Add(Me.tb_FechaHasta)
        Me.PanelSuperior.Controls.Add(Me.LabelX4)
        Me.PanelSuperior.Controls.Add(Me.tb_FechaDe)
        Me.PanelSuperior.Controls.Add(Me.LabelX17)
        Me.PanelSuperior.Controls.Add(Me.cbSucursal)
        Me.PanelSuperior.Controls.Add(Me.btn_Buscar)
        Me.PanelSuperior.Controls.Add(Me.btn_Modificar)
        Me.PanelSuperior.Controls.Add(Me.btn_Confirmar)
        Me.PanelSuperior.Controls.Add(Me.Btn_Imprimir)
        Me.PanelSuperior.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelSuperior.Location = New System.Drawing.Point(0, 0)
        Me.PanelSuperior.Name = "PanelSuperior"
        Me.PanelSuperior.Size = New System.Drawing.Size(1087, 60)
        Me.PanelSuperior.TabIndex = 2
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX3.Location = New System.Drawing.Point(12, 31)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX3.Size = New System.Drawing.Size(64, 23)
        Me.LabelX3.TabIndex = 248
        Me.LabelX3.Text = "Estado:"
        '
        'cb_Estado
        '
        cb_Estado_DesignTimeLayout.LayoutString = resources.GetString("cb_Estado_DesignTimeLayout.LayoutString")
        Me.cb_Estado.DesignTimeLayout = cb_Estado_DesignTimeLayout
        Me.cb_Estado.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb_Estado.Location = New System.Drawing.Point(82, 31)
        Me.cb_Estado.Name = "cb_Estado"
        Me.cb_Estado.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cb_Estado.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cb_Estado.SelectedIndex = -1
        Me.cb_Estado.SelectedItem = Nothing
        Me.cb_Estado.Size = New System.Drawing.Size(110, 23)
        Me.cb_Estado.TabIndex = 247
        Me.cb_Estado.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX1.Location = New System.Drawing.Point(236, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX1.Size = New System.Drawing.Size(36, 23)
        Me.LabelX1.TabIndex = 244
        Me.LabelX1.Text = "Hasta:"
        '
        'tb_FechaHasta
        '
        '
        '
        '
        Me.tb_FechaHasta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tb_FechaHasta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaHasta.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tb_FechaHasta.ButtonDropDown.Visible = True
        Me.tb_FechaHasta.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_FechaHasta.IsPopupCalendarOpen = False
        Me.tb_FechaHasta.Location = New System.Drawing.Point(278, 3)
        '
        '
        '
        '
        '
        '
        Me.tb_FechaHasta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaHasta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tb_FechaHasta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tb_FechaHasta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaHasta.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tb_FechaHasta.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tb_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tb_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaHasta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tb_FechaHasta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaHasta.MonthCalendar.TodayButtonVisible = True
        Me.tb_FechaHasta.Name = "tb_FechaHasta"
        Me.tb_FechaHasta.Size = New System.Drawing.Size(106, 23)
        Me.tb_FechaHasta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tb_FechaHasta.TabIndex = 243
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX4.Location = New System.Drawing.Point(14, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX4.Size = New System.Drawing.Size(64, 23)
        Me.LabelX4.TabIndex = 242
        Me.LabelX4.Text = "Fecha De:"
        '
        'tb_FechaDe
        '
        '
        '
        '
        Me.tb_FechaDe.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.tb_FechaDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaDe.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.tb_FechaDe.ButtonDropDown.Visible = True
        Me.tb_FechaDe.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb_FechaDe.IsPopupCalendarOpen = False
        Me.tb_FechaDe.Location = New System.Drawing.Point(82, 3)
        '
        '
        '
        '
        '
        '
        Me.tb_FechaDe.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaDe.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.tb_FechaDe.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.tb_FechaDe.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaDe.MonthCalendar.DisplayMonth = New Date(2017, 2, 1, 0, 0, 0, 0)
        Me.tb_FechaDe.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        '
        '
        '
        Me.tb_FechaDe.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.tb_FechaDe.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.tb_FechaDe.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.tb_FechaDe.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.tb_FechaDe.MonthCalendar.TodayButtonVisible = True
        Me.tb_FechaDe.Name = "tb_FechaDe"
        Me.tb_FechaDe.Size = New System.Drawing.Size(110, 23)
        Me.tb_FechaDe.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.tb_FechaDe.TabIndex = 241
        '
        'LabelX17
        '
        Me.LabelX17.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.LabelX17.Location = New System.Drawing.Point(586, 3)
        Me.LabelX17.Name = "LabelX17"
        Me.LabelX17.SingleLineColor = System.Drawing.SystemColors.Control
        Me.LabelX17.Size = New System.Drawing.Size(64, 23)
        Me.LabelX17.TabIndex = 240
        Me.LabelX17.Text = "Deposito:"
        Me.LabelX17.Visible = False
        '
        'cbSucursal
        '
        cbSucursal_DesignTimeLayout.LayoutString = resources.GetString("cbSucursal_DesignTimeLayout.LayoutString")
        Me.cbSucursal.DesignTimeLayout = cbSucursal_DesignTimeLayout
        Me.cbSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSucursal.Location = New System.Drawing.Point(656, 3)
        Me.cbSucursal.Name = "cbSucursal"
        Me.cbSucursal.Office2007ColorScheme = Janus.Windows.GridEX.Office2007ColorScheme.Custom
        Me.cbSucursal.Office2007CustomColor = System.Drawing.Color.DodgerBlue
        Me.cbSucursal.SelectedIndex = -1
        Me.cbSucursal.SelectedItem = Nothing
        Me.cbSucursal.Size = New System.Drawing.Size(112, 23)
        Me.cbSucursal.TabIndex = 239
        Me.cbSucursal.Visible = False
        Me.cbSucursal.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2007
        '
        'btn_Buscar
        '
        Me.btn_Buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Buscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Buscar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Buscar.Image = Global.DinoM.My.Resources.Resources.search
        Me.btn_Buscar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btn_Buscar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btn_Buscar.Location = New System.Drawing.Point(787, 0)
        Me.btn_Buscar.Name = "btn_Buscar"
        Me.btn_Buscar.Size = New System.Drawing.Size(75, 60)
        Me.btn_Buscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Buscar.TabIndex = 7
        Me.btn_Buscar.Text = "Buscar"
        '
        'btn_Modificar
        '
        Me.btn_Modificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Modificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Modificar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Modificar.Image = Global.DinoM.My.Resources.Resources.edit
        Me.btn_Modificar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btn_Modificar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btn_Modificar.Location = New System.Drawing.Point(862, 0)
        Me.btn_Modificar.Name = "btn_Modificar"
        Me.btn_Modificar.Size = New System.Drawing.Size(75, 60)
        Me.btn_Modificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Modificar.TabIndex = 4
        Me.btn_Modificar.Text = "Modificar"
        '
        'btn_Confirmar
        '
        Me.btn_Confirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btn_Confirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btn_Confirmar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btn_Confirmar.Image = Global.DinoM.My.Resources.Resources.checked
        Me.btn_Confirmar.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btn_Confirmar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btn_Confirmar.Location = New System.Drawing.Point(937, 0)
        Me.btn_Confirmar.Name = "btn_Confirmar"
        Me.btn_Confirmar.Size = New System.Drawing.Size(75, 60)
        Me.btn_Confirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btn_Confirmar.TabIndex = 6
        Me.btn_Confirmar.Text = "Confirmar"
        '
        'Btn_Imprimir
        '
        Me.Btn_Imprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Btn_Imprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Btn_Imprimir.Dock = System.Windows.Forms.DockStyle.Right
        Me.Btn_Imprimir.Image = Global.DinoM.My.Resources.Resources.printee
        Me.Btn_Imprimir.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.Btn_Imprimir.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.Btn_Imprimir.Location = New System.Drawing.Point(1012, 0)
        Me.Btn_Imprimir.Name = "Btn_Imprimir"
        Me.Btn_Imprimir.Size = New System.Drawing.Size(75, 60)
        Me.Btn_Imprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Btn_Imprimir.TabIndex = 5
        Me.Btn_Imprimir.Text = "Imprimir"
        Me.Btn_Imprimir.Visible = False
        '
        'PanelProducto
        '
        Me.PanelProducto.Controls.Add(Me.Dgv_Detalle)
        Me.PanelProducto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelProducto.Location = New System.Drawing.Point(0, 292)
        Me.PanelProducto.Name = "PanelProducto"
        Me.PanelProducto.Size = New System.Drawing.Size(1087, 158)
        Me.PanelProducto.TabIndex = 3
        '
        'Dgv_Detalle
        '
        Me.Dgv_Detalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Detalle.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Detalle.Name = "Dgv_Detalle"
        Me.Dgv_Detalle.Size = New System.Drawing.Size(1087, 158)
        Me.Dgv_Detalle.TabIndex = 3
        '
        'PanelPedido
        '
        Me.PanelPedido.Controls.Add(Me.Dgv_Busqueda)
        Me.PanelPedido.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelPedido.Location = New System.Drawing.Point(0, 60)
        Me.PanelPedido.Name = "PanelPedido"
        Me.PanelPedido.Size = New System.Drawing.Size(1087, 232)
        Me.PanelPedido.TabIndex = 4
        '
        'Dgv_Busqueda
        '
        Me.Dgv_Busqueda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dgv_Busqueda.Location = New System.Drawing.Point(0, 0)
        Me.Dgv_Busqueda.Name = "Dgv_Busqueda"
        Me.Dgv_Busqueda.Size = New System.Drawing.Size(1087, 232)
        Me.Dgv_Busqueda.TabIndex = 2
        '
        'TimerActualizar
        '
        Me.TimerActualizar.Interval = 3000
        '
        'F0_FormulaProduccion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1087, 450)
        Me.Controls.Add(Me.PanelPedido)
        Me.Controls.Add(Me.PanelProducto)
        Me.Controls.Add(Me.PanelSuperior)
        Me.Name = "F0_FormulaProduccion"
        Me.Text = "FORMULA DE PRODUCCION"
        Me.PanelSuperior.ResumeLayout(False)
        Me.PanelSuperior.PerformLayout()
        CType(Me.cb_Estado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_FechaHasta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tb_FechaDe, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cbSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelProducto.ResumeLayout(False)
        CType(Me.Dgv_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPedido.ResumeLayout(False)
        CType(Me.Dgv_Busqueda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PanelSuperior As Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tb_FechaHasta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tb_FechaDe As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cbSucursal As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents btn_Buscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_Modificar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btn_Confirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Btn_Imprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PanelProducto As Panel
    Friend WithEvents Dgv_Detalle As Janus.Windows.GridEX.GridEX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cb_Estado As Janus.Windows.GridEX.EditControls.MultiColumnCombo
    Friend WithEvents PanelPedido As Panel
    Friend WithEvents Dgv_Busqueda As Janus.Windows.GridEX.GridEX
    Friend WithEvents TimerActualizar As Timer
End Class
