using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	/// Interaction logic for UserControl1.xaml
	/// </summary>
	public partial class InputFrame : UserControl
	{
		public int counter;
		public int direction;
		public int aState, bState, cState, dState;
		public bool isSpecialFrame = false;

		public InputFrame()
		{
			InitializeComponent();
			this.DataContext = new InputViewModel(this);
		}

		public InputFrame(int dir, bool a, bool b, bool c, bool d)
		{
			InitializeComponent();
			this.DataContext = new InputViewModel(this);
			this.direction = dir;
			this.a = a;
			this.b = b;
			this.c = c;
			this.d = d;
		}

		public bool a
		{
			get
			{
				var Downcast = this.DataContext as InputViewModel;
				return Downcast?.aChecked ?? false;
			}
			set
			{
				var Downcast = this.DataContext as InputViewModel;
				Downcast.aChecked = value;
			}
		}

		public bool b
		{
			get
			{
				var Downcast = this.DataContext as InputViewModel;
				return Downcast?.bChecked ?? false;
			}
			set
			{
				var Downcast = this.DataContext as InputViewModel;
				Downcast.bChecked = value;
			}
		}

		public bool c
		{
			get
			{
				var Downcast = this.DataContext as InputViewModel;
				return Downcast?.cChecked ?? false;
			}
			set
			{
				var Downcast = this.DataContext as InputViewModel;
				Downcast.cChecked = value;
			}
		}

		public bool d
		{
			get
			{
				var Downcast = this.DataContext as InputViewModel;
				return Downcast?.dChecked ?? false;
			}
			set
			{
				var Downcast = this.DataContext as InputViewModel;
				Downcast.dChecked = value;
			}
		}
		//b, c, d;
	}

	public class InputViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool m_aChecked = false;
		public bool aChecked
		{
			get
			{
				return m_aChecked;
			}
			set
			{
				if(m_aChecked != value)
				{
					m_aChecked = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("aChecked"));
				}
			}
		}

		private bool m_bChecked = false;
		public bool bChecked
		{
			get
			{
				return m_bChecked;
			}
			set
			{
				if (m_bChecked != value)
				{
					m_bChecked = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("bChecked"));
				}
			}
		}

		private bool m_cChecked = false;
		public bool cChecked
		{
			get
			{
				return m_cChecked;
			}
			set
			{
				if (m_cChecked != value)
				{
					m_cChecked = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("cChecked"));
				}
			}
		}

		private bool m_dChecked = false;
		public bool dChecked
		{
			get
			{
				return m_dChecked;
			}
			set
			{
				if (m_dChecked != value)
				{
					m_dChecked = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("dChecked"));
				}
			}
		}

		public InputViewModel(InputFrame input)
		{
			aChecked = input.a;
			bChecked = input.b;
			cChecked = input.c;
			dChecked = input.d;
		}
	}
}
