﻿using NPDApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NPDApp.Forms
{
    public abstract class BaseForm : Form
    {
        protected NDPAppContext context;
        protected RepositoryFactory repositoryFactory;
        protected BaseForm()
        {
            context = new NDPAppContext();
            repositoryFactory = new RepositoryFactory(context);
        }
    }
}