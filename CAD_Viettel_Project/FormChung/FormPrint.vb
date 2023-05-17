Imports System.IO
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Runtime
Imports System
Imports System.Drawing.Imaging
Imports System.Runtime.CompilerServices
Imports Autodesk.AutoCAD.ApplicationServices.DocumentExtension
Imports Autodesk.AutoCAD.ApplicationServices.Document
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports Autodesk.AutoCAD.Colors
Imports Autodesk.AutoCAD.PlottingServices
Imports System.Runtime.InteropServices
' Add ribbon 
Imports Autodesk.Windows
Imports System.Windows.Input
Public Class FormPrint
    Dim fcSPC As New mdSPCFunction_TA
    Dim path As String
    Dim TenTram As String = ""
    'Private Sub Button1_Click(sender As Object, e As EventArgs)
    '    Dim doc = Application.DocumentManager.MdiActiveDocument
    '    ''Dim strDWGName As String = doc.Name
    '    'If doc Is Nothing Then Return
    '    'Dim ed = doc.Editor
    '    'Dim pofo = New PromptSaveFileOptions(vbLf & "Select image location")

    '    'pofo.Filter = "Bitmap (*.bmp)|*.bmp|GIF (*.gif)|*.gif|JPEG (*.jpg)|*.jpg|" & "PNG (*.png)|*.png|TIFF (*.tif)|*.tif"
    '    'Dim fn As String = doc.Database.Filename
    '    'If fn.Contains(".") Then
    '    '    Dim extIdx As Integer = fn.LastIndexOf(".")
    '    '    If fn.Substring(extIdx + 1) <> "dwt" AndAlso fn.Contains("\") Then
    '    '        pofo.InitialDirectory = Path.GetDirectoryName(fn)
    '    '    End If
    '    'End If

    '    ''strDWGName = DefaultProjectFolder & " \ Data" & ThongTinChung.MaTram & "_" & ThongTinChung.DiaDiem
    '    'Dim pfnr = ed.GetFileNameForSave(pofo)

    '    'If pfnr.Status <> PromptStatus.OK Then Return
    '    Dim outFile = txtDuongDan.Text.ToString
    '    MsgBox("Đã lưu hình ảnh Mặt bằng" & outFile)
    '    'doc.Database.SaveAs(strDWGName, True, DwgVersion.Current,
    '    'doc.Database.SecurityParameters)

    '    Dim size = doc.Window.DeviceIndependentSize
    '    Using bmp = DocumentExtension.CapturePreviewImage(doc, Convert.ToUInt32(size.Width), Convert.ToUInt32(size.Height))
    '        bmp.Save(outFile, outFile.GetFormat())
    '    End Using
    'End Sub
    Dim sl As Integer
    Private Sub rdbMatDung_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMatDung.CheckedChanged
        txtDuongDan.Text = path & "\Data" & TenTram & "\MatDung.png"
        sl = 1
    End Sub

    Private Sub rdbMatBang_CheckedChanged(sender As Object, e As EventArgs) Handles rdbMatBang.CheckedChanged
        txtDuongDan.Text = path & "\Data" & TenTram & "\MatBang.png"
        sl = 2
    End Sub

    Private Sub FormPrint_Load(sender As Object, e As EventArgs) Handles Me.Load
        path = fcSPC.ReadText("C:\ProgramData\PathSupport.txt")

        Dim List() As String = path.Split("\")
        TenTram = List(List.Length - 1)
        'Dim list2() As String = TenTram.Split("_")
        ''lbTenTram.Visible = True
        ''lbTenTram.Text = list2(0).ToString
        'TenTram = list2(0).ToString
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If sl = 2 Then
            Lib_Drawing.SaveDrawing(path & "\Data" & TenTram & "\MatBang")
            Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database

            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                ' Reference the Layout Manager
                Dim acLayoutMgr As LayoutManager = LayoutManager.Current
                ' Get the current layout and output its name in the Command Line window
                Dim acLayout As Layout = acTrans.GetObject(acLayoutMgr.GetLayoutId(acLayoutMgr.CurrentLayout),
                              OpenMode.ForWrite)


                'Dim PlotConfig As StdConfiguration
                ' Get the PlotInfo from the layout
                Using acPlInfo As PlotInfo = New PlotInfo()
                    acPlInfo.Layout = acLayout.ObjectId

                    ' Get a copy of the PlotSettings from the layout
                    Using acPlSet As PlotSettings = New PlotSettings(acLayout.ModelType)
                        acPlSet.CopyFrom(acLayout)
                        acPlSet.PrintLineweights = True
                        acPlSet.PlotTransparency = False
                        acPlSet.PlotPlotStyles = True
                        acPlSet.DrawViewportsFirst = True
                        ' Update the PlotSettings object
                        Dim acPlSetVdr As PlotSettingsValidator = PlotSettingsValidator.Current
                        acPlSetVdr.RefreshLists(acLayout)
                        Dim styleSheetName As System.Collections.Specialized.StringCollection = acPlSetVdr.GetPlotStyleSheetList()
                        acPlSetVdr.SetCurrentStyleSheet(acLayout, "monochrome.ctb") 'kaitomajickid

                        acPlSetVdr.SetPlotRotation(acPlSet, PlotRotation.Degrees000)
                        ' Set the plot type
                        acPlSetVdr.SetPlotType(acPlSet, Autodesk.AutoCAD.DatabaseServices.PlotType.Extents)

                        ' Set the plot scale
                        acPlSetVdr.SetUseStandardScale(acPlSet, True)
                        acPlSetVdr.SetStdScaleType(acPlSet, StdScaleType.ScaleToFit)
                        ' Center the plotss
                        acPlSetVdr.SetPlotCentered(acPlSet, True)


                        ' Set the plot device to use
                        acPlSetVdr.SetPlotConfigurationName(acPlSet, "PublishToWeb PNG.pc3", "Sun_Hi-Res_(1600.00_x_1280.00_Pixels)")
                        'acPlSetVdr.SetPlotConfigurationName(acPlSet, "DWG To PDF.pc3", "ISO_A4_(297.00_x_210.00_MM)")
                        ' Set the plot info as an override since it will
                        ' not be saved back to the layout

                        acPlInfo.OverrideSettings = acPlSet

                        ' Validate the plot info
                        Using acPlInfoVdr As PlotInfoValidator = New PlotInfoValidator()
                            acPlInfoVdr.MediaMatchingPolicy = MatchingPolicy.MatchEnabled
                            acPlInfoVdr.Validate(acPlInfo)

                            ' Check to see if a plot is already in progress
                            If PlotFactory.ProcessPlotState =
                            ProcessPlotState.NotPlotting Then

                                Using acPlEng As PlotEngine =
                                PlotFactory.CreatePublishEngine()

                                    ' Track the plot progress with a Progress dialog
                                    Using acPlProgDlg As PlotProgressDialog =
                                    New PlotProgressDialog(False, 1, True)

                                        Using (acPlProgDlg)
                                            ' Define the status messages to display 
                                            ' when plotting starts
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.DialogTitle) = "Plot Progress"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.CancelJobButtonMessage) = "Cancel Job"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.CancelSheetButtonMessage) = "Cancel Sheet"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.SheetSetProgressCaption) = "Sheet Set Progress"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.SheetProgressCaption) = "Sheet Progress"

                                            ' Set the plot progress range
                                            acPlProgDlg.LowerPlotProgressRange = 0
                                            acPlProgDlg.UpperPlotProgressRange = 100
                                            acPlProgDlg.PlotProgressPos = 0

                                            ' Display the Progress dialog
                                            acPlProgDlg.OnBeginPlot()
                                            acPlProgDlg.IsVisible = True

                                            ' Start to plot the layout
                                            acPlEng.BeginPlot(acPlProgDlg, Nothing)

                                            ' Define the plot output
                                            acPlEng.BeginDocument(acPlInfo, "SPC.pdf", Nothing, 1, True, txtDuongDan.Text)

                                            ' Display information about the current plot
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.Status) = "Plotting: " & "SPC.pdf" & " - " & "Layout1"

                                            ' Set the sheet progress range
                                            acPlProgDlg.OnBeginSheet()
                                            acPlProgDlg.LowerSheetProgressRange = 0
                                            acPlProgDlg.UpperSheetProgressRange = 100
                                            acPlProgDlg.SheetProgressPos = 0

                                            ' Plot the first sheet/layout
                                            Using acPlPageInfo As PlotPageInfo =
                                            New PlotPageInfo()
                                                acPlEng.BeginPage(acPlPageInfo,
                                                              acPlInfo,
                                                              True,
                                                              Nothing)
                                            End Using

                                            acPlEng.BeginGenerateGraphics(Nothing)
                                            acPlEng.EndGenerateGraphics(Nothing)

                                            ' Finish plotting the sheet/layout
                                            acPlEng.EndPage(Nothing)
                                            acPlProgDlg.SheetProgressPos = 100
                                            acPlProgDlg.OnEndSheet()

                                            ' Finish plotting the document
                                            acPlEng.EndDocument(Nothing)

                                            ' Finish the plot
                                            acPlProgDlg.PlotProgressPos = 100
                                            acPlProgDlg.OnEndPlot()
                                            acPlEng.EndPlot(Nothing)
                                        End Using
                                    End Using
                                End Using
                            End If
                        End Using
                    End Using
                End Using
            End Using
            MsgBox("Đã lưu hình ảnh vào đường dẫn !")
            Me.Close()
        Else
            Lib_Drawing.SaveDrawing(path & "\Data" & TenTram & "\MatDung")
            Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database

            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
                ' Reference the Layout Manager
                Dim acLayoutMgr As LayoutManager = LayoutManager.Current
                ' Get the current layout and output its name in the Command Line window
                Dim acLayout As Layout = acTrans.GetObject(acLayoutMgr.GetLayoutId(acLayoutMgr.CurrentLayout),
                              OpenMode.ForWrite)


                'Dim PlotConfig As StdConfiguration
                ' Get the PlotInfo from the layout
                Using acPlInfo As PlotInfo = New PlotInfo()
                    acPlInfo.Layout = acLayout.ObjectId

                    ' Get a copy of the PlotSettings from the layout
                    Using acPlSet As PlotSettings = New PlotSettings(acLayout.ModelType)
                        acPlSet.CopyFrom(acLayout)
                        acPlSet.PrintLineweights = True
                        acPlSet.PlotTransparency = False
                        acPlSet.PlotPlotStyles = True
                        acPlSet.DrawViewportsFirst = True
                        ' Update the PlotSettings object
                        Dim acPlSetVdr As PlotSettingsValidator = PlotSettingsValidator.Current
                        acPlSetVdr.RefreshLists(acLayout)
                        Dim styleSheetName As System.Collections.Specialized.StringCollection = acPlSetVdr.GetPlotStyleSheetList()
                        acPlSetVdr.SetCurrentStyleSheet(acLayout, "monochrome.ctb") 'kaitomajickid

                        acPlSetVdr.SetPlotRotation(acPlSet, PlotRotation.Degrees000)
                        ' Set the plot type
                        acPlSetVdr.SetPlotType(acPlSet, Autodesk.AutoCAD.DatabaseServices.PlotType.Extents)

                        ' Set the plot scale
                        acPlSetVdr.SetUseStandardScale(acPlSet, True)
                        acPlSetVdr.SetStdScaleType(acPlSet, StdScaleType.ScaleToFit)
                        ' Center the plotss
                        acPlSetVdr.SetPlotCentered(acPlSet, True)


                        ' Set the plot device to use
                        acPlSetVdr.SetPlotConfigurationName(acPlSet, "PublishToWeb PNG.pc3", "Sun_Hi-Res_(1280.00_x_1600.00_Pixels)")
                        'acPlSetVdr.SetPlotConfigurationName(acPlSet, "DWG To PDF.pc3", "ISO_A4_(210.00_x_297.00_MM)")
                        ' Set the plot info as an override since it will
                        ' not be saved back to the layout

                        acPlInfo.OverrideSettings = acPlSet

                        ' Validate the plot info
                        Using acPlInfoVdr As PlotInfoValidator = New PlotInfoValidator()
                            acPlInfoVdr.MediaMatchingPolicy = MatchingPolicy.MatchEnabled
                            acPlInfoVdr.Validate(acPlInfo)

                            ' Check to see if a plot is already in progress
                            If PlotFactory.ProcessPlotState =
                            ProcessPlotState.NotPlotting Then

                                Using acPlEng As PlotEngine =
                                PlotFactory.CreatePublishEngine()

                                    ' Track the plot progress with a Progress dialog
                                    Using acPlProgDlg As PlotProgressDialog =
                                    New PlotProgressDialog(False, 1, True)

                                        Using (acPlProgDlg)
                                            ' Define the status messages to display 
                                            ' when plotting starts
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.DialogTitle) = "Plot Progress"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.CancelJobButtonMessage) = "Cancel Job"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.CancelSheetButtonMessage) = "Cancel Sheet"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.SheetSetProgressCaption) = "Sheet Set Progress"
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.SheetProgressCaption) = "Sheet Progress"

                                            ' Set the plot progress range
                                            acPlProgDlg.LowerPlotProgressRange = 0
                                            acPlProgDlg.UpperPlotProgressRange = 100
                                            acPlProgDlg.PlotProgressPos = 0

                                            ' Display the Progress dialog
                                            acPlProgDlg.OnBeginPlot()
                                            acPlProgDlg.IsVisible = True

                                            ' Start to plot the layout
                                            acPlEng.BeginPlot(acPlProgDlg, Nothing)

                                            ' Define the plot output
                                            acPlEng.BeginDocument(acPlInfo, "SPC.pdf", Nothing, 1, True, txtDuongDan.Text)

                                            ' Display information about the current plot
                                            acPlProgDlg.PlotMsgString(PlotMessageIndex.Status) = "Plotting: " & "SPC.pdf" & " - " & "Layout1"

                                            ' Set the sheet progress range
                                            acPlProgDlg.OnBeginSheet()
                                            acPlProgDlg.LowerSheetProgressRange = 0
                                            acPlProgDlg.UpperSheetProgressRange = 100
                                            acPlProgDlg.SheetProgressPos = 0

                                            ' Plot the first sheet/layout
                                            Using acPlPageInfo As PlotPageInfo =
                                            New PlotPageInfo()
                                                acPlEng.BeginPage(acPlPageInfo,
                                                              acPlInfo,
                                                              True,
                                                              Nothing)
                                            End Using

                                            acPlEng.BeginGenerateGraphics(Nothing)
                                            acPlEng.EndGenerateGraphics(Nothing)

                                            ' Finish plotting the sheet/layout
                                            acPlEng.EndPage(Nothing)
                                            acPlProgDlg.SheetProgressPos = 100
                                            acPlProgDlg.OnEndSheet()

                                            ' Finish plotting the document
                                            acPlEng.EndDocument(Nothing)

                                            ' Finish the plot
                                            acPlProgDlg.PlotProgressPos = 100
                                            acPlProgDlg.OnEndPlot()
                                            acPlEng.EndPlot(Nothing)
                                        End Using
                                    End Using
                                End Using
                            End If
                        End Using
                    End Using
                End Using
            End Using
            MsgBox("Đã lưu hình ảnh vào đường dẫn !")
            Me.Close()
        End If
        ' Get the current document and database, and start a transaction

    End Sub

End Class

