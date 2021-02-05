﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Havit.Blazor.Components.Web;
using Havit.Blazor.Components.Web.Bootstrap;
using Havit.Blazor.Components.Web.Bootstrap.Layouts;
using Havit.GoranG3.Contracts.Finance;
using Havit.GoranG3.Web.Client.Resources;
using Havit.GoranG3.Web.Client.Resources.Model.Finance;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace Havit.GoranG3.Web.Client.Pages.Admin
{
	// TODO: Detekce změn + onBeforeUnload? nebo alespoň před přepnutím na jinou instanci?
	public partial class BankAccountEdit : ComponentBase
	{
		[Parameter] public BankAccountDto Value { get; set; }
		[Parameter] public EventCallback<BankAccountDto> ValueChanged { get; set; }
		[Parameter] public LayoutDisplayMode DisplayMode { get; set; } = LayoutDisplayMode.Drawer;
		[Parameter] public EventCallback OnClosed { get; set; }

		[Inject] protected IHxMessengerService Messenger { get; set; }
		[Inject] protected IBankAccountFacade BankAccountFacade { get; set; }
		[Inject] protected IBankAccountLocalizer BankAccountLocalizer { get; set; }
		[Inject] protected IGlobalLocalizer GlobalLocalizer { get; set; }
		[Inject] protected ILogger<BankAccountEdit> Logger { get; set; }

		private BankAccountDto model;
		private HxDisplayLayout hxDisplayLayout;

		protected override void OnParametersSet()
		{
			Logger.LogDebug("OnParametersSet");

			base.OnParametersSet();

			model = this.Value with { }; // Clone!
		}

		public async Task HandleValidSubmit()
		{
			try
			{
				if (model.Id == default)
				{
					model.Id = (await BankAccountFacade.CreateBankAccountAsync(model)).Value;
					Messenger.AddInformation(model.Name, GlobalLocalizer.NewSuccess);
				}
				else
				{
					await BankAccountFacade.UpdateBankAccountAsync(model);
					Messenger.AddInformation(model.Name, GlobalLocalizer.UpdateSuccess);
				}

				await hxDisplayLayout.HideAsync();

				Value.UpdateFrom(model);
				await ValueChanged.InvokeAsync(this.Value);
			}
			catch (OperationFailedException)
			{
				// NOOP - The user should be able to fix the issues and repeat the action
			}
		}

		public Task ShowAsync() => hxDisplayLayout.ShowAsync();
	}
}
