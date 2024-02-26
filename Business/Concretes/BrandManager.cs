using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class BrandManager : IBrandService
{
    private readonly IBrandDal _brandDal;

    public BrandManager(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }
    public CreateBrandResponse Add(CreateBrandRequest createdBrandRequest)
    {
        // mapping
        Brand brand = new();
        brand.Name = createdBrandRequest.Name;

        _brandDal.Add(brand);
        CreateBrandResponse createdBrandResponse = new CreateBrandResponse();
        createdBrandResponse.Name = createdBrandRequest.Name;
        createdBrandResponse.Id = 4;
        createdBrandResponse.CreatedDate = brand.CreatedDate;

        return createdBrandResponse;
    }

    public List<GetAllBrandResponse> GetAll()
    {
       List<Brand> brands = _brandDal.GetAll();
        List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

        foreach (var item in brands)
        {
            GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
            getAllBrandResponse.Name = item.Name;
            getAllBrandResponse.Id = item.Id;
            getAllBrandResponse.CreatedDate = item.CreatedDate;

            getAllBrandResponses.Add(getAllBrandResponse);
        }
        return getAllBrandResponses;

    }
}
