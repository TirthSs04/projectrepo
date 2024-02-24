// MainWindow.xaml.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using WpfApp2;
using WpfApp2.Model;


namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        //private List<Employee> employees = new List<Employee>();
        List<Employee> employeeName = new List<Employee>();
        List<string> employeeData = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void radioButtonHourly_Checked(object sender, RoutedEventArgs e)
        {

            //if (radioButtonCommission.IsChecked == false && radioButtonWeekly.IsChecked == false)
            //{
            //    lblHWorked.Content = "Hours Worked";
            //    lblHWages.Content = "Hourly Wages";

            //}
            // Show/hide relevant labels and textboxes for HourlyEmployee
            HideCommissionLabels();
            HideWeeklySalaryLabels();
            ShowHourlyLabels();
        }

        private void radioButtonCommission_Checked(object sender, RoutedEventArgs e)
        {
            if(radioButtonCommission.IsChecked == true)
            {
                lblHWorked.Content = "Gross Sales";
                lblHWages.Content = "Comission Rate";

            }
            //// Show/hide relevant labels and textboxes for CommissionEmployee
            //HideHourlyLabels();
            //HideWeeklySalaryLabels();
            //ShowCommissionLabels();
        }

        // Helper methods to show/hide labels and textboxes for specific employee types

        private void ShowHourlyLabels()
        {
            //textBlockHoursWorked.Visibility = Visibility.Visible;
            //textBlockHourlyWage.Visibility = Visibility.Visible;
            //textBoxHoursWorked.Visibility = Visibility.Visible;
            //textBoxHourlyWage.Visibility = Visibility.Visible;
        }

        private void HideHourlyLabels()
        {
            //textBlockHoursWorked.Visibility = Visibility.Collapsed;
            //textBlockHourlyWage.Visibility = Visibility.Collapsed;
            //textBoxHoursWorked.Visibility = Visibility.Collapsed;
            //textBoxHourlyWage.Visibility = Visibility.Collapsed;
        }

        private void ShowCommissionLabels()
        {
            //textBlockHoursWorked.Text = "Gross Sales:";
            //textBlockHourlyWage.Text = "Commission Rate:";
            //textBlockHoursWorked.Visibility = Visibility.Visible;
            //textBlockHourlyWage.Visibility = Visibility.Visible;
            //textBoxHoursWorked.Visibility = Visibility.Visible;
            //textBoxHourlyWage.Visibility = Visibility.Visible;
        }

        private void HideCommissionLabels()
        {
           // //textBlockHoursWorked.Visibility = Visibility.Collapsed;
           //// textBlockHourlyWage.Visibility = Visibility.Collapsed;
           // textBoxHoursWorked.Visibility = Visibility.Collapsed;
           // textBoxHourlyWage.Visibility = Visibility.Collapsed;
        }

        private void HideWeeklySalaryLabels()
        {
            //textBlockHoursWorked.Visibility = Visibility.Collapsed;
            //textBlockHourlyWage.Visibility = Visibility.Collapsed;
            //textBoxHoursWorked.Visibility = Visibility.Collapsed;
            //textBoxHourlyWage.Visibility = Visibility.Collapsed;
        }



        private void buttonCalculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var uniqueID = GenerateUniqueId();
                var employeeName = textBoxName.Text;

                decimal federalTax = 0.20M;
                decimal hourWorked =  Convert.ToDecimal(textBoxHoursWorked.Text);
                decimal hourlyWage = Convert.ToDecimal(textBoxHourlyWage.Text);
                //decimal gross_earning = 0.00M;
                //decimal netearning = 0.00M;
                //decimal taxes = 0.00m;

                Employee employee;

                if(radioButtonHourly.IsChecked == true)
                {
                    employee = new HourlyEmployee();

                    employee.EmpType = EmployeeType.HourlyEmployee;
                    employee.HoursWorked = hourWorked;
                    employee.HourlyWage = hourlyWage;
                    employee.ID = uniqueID;
                    employee.Name = employeeName;


                    //if (Convert.ToInt32(hourWorked) <= 40)
                    //{`
                    //    hourlyEmployee.grossEarning = hourlyWage * hourWorked;
                    //}
                    //else
                    //{
                    //    var regular_hours_pay = hourlyWage * 40;
                    //    var overtime_hours_pay = (hourWorked - Convert.ToDecimal(40)) * hourlyWage * Convert.ToDecimal(1.5);
                    //    hourlyEmployee.grossEarning = regular_hours_pay + overtime_hours_pay;
                    //}

                }
                else if(radioButtonCommission.IsChecked == true)
                {
                    employee = new CommissionEmployee();

                    employee.EmpType = EmployeeType.CommissionEmployee;
                    employee.GrossSales = hourWorked;
                    employee.CommissionRate = hourlyWage;
                    employee.ID = uniqueID;
                    employee.Name = employeeName;
                    //comissionEmployee.grossEarning = hourlyWage * hourWorked;
                }
                else if(radioButtonWeekly.IsChecked == true)
                {
                    employee = new SalariedEmployee
                    {
                    employee.WeeklySalary = hourlyWage,
                    employee.ID = uniqueID,
                    employee.Name = employeeName

                    };
                                        //salaryEmployee.grossEarning = hourWorked;
                }

                //// Calculate taxes (assuming a federal tax rate of 20%)
                //employee.tax = federalTax * employee.grossEarning;

                ////Calculate net earnings
                //employee.netEarning = employee.grossEarning - employee.tax;

                //
                //List<Employee> employeeName = new List<Employee>
                //{
                //    new Employee {ID = GenerateUniqueId(), Name=textBoxName.Text }


                //};

                //List<string> employeeName = new List<string>();
                //var uniqueID = GenerateUniqueId();
                string CompletedValue = uniqueID + " " + textBoxName.Text;
                employeeData.Add(CompletedValue);

                listBoxEmployees.ItemsSource = employeeData.ToList();



                //add employee data in to list.
                //employee.Name = textBoxName.Text;
                //employee.ID = uniqueID;
                employeeName.add(employee);
                //Employee employee;
                //if (radioButtonHourly.IsChecked == true)
                //{
                //    //employee = new HourlyEmployee
                //    {
                //        //EmployeeType = EmployeeType.HourlyEmployee,
                //        EmployeeName = textBoxName.Text,
                //        HoursWorked = double.Parse(textBoxHoursWorked.Text),
                //        HourlyWage = double.Parse(textBoxHourlyWage.Text)
                //    };
                //}
                //else if (radioButtonCommission.IsChecked == true)
                //{
                //    employee = new CommissionEmployee
                //    {
                //        EmployeeType = EmployeeType.CommissionEmployee,
                //        EmployeeName = textBoxName.Text,
                //        GrossSales = double.Parse(textBoxHoursWorked.Text),
                //        CommissionRate = double.Parse(textBoxHourlyWage.Text)
                //    };
                //}
                //else
                //{
                //    employee = new SalariedEmployee
                //    {
                //        EmployeeType = EmployeeType.SalariedEmployee,
                //        EmployeeName = textBoxName.Text,
                //        WeeklySalary = double.Parse(textBoxHoursWorked.Text)
                //    };
                //}

                // Calculate and display earnings
                //textBoxGrossEarning.Text = employee.GrossEarnings.ToString();
                //textBoxTax.Text = employee.Tax.ToString();
                //textBoxNetEarning.Text = employee.NetEarnings.ToString();

                //// Add employee name to ListBox
                //listBoxEmployees.Items.Add(employee.EmployeeName);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input format. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {

            // Implement logic to clear all fields except ListBox
            textBoxName.Clear();
            textBoxHoursWorked.Clear();
            textBoxHourlyWage.Clear();
            textBoxGrossEarning.Clear();
            textBoxTax.Clear();
            textBoxNetEarning.Clear();
           
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }

        private void listBoxEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var employeInfo = listBoxEmployees.SelectedItem.ToString();

            if(employeInfo != "")
            {
                foreach (var item in employeeName)
                {
                    var empUni = item.ID + " " + item.Name;
                    if(empUni == employeInfo)
                    {
                        textBoxGrossEarning.Text = item.grossEarning.ToString();
                        textBoxNetEarning.Text= item.netEarning.ToString();
                        textBoxTax.Text= item.tax.ToString();
                    }
                }
            }
            else
            {

                MessageBox.Show("Employee Information is not available");
            }
            
            // Handle ListBox selection change
            //if (listBoxEmployees.SelectedIndex != -1)
            //{
            //    // Get the selected employee name
            //    string selectedEmployeeName = listBoxEmployees.SelectedItem.ToString();

            //    // Find the corresponding employee in the collection
            //    //Employee selectedEmployee = employees.Find(emp => emp.EmployeeName == selectedEmployeeName);

            //    // Update UI based on the selected employee type
            //    if (selectedEmployee != null)
            //    {
            //        UpdateUIBasedOnEmployeeType(selectedEmployee.EmployeeType);
            //        // Additional logic to update other UI elements if needed
            //    }

            //}
        }

        private void textBoxName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle changes in the Name TextBox

            // Basic validation: Ensure the Name is not empty
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxName.Clear(); // Clear the TextBox
                return;
            }

            // Additional validation or logic can be added as needed
        }

        // Helper method to update UI based on the selected employee type
        //private void UpdateUIBasedOnEmployeeType(EmployeeType employeeType)
        //{
        //    switch (employeeType)
        //    {
        //        case EmployeeType.HourlyEmployee:
        //            radioButtonHourly.IsChecked = true;
        //            radioButtonHourly_Checked(null, null); // Call the logic for HourlyEmployee UI
        //            break;

        //        case EmployeeType.CommissionEmployee:
        //            radioButtonCommission.IsChecked = true;
        //            radioButtonCommission_Checked(null, null); // Call the logic for CommissionEmployee UI
        //            break;

        //        case EmployeeType.SalariedEmployee:
        //            radioButtonWeekly.IsChecked = true;
        //            // Additional logic for SalariedEmployee UI if needed
        //            break;

        //        // Handle other employee types if applicable

        //        default:
        //            break;
        //    }
        //}

        private void textBoxHoursWorked_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle changes in the Hours Worked TextBox
            // You can add validation or other logic here
            if (double.TryParse(textBoxHoursWorked.Text, out double hoursWorked))
            {
                // Validation successful, you can use the 'hoursWorked' variable
                // Add your logic here
            }
            else
            {
                MessageBox.Show("Invalid input for Hours Worked. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxHoursWorked.Clear();
            }
        }

        private void textBoxHourlyWage_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Handle changes in the Hourly Wage TextBox
            // You can add validation or other logic here
            if (double.TryParse(textBoxHourlyWage.Text, out double hourlyWage))
            {
                // Validation successful, you can use the 'hourlyWage' variable
                // Add your logic here
            }
            else
            {
                MessageBox.Show("Invalid input for Hourly Wage. Please enter a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                textBoxHourlyWage.Clear();
            }
        }

        private void textBoxGrossEarning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxTax_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBoxNetEarning_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void radioButtonWeekly_Checked(object sender, RoutedEventArgs e)
        {

            if (radioButtonWeekly.IsChecked == true)
            {
                lblHWorked.Content = "Weekly Salary";
                lblHWages.Content = "Hourly Wage";

            }
        }

        ////private void textBoxGrossEarning_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        public static int GenerateUniqueId()
        {
            // Get the current timestamp
            //long timestamp = DateTime.Now.Ticks;

            //// Generate a random number
            var rand = new Random();
             int randomNumber = rand.Next(1000, 9999); // Adjust the range as needed

            // Combine timestamp and random number to create a unique ID
            //string uniqueIdString = $"{randomNumber}";

            // Parse the string into an integer
            //int uniqueId = int.Parse(uniqueIdString);

            return randomNumber;
        }
    }



}
