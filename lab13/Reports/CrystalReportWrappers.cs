using System;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Lab13_CrystalReport.Reports
{
    /// <summary>
    /// Lớp CrystalReportSinhVien kế thừa ReportClass theo chuẩn SAP Crystal Reports
    /// Khớp định nghĩa trong Bài 4 của tài liệu Lab 13
    /// </summary>
    public class CrystalReportSinhVien : ReportClass
    {
        public CrystalReportSinhVien()
        {
        }

        public override string ResourceName
        {
            get => "CrystalReportSinhVien.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab13_CrystalReport.Reports.CrystalReportSinhVien.rpt";
            set { }
        }
    }

    /// <summary>
    /// Lớp CrystalReportKhoa phục vụ Bài 6
    /// </summary>
    public class CrystalReportKhoa : ReportClass
    {
        public CrystalReportKhoa()
        {
        }

        public override string ResourceName
        {
            get => "CrystalReportKhoa.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab13_CrystalReport.Reports.CrystalReportKhoa.rpt";
            set { }
        }
    }

    /// <summary>
    /// Lớp CrystalReportHocPhan phục vụ Bài 8
    /// </summary>
    public class CrystalReportHocPhan : ReportClass
    {
        public CrystalReportHocPhan()
        {
        }

        public override string ResourceName
        {
            get => "CrystalReportHocPhan.rpt";
            set { }
        }

        public override bool NewGenerator
        {
            get => true;
            set { }
        }

        public override string FullResourceName
        {
            get => "Lab13_CrystalReport.Reports.CrystalReportHocPhan.rpt";
            set { }
        }
    }
}
