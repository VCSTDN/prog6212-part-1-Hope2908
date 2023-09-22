using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeManagementLibrary; //importing the namespace of the classs library created 



namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Module> modules = new ObservableCollection<Module>();

        public MainWindow()
        {
            InitializeComponent();
            lvModules.ItemsSource = modules;
        }

        private void AddModule_Click(object sender, RoutedEventArgs e)
        {
            // To retrieve data from UI controls
            string code = txtCode.Text;
            string name = txtName.Text;
            int credits = int.Parse(txtCredits.Text);
            int classHoursPerWeek = int.Parse(txtClassHours.Text);

            // To create a new module instance and add it to the collection
            Module module = new Module(code, name, credits, classHoursPerWeek)
            {
                WeeksInSemester = int.Parse(txtWeeksInSemester.Text),
                StartDate = dpStartDate.SelectedDate ?? DateTime.MinValue
            };

            modules.Add(module);
            ClearTextBoxes();
        }
        // Using LINQ to filter modules 
        // Filtering modules based on user input
        private void FilterModulesButton_Click(object sender, RoutedEventArgs e)
        {
            var filteredModules = modules.Where(module => module.Credits > 10).ToList();

        }

        // Function to clear input fields
        private void ClearTextBoxes()
        {
            txtCode.Clear();
            txtName.Clear();
            txtCredits.Clear();
            txtClassHours.Clear();
            txtWeeksInSemester.Clear();
            dpStartDate.SelectedDate = null;
        }

        private void RecordHours_Click(object sender, RoutedEventArgs e)
        {
            if (lvModules.SelectedItem != null && dpRecordDate.SelectedDate != null)
            {
                Module selectedModule = (Module)lvModules.SelectedItem;
                DateTime recordDate = dpRecordDate.SelectedDate ?? DateTime.MinValue;
                int hoursStudied = int.Parse(txtHoursStudied.Text);

                // Create a study record and add it to the selected module
                selectedModule.StudyRecords.Add(new ModuleStudyRecord
                {
                    Date = recordDate,
                    HoursStudied = hoursStudied
                });

                CalculateRemainingSelfStudy(selectedModule);
            }
        }

        private void CalculateRemainingSelfStudy(Module module)
        {
            if (module.WeeksInSemester == 0 || module.StartDate == DateTime.MinValue)
                return;

            // Calculate the current week based on the selected date
            DateTime currentDate = DateTime.Now;
            int currentWeek = (int)Math.Ceiling((currentDate - module.StartDate).TotalDays / 7);

            if (currentWeek <= module.WeeksInSemester)
            {
                // Calculate self-study hours remaining for the current week
                int totalSelfStudyHours = (module.Credits * 10) - (currentWeek * module.ClassHoursPerWeek);
                int hoursStudiedThisWeek = module.StudyRecords
                    .Where(record => currentWeek == (int)Math.Ceiling((record.Date - module.StartDate).TotalDays / 7))
                    .Sum(record => record.HoursStudied);

                int remainingHoursThisWeek = totalSelfStudyHours - hoursStudiedThisWeek;
                MessageBox.Show($"Remaining self-study hours for {module.Name} this week: {remainingHoursThisWeek}");
            }
        }
    }
}
