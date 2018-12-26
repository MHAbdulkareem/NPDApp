using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPDApp.DataAccess;

namespace NPDAppTesting
{
    [TestClass]
    public class BaseTest
    {
        protected MockContext mockContext;
        protected RepositoryFactory repoFactory;

        public virtual void SetUp()
        {
            // Initialise the mock context
            mockContext = new MockContext();
            // Initialise the repository factory with the context
            repoFactory = new RepositoryFactory(mockContext.Context);
        }
    }
}
