<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScrapeWeb
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScrapeWeb))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btnScrape = New System.Windows.Forms.ToolStripSplitButton()
        Me.lblURL = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnLoadURL = New System.Windows.Forms.ToolStripSplitButton()
        Me.btnLoadURLList = New System.Windows.Forms.ToolStripSplitButton()
        Me.lblStats = New System.Windows.Forms.ToolStripStatusLabel()
        Me.wb = New System.Windows.Forms.WebBrowser()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnScrape, Me.lblURL, Me.btnLoadURL, Me.btnLoadURLList, Me.lblStats})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 473)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(699, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btnScrape
        '
        Me.btnScrape.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.btnScrape.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnScrape.Image = CType(resources.GetObject("btnScrape.Image"), System.Drawing.Image)
        Me.btnScrape.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnScrape.Name = "btnScrape"
        Me.btnScrape.Size = New System.Drawing.Size(58, 20)
        Me.btnScrape.Text = "Scrape"
        '
        'lblURL
        '
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(21, 17)
        Me.lblURL.Text = "url"
        '
        'btnLoadURL
        '
        Me.btnLoadURL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnLoadURL.Image = CType(resources.GetObject("btnLoadURL.Image"), System.Drawing.Image)
        Me.btnLoadURL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoadURL.Name = "btnLoadURL"
        Me.btnLoadURL.Size = New System.Drawing.Size(73, 20)
        Me.btnLoadURL.Text = "Load URL"
        Me.btnLoadURL.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'btnLoadURLList
        '
        Me.btnLoadURLList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnLoadURLList.Image = CType(resources.GetObject("btnLoadURLList.Image"), System.Drawing.Image)
        Me.btnLoadURLList.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoadURLList.Name = "btnLoadURLList"
        Me.btnLoadURLList.Size = New System.Drawing.Size(84, 20)
        Me.btnLoadURLList.Text = "Load url list"
        Me.btnLoadURLList.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'lblStats
        '
        Me.lblStats.Name = "lblStats"
        Me.lblStats.Size = New System.Drawing.Size(36, 17)
        Me.lblStats.Text = "# urls"
        '
        'wb
        '
        Me.wb.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wb.Location = New System.Drawing.Point(0, 0)
        Me.wb.Margin = New System.Windows.Forms.Padding(2)
        Me.wb.MinimumSize = New System.Drawing.Size(13, 13)
        Me.wb.Name = "wb"
        Me.wb.Size = New System.Drawing.Size(699, 495)
        Me.wb.TabIndex = 6
        '
        'frmScrapeWeb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(699, 495)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.wb)
        Me.Name = "frmScrapeWeb"
        Me.Text = "Scrape Web"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents btnScrape As ToolStripSplitButton
    Friend WithEvents lblURL As ToolStripStatusLabel
    Friend WithEvents btnLoadURL As ToolStripSplitButton
    Friend WithEvents wb As WebBrowser
    Friend WithEvents btnLoadURLList As ToolStripSplitButton
    Friend WithEvents lblStats As ToolStripStatusLabel
End Class
