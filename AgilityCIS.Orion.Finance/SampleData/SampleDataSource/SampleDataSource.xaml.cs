//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.SampleDataSource
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleDataSource {

}
#else

	public class SampleDataSource : System.ComponentModel.INotifyPropertyChanged
	{
		#region Fields (1) 

		private ItemCollection _Collection = new ItemCollection();

		#endregion Fields 

		#region Constructors (1) 

		public SampleDataSource()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/AgilityCIS.Orion.Customers;component/SampleData/SampleDataSource/SampleDataSource.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		#endregion Constructors 

		#region Properties (1) 

		public ItemCollection Collection
		{
			get
			{
				return this._Collection;
			}
		}

		#endregion Properties 

		#region Delegates and Events (1) 

		// Events (1) 

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		#endregion Delegates and Events 

		#region Methods (1) 

		// Protected Methods (1) 

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion Methods 
	}

	public class Item : System.ComponentModel.INotifyPropertyChanged
	{
		#region Fields (2) 

		private string _Property1 = string.Empty;
		private string _Property2 = string.Empty;

		#endregion Fields 

		#region Properties (2) 

		public string Property1
		{
			get
			{
				return this._Property1;
			}

			set
			{
				if (this._Property1 != value)
				{
					this._Property1 = value;
					this.OnPropertyChanged("Property1");
				}
			}
		}

		public string Property2
		{
			get
			{
				return this._Property2;
			}

			set
			{
				if (this._Property2 != value)
				{
					this._Property2 = value;
					this.OnPropertyChanged("Property2");
				}
			}
		}

		#endregion Properties 

		#region Delegates and Events (1) 

		// Events (1) 

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		#endregion Delegates and Events 

		#region Methods (1) 

		// Protected Methods (1) 

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		#endregion Methods 
	}

	public class ItemCollection : System.Collections.ObjectModel.ObservableCollection<Item>
	{

}
#endif
}
