Imports System
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Timers

Public Class frmScrapeWeb
#Region "Global"
    Private Shared dir As String = Regex.Replace(My.Application.Info.DirectoryPath, "\bbin\b\\.*", "") ' .Replace("bin\Debug", "")
    Public Shared appData As String = String.Format("{0}appData\{1}", dir, "{0}")
    Public Shared scrapedDir As String = String.Format(appData, "scraped\{0}")

    Private urlList As New List(Of String)
    Private url As String = ""
    Private ttl As Double = 0
#End Region
#Region "Browser Simulation"


    Private Const BrowserKeyPath As String = "\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
    Private Sub CreateBrowserKey(Optional ByVal IgnoreIDocDirective As Boolean = False)
        Dim basekey As String = Microsoft.Win32.Registry.CurrentUser.ToString
        Dim value As Int32
        Dim thisAppsName As String = My.Application.Info.AssemblyName & ".exe"
        ' Value reference: http://msdn.microsoft.com/en-us/library/ee330730%28v=VS.85%29.aspx
        ' IDOC Reference:  http://msdn.microsoft.com/en-us/library/ms535242%28v=vs.85%29.aspx
        Select Case (New WebBrowser).Version.Major
            Case 8
                If IgnoreIDocDirective Then
                    value = 8888
                Else
                    value = 8000
                End If
            Case 9
                If IgnoreIDocDirective Then
                    value = 9999
                Else
                    value = 9000
                End If
            Case 10
                If IgnoreIDocDirective Then
                    value = 10001
                Else
                    value = 10000
                End If
            Case 11
                If IgnoreIDocDirective Then
                    value = 11001
                Else
                    value = 11000
                End If

            Case Else
                Exit Sub
        End Select
        Microsoft.Win32.Registry.SetValue(Microsoft.Win32.Registry.CurrentUser.ToString & BrowserKeyPath,
                                          Process.GetCurrentProcess.ProcessName & ".exe",
                                          value,
                                          Microsoft.Win32.RegistryValueKind.DWord)
    End Sub
    Private Sub RemoveBrowerKey()
        Dim key As Microsoft.Win32.RegistryKey
        key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(BrowserKeyPath.Substring(1), True)
        key.DeleteValue(Process.GetCurrentProcess.ProcessName & ".exe", False)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        RemoveBrowerKey()
    End Sub
#End Region

    Public Sub New()
        CreateBrowserKey()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        wb.ScriptErrorsSuppressed = True
    End Sub

    Private Sub btnLoadURL_ButtonClick(sender As Object, e As EventArgs) Handles btnLoadURL.ButtonClick
        If url = "" Then
            MsgBox("There are currently no urls to view", MsgBoxStyle.Critical)
        Else
            lblURL.Text = url
            wb.Navigate(url)
        End If
    End Sub

    Private Sub btnScrape_ButtonClick(sender As Object, e As EventArgs) Handles btnScrape.ButtonClick
        AddHandler t.Elapsed, New ElapsedEventHandler(AddressOf Elapsed)
        t.Start()
    End Sub

    Private Sub btnLoadURLList_ButtonClick(sender As Object, e As EventArgs) Handles btnLoadURLList.ButtonClick
        Using dr As New StreamReader(String.Format(appData, "url.txt"))
            Do Until dr.EndOfStream
                urlList.Add(dr.ReadLine)
            Loop
        End Using

        ttl = urlList.Count

        Using dr As New StreamReader(String.Format(appData, "complete.txt"))
            Do Until dr.EndOfStream
                Dim tmp_url As String = dr.ReadLine.Split(",")(1)
                urlList.Remove(tmp_url)
            Loop
        End Using

        url = urlList(0)
        urlList.RemoveAt(0)

        lblURL.Text = url
        lblStats.Text = String.Format("Remaining:{0}/{1}", urlList.Count + 1, ttl)
    End Sub

    Dim bool As Boolean = False

    Private t As New Timers.Timer(5000)
    Private Sub Elapsed(ByVal sender As Object, ByVal e As ElapsedEventArgs)
        Try
            Me.Invoke(New MethodInvoker(AddressOf extractNextURL))
        Catch ex As Exception

        End Try
    End Sub

    Dim cnt As Double = 0
    Public Sub extractNextURL()
        cnt += 1
        If cnt Mod 50 = 0 Then
            t.Stop()
            Thread.Sleep(30000)
            t.Start()
        End If
        Dim txt As String = wb.Document.Body.InnerHtml

        Dim id As Guid = Guid.NewGuid

        Using wr As New StreamWriter(String.Format(scrapedDir, id.ToString & ".txt"))
            wr.AutoFlush = True
            wr.Write(txt)
            wr.Close()
        End Using

        Using wr As New StreamWriter(String.Format(appData, "complete.txt"), append:=True)
            wr.AutoFlush = True
            wr.WriteLine(String.Format("{0},{1}", id.ToString, url.ToString))
            wr.Close()
        End Using

        If urlList.Count = 0 Then
            t.Stop()
            MsgBox("Complete!!!", MsgBoxStyle.Critical)
        End If

        url = urlList(0)
        urlList.RemoveAt(0)

        lblURL.Text = url
        lblStats.Text = String.Format("Remaining:{0}/{1}", urlList.Count + 1, ttl)

        wb.Navigate(url)
    End Sub

End Class
