using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace P3_StudentDetails
{
    public partial class MainWindow : Window
    {
        private Dictionary<int, string> students = new Dictionary<int, string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Add Student
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = int.Parse(studentId.Text);
                string name = studentName.Text.Trim();

                if (students.ContainsKey(Id))
                {
                    MessageBox.Show("Student with this ID already exists. Please enter a new ID.","Duplicate ID", MessageBoxButton.OK);
                    return;
                }

                students[Id] = name;
                MessageBox.Show($"Student {name} (ID: {Id}) added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                studentId.Clear();
                studentName.Clear();

                UpdateStudentList();
            }
            catch (FormatException)
            {
                MessageBox.Show("❌ Invalid input! Please enter a valid numeric ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Remove Student
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int Id = int.Parse(stuId.Text);

                if (students.ContainsKey(Id))
                {
                    students.Remove(Id);
                    MessageBox.Show($"student with ID {Id} removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Student ID not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

                stuId.Clear();
                UpdateStudentList();
            }
            catch (FormatException)
            {
                MessageBox.Show("❌ Invalid ID! Please enter a valid numeric ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStudentList()
        {
            lstBox.Items.Clear();

            if (students.Count == 0)
            {
                lstBox.Items.Add("No student records found.");
                return;
            }

            foreach (var student in students)
            {
                lstBox.Items.Add($"ID: {student.Key} | Name: {student.Value}");
            }
        }
    }
}
