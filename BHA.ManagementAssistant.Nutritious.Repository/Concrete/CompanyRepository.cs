using BHA.ManagementAssistant.Nutritious.Model.Context;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Repository.Concrete
{
    public class CompanyRepository: RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ManagementAssistantContext context): base(context) { }
    }
}
