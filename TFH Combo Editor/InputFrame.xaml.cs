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

		public int direction
		{
			get
			{
				var Downcast = this.DataContext as InputViewModel;
				if (Downcast.ValueAs0) return 0;
				if (Downcast.ValueAs1) return 1;
				if (Downcast.ValueAs2) return 2;
				if (Downcast.ValueAs3) return 3;
				if (Downcast.ValueAs4) return 4;
				if (Downcast.ValueAs5) return 5;
				if (Downcast.ValueAs6) return 6;
				if (Downcast.ValueAs7) return 7;
				if (Downcast.ValueAs8) return 8;
				return 8;
			}
			set
			{
				var Downcast = this.DataContext as InputViewModel;
				switch (value)
				{
					case 0:
						Downcast.ValueAs0 = true;
						break;
					case 1:
						Downcast.ValueAs1 = true;
						break;
					case 2:
						Downcast.ValueAs2 = true;
						break;
					case 3:
						Downcast.ValueAs3 = true;
						break;
					case 4:
						Downcast.ValueAs4 = true;
						break;
					case 5:
						Downcast.ValueAs5 = true;
						break;
					case 6:
						Downcast.ValueAs6 = true;
						break;
					case 7:
						Downcast.ValueAs7 = true;
						break;
					case 8:
						Downcast.ValueAs8 = true;
						break;
				}
			}
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
	}

	public class InputViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		private bool _ValueAs0 = false;
		public bool ValueAs0
		{
			get { return _ValueAs0; }
			set
			{
				if (_ValueAs0 != value)
				{
					_ValueAs0 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs0"));
				}
			}
		}

		private bool _ValueAs1 = false;
		public bool ValueAs1
		{
			get { return _ValueAs1; }
			set
			{
				if (_ValueAs1 != value)
				{
					_ValueAs1 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs1"));
				}
			}
		}

		private bool _ValueAs2 = false;
		public bool ValueAs2
		{
			get { return _ValueAs2; }
			set
			{
				if (_ValueAs2 != value)
				{
					_ValueAs2 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs2"));
				}
			}
		}

		private bool _ValueAs3 = false;
		public bool ValueAs3
		{
			get { return _ValueAs3; }
			set
			{
				if (_ValueAs3 != value)
				{
					_ValueAs3 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs3"));
				}
			}
		}

		private bool _ValueAs4 = false;
		public bool ValueAs4
		{
			get { return _ValueAs4; }
			set
			{
				if (_ValueAs4 != value)
				{
					_ValueAs4 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs4"));
				}
			}
		}

		private bool _ValueAs5 = false;
		public bool ValueAs5
		{
			get { return _ValueAs5; }
			set
			{
				if (_ValueAs5 != value)
				{
					_ValueAs5 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs5"));
				}
			}
		}

		private bool _ValueAs6 = false;
		public bool ValueAs6
		{
			get { return _ValueAs6; }
			set
			{
				if (_ValueAs6 != value)
				{
					_ValueAs6 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs6"));
				}
			}
		}

		private bool _ValueAs7 = false;
		public bool ValueAs7
		{
			get { return _ValueAs7; }
			set
			{
				if (_ValueAs7 != value)
				{
					_ValueAs7 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs7"));
				}
			}
		}

		private bool _ValueAs8 = false;
		public bool ValueAs8
		{
			get { return _ValueAs8; }
			set
			{
				if (_ValueAs8 != value)
				{
					_ValueAs8 = value;
					if (PropertyChanged != null)
						PropertyChanged(this, new PropertyChangedEventArgs("ValueAs8"));
				}
			}
		}


		private bool m_aChecked = false;
		public bool aChecked
		{
			get
			{
				return m_aChecked;
			}
			set
			{
				if (m_aChecked != value)
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
