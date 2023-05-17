Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Imports System.Windows.Media
Imports Autodesk.AutoCAD.Interop
' Add ribbon 
Imports Autodesk.Windows
Imports System.Windows.Input
Imports System.Windows.Media.Imaging
Imports System.Drawing


Namespace Viettel.Project

    Public Class MyFormAndRibbon

        Implements IExtensionApplication

        <CommandMethod("Formtest")>
        Public Sub Formtest()

            Dim Frm As New Formtest
            Application.ShowModalDialog(Frm)

        End Sub

        <CommandMethod("CreateForm")>
        Public Sub CreateForm()

            Dim Frm As New FormMain
            Application.ShowModalDialog(Frm)

        End Sub
        ' Tạo command lệnh tạo RibbonTab
        <CommandMethod("CreateMyRibbon")>
        Public Sub CreateMyRibbon()

            Dim ribCntrl As RibbonControl = ComponentManager.Ribbon

            'create a ribbontab
            Dim ribTab As New RibbonTab()

            'set a few properties
            ribTab.Title = "Viettel"
            ribTab.Id = "Viettel"

            '  -----------------THÊM CÁC ĐỐI TƯỢNG VÀO RIBBON TAB ----------------------
            ' gọi thủ tục thêm button
            addContent(ribTab)

            ' -------------------- ---------------------------------------
            'add the tab to the ribbon
            ribCntrl.Tabs.Add(ribTab)
            'set as active tab
            ribTab.IsActive = True

        End Sub
        Public Sub Initialize() Implements IExtensionApplication.Initialize
            ' Gọi đến thủ tục để tạo ribbon
            Dim acPrefComObj As AcadPreferences = Application.Preferences
            'Lấy đường dẫn file Qnew
            DuongDanThuVien = acPrefComObj.Files.QNewTemplateFile
            NewDrawing()
            If DuongDanThuVien = "" Then
            Else
                CreateMyRibbon()
            End If
        End Sub

        Public Sub Terminate() Implements IExtensionApplication.Terminate

        End Sub
        Private Sub addContent(ByVal ribTab As RibbonTab)

            'create the panel source
            Dim ribSourcePanel As RibbonPanelSource = New RibbonPanelSource()
            ribSourcePanel.Title = "Viettel"

            'now the panel
            Dim ribPanel As New RibbonPanel()
            ribPanel.Source = ribSourcePanel
            ribTab.Panels.Add(ribPanel)

            'create a button
            Dim ribButton1 As RibbonButton = New RibbonButton()
            ribButton1.Text = "BCKD"
            ribButton1.CommandParameter = "CreateForm" & vbLf
            ribButton1.ShowText = True
            ribButton1.ShowImage = True
            ' Thêm hình ảnh vào Button
            ribButton1.Image = LoadImage()
            ribButton1.LargeImage = LoadImage1()
            ribButton1.Orientation = System.Windows.Controls.Orientation.Vertical
            ribButton1.Size = RibbonItemSize.Large
            ribButton1.CommandHandler = New RibbonCommandHandler()
            Dim bmi As BitmapImage = New BitmapImage(New Uri("ICon_Viettel.ico", UriKind.Relative))
            'ribButton1.LargeImage= "iconc" 
            ' button.LargeImage =resourceDictionary["ButtonImage"] as BitmapImage;
            'ribButton1.CommandHandler = New SendParameterToCommand()
            'ribButton1.Image = bmi
            'ribButton1.LargeImage = bmi
            ' 
            ribButton1.CommandHandler = New SendParameterToCommand()

            'add the button
            ribSourcePanel.Items.Add(ribButton1)


        End Sub
        Private Shared Function LoadImage() As System.Windows.Media.Imaging.BitmapImage
            Dim pic As Bitmap = My.Resources.Resource1.icon_viettel
            Dim ms As New MemoryStream()
            pic.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Dim bi As New System.Windows.Media.Imaging.BitmapImage()
            bi.BeginInit()
            bi.StreamSource = ms
            bi.EndInit()

            Return bi
        End Function
        Private Shared Function LoadImage1() As System.Windows.Media.Imaging.BitmapImage
            Dim pic As Bitmap = My.Resources.Resource1.icon_viettel
            Dim ms As New MemoryStream()
            pic.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            Dim bi As New System.Windows.Media.Imaging.BitmapImage()
            bi.BeginInit()
            bi.StreamSource = ms
            bi.EndInit()

            Return bi
        End Function
        <CommandMethod("PrefsSetCursor")> _
        Public Sub PrefsSetCursor()
            '' This example sets the crosshairs of the AutoCAD drawing cursor
            '' to full screen.

            '' Access the Preferences object
            Dim acPrefComObj As AcadPreferences = Application.Preferences

            '' Use the CursorSize property to set the size of the crosshairs
            acPrefComObj.Display.CursorSize = 100
            Dim Template As String
            Template = acPrefComObj.Files.QNewTemplateFile
            MsgBox(Template)
        End Sub

        <CommandMethod("EraseLayer")>
        Public Sub EraseLayer()
            '' Get the current document and database
            Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
            Dim acCurDb As Database = acDoc.Database

            '' Start a transaction
            Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

                '' Open the Layer table for read
                Dim acLyrTbl As LayerTable
                acLyrTbl = acTrans.GetObject(acCurDb.LayerTableId,
                                             OpenMode.ForRead)

                Dim sLayerName As String = "1"

                If acLyrTbl.Has(sLayerName) = True Then
                    '' Check to see if it is safe to erase layer
                    Dim acObjIdColl As ObjectIdCollection = New ObjectIdCollection()
                    acObjIdColl.Add(acLyrTbl(sLayerName))
                    acCurDb.Purge(acObjIdColl)

                    If acObjIdColl.Count > 0 Then
                        Dim acLyrTblRec As LayerTableRecord
                        acLyrTblRec = acTrans.GetObject(acObjIdColl(0), OpenMode.ForWrite)

                        Try
                            '' Erase the unreferenced layer
                            acLyrTblRec.Erase(True)

                            '' Save the changes and dispose of the transaction
                            acTrans.Commit()
                        Catch Ex As Autodesk.AutoCAD.Runtime.Exception
                            '' Layer could not be deleted
                            Application.ShowAlertDialog("Error:\n" + Ex.Message)
                        End Try
                    End If
                End If
            End Using
        End Sub
        <CommandMethod("NewDrawing")>
        Public Shared Sub NewDrawing()

            Dim acPrefComObj As AcadPreferences = Application.Preferences
            'Lấy đường dẫn file Qnew
            'DuongDanThuVien = acPrefComObj.Files.QNewTemplateFile "D:\1.DuAnViettel\ToolCad\SPCTemplate.dwt"
            DuongDanThuVien = "D:\1.DuAnViettel\ToolCad\SPCTemplate.dwt"
            If DuongDanThuVien = "" Then
                MsgBox("Bạn phải thêm đường dẫn File Template trước khi sử dụng")
            Else
                'MsgBox("Chúc mừng năm mới")
                Dim strTemplatePath As String = DuongDanThuVien
                Dim acDocMgr As DocumentCollection = Application.DocumentManager
                Dim acDoc As Document = DocumentCollectionExtension.Add(acDocMgr, strTemplatePath)
                acDocMgr.MdiActiveDocument = acDoc
            End If

        End Sub
        <CommandMethod("OpenDrawing", CommandFlags.Session)>
        Public Sub OpenDrawing()
            Dim strFileName As String = DuongDanThuVien

            Dim acDocMgr As DocumentCollection = Application.DocumentManager

            If (File.Exists(strFileName)) Then
                DocumentCollectionExtension.Open(acDocMgr, strFileName, False)
            Else
                acDocMgr.MdiActiveDocument.Editor.WriteMessage("File " & strFileName & " does not exist.")
            End If
        End Sub
        <CommandMethod("SelectObjectsByCrossingWindow")>
        Public Sub SelectObjectsByCrossingWindow()
            '' Get the current document editor
            Dim acDocEd As Editor = Application.DocumentManager.MdiActiveDocument.Editor
            '' Create a crossing window from (2,2,0) to (10,8,0)
            Dim acSSPrompt As PromptSelectionResult
            acSSPrompt = acDocEd.SelectCrossingWindow(New Point3d(2, 2, 0),
                                                        New Point3d(10, 8, 0))
            '' If the prompt status is OK, objects were selected
            If acSSPrompt.Status = PromptStatus.OK Then
                Dim acSSet As SelectionSet = acSSPrompt.Value
                Application.ShowAlertDialog("Number of objects selected: " &
                                                  acSSet.Count.ToString())
            Else
                Application.ShowAlertDialog("Number of objects selected: 0")
            End If
        End Sub
    End Class

    Public Class RibbonCommandHandler
        Implements System.Windows.Input.ICommand

        Public Event CanExecuteChanged As EventHandler

        Public Function CanExecute(ByVal parameter As Object) As Boolean Implements System.Windows.Input.ICommand.CanExecute
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument

            If TypeOf parameter Is RibbonButton Then
                Dim button As RibbonButton = TryCast(parameter, RibbonButton)
                doc.Editor.WriteMessage(vbLf & "RibbonButton Executed: " + button.Text + vbLf)
            End If
            Return True
        End Function

        Public Event CanExecuteChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Implements System.Windows.Input.ICommand.CanExecuteChanged

        Public Sub Execute1(ByVal parameter As Object) Implements System.Windows.Input.ICommand.Execute

        End Sub
    End Class
    Public Class SendParameterToCommand
        Implements System.Windows.Input.ICommand

        Public Event CanExecuteChanged As EventHandler Implements ICommand.CanExecuteChanged

        Public Sub Execute(parameter As Object) Implements ICommand.Execute
            Dim ribBtn As RibbonButton = TryCast(parameter, RibbonButton)
            Dim doc As Document = Application.DocumentManager.MdiActiveDocument

            ' Gửi text của ribbonButton vào command lệnh để thực thi
            If ribBtn IsNot Nothing Then
                doc.SendStringToExecute(ribBtn.CommandParameter, True, False, True)
            End If

        End Sub

        Public Function CanExecute(parameter As Object) As Boolean Implements ICommand.CanExecute
            Return True
        End Function
    End Class

End Namespace
