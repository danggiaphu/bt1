using lab01_2;
using System;
using System.Collections.Generic;
using System.Linq;

// ***************************************************************
// LƯU Ý: Lớp Student (và hàm input/display) PHẢI TỒN TẠI 
//        trong file hoặc namespace của bạn để mã này hoạt động.
// ***************************************************************

public class Program
{
    // =================================================================
    // HAM CHINH (MAIN) - SUA LAI HOAN TOAN THEO YEU CAU
    // =================================================================
    static void Main(string[] args)
    {
        List<Student> studentList = new List<Student>();
        int choice;

        do
        {
            // Hiển thị Menu
            Console.WriteLine("\n========== CHUONG TRINH QUAN LY SINH VIEN ==========");
            Console.WriteLine("1. Them sinh vien moi");
            Console.WriteLine("2. Hien thi danh sach sinh vien");
            Console.WriteLine("3. Xuat thong tin SV thuoc khoa 'CNTT'");
            Console.WriteLine("4. Xuat thong tin SV co Diem TB >= 5");
            Console.WriteLine("5. Sap xep SV theo Diem TB tang dan");
            Console.WriteLine("6. Xuat thong tin SV Diem TB >= 5 va thuoc khoa 'CNTT'");
            Console.WriteLine("7. Xuat thong tin SV co Diem TB cao nhat va thuoc khoa 'CNTT'");
            Console.WriteLine("8. Thong ke so luong SV theo xep loai");
            Console.WriteLine("0. Thoat chuong trinh");
            Console.Write("Nhap lua chon cua ban: ");

            // Xử lý lựa chọn
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1: // Thêm sinh viên
                        Console.Write("Nhap so luong sinh vien muon them: ");
                        if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
                        {
                            AddStudent(studentList, count);
                        }
                        else
                        {
                            Console.WriteLine("So luong khong hop le.");
                        }
                        break;
                    case 2: // Hiển thị danh sách
                        ShowAllStudents(studentList);
                        break;
                    case 3: // Lọc theo Khoa 'CNTT'
                        FilterByFaculty(studentList, "CNTT");
                        break;
                    case 4: // Lọc Diem TB >= 5
                        FilterByMinScore(studentList, 5.0f);
                        break;
                    case 5: // Sắp xếp theo Diem TB tăng dần
                        SortStudentsByScoreAscending(studentList);
                        break;
                    case 6: // Lọc Diem TB >= 5 và Khoa 'CNTT'
                        FilterByScoreAndFaculty(studentList, 5.0f, "CNTT");
                        break;
                    case 7: // Diem TB cao nhat Khoa 'CNTT'
                        GetHighestScoreCNTT(studentList, "CNTT");
                        break;
                    case 8: // Thống kê xếp loại
                        CountByClassification(studentList);
                        break;
                    case 0:
                        Console.WriteLine("Tam biet! Hen gap lai.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long thu lai.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Dinh dang nhap khong hop le. Vui long nhap so.");
            }

        } while (choice != 0);
    }

    // =================================================================
    // HAM CHUC NANG (HELPER FUNCTIONS)
    // =================================================================

    // Hàm 1: Thêm sinh viên (đã sửa để kiểm tra trùng lặp)
    static void AddStudent(List<Student> students, int count)
    {
        Console.WriteLine($"\n--- Bat dau nhap thong tin {count} sinh vien ---");
        int studentsAdded = 0;

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\n[Sinh vien thu {i + 1}]");
            Student newStudent = new Student();

            bool isDuplicate;

            do
            {
                newStudent.Input();

              
                isDuplicate = students.Any(s =>
                    s.StudentID.Equals(newStudent.StudentID, StringComparison.OrdinalIgnoreCase));

                if (isDuplicate)
                {
                    Console.WriteLine($"\n(!) MSSV '{newStudent.StudentID}' da ton tai. Vui long nhap lai.");
                }

            } while (isDuplicate); 
            students.Add(newStudent);
            studentsAdded++;
        }
        Console.WriteLine($"\nThem {studentsAdded} sinh vien vao danh sach thanh cong!");
    }

    // Hàm 2: Hiển thị danh sách sinh viên
    static void ShowAllStudents(List<Student> students)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        Console.WriteLine("\n=======================================================");
        Console.WriteLine("           DANH SACH SINH VIEN TRONG HE THONG          ");
        Console.WriteLine("=======================================================");
        Console.WriteLine($"{"STT",-5} | {"MSSV",-10} | {"Ho Ten",-20} | {"Khoa",-10} | {"Diem TB",-8}");
        Console.WriteLine("-------------------------------------------------------");

        int stt = 1;
        foreach (var s in students)
        {
            Console.Write($"{stt,-5} | ");
            s.Show();
            stt++;
        }
        Console.WriteLine("=======================================================");
    }

    // Hàm 3: Xuất SV thuộc khoa
    static void FilterByFaculty(List<Student> students, string facultyName)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        var result = students
            .Where(s => s.Faculty.Equals(facultyName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine($"\n--- SINH VIEN THUOC KHOA '{facultyName}' ---");
        if (result.Any())
        {
            ShowAllStudents(result);
        }
        else
        {
            Console.WriteLine($"Khong tim thay sinh vien nao thuoc khoa '{facultyName}'.");
        }
    }

    // Hàm 4: Xuất SV có điểm TB lớn hơn hoặc bằng 5
    static void FilterByMinScore(List<Student> students, float minScore)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        var result = students
            .Where(s => s.AverageScore >= minScore)
            .ToList();

        Console.WriteLine($"\n--- SINH VIEN CO DIEM TB LON HON HOAC BANG {minScore:F2} ---");
        if (result.Any())
        {
            ShowAllStudents(result);
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien nao thoa man dieu kien.");
        }
    }

    // Hàm 5: Sắp xếp SV theo điểm TB tăng dần
    static void SortStudentsByScoreAscending(List<Student> students)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        var sortedList = students
            .OrderBy(s => s.AverageScore)
            .ToList();

        Console.WriteLine("\n--- DANH SACH SAU KHI SAP XEP THEO DIEM TB TANG DAN ---");
        ShowAllStudents(sortedList);
    }

    // Hàm 6: Xuất SV có điểm TB >= 5 và thuộc khoa 'CNTT'
    static void FilterByScoreAndFaculty(List<Student> students, float minScore, string facultyName)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        var result = students
            .Where(s => s.AverageScore >= minScore &&
                        s.Faculty.Equals(facultyName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        Console.WriteLine($"\n--- SINH VIEN CO DIEM TB >= {minScore:F2} VA THUOC KHOA '{facultyName}' ---");
        if (result.Any())
        {
            ShowAllStudents(result);
        }
        else
        {
            Console.WriteLine("Khong tim thay sinh vien nao thoa man dieu kien.");
        }
    }

    // Hàm 7: Xuất SV có điểm TB cao nhất và thuộc khoa 'CNTT'
    static void GetHighestScoreCNTT(List<Student> students, string facultyName)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        var cnttStudents = students
            .Where(s => s.Faculty.Equals(facultyName, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (!cnttStudents.Any())
        {
            Console.WriteLine($"Khong tim thay sinh vien nao thuoc khoa '{facultyName}'.");
            return;
        }

        float maxScore = cnttStudents.Max(s => s.AverageScore);

        var result = cnttStudents
            .Where(s => s.AverageScore == maxScore)
            .ToList();

        Console.WriteLine($"\n--- SINH VIEN KHOA '{facultyName}' CO DIEM TB CAO NHAT ({maxScore:F2}) ---");
        ShowAllStudents(result);
    }

    // Hàm phụ trợ cho Hàm 8: Xác định xếp loại
    static string GetClassification(float score)
    {
        if (score >= 9.0f) return "Xuat sac";
        if (score >= 8.0f) return "Gioi";
        if (score >= 7.0f) return "Kha";
        if (score >= 5.0f) return "Trung binh";
        if (score >= 4.0f) return "Yeu";
        return "Kem";
    }

    // Hàm 8: Thống kê số lượng SV theo xếp loại
    static void CountByClassification(List<Student> students)
    {
        if (!students.Any())
        {
            Console.WriteLine("\nDanh sach sinh vien hien tai dang trong.");
            return;
        }

        // Nhóm sinh viên theo xếp loại và đếm số lượng
        var classificationCounts = students
            .GroupBy(s => GetClassification(s.AverageScore))
            .Select(g => new { Classification = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count)
            .ToList();

        Console.WriteLine("\n--- THONG KE SO LUONG SINH VIEN THEO XEP LOAI ---");
        Console.WriteLine($"{"Xep Loai",-15} {"So Luong",-8}");
        Console.WriteLine("-------------------------");

        foreach (var item in classificationCounts)
        {
            Console.WriteLine($"{item.Classification,-15} {item.Count,-8}");
        }
        Console.WriteLine("-------------------------");
        Console.WriteLine($"Tong cong: {students.Count} sinh vien");
    }
}