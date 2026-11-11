1. THÔNG TIN PHIÊN BẢN CRYSTAL REPORTS VÀ RUNTIME SỬ DỤNG
--------------------------------------------------------------------------------
- Công cụ phát triển: Visual Studio 2022 / .NET 9.0 Windows Forms Desktop SDK
- Phiên bản SAP Crystal Reports for Visual Studio: Service Pack 33 (SP33)
- Phiên bản SAP Crystal Reports Runtime: 13.0.4003 (x86 & x64 compatible)
- Các Assemblies Crystal Reports được nạp trong Project:
    + CrystalDecisions.CrystalReports.Engine.dll (v13.0.4003)
    + CrystalDecisions.Shared.dll (v13.0.4003)
    + CrystalDecisions.Windows.Forms.dll (v13.0.4003)
- Thư viện bổ trợ kết xuất PDF vector cao cấp: PDFsharp 6.1.1 (Standard A4 layout)
- Cơ sở dữ liệu: Microsoft SQL Server LocalDB ((localdb)\MSSQLLocalDB) - CSDL QLSinhVien

2. CẤU TRÚC DỰ ÁN VÀ KIẾN TRÚC 3 TẦNG (3-TIER ARCHITECTURE)
--------------------------------------------------------------------------------
IT3212_Labs.sln
│
├── Lab13_Views_Setup.sql          : Script tạo 3 views và dữ liệu >= 20 sinh viên
├── DanhSachSinhVien.pdf           : Tệp PDF mẫu xuất từ báo cáo Sinh viên
├── DanhSachKhoa.pdf               : Tệp PDF mẫu xuất từ báo cáo Khoa
├── DanhSachHocPhan.pdf            : Tệp PDF mẫu xuất từ báo cáo Học phần
├── 24002545_PhanVanThang_Lab13.docx: Báo cáo thực hành chi tiết theo định dạng chuẩn
├── 24002545_PhanVanThang_Lab13.zip : Gói nộp bài hoàn chỉnh, sạch sẽ
├── README.txt                     : Hướng dẫn cấu hình và vận hành hệ thống
│
├── screenshots/                   : Bộ 10 ảnh minh chứng bài tập 1 đến 10
│   ├── hinh01_kiem_tra_moi_truong_crystal_reports.png
│   ├── hinh02_view_vw_baocaosinhvien.png
│   ├── hinh03_datatable_baocao_dal.png
│   ├── hinh04_crystal_report_viewer_sinhvien.png
│   ├── hinh05_xuat_bao_cao_pdf.png
│   ├── hinh06_bao_cao_danh_sach_khoa.png
│   ├── hinh07_dinh_dang_bao_cao_chuan.png
│   ├── hinh08_bao_cao_danh_sach_hoc_phan.png
│   ├── hinh09_menu_he_thong_frmmain.png
│   └── hinh10_kiem_thu_in_va_xuat_bao_cao.png
│
└── lab13/
    ├── DAL/
    │   ├── DbConnectionFactory.cs : Cấp phát SqlConnection chuẩn từ App.config
    │   └── BaoCaoDAL.cs           : Tầng truy cập dữ liệu từ các Views báo cáo
    ├── BUS/
    │   ├── BaoCaoBUS.cs           : Tầng nghiệp vụ xử lý logic và luồng dữ liệu
    │   └── PdfExportHelper.cs     : Xử lý định dạng báo cáo chuẩn & kết xuất PDF
    ├── DTO/
    │   ├── SinhVienReportDTO.cs   : Đối tượng truyền dữ liệu báo cáo sinh viên
    │   ├── KhoaReportDTO.cs       : Đối tượng truyền dữ liệu báo cáo khoa
    │   └── HocPhanReportDTO.cs    : Đối tượng truyền dữ liệu báo cáo học phần
    ├── GUI/
    │   ├── frmReportViewer.cs     : Canvas xem trước báo cáo với thanh công cụ Zoom/In/Xuất
    │   ├── frmBaoCaoSinhVien.cs   : Giao diện báo cáo sinh viên (Bài 4 & 5)
    │   ├── frmBaoCaoKhoa.cs       : Giao diện báo cáo khoa (Bài 6 & 7)
    │   ├── frmBaoCaoHocPhan.cs    : Giao diện báo cáo học phần (Bài 8)
    │   └── frmMain.cs             : Giao diện menu chính & chống mở trùng form (Bài 9)
    ├── Reports/
    │   ├── CrystalReportWrappers.cs: Lớp kế thừa ReportClass theo chuẩn SAP CR
    │   ├── CrystalReportSinhVien.rpt: File thiết kế báo cáo danh sách sinh viên
    │   ├── CrystalReportKhoa.rpt    : File thiết kế báo cáo khoa
    │   └── CrystalReportHocPhan.rpt : File thiết kế báo cáo học phần
    ├── App.config                 : Chuỗi kết nối QLSinhVienConnection
    ├── Lab13_CrystalReport.csproj : File dự án .NET 9 WinForms Desktop
    ├── Program.cs                 : Điểm khởi động ứng dụng & cờ --capture
    └── ScreenshotCapture.cs       : Tự động kiểm thử & chụp 10 ảnh minh chứng

3. HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY CHƯƠNG TRÌNH
--------------------------------------------------------------------------------
Bước 1: Khởi tạo View và Dữ liệu CSDL
   - Mở SQL Server Management Studio (SSMS) hoặc sqlcmd kết nối tới (localdb)\MSSQLLocalDB.
   - Mở và thực thi tệp `Lab13_Views_Setup.sql` trên cơ sở dữ liệu `QLSinhVien`.
   - Script sẽ tạo:
     + vw_BaoCaoSinhVien (MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, TenKhoa, DiemTB, Email)
     + vw_BaoCaoKhoa (MaKhoa, TenKhoa, SoLuongSinhVien, DiemTrungBinhKhoa)
     + vw_BaoCaoHocPhan (MaHP, TenHP, SoTinChi, SoLuongDangKy)
     + Đảm bảo số lượng sinh viên đạt >= 20 bản ghi.

Bước 2: Biên dịch ứng dụng
   - Mở Command Prompt hoặc PowerShell tại thư mục dự án:
       dotnet build IT3212_Labs.sln
   - Dự án sẽ biên dịch thành công mà không có bất kỳ lỗi hay cảnh báo nào.

Bước 3: Vận hành ứng dụng
   - Chạy giao diện chính:
       dotnet run --project lab13\Lab13_CrystalReport.csproj
   - Hoặc chạy chế độ chụp tự động & xuất PDF:
       dotnet run --project lab13\Lab13_CrystalReport.csproj -- --capture

4. DANH SÁCH 10 BÀI TẬP VÀ KẾT QUẢ ĐẠT ĐƯỢC
--------------------------------------------------------------------------------
1. Bài 1: Cấu hình môi trường Crystal Reports, kiểm tra namespace và packages.
2. Bài 2: Tạo view vw_BaoCaoSinhVien kết nối bảng SinhVien và Khoa.
3. Bài 3: Xây dựng hàm BaoCaoDAL.GetStudentReportData() trả về DataTable chuẩn.
4. Bài 4: Hiển thị báo cáo trên CrystalReportViewer, quản lý giải phóng tài nguyên.
5. Bài 5: Chức năng xuất báo cáo ra file PDF với SaveFileDialog.
6. Bài 6: Báo cáo danh sách khoa kèm tổng số lượng sinh viên và điểm trung bình.
7. Bài 7: Định dạng báo cáo chuẩn: Logo EAUT, tiêu đề, ngày giờ lập, số trang Page N/M, format ngày dd/MM/yyyy, điểm N2.
8. Bài 8: Báo cáo danh sách học phần đào tạo sắp xếp theo tên (A-Z).
9. Bài 9: Tích hợp menu Báo cáo trong frmMain với cơ chế chống mở trùng và giải phóng form con.
10. Bài 10: Kiểm thử in và xuất báo cáo PDF hàng loạt đạt 100% test cases.
================================================================================
