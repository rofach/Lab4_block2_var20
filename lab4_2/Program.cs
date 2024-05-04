using struct_lab_student;
using System;
using System.Text;

class Programm
{
	
	static void RunMenu(List<Student> students)
	{
		Console.WriteLine("На поточному етапі розвитку програми немає потреби робити меню");
		RunVar20(students);
	}
	static void RunVar20(List<Student> students)
	{		
		Console.WriteLine(GetPerfectGradeStudents(students));
	}
	static string GetPerfectGradeStudents(List<Student> students)
	{
		int studentCount = 0;
		StringBuilder studentsInformation = new("Списки студентів\n");
		bool flag = false;
		foreach(var student in students)
		{
			if (student.physicsMark == '5' 
			&&  student.informaticsMark == '5' 
			&&  student.mathematicsMark == '5')
			{
				studentsInformation.Append(GetStudentInformation(student));
				studentCount++;
				flag = true;
			}
		}
		if (!flag) return "Немає студентів із усіма відмінними оцінками";
		
		studentsInformation.Insert(0, "Кількість студентів із відмінними оцінками: " + 
								studentCount + "\n");		
		return studentsInformation.ToString();
		
		
		
	}
	static string GetStudentInformation(Student student)
	{
		return student.surName + " "
			 + student.firstName + " "
			 + student.patronymic + " "
			 + student.scholarship + "\n";

	}
	static List<Student> ReadData(StreamReader sr)
	{
		List<Student> students = new();
		string line;
		try
		{
			
			line = sr.ReadLine();
			while (line != null)
			{
				string[] subs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
				string newStr = string.Join(" ", subs);
				students.Add(new Student(newStr));
				line = sr.ReadLine();

			}
			sr.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine("Exception: " + e.Message);
		}
		return students;
	}
	static void Main(string[] args)
	{
		StreamReader sr = new StreamReader("input.txt");
		List<Student> students = ReadData(sr);
		
		Console.InputEncoding = Encoding.UTF8;		
		Console.OutputEncoding = Encoding.UTF8;
		RunMenu(students);

	}
}