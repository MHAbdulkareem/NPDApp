﻿using NPDApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDApp.Forms
{
    public class BaseForm : Form
    {
        protected NDPAppContext context;
        protected RepositoryFactory repositoryFactory;
        public BaseForm()
        {
            context = new NDPAppContext();
            repositoryFactory = new RepositoryFactory(context);
        }
    }
}
