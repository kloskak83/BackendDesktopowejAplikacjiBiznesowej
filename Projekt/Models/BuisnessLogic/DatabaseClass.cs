using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Models.Context;

namespace Projekt.Models.BuisnessLogic
{
    public class DatabaseClass
    {
        #region Fields
        protected ProjektDbContext dbContext;
        #endregion
        #region Constructor
        public DatabaseClass(ProjektDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion
    }
}
