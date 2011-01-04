﻿using System;
using System.IO;
using MbUnit.Framework;
using Negroni.DataPipeline;
using Negroni.OpenSocial.OSML.Controls;

using Negroni.OpenSocial.Tests.Controls;

namespace Negroni.OpenSocial.Tests.OSML
{
    /// <summary>
	/// A <see cref="TestFixture"/> for the <see cref="OsmlName"/> class.
    /// </summary>
    [TestFixture]
	[TestsOn(typeof(OsRender))]
	public class OsRenderTest : OsmlControlTestBase
    {
		const string baseTag = "<os:Render content=\"${foo}\" />";
		const string baseKey = "foo";

		[Test]
		public void TestRenderFromMarkup()
		{
			string markup = "<h1>Hello World</h1>";

			OsRender control = new OsRender(baseTag);
			DataContext dc = control.MyDataContext;
			dc.RegisterDataItem(baseKey, markup);

			Assert.IsTrue(AssertRenderResultsEqual(control, markup));
			
		}


	}
}
	