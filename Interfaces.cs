﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clifton.Semantics
{
	public interface ISemanticProcessor
	{
		IMembrane Surface { get; }
		IMembrane Logger { get; }

		void Register<M, T>()
			where M : IMembrane, new()
			where T : IReceptor;

		void Register<M>(IReceptor receptor)
			where M : IMembrane, new();

		void Register(IMembrane membrane, IReceptor receptor);

		void ProcessInstance<M, T>(Action<T> initializer, bool processOnCallerThread = false)
			where M : IMembrane, new()
			where T : ISemanticType, new();

		void ProcessInstance<M, T>(bool processOnCallerThread = false)
			where M : IMembrane, new()
			where T : ISemanticType, new();

		void ProcessInstance<M, T>(T obj, bool processOnCallerThread = false)
			where M : IMembrane, new()
			where T : ISemanticType;

		void ProcessInstance<T>(IMembrane membrane, T obj, bool processOnCallerThread = false)
			where T : ISemanticType;
	}

	public interface IMembrane
	{
		// Do not any members here.  This is an interface helper.
	}

	public interface ISemanticType
	{
		// Do not any members here.  This is an interface helper.
	}

	public interface IReceptor
	{
		// Do not any members here.  This is an interface helper.
	}

	public interface IReceptor<T> : IReceptor
	{
		void Process(ISemanticProcessor pool, IMembrane membrane, T obj);
	}
}
