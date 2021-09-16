using AutoMapper;
using MinhlndShop.API.Models;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhlndShop.API.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        //public static void Configure()
        //{
        //    Mapper.Initialize(cfg =>
        //    {
        //        cfg.CreateMap<Post, PostViewModel>();
        //        cfg.CreateMap<PostCategory, PostCategoryViewModel>();
        //        cfg.CreateMap<Tag, TagViewModel>();
        //        //cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
        //        //cfg.CreateMap<Product, ProductViewModel>();
        //        //cfg.CreateMap<ProductTag, ProductTagViewModel>();
        //        //cfg.CreateMap<Footer, FooterViewModel>();
        //        //cfg.CreateMap<Slide, SlideViewModel>();
        //        //cfg.CreateMap<Page, PageViewModel>();
        //        //cfg.CreateMap<ContactDetail, ContactDetailViewModel>();
        //        //cfg.CreateMap<ApplicationGroup, ApplicationGroupViewModel>();
        //        //cfg.CreateMap<ApplicationRole, ApplicationRoleViewModel>();
        //        //cfg.CreateMap<ApplicationUser, ApplicationUserViewModel>();
        //    });
        //}
        public AutoMapperConfiguration()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<Footer, FooterViewModel>();
            CreateMap<Slide, SlideViewModel>();
            CreateMap<Page, PageViewModel>();
            CreateMap<User, UserViewModel>(); 
        }
    }
}
