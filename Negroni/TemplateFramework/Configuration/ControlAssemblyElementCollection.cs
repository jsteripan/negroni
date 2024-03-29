﻿/* *********************************************************************
   Copyright 2009-2010 MySpace

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
********************************************************************* */


using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Negroni.TemplateFramework.Configuration
{
	[ConfigurationCollection(typeof(ControlAssemblyElement), AddItemName = "assembly")]
	public class ControlAssemblyElementCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ControlAssemblyElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			ControlAssemblyElement elem = element as ControlAssemblyElement;
			if (elem == null)
			{
				throw new ArgumentException("Argument must be non-null and of type NegroniAssemblyElement", "element");
			}
			return elem.Name == null ? string.Empty : elem.Name;
		}

		public void Add(ControlAssemblyElement element)
		{
			this.BaseAdd(element);
		}

		public void Remove(ControlAssemblyElement element)
		{
			this.BaseRemove(this.GetElementKey(element));
		}

		public void Clear()
		{
			this.BaseClear();
		}

		public ControlAssemblyElement this[int index]
		{
			get
			{
				if (this.Count <= index)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				return base.BaseGet(index) as ControlAssemblyElement;
			}
		}

		public ControlAssemblyElement LookupByName(string name)
		{
			ControlAssemblyElement retval = base.BaseGet(name) as ControlAssemblyElement;
			if (retval == null)
			{
				throw new ArgumentException("key");
			}
			return retval;
		}
	}
}
