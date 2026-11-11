using System;
using System.Collections.Generic;
using System.Data;
using Lab13_CrystalReport.DAL;
using Lab13_CrystalReport.DTO;

namespace Lab13_CrystalReport.BUS
{
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAL _baoCaoDAL;

        public BaoCaoBUS()
        {
            _baoCaoDAL = new BaoCaoDAL();
        }

        public DataTable GetStudentReportData(string maKhoa = null)
        {
            return _baoCaoDAL.GetStudentReportData(maKhoa);
        }

        public List<SinhVienReportDTO> GetStudentReportList(string maKhoa = null)
        {
            return _baoCaoDAL.GetStudentReportList(maKhoa);
        }

        public DataTable GetFacultyReportData()
        {
            return _baoCaoDAL.GetFacultyReportData();
        }

        public List<KhoaReportDTO> GetFacultyReportList()
        {
            return _baoCaoDAL.GetFacultyReportList();
        }

        public DataTable GetCourseReportData()
        {
            return _baoCaoDAL.GetCourseReportData();
        }

        public List<HocPhanReportDTO> GetCourseReportList()
        {
            return _baoCaoDAL.GetCourseReportList();
        }

        public DataTable GetAllKhoa()
        {
            return _baoCaoDAL.GetAllKhoa();
        }
    }
}
