﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Havit.Data.EntityFrameworkCore.Patterns;
using Havit.Data.Patterns.DataEntries;
using Havit.Data.Patterns.Repositories;

namespace Havit.NewProjectTemplate.DataLayer.DataEntries.Crm
{
	[System.CodeDom.Compiler.GeneratedCode("Havit.Data.EntityFrameworkCore.CodeGenerator", "1.0")]
	public class ContactEntries : DataEntries<Havit.NewProjectTemplate.Model.Crm.Contact>, IContactEntries 
	{
		public Havit.NewProjectTemplate.Model.Crm.Contact Self
        {
            get
            {
				if (self == null)
				{
					self = GetEntry(Havit.NewProjectTemplate.Model.Crm.Contact.Entry.Self);
				}
				return self;
            }
        }
		private Havit.NewProjectTemplate.Model.Crm.Contact self;

		public ContactEntries(Havit.NewProjectTemplate.DataLayer.Repositories.Crm.IContactRepository repository)
			: base(repository)
		{
		}
	}
}