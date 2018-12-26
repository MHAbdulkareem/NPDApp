using Moq;
using NPDApp.DataAccess;
using NPDApp.models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NPDAppTesting
{
    public class MockContext
    {
        // Declare a mock context
        Mock<NDPAppContext> mockContext;
        public MockContext()
        {
            // Mock the target context
            mockContext = new Mock<NDPAppContext>();
            // Regisgter the models in the mock context
            SetupContext();
        }

        // Property for initialising mock client data
        public static List<Client> ClientDataInitialiser { private get; set; }
        // Property for initialising mock job data
        public static List<Job> JobDataInitialiser { private get; set; }

        private void SetupContext()
        {
            // Mock the DbSet for client with initial data
            var mockClientSet = new MockDbSet<Client>(ClientDataInitialiser);
            // Mock the DbSet for job with initial data
            var mockJobSet = new MockDbSet<Job>(JobDataInitialiser);

            // Add the mock DbSets to the context
            mockContext.Setup(c => c.Set<Client>()).Returns(mockClientSet.Object);
            mockContext.Setup(j => j.Set<Job>()).Returns(mockJobSet.Object);
        }

        // Returns a mock of the target context
        public NDPAppContext Context
        {
            get { return mockContext.Object; }
        }

        // Class for mocking generic DbSet
        class MockDbSet<TEntity> : Mock<DbSet<TEntity>> where TEntity : class
        {
            // Collection for initialising and storing backstore data
            private ICollection<TEntity> BackingStore { get; set; }

            // Accept initialising data. set to null by default
            public MockDbSet(List<TEntity> backStore = null)
            {
                // Convert the backstore to an IQueryable
                BackingStore = backStore;
                var queryable = (this.BackingStore ?? (this.BackingStore = new List<TEntity>())).AsQueryable();

                // Setup the mock DbSet with the necessary return types
                As<IQueryable<TEntity>>().Setup(e => e.Provider).Returns(queryable.Provider);
                As<IQueryable<TEntity>>().Setup(e => e.Expression).Returns(queryable.Expression);
                As<IQueryable<TEntity>>().Setup(e => e.ElementType).Returns(queryable.ElementType);
                As<IQueryable<TEntity>>().Setup(e => e.GetEnumerator()).Returns(() => queryable.GetEnumerator());

                // Mock the insertion of entities
                Setup(e => e.Add(It.IsAny<TEntity>())).Returns((TEntity entity) =>
                {
                    this.BackingStore.Add(entity);

                    return entity;
                });

                // Mock the finding of entities
                Setup(x => x.Find(It.IsAny<object[]>())).Returns<object[]>(x => BackingStore.FirstOrDefault(y => y.GetType().GetProperty("ID").GetValue(y).Equals(x[0])) as TEntity);

                // TODO: Other DbSet members can be mocked, such as Remove().
            }


        }
    }
}
