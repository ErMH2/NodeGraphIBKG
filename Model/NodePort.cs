﻿using NodeGraph.ViewModel;
using System;
using System.Collections.ObjectModel;

namespace NodeGraph.Model
{
	public class NodePort : ModelBase
	{
		#region Fields

		public NodePortViewModel ViewModel;

		public readonly Node Owner;

		public readonly string Name;

		public readonly bool IsInput;

		public readonly bool AllowMultipleInput;

		public readonly bool AllowMultipleOutput;

		#endregion // Fields

		#region Properties

		private string _DisplayName;
		public string DisplayName
		{
			get { return _DisplayName; }
			set
			{
				if( value != _DisplayName )
				{
					_DisplayName = value;
					RaisePropertyChanged( "DisplayName" );
				}
			}
		}

		private ObservableCollection<Connector> _Connectors = new ObservableCollection<Connector>();
		public ObservableCollection<Connector> Connectors
		{
			get { return _Connectors; }
			set
			{
				if( value != _Connectors )
				{
					_Connectors = value;
					RaisePropertyChanged( "Connectors" );
				}
			}
		}

		#endregion // Properties

		#region Constructor

		/// <summary>
		/// Never call this constructor directly. Use GraphManager.CreateNodeFlowPort() or GraphManager.CreateNodePropertyPort() method.
		/// </summary>
		protected NodePort( Guid guid, Node node, string name, string displayName, bool isInput, bool allowMultipleInput, bool allowMultipleOutput ) : base( guid )
		{
			Owner = node;
			Name = name;
			DisplayName = displayName;
			IsInput = isInput;
			AllowMultipleInput = allowMultipleInput;
			AllowMultipleOutput = allowMultipleOutput;
		}

		#endregion // Constructor

		#region Destructor

		~NodePort()
		{
		}

		#endregion // Destructor
				
		#region Methods

		public virtual bool IsConnectable( NodePort otherPort )
		{
			return true;
		}

		#endregion // Methods

		#region Callbacks

		public virtual void OnCreate()
		{
			if( NodeGraphManager.OutputDebugInfo )
				System.Diagnostics.Debug.WriteLine( "NodePort.OnCreate()" );
		}

		public virtual void OnPreDestroy()
		{
			if( NodeGraphManager.OutputDebugInfo )
				System.Diagnostics.Debug.WriteLine( "NodePort.OnPreDestroy()" );
		}

		public virtual void OnPostDestroy()
		{
			if( NodeGraphManager.OutputDebugInfo )
				System.Diagnostics.Debug.WriteLine( "NodePort.OnPostDestroy()" );
		}

		public virtual void OnConnect( Connector connector )
		{
			if( NodeGraphManager.OutputDebugInfo )
				System.Diagnostics.Debug.WriteLine( "NodePort.OnConnect()" );
		}

		public virtual void OnDisconnect( Connector connector )
		{
			if( NodeGraphManager.OutputDebugInfo )
				System.Diagnostics.Debug.WriteLine( "NodePort.OnDisconnect()" );
		}

		#endregion // Callbacks
	}
}
