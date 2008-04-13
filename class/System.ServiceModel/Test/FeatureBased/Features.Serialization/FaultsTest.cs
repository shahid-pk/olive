﻿using System;
using System.Collections.Generic;
using System.Text;
using Proxy.MonoTests.Features.Client;
using NUnit.Framework;
using System.ServiceModel;

namespace MonoTests.Features.Serialization
{
	[TestFixture]
	[Category ("NotWorking")]
	public class FaultsTest : TestFixtureBase<FaultsTesterContractClient, MonoTests.Features.Contracts.FaultsTester>
	{
		[Test]
		public void TestFault ()
		{
			try {
				Client.FaultMethod ("heh");
			}
			catch (FaultException e) {
            } 
            catch (Exception e) {
                Assert.Fail("Exception is not FaultException");
			}
		}
	}

	[TestFixture]
	[Category ("NotWorking")]
	public class FaultsTestIncludeDetails : TestFixtureBase<FaultsTesterContractClientIncludeDetails, MonoTests.Features.Contracts.FaultsTesterIncludeDetails>
	{
		[Test]
		public void TestFault ()
		{
			try {
				Client.FaultMethod ("heh");
			}
			catch (Exception e) {
				Assert.AreEqual ("heh", e.Message);
			}
		}
	}
}
