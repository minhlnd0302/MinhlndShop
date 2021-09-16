using Microsoft.VisualStudio.TestTools.UnitTesting;
using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Data.Repository;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        //IDbFactory dbFactory;
        //IPostCategoryRepository objRepository;
        //IUnitOfWork unitOfWork;

        [TestInitialize()]
        public void Initialize()
        {
            //dbFactory = new DbFactory();
            //objRepository = new PostCategoryRepository(dbFactory);
            //unitOfWork = new UnitOfWork(dbFactory); 
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            //PostCategory postCategory = new PostCategory();
            //postCategory.Name = "Test category";
            //postCategory.Alias = "Test category";
            //postCategory.Status = true;

            //var result = objRepository.Add(postCategory);
            //unitOfWork.CommitAsync();

            //Assert.IsNotNull(result);
            //Assert.AreEqual(1, result.ID); 
        }

    }
}
