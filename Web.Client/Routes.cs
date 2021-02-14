﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havit.NewProjectTemplate.Web.Client
{
	public static class Routes
	{
		public const string Home = "/";

		public static class Administration
		{
			public const string Index = "/admin/";
		}

		public static class UserAdministration
		{
			public const string Currencies = "/admin/user/currencies";
			public const string ExchangeRates = "/admin/user/exchange-rates";
			public const string BankAccounts = "/admin/user/bank-accounts";
		}

		public static class Diagnostics
		{
			public const string Info = "/diag/info";
		}
	}
}
