using System;
using System.Collections.Generic;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious.Common.Constant
{
    public static class Connection
    {
        public const string LocalConnectionString = @"Data Source=DESKTOP-IA00J0R\SQLEXPRESS;Initial Catalog=ManagementAssistant;Integrated Security=True;";
        public const string DefaultMigrationLayer = "BHA.ManagementAssistant.Nutritious.WebApi";
    }
}
