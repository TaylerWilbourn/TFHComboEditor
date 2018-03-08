using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace TFH_Combo_Editor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private ObservableCollection<InputFrame> inputList = CreateTestInputs();

		public MainWindow()
		{
			InitializeComponent();
			//List<InputFrame> inputList = CreateTestInputs();
			FileManager FM = new FileManager();
			FM.SaveFile(inputList);
			inputListBox.ItemsSource = this.inputList;
		}

		public static ObservableCollection<InputFrame> CreateTestInputs()
		{
			ObservableCollection<InputFrame> testInputs = new ObservableCollection<InputFrame>
			{
				new InputFrame(1, true, false, false, false),
				new InputFrame(2, false, true, false, false),
				new InputFrame(3, false, false, true, false),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(4, false, false, false, true),
				new InputFrame(5, false, false, false, false)
			};

			return testInputs;
		}
	}
}
