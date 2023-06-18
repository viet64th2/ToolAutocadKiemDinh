Imports System
Imports Autodesk.AutoCAD.Runtime
Imports Autodesk.AutoCAD.ApplicationServices
Imports Autodesk.AutoCAD.EditorInput
Imports Autodesk.AutoCAD.Windows
Imports Autodesk.AutoCAD.DatabaseServices
Imports Autodesk.AutoCAD.Geometry 'Namespace chứa các đối tượng tạo nên thực thể đồ họa
Imports System.IO

Public Class CanhraTD

    Public Shared Sub CanhCanhraTD_3MongBCKD(Canhtruc1 As Double, Canhtruc2 As Double, Canhtruc3 As Double, Canh1 As Double, Canh2 As Double, Canh3 As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim acCurDb As Database = acDoc.Database

        Dim goc1 As Double = TinhGoc(Canhtruc1, Canhtruc2, Canh1)
        Dim Diem1(1) As Double
        Diem1(0) = Canhtruc1 * Math.Cos(goc1) - 0 * Math.Sin(goc1)
        Diem1(1) = Canhtruc1 * Math.Sin(goc1) + 0 * Math.Cos(goc1)

        Dim goc2 As Double = TinhGoc(Canhtruc3, Canhtruc2, Canh2)
        goc2 = goc2 + goc1
        Dim Diem2(1) As Double
        Diem2(0) = Canhtruc2 * Math.Cos(goc2) - 0 * Math.Sin(goc2)
        Diem2(1) = Canhtruc2 * Math.Sin(goc2) + 0 * Math.Cos(goc2)

    End Sub
    Public Shared Sub CanhCanhraTD_4MongBCKD(Canhtruc1 As Double, Canhtruc2 As Double, Canhtruc3 As Double, Canhtruc4 As Double, Canh1 As Double, Canh2 As Double, Canh3 As Double, Canh4 As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim acCurDb As Database = acDoc.Database

        Dim goc1 As Double = TinhGoc(Canhtruc1, Canhtruc2, Canh1)
        Dim Diem1(1) As Double
        Diem1(0) = Canhtruc1 * Math.Cos(goc1) - 0 * Math.Sin(goc1)
        Diem1(1) = Canhtruc1 * Math.Sin(goc1) + 0 * Math.Cos(goc1)

        Dim goc2 As Double = TinhGoc(Canhtruc3, Canhtruc2, Canh2)
        goc2 = goc2 + goc1
        Dim Diem2(1) As Double
        Diem2(0) = Canhtruc2 * Math.Cos(goc2) - 0 * Math.Sin(goc2)
        Diem2(1) = Canhtruc2 * Math.Sin(goc2) + 0 * Math.Cos(goc2)

        Dim goc3 As Double = TinhGoc(Canhtruc3, Canhtruc2, Canh2)
        goc3 = goc2 + goc3
        Dim Diem3(1) As Double
        Diem3(0) = Canhtruc2 * Math.Cos(goc3) - 0 * Math.Sin(goc3)
        Diem3(1) = Canhtruc2 * Math.Sin(goc3) + 0 * Math.Cos(goc3)
    End Sub

    Public Shared Sub CanhGocraTD_3Mong(Canhtruc1 As Double, Canhtruc2 As Double, Canhtruc3 As Double, Goc1 As Double, Goc2 As Double, Goc3 As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim acCurDb As Database = acDoc.Database

        Dim id_1 As ObjectId
        id_1 = Lib_Drawing.CreateLine(New Point3d(-Canhtruc2, 0, 0), New Point3d(0, 0, 0))
        Lib_Drawing.RotateEntity(id_1, Matrix3d.Rotation(-Goc1 * Math.PI / 180, curUCS.Zaxis, New Point3d(0, 0, 0)))

        Goc2 = Goc2 + Goc1
        Dim id_2 As ObjectId
        id_2 = Lib_Drawing.CreateLine(New Point3d(-Canhtruc3, 0, 0), New Point3d(0, 0, 0))
        Lib_Drawing.RotateEntity(id_2, Matrix3d.Rotation(-Goc2 * Math.PI / 180, curUCS.Zaxis, New Point3d(0, 0, 0)))
        Dim canhcanh As Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            canhcanh = acTrans.GetObject(id_1, OpenMode.ForWrite)
            acTrans.Commit()
        End Using
        Dim diem1 As Point3d = canhcanh.GetPointAtDist(0)
        mbVeMong.Erase_E(id_1)
        Dim canhcanh1 As Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            canhcanh1 = acTrans.GetObject(id_2, OpenMode.ForWrite)
            acTrans.Commit()
        End Using
        Dim diem2 As Point3d = canhcanh1.GetPointAtDist(0)
        mbVeMong.Erase_E(id_2)
        Dim diem As Point3d = New Point3d(-Canhtruc1, 0, 0)

        frmTTC.dgvToaDoMong.RowCount = 0
        frmTTC.dgvToaDoMong.Rows.Add({"Móng M1", Math.Round(diem.X, 3), Math.Round(diem.Y, 3), diem.Z, "Sửa"})
        frmTTC.dgvToaDoMong.Rows.Add({"Móng M2", Math.Round(diem1.X, 3), Math.Round(diem1.Y, 3), diem1.Z, "Sửa"})
        frmTTC.dgvToaDoMong.Rows.Add({"Móng M3", Math.Round(diem2.X, 3), Math.Round(diem2.Y, 3), diem2.Z, "Sửa"})

    End Sub
    Public Shared Sub CanhGocraTD_4Mong(Canhtruc1 As Double, Canhtruc2 As Double, Canhtruc3 As Double, Canhtruc4 As Double, Goc1 As Double, Goc2 As Double, Goc3 As Double, Goc4 As Double)
        Dim acDoc As Document = Application.DocumentManager.MdiActiveDocument
        Dim curUCSMatrix As Matrix3d = acDoc.Editor.CurrentUserCoordinateSystem
        Dim curUCS As CoordinateSystem3d = curUCSMatrix.CoordinateSystem3d
        Dim acCurDb As Database = acDoc.Database

        'Lib_Drawing.CreateLine(New Point3d(Canhtruc1, 0, 0), New Point3d(0, 0, 0))

        Dim id_1 As ObjectId
        id_1 = Lib_Drawing.CreateLine(New Point3d(Canhtruc2, 0, 0), New Point3d(0, 0, 0))
        Lib_Drawing.RotateEntity(id_1, Matrix3d.Rotation(-Goc1, curUCS.Zaxis, New Point3d(0, 0, 0)))
        mbVeMong.Erase_E(id_1)

        Goc2 = Goc2 + Goc1
        Dim id_2 As ObjectId
        id_2 = Lib_Drawing.CreateLine(New Point3d(Canhtruc3, 0, 0), New Point3d(0, 0, 0))
        Lib_Drawing.RotateEntity(id_2, Matrix3d.Rotation(-Goc2, curUCS.Zaxis, New Point3d(0, 0, 0)))
        mbVeMong.Erase_E(id_2)

        Goc3 = Goc2 + Goc3
        Dim id_3 As ObjectId
        id_3 = Lib_Drawing.CreateLine(New Point3d(Canhtruc4, 0, 0), New Point3d(0, 0, 0))
        Lib_Drawing.RotateEntity(id_3, Matrix3d.Rotation(-Goc3, curUCS.Zaxis, New Point3d(0, 0, 0)))
        mbVeMong.Erase_E(id_3)
        Dim canhcanh As Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            canhcanh = acTrans.GetObject(id_1, OpenMode.ForWrite)
            acTrans.Commit()
        End Using
        Dim diem1 As Point3d = canhcanh.GetPointAtDist(0)

        Dim canhcanh1 As Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            canhcanh1 = acTrans.GetObject(id_2, OpenMode.ForWrite)
            acTrans.Commit()
        End Using
        Dim diem2 As Point3d = canhcanh1.GetPointAtDist(0)

        Dim canhcanh2 As Line
        Using acTrans As Transaction = acCurDb.TransactionManager.StartTransaction()
            canhcanh2 = acTrans.GetObject(id_3, OpenMode.ForWrite)
            acTrans.Commit()
        End Using
        Dim diem3 As Point3d = canhcanh2.GetPointAtDist(0)
        Dim diem As Point3d = New Point3d(Canhtruc1, 0, 0)
        frmTTC.dgvToaDoMong.RowCount = 0

        frmTTC.dgvToaDoMong.Rows.Add({"Móng M1", Math.Round(diem.X, 3), Math.Round(diem.Y, 3), diem.Z})
        frmTTC.dgvToaDoMong.Rows.Add({"Móng M2", Math.Round(diem1.X, 3), Math.Round(diem1.Y, 3), diem1.Z})
        frmTTC.dgvToaDoMong.Rows.Add({"Móng M3", Math.Round(diem2.X, 3), Math.Round(diem2.Y, 3), diem2.Z})
        frmTTC.dgvToaDoMong.Rows.Add({"Móng M4", Math.Round(diem3.X, 3), Math.Round(diem3.Y, 3), diem3.Z})
    End Sub

End Class
