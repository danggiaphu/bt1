using System;
using System.Collections.Generic;
using System.Linq;

namespace lab01_2
{
    // Đã đổi tên lớp thành Student (chữ hoa) theo quy tắc C#
    internal class Student
    {
        // 1. Sử dụng Auto-Implemented Properties
        public string StudentID { get; set; }
        public string FullName { get; set; }
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student() { }

        // 2. Constructor đầy đủ tham số
        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.StudentID = studentID;
            this.FullName = fullName;
            this.AverageScore = averageScore;
            this.Faculty = faculty;
        }

        // 3. Phương thức nhập thông tin
        public void Input()
        {
            Console.Write("Nhap MSSV: ");
            StudentID = Console.ReadLine();
            Console.Write("Nhap ho va ten: ");
            FullName = Console.ReadLine();

            float score;
            Console.Write("Nhap diem trung binh (0-10): ");
            // Đảm bảo nhập số hợp lệ
            while (!float.TryParse(Console.ReadLine(), out score) || score < 0 || score > 10)
            {
                Console.Write("Diem khong hop le (phai la so, tu 0 den 10). Vui long nhap lai: ");
            }
            AverageScore = score;

            Console.Write("Nhap khoa: ");
            Faculty = Console.ReadLine();
        }

        // 4. Phương thức hiển thị thông tin
        public void Show()
        {
            // Sử dụng String Interpolation $"" và định dạng căn lề/thập phân
            Console.WriteLine($"MSSV: {StudentID,-10} HoTen: {FullName,-20} Khoa: {Faculty,-15} DiemTB: {AverageScore,-8:F2}");
        }
    }
}