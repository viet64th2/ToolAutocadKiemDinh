Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO
Public Class Lib_Drawing
    Public Shared Sub DoiXung(startPoint As Point3d, endPoint As Point3d, ThucThe As Line)
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)
            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
            '' Create a copy of the original entity
            '' Add the new object to the block table record and the transaction
            'acBlkTblRec.AppendEntity(ThucThe)
            'acTrans.AddNewlyCreatedDBObject(ThucThe, True)

            '' Create a copy of the original polyline
            Dim acPolyMirCopy As Line = ThucThe.Clone()
            'acPolyMirCopy.ColorIndex = 5

            '' Define the mirror line
            Dim acPtFrom As Point3d = New Point3d(0, 0, 0)
            Dim acPtTo As Point3d = New Point3d(0, 1000000, 0)
            Dim acLine3d As Line3d = New Line3d(startPoint, endPoint)

            '' Mirror the polyline across the X axis
            acPolyMirCopy.TransformBy(Matrix3d.Mirroring(acLine3d))
            '' Add the new object to the block table record and the transaction
            acBlkTblRec.AppendEntity(acPolyMirCopy)
            acTrans.AddNewlyCreatedDBObject(acPolyMirCopy, True)
            acTrans.Commit()
        End Using
    End Sub
    ' Hàm vẽ Polyline; tham số: mảng tọa độ đỉnh, đóng/mở.
    Public Shared Function CreateNewPolyline1(Mang_Toa_Do_Dinh() As Point2d, Dong_Mo As Boolean) As ObjectId
        Dim ID_Polyline As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForWrite)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ POLYLINE -----------------------
            Dim NewPolyline As Polyline = New Polyline()
            Dim i As Integer
            For Each Dinh As Point2d In Mang_Toa_Do_Dinh
                NewPolyline.AddVertexAt(i, Dinh, 0, 0, 0)
                i += 1
            Next
            NewPolyline.Closed = Dong_Mo ' Cho phép đóng kín miền
            NewPolyline.ColorIndex = 1
            ID_Polyline = BlTbRe.AppendEntity(NewPolyline)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewPolyline, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return ID_Polyline
    End Function
    Public Shared Function CreateNewPolyline(Mang_Toa_Do_Dinh() As Point2d, Dong_Mo As Boolean) As ObjectId
        Dim ID_Polyline As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForWrite)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ POLYLINE -----------------------
            Dim NewPolyline As Polyline = New Polyline()
            Dim i As Integer
            For Each Dinh As Point2d In Mang_Toa_Do_Dinh
                NewPolyline.AddVertexAt(i, Dinh, 0, 0, 0)
                i += 1
            Next
            NewPolyline.Closed = Dong_Mo ' Cho phép đóng kín miền

            ID_Polyline = BlTbRe.AppendEntity(NewPolyline)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewPolyline, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return ID_Polyline
    End Function

    ' Hàm vẽ: CIRCLE, LINE; ARC, HATCH, MTEXT, DIMENSION , GROUP
    Public Shared Function CreateCircle(Tam_DT As Point3d, Ban_Kinh As Double) As ObjectId
        Dim ID_Circle As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ POLYLINE -----------------------
            Dim NewCircle As Circle = New Circle()
            NewCircle.Center = Tam_DT
            NewCircle.Radius = Ban_Kinh

            ID_Circle = BlTbRe.AppendEntity(NewCircle)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewCircle, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return ID_Circle
    End Function
    Public Shared Function CreateLine(Startpoint As Point3d, Endpoint As Point3d) As ObjectId
        Dim ID_Line As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ POLYLINE -----------------------
            Dim NewLine As Line = New Line()
            NewLine.StartPoint = Startpoint
            NewLine.EndPoint = Endpoint
            ID_Line = BlTbRe.AppendEntity(NewLine)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewLine, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return ID_Line
    End Function
    ' Tạo ra hàm hatch
    ' Tham số truyền: Miền bao, kiểu mẫu, tỉ lệ, màu sắc
    Public Shared Function CreateHatch_1MienBao(Mien_Bao As ObjectIdCollection,
                                       Kieu_Mau_Hatch As String,
                                       Mau_Sac As Integer,
                                       Ti_Le As Double) As ObjectId
        Dim ID_Hatch As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ HATCH -----------------------
            Dim NewHatch As Hatch = New Hatch()
            NewHatch.SetDatabaseDefaults()
            ID_Hatch = BlTbRe.AppendEntity(NewHatch)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewHatch, True)
            ' Xác nhận thực thi các câu lệnh ở trên 

            ' Cai dat cac thuoc tinh
            NewHatch.PatternScale = Ti_Le ' Tỉ lệ scale
            NewHatch.ColorIndex = Mau_Sac ' Màu sắc cho hatch
            ' Cài đặt mẫu hatch để hiển thị
            NewHatch.SetHatchPattern(HatchPatternType.PreDefined, Kieu_Mau_Hatch)
            ' Câu lệnh QUAN TRỌNG NHẤT - chỉ ra đường bao của hatch
            NewHatch.AppendLoop(HatchLoopTypes.Outermost, Mien_Bao)

            tr.Commit()
        End Using
        Return ID_Hatch
    End Function

    Public Shared Function CreateHatch_2MienBao(Mien_Bao_Ngoai As ObjectIdCollection,
                                                Mien_Bao_Trong As ObjectIdCollection,
                                       Kieu_Mau_Hatch As String,
                                       Mau_Sac As Integer,
                                       Ti_Le As Double) As ObjectId
        Dim ID_Hatch As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ HATCH -----------------------
            Dim NewHatch As Hatch = New Hatch()
            NewHatch.SetDatabaseDefaults()
            ID_Hatch = BlTbRe.AppendEntity(NewHatch)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewHatch, True)
            ' Xác nhận thực thi các câu lệnh ở trên 

            ' Cai dat cac thuoc tinh
            NewHatch.PatternScale = Ti_Le ' Tỉ lệ scale
            NewHatch.ColorIndex = Mau_Sac ' Màu sắc cho hatch
            ' Cài đặt mẫu hatch để hiển thị
            NewHatch.SetHatchPattern(HatchPatternType.PreDefined, Kieu_Mau_Hatch)
            ' Câu lệnh QUAN TRỌNG NHẤT - chỉ ra đường bao của hatch
            NewHatch.AppendLoop(HatchLoopTypes.Outermost, Mien_Bao_Ngoai)
            NewHatch.AppendLoop(HatchLoopTypes.Default, Mien_Bao_Trong)
            tr.Commit()
        End Using
        Return ID_Hatch
    End Function


    Public Shared Function CreateHatch_3MienBao(Mien_Bao_Ngoai As ObjectIdCollection,
                                                Mien_Bao_Trong1 As ObjectIdCollection,
                                                Mien_Bao_Trong2 As ObjectIdCollection,
                                       Kieu_Mau_Hatch As String,
                                       Mau_Sac As Integer,
                                       Ti_Le As Double) As ObjectId
        Dim ID_Hatch As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  ---------------------- KHAI BÁO ĐỐI TƯỢNG LÀ HATCH -----------------------
            Dim NewHatch As Hatch = New Hatch()
            NewHatch.SetDatabaseDefaults()
            ID_Hatch = BlTbRe.AppendEntity(NewHatch)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewHatch, True)
            ' Xác nhận thực thi các câu lệnh ở trên 

            ' Cai dat cac thuoc tinh
            NewHatch.PatternScale = Ti_Le ' Tỉ lệ scale
            NewHatch.ColorIndex = Mau_Sac ' Màu sắc cho hatch
            ' Cài đặt mẫu hatch để hiển thị
            NewHatch.SetHatchPattern(HatchPatternType.PreDefined, Kieu_Mau_Hatch)
            ' Câu lệnh QUAN TRỌNG NHẤT - chỉ ra đường bao của hatch
            NewHatch.AppendLoop(HatchLoopTypes.Outermost, Mien_Bao_Ngoai)
            NewHatch.AppendLoop(HatchLoopTypes.Default, Mien_Bao_Trong1)
            NewHatch.AppendLoop(HatchLoopTypes.Default, Mien_Bao_Trong2)
            tr.Commit()
        End Using
        Return ID_Hatch
    End Function

    ' Hàm Dim
    Public Shared Function CreateRotatedDimension(Diem_Dau As Point3d,
                                                  Diem_Cuoi As Point3d,
                                                  Diem_Ghim As Point3d,
                                                  Goc_Xoay As Double) As ObjectId
        Dim ID_Dim As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ RotatedDimension -----------------
            Dim RoDim As RotatedDimension = New RotatedDimension()
            RoDim.SetDatabaseDefaults()
            RoDim.XLine1Point = Diem_Dau
            RoDim.XLine2Point = Diem_Cuoi
            RoDim.DimLinePoint = Diem_Ghim
            RoDim.DimensionStyle = db.Dimstyle
            RoDim.Rotation = Goc_Xoay * Math.PI / 180
            RoDim.Dimscale = 170
            ' Thêm text vào block quản lý nó
            ID_Dim = BlTbRe.AppendEntity(RoDim)
            ' Thêm text vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(RoDim, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using

        Return ID_Dim
    End Function
    Public Shared Function CreateAlignedDimension(Diem_Dau As Point3d,
                                                    Diem_Cuoi As Point3d,
                                                    Diem_Ghim As Point3d,
                                                    Dimscale As Double) As ObjectId
        Dim ID_Dim As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ RotatedDimension -----------------
            Dim RoDim As AlignedDimension = New AlignedDimension()
            RoDim.SetDatabaseDefaults()
            RoDim.XLine1Point = Diem_Dau
            RoDim.XLine2Point = Diem_Cuoi
            RoDim.DimLinePoint = Diem_Ghim
            RoDim.DimensionStyle = db.Dimstyle
            RoDim.Dimscale = mbVeMong.mbTileMD(Dimscale)
            ' Thêm text vào block quản lý nó
            ID_Dim = BlTbRe.AppendEntity(RoDim)
            ' Thêm text vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(RoDim, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using

        Return ID_Dim
    End Function
    Public Shared Function CreateRotatedDimension1(Diem_Dau As Point3d,
                                                  Diem_Cuoi As Point3d,
                                                  Diem_Ghim As Point3d,
                                                  Goc_Xoay As Double, Dimscale As Double) As ObjectId
        Dim ID_Dim As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ RotatedDimension -----------------
            Dim RoDim As RotatedDimension = New RotatedDimension()
            RoDim.SetDatabaseDefaults()
            RoDim.XLine1Point = Diem_Dau
            RoDim.XLine2Point = Diem_Cuoi
            RoDim.DimLinePoint = Diem_Ghim
            RoDim.DimensionStyle = db.Dimstyle
            RoDim.Rotation = Goc_Xoay * Math.PI / 180
            RoDim.Dimscale = Dimscale * 2 ' 2 la chieu cao chu doi voi kho giay A4
            ' Thêm text vào block quản lý nó
            ID_Dim = BlTbRe.AppendEntity(RoDim)
            ' Thêm text vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(RoDim, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using

        Return ID_Dim
    End Function

    ' Hàm tạo Group
    Public Shared Sub CreateGroup(ID_TapDoiTuong As ObjectIdCollection,
                                   Ten_Group As System.String)
        Dim db As Database = Application.DocumentManager.MdiActiveDocument.Database
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            Dim gp As New Group(Ten_Group, True)
            Dim dict As DBDictionary = tr.GetObject(db.GroupDictionaryId, OpenMode.ForWrite, True)
            dict.SetAt("THXD", gp)
            Dim thisId As ObjectId

            For Each thisId In ID_TapDoiTuong
                gp.Append(thisId)
            Next

            tr.AddNewlyCreatedDBObject(gp, True)
            tr.Commit()
        End Using


    End Sub

    ' Hàm vẽ đường cong
    Public Shared Function CreateNewArc(Tam As Point3d,
                                        Ban_Kinh As Double,
                                        Goc_Dau As Double,
                                        Goc_Cuoi As Double) As ObjectId
        Dim ID_Arc As ObjectId

        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction

        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ ARC -----------------
            Dim NewArc As Arc = New Arc()
            NewArc.Center = Tam ' Gán tâm đường cong
            NewArc.Radius = Ban_Kinh
            'NewArc.LinetypeScale =
            NewArc.StartAngle = Goc_Dau * Math.PI / 180 ' Góc là radian
            NewArc.EndAngle = Goc_Cuoi * Math.PI / 180

            ' Thêm đường tròn vào block quản lý nó
            ID_Arc = BlTbRe.AppendEntity(NewArc)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(NewArc, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return ID_Arc

    End Function


    Public Shared Function CreateNewMText(Vitri As Point3d, Text As String, Tile As Double) As ObjectId
        Dim Id_MText As ObjectId
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ ARC -----------------
            '' Create a multiline text object
            Dim acMText As MText = New MText()
            acMText.Location = Vitri
            acMText.Contents = Text
            acMText.TextHeight = Tile * 2 'Do cao chu mac dinh o ban ve A4 = 2
            acMText.ColorIndex = 2
            ' Thêm đường tròn vào block quản lý nó
            BlTbRe.AppendEntity(acMText)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(acMText, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return Id_MText
    End Function
    Public Shared Function CreateNewMText1(Vitri As Point3d, Text As String, Tile As Double, GocXoay As Double) As ObjectId
        Dim Id_MText As ObjectId
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ ARC -----------------
            '' Create a multiline text object
            Dim acMText As MText = New MText()
            acMText.Location = Vitri
            acMText.Contents = Text
            acMText.TextHeight = Tile * 2 'Do cao chu mac dinh o ban ve A4 = 2
            acMText.ColorIndex = 2
            acMText.Rotation = GocXoay
            ' Thêm đường tròn vào block quản lý nó
            BlTbRe.AppendEntity(acMText)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(acMText, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return Id_MText
    End Function
    Public Shared Function CreateRadialDimension(TamDT As Point3d,
                                                 Diemdim As Point3d,
                                                 KeoDai As Double)
        Dim Id_Ra As ObjectId
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = tr.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), OpenMode.ForWrite)
            '' Create the radial dimension
            Using acRadDim As RadialDimension = New RadialDimension()
                acRadDim.Center = TamDT
                acRadDim.ChordPoint = Diemdim
                acRadDim.LeaderLength = KeoDai
                acRadDim.DimensionStyle = db.Dimstyle
                '' Add the new object to Model space and the transaction
                acBlkTblRec.AppendEntity(acRadDim)
                tr.AddNewlyCreatedDBObject(acRadDim, True)
            End Using
            '' Commit the changes and dispose of the transaction
            tr.Commit()
        End Using
        Return Id_Ra
    End Function
    Public Shared Sub RotateEntity(ByVal id As ObjectId, ByVal mat As Matrix3d)
        ' Get the current database and start a transaction
        Dim acCurDb As Autodesk.AutoCAD.DatabaseServices.Database
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            Dim ent As Entity = acTrans.GetObject(id, OpenMode.ForWrite)
            ent.TransformBy(mat)
            'Matrix3d.
            acTrans.Commit()
        End Using

    End Sub
    Public Shared Function mbTinhgoc(x As Double, y As Double, somong As Integer) As Double
        Dim tu As Double = x * y
        Dim mau As Double = y * Math.Sqrt(x ^ 2 + y ^ 2)
        Dim cos As Double = tu / mau
        Dim kq As Double = Math.Acos(cos)
        Dim kqcc As Double
        Dim score As Integer = somong
        If ((y = 0)) Then
            kqcc = 0
        Else
            Select Case score
                Case Is = 1 ' vi tri mong 1
                    kqcc = (180 * Math.PI / 180) - kq
                Case Is = 2 ' vi tri mong 2
                    kqcc = kq
                Case Is = 3 ' vi tri mong 3
                    kqcc = kq + (180 * Math.PI / 180)
                Case Is = 4 ' vi tri mong 4
                    kqcc = (360 * Math.PI / 180) - kq
                Case Is = 5
                    kqcc = 0
            End Select
        End If
        Return kqcc
    End Function
    Public Shared Function mbTinhgoc1(x As Double, y As Double) As Double
        Dim tu As Double = x * y
        Dim mau As Double = y * Math.Sqrt(x ^ 2 + y ^ 2)
        Dim cos As Double = tu / mau
        Dim kq As Double
        If ((x = 0) Or (y = 0)) Then
            kq = 0
        Else
            kq = Math.Acos(cos)
        End If


        Return kq
    End Function
    Public Shared Function mbTinhgoc2(x As Double, y As Double, somong As Integer) As Double
        Dim tu As Double = Math.Abs(y) 'Tính góc xoay cho móng loại 1
        Dim mau As Double = Math.Sqrt(x ^ 2 + y ^ 2)
        Dim cos As Double = tu / mau
        Dim kq As Double = Math.Acos(cos)
        Dim kqcc As Double
        Dim score As Integer = somong
        Select Case score
            Case Is = 1 ' vi tri mong 1
                kqcc = kq + (Math.PI / 2)
            Case Is = 2 ' vi tri mong 2
                kqcc = kq
            Case Is = 3 ' vi tri mong 3
                kqcc = kq + (180 * Math.PI / 180)
            Case Is = 4 ' vi tri mong 4
                kqcc = (360 * Math.PI / 180) - kq
            Case Is = 5
                kqcc = 0
        End Select

        Return kqcc
    End Function
    Public Shared Function mbTinhgoc3(xA As Double, yA As Double, Co As Boolean) As Double
        'Tính góc xoay cho móng loại 2
        'Dim AB As Double = Math.Sqrt((xB - xA) * (xB - xA) + (yB - yA) * (yB - yA))
        'Dim AC As Double = Math.Sqrt((xC - xA) * (xC - xA) + (yC - yA) * (yC - yA))
        'Dim BC As Double = Math.Sqrt((xC - xB) * (xC - xB) + (yC - yB) * (yC - yB))
        'Dim Cos As Double = ((AB * AB) + (AC * AC) - (BC * BC)) / (2 * AB * AC)
        Dim cos, kq, goc As Double
        Dim tu As Double
        Dim mau As Double
        tu = Math.Abs(xA)
        mau = Math.Sqrt(xA * xA + yA * yA)
        cos = tu / mau
        kq = Math.Acos(cos)
        goc = kq * (180 / Math.PI)
        Dim kqcc As Double
        If Co Then
            If xA <= 0 And yA >= 0 Then
                If goc > 45 Then
                    kqcc = (45 - goc) * (Math.PI / 180)
                Else
                    kqcc = (45 - goc) * (Math.PI / 180)
                End If
            ElseIf xA >= 0 And yA >= 0 Then
                If goc > 45 Then
                    kqcc = -(45 - goc) * (Math.PI / 180)
                Else
                    kqcc = -(45 - goc) * (Math.PI / 180)
                End If
            ElseIf xA >= 0 And yA <= 0 Then
                If goc > 45 Then
                    kqcc = (45 - goc) * (Math.PI / 180)
                Else
                    kqcc = (45 - goc) * (Math.PI / 180)
                End If
            ElseIf xA <= 0 And yA <= 0 Then
                If goc > 45 Then
                    kqcc = -(45 - goc) * (Math.PI / 180)
                Else
                    kqcc = -(45 - goc) * (Math.PI / 180)
                End If
            End If
        Else
            kqcc = 0
        End If
        Return kqcc
    End Function
    Public Shared Sub deleteDBObject(ByRef dbObj As DBObject)
        Dim ed As Editor = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor
        Dim db As Database = HostApplicationServices.WorkingDatabase
        Dim tm As Transaction = db.TransactionManager.StartTransaction()
        Try
            Dim ent As Entity = CType(tm.GetObject(dbObj.Id, OpenMode.ForWrite), Entity)
            ent.Erase()
            ent = Nothing
            dbObj = Nothing
            tm.Commit()
        Catch
        Finally
            tm.Dispose()
        End Try
        Autodesk.AutoCAD.ApplicationServices.Application.UpdateScreen()
    End Sub
    Public Shared Sub ZoomExtent()

        'AcadApplication has a function to zoom extent

        Dim acadApp As Object = Application.AcadApplication

        acadApp.ZoomExtents()

    End Sub
    Public Shared Sub NewDrawing()
        '' Specify the template to use, if the template is not found
        '' the default settings are used.
        Dim strTemplatePath As String = "acad.dwt"
        Dim acDocMgr As DocumentCollection = Application.DocumentManager
        Dim acDoc As Document = DocumentCollectionExtension.Add(acDocMgr, strTemplatePath)
        acDocMgr.MdiActiveDocument = acDoc
    End Sub
    Public Shared Function SaveDrawing(DuongDan As String)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim strDWGName As String = acDoc.Name

        Dim obj As Object = Application.GetSystemVariable("DWGTITLED")

        '' Check to see if the drawing has been named
        If System.Convert.ToInt16(obj) = 0 Then
            '' If the drawing is using a default name (Drawing1, Drawing2, etc)
            '' then provide a new name
            strDWGName = DuongDan + ".dwg"
        End If

        '' Save the active drawing
        acDoc.Database.SaveAs(strDWGName, True, DwgVersion.Current, acDoc.Database.SecurityParameters)
        Return Nothing
    End Function


    Public Shared Sub insertBlock(Vitri As Point3d, TenBlock As String, tile As Double, text As String)
        'kaitomajickid1412
        Dim db As Database = HostApplicationServices.WorkingDatabase()
        Dim doc As Document = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.GetDocument(db)
        Dim ed As Editor = doc.Editor
        Using trans As Transaction = db.TransactionManager.StartTransaction()
            'Lấy đối tượng BlockTable
            Dim bt As BlockTable = trans.GetObject(db.BlockTableId, OpenMode.ForRead)
            'BlockTable quản lý BlockTableRecord
            Dim btr As BlockTableRecord = trans.GetObject(db.CurrentSpaceId, OpenMode.ForWrite)
            'Lấy BlockTableRecord qua tên block
            Dim blockDef As BlockTableRecord = trans.GetObject(bt(TenBlock), OpenMode.ForRead)
            ' sử dụng BlockReference từ id của BlockTableRecord
            Using acNewBlockRef As New BlockReference(Vitri, blockDef.ObjectId)
                ' scale đối tượng
                acNewBlockRef.TransformBy(Matrix3d.Scaling(tile, Vitri))
                ' thêm đối tượng vào BlockTableRecord
                btr.AppendEntity(acNewBlockRef)
                ' xác nhận thêm mới DBObject
                trans.AddNewlyCreatedDBObject(acNewBlockRef, True)
                ' vòng lặp lấy id của BlockTableRecord
                For Each attId As ObjectId In blockDef
                    ' chuyển BlockTableRecord thành Entity
                    Dim ent As Entity = trans.GetObject(attId, OpenMode.ForRead)
                    If TypeOf ent Is AttributeDefinition Then
                        ' khai báo chính sửa thuộc tính của thực thể
                        Dim attDef As AttributeDefinition = DirectCast(ent, AttributeDefinition)
                        ' nếu chứa thuộc chính 
                        If (attDef IsNot Nothing) AndAlso (Not attDef.Constant) Then

                            Using attRef As New AttributeReference()
                                ' sử dụng môi trường reference để chỉnh sửa thuộc tính 
                                attRef.SetAttributeFromBlock(attDef, acNewBlockRef.BlockTransform)
                                ' AttributeCollection các thuộc tính trong môi trường reference
                                acNewBlockRef.AttributeCollection.AppendAttribute(attRef)
                                trans.AddNewlyCreatedDBObject(attRef, True)
                                ' chỉnh sửa thuộc tính
                                attRef.TextString = text
                                If attRef.HasFields Then
                                    Dim fOif As ObjectId = attRef.GetField()
                                    Dim fo As Field = trans.GetObject(fOif, OpenMode.ForWrite)
                                    fo.Evaluate()
                                End If
                            End Using
                        End If
                    End If
                Next
            End Using
            trans.Commit()
        End Using
    End Sub
    Public Shared Function RedefiningABlock(TenBlock As String, Ten As String, caodo As String) As ObjectId
        Dim ID_RBlock As ObjectId
        ' Get the current database and start a transaction
        Dim acCurDb As Autodesk.AutoCAD.DatabaseServices.Database
        acCurDb = Application.DocumentManager.MdiActiveDocument.Database

        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            ' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, OpenMode.ForRead)

            If Not acBlkTbl.Has(TenBlock) Then
                Using acBlkTblRec As New BlockTableRecord
                    acBlkTblRec.Name = TenBlock

                    ' Set the insertion point for the block
                    acBlkTblRec.Origin = New Point3d(0, 0, 0)

                    ' Add a circle to the block
                    Using acCirc As New Circle
                        'acCirc.Center = New Point3d(0, 0, 0)
                        'acCirc.Radius = 2
                        'acBlkTblRec.AppendEntity(acCirc)
                        'acBlkTbl.UpgradeOpen()
                        'acBlkTbl.Add(acBlkTblRec)
                        'acTrans.AddNewlyCreatedDBObject(acBlkTblRec, True)

                        ' Insert the block into the current space
                        Using acBlkRef As New BlockReference(New Point3d(0, 0, 0), acBlkTblRec.Id)

                            Dim acModelSpace As BlockTableRecord
                            acModelSpace = acTrans.GetObject(acCurDb.CurrentSpaceId, OpenMode.ForWrite)

                            acModelSpace.AppendEntity(acBlkRef)
                            acTrans.AddNewlyCreatedDBObject(acBlkRef, True)

                            MsgBox(TenBlock & " has been created.")
                        End Using
                    End Using
                End Using
            Else
                ' Redefine the block if it exists
                Dim acBlkTblRec As BlockTableRecord =
                acTrans.GetObject(acBlkTbl.Item(TenBlock), OpenMode.ForWrite)

                ' Step through each object in the block table record
                For Each objID As ObjectId In acBlkTblRec

                    Dim dbObj As DBObject = acTrans.GetObject(objID, OpenMode.ForRead)
                    ' Revise the circle in the block

                    If TypeOf dbObj Is AttributeReference Then
                        Dim RBlock As AttributeReference = dbObj
                        RBlock.UpgradeOpen()
                    End If
                Next
                ' Update existing block references
                For Each objID As ObjectId In acBlkTblRec.GetBlockReferenceIds(False, True)
                    Dim acBlkRef As BlockReference = acTrans.GetObject(objID, OpenMode.ForWrite)
                    acBlkRef.RecordGraphicsModified(True)
                Next
                MsgBox(TenBlock & " has been revised.")
            End If
            ' Save the new object to the database
            acTrans.Commit()
            ' Dispose of the transaction
        End Using
        Return ID_RBlock
    End Function
    Public Shared Function TextCaoDo(Vitri As Point3d, DoCao As Double, text As String)
        Dim Id_MText As ObjectId
        Dim doc As Document = Application.DocumentManager.MdiActiveDocument
        Dim db As Database = doc.Database
        Dim ed As Editor = doc.Editor
        Dim tr As Transaction = db.TransactionManager.StartTransaction
        Using tr
            ' Khai báo biến lấy BlockTable trong csdl
            Dim BlTb As BlockTable = tr.GetObject(db.BlockTableId, OpenMode.ForRead)
            ' Khai báo biến và gán nó là không gian model space
            Dim BlTbRe As BlockTableRecord = tr.GetObject(BlTb(BlockTableRecord.ModelSpace), OpenMode.ForWrite)

            '  -------------- KHAI BÁO ĐỐI TƯỢNG LÀ ARC -----------------
            '' Create a multiline text object
            Dim acMText As MText = New MText()
            acMText.Location = Vitri
            acMText.Contents = text
            acMText.TextHeight = DoCao
            acMText.ColorIndex = 2
            ' Thêm đường tròn vào block quản lý nó
            BlTbRe.AppendEntity(acMText)
            ' Thêm đường tròn vào csdl của bản vẽ (database)
            tr.AddNewlyCreatedDBObject(acMText, True)
            ' Xác nhận thực thi các câu lệnh ở trên 
            tr.Commit()
        End Using
        Return Id_MText
    End Function
    Public Shared Function TimDiem(x1 As Double, y1 As Double, x2 As Double, y2 As Double, ByRef khoangofset As Double) As Point3d
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim DiemCanTim As New Point3d 'M(xM,yM)
        Dim DiemDim As New Point3d
        Dim xM, yM As Double
        'u(a,b)
        Dim VecToChiPhuongX As Double = (x2 - x1) 'a 
        Dim VecToChiPhuongY As Double = (y2 - y1) 'b
        'n(b,-a)
        Dim VecToPhapTuyenX As Double = VecToChiPhuongY
        Dim VecToPhapTuyenY As Double = -VecToChiPhuongX
        'lap phuong trinh duong thang 
        Dim A1 As Double = VecToPhapTuyenX
        Dim B1 As Double = VecToPhapTuyenY
        Dim C1 As Double = -VecToPhapTuyenX * x1 - VecToPhapTuyenY * y1
        'VecTo 0M (xM-0,yM-0)
        Dim VecTo0MX As Double = xM - 0
        Dim VecTo0MY As Double = yM - 0
        'vecto 0M*u(a,b) = 0
        Dim A2 As Double = -VecToChiPhuongX
        Dim B2 As Double = -VecToChiPhuongY
        Dim C2 As Double = 0
        ' giai phuong trinh Cramer
        Dim D As Double = A1 * B2 - A2 * B1
        Dim Dx As Double = C1 * B2 - C2 * B1
        Dim Dy As Double = A1 * C2 - A2 * C1
        xM = Dx / D
        yM = Dy / D
        DiemCanTim = New Point3d(xM, yM, 0)
        'Lib_Drawing.CreateLine(New Point3d(0, 0, 0), DiemCanTim)
        Dim id_line1 As ObjectId
        id_line1 = Lib_Drawing.MoveAndCreateLine(New Point3d(0, 0, 0), DiemCanTim)
        Dim id_line2 As ObjectId
        id_line2 = Lib_Drawing.SuaDoiLine(id_line1, khoangofset)
        ' MsgBox(xM)
        'MsgBox(yM)
        Dim Goc As Double = Lib_Drawing.GocDim(xM, yM)
        'MsgBox(Goc)
        Lib_Drawing.RotateEntity(id_line2, Matrix3d.Rotation(Goc, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Dim line2 As Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            line2 = acTrans.GetObject(id_line2, OpenMode.ForWrite)
            DiemDim = line2.EndPoint
            line2.Erase()
            acTrans.Commit()
        End Using

        Return DiemDim
    End Function
    Public Shared Function MoveAndCreateLine(DiemDau As Point3d, DiemCuoi As Point3d) As ObjectId
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim id_line As ObjectId
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)

            '' Create a circle that is at 2,2 with a radius of 0.5
            Using acline As Line = New Line()
                acline.StartPoint = New Point3d(0, 0, 0)
                acline.EndPoint = DiemCuoi

                '' Create a matrix and move the circle using a vector from (0,0,0) to (2,0,0)
                Dim acPt3d As Point3d = DiemCuoi
                Dim acVec3d As Vector3d = acPt3d.GetVectorTo(DiemDau)
                acline.TransformBy(Matrix3d.Displacement(acVec3d))
                '' Add the new object to the block table record and the transaction
                id_line = acBlkTblRec.AppendEntity(acline)
                acTrans.AddNewlyCreatedDBObject(acline, True)
            End Using
            '' Save the new objects to the database
            acTrans.Commit()
        End Using
        Return id_line
    End Function
    Public Shared Function SuaDoiLine(id_line As ObjectId, Khoangofset As Double) As ObjectId
        '' Get the current document and database
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim acCurDb As Database = acDoc.Database
        Dim id As ObjectId
        '' Start a transaction
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()

            '' Open the Block table for read
            Dim acBlkTbl As BlockTable
            acBlkTbl = acTrans.GetObject(acCurDb.BlockTableId, _
                                         OpenMode.ForRead)

            '' Open the Block table record Model space for write
            Dim acBlkTblRec As BlockTableRecord
            acBlkTblRec = acTrans.GetObject(acBlkTbl(BlockTableRecord.ModelSpace), _
                                            OpenMode.ForWrite)
            Dim entline As Line = acTrans.GetObject(id_line, OpenMode.ForWrite)
            Dim DoDai As Double
            DoDai = entline.Length
            entline.Erase()
            '' Create a circle that is at 2,2 with a radius of 0.5
            Using acline As Line = New Line()
                acline.StartPoint = New Point3d(0, 0, 0)
                acline.EndPoint = New Point3d(DoDai + Khoangofset, 0, 0)
                '' Add the new object to the block table record and the transaction
                id = acBlkTblRec.AppendEntity(acline)
                acTrans.AddNewlyCreatedDBObject(acline, True)
            End Using
            '' Save the new objects to the database

            acTrans.Commit()
        End Using
        Return id
    End Function
    Public Shared Function GocDim(ByRef x As Double, ByRef y As Double) As Double
        Dim Goc As Double
        Dim tu As Double = x * y
        Dim mau As Double = y * Math.Sqrt(x ^ 2 + y ^ 2)
        Dim cos As Double = tu / mau
        If (y = 0) And (x < 0) Then
            Goc = 0
        ElseIf (y = 0) And (x > 0) Then
            Goc = Math.PI
        ElseIf (x <= 0) And (y >= 0) Then ' x>0 y<0 hien thi
            Goc = Math.PI + Math.Acos(cos)
        ElseIf (x >= 0) And (y >= 0) Then ' x<0 y<0 hien thi
            Goc = Math.PI + Math.Acos(cos)
        ElseIf (x >= 0) And (y <= 0) Then ' x<0 y>0 hien thi
            Goc = Math.PI - Math.Acos(cos)
        ElseIf (x <= 0) And (y <= 0) Then ' x>0 y>0 hien thi
            Goc = Math.PI - Math.Acos(cos)
        End If
        Return Goc
    End Function
    Public Shared Function mbTinhgoc1Update(x As Double, y As Double) As Double
        Dim tu As Double = x * y
        Dim mau As Double = y * Math.Sqrt(x ^ 2 + y ^ 2)
        Dim cos As Double = tu / mau
        Dim kq As Double
        If ((y = 0) And (x < 0)) Then
            kq = Math.PI
        ElseIf (y = 0) And (x > 0) Then
            kq = 0
        ElseIf (x = 0) And (y < 0) Then
            kq = (2 * Math.PI) - (Math.PI / 2)
        ElseIf (x = 0) And (y > 0) Then
            kq = Math.PI / 2
        ElseIf (x < 0) And (y > 0) Then
            kq = Math.Acos(cos)
        ElseIf (x > 0) And (y > 0) Then
            kq = Math.Acos(cos)
        ElseIf (x > 0) And (y < 0) Then
            kq = 2 * Math.PI - Math.Acos(cos)
        ElseIf (x < 0) And (y < 0) Then
            kq = 2 * Math.PI - Math.Acos(cos)
        ElseIf (x = 0) And (y = 0) Then
            kq = 0
        End If
        Return kq
    End Function
End Class