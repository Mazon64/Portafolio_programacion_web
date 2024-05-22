using System.ComponentModel.DataAnnotations;
namespace ProjectBlazor.Models
{
    public class Student
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public string? Email { get; set; }
        [Range(0, 10, ErrorMessage = "La nota debe estar entre 0 y 10")]
        public double Grade { get; set; }
        public Dictionary<string, string> ValidationErrors { get; set; } = new Dictionary<string, string>();
    }

    public class School
    {
        private List<Student> students = new List<Student>();

        public IReadOnlyList<Student> Students => students.AsReadOnly();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }
    }
}