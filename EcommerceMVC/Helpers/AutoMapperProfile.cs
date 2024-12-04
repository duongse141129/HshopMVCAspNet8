using AutoMapper;
using EcommerceMVC.Data;
using EcommerceMVC.ViewModels;

namespace EcommerceMVC.Helpers
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<RegisterVM, Customer>();
			
			//.ReverseMap();
		}
	}
}
