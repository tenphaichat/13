-- ===================================================================
-- LAB 13: TẠO BÁO CÁO CƠ BẢN BẰNG CRYSTAL REPORT
-- Học phần: Lập trình .NET (IT3212) - EAUT
-- Sinh viên: Phan Văn Thắng - MSSV: 24002545 - Lớp: IT3212
-- CSDL: QLSinhVien ((localdb)\MSSQLLocalDB)
-- ===================================================================

USE QLSinhVien;
GO

-- 1. Bài 2: Tạo view báo cáo sinh viên (vw_BaoCaoSinhVien)
CREATE OR ALTER VIEW vw_BaoCaoSinhVien
AS
SELECT sv.MaSV, sv.HoTen, sv.NgaySinh,
       CASE sv.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
       k.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email, sv.IsActive
FROM SinhVien sv
JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
WHERE sv.IsActive = 1;
GO

-- 2. Bài 6: Tạo view báo cáo danh sách khoa kèm số lượng sinh viên (vw_BaoCaoKhoa)
CREATE OR ALTER VIEW vw_BaoCaoKhoa
AS
SELECT k.MaKhoa, k.TenKhoa, 
       COUNT(sv.MaSV) AS SoLuongSinhVien,
       ISNULL(AVG(sv.DiemTB), 0.0) AS DiemTrungBinhKhoa
FROM Khoa k
LEFT JOIN SinhVien sv ON k.MaKhoa = sv.MaKhoa AND sv.IsActive = 1
GROUP BY k.MaKhoa, k.TenKhoa;
GO

-- 3. Bài 8: Tạo view báo cáo danh mục học phần (vw_BaoCaoHocPhan)
CREATE OR ALTER VIEW vw_BaoCaoHocPhan
AS
SELECT hp.MaHP, hp.TenHP, hp.SoTinChi,
       COUNT(dk.MaSV) AS SoLuongDangKy
FROM HocPhan hp
LEFT JOIN DangKy dk ON hp.MaHP = dk.MaHP
GROUP BY hp.MaHP, hp.TenHP, hp.SoTinChi;
GO

-- 4. Đảm bảo dữ liệu tối thiểu 20 sinh viên
IF (SELECT COUNT(*) FROM SinhVien WHERE IsActive = 1) < 20
BEGIN
    INSERT INTO SinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email, IsActive)
    VALUES 
    ('SV021', N'Nguyễn Hoàng Long', '2005-02-14', 1, 'CNTT', 8.45, 'longnh@eaut.edu.vn', 1),
    ('SV022', N'Đỗ Thị Mai', '2005-08-20', 0, 'CNTT', 7.90, 'maidt@eaut.edu.vn', 1),
    ('SV023', N'Bùi Quốc Anh', '2005-11-05', 1, 'CNTT', 9.10, 'anhbq@eaut.edu.vn', 1),
    ('SV024', N'Lê Thị Hương', '2005-04-12', 0, 'KT', 8.25, 'huonglt@eaut.edu.vn', 1),
    ('SV025', N'Trần Minh Tuấn', '2005-09-30', 1, 'QTKD', 7.50, 'tuantm@eaut.edu.vn', 1);
END;
GO
