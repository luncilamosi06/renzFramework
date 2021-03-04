using AutoMapper;
using RivTech.WebService.Generic.Data.Entity;
using RivTech.WebService.Generic.DataProvider.Repository;
using RivTech.WebService.Generic.DTO;
using RivTech.WebService.Generic.Service.Exceptions;
using RivTech.WebService.Generic.Service.Services;
using System.Collections.Generic;

namespace RivTech.WebService.Generic.Service
{
    public class WeightService : IWeightService
    {
        private readonly IWeightRepository _weightRepository;
        private readonly IMapper _mapper;
        public WeightService(IWeightRepository weightRepository, IMapper mapper)
        {
            _weightRepository = weightRepository;
            _mapper = mapper;
        }

        public List<WeightDTO> GetAll()
        {
            var data = _weightRepository.FindAll();
            var result = _mapper.Map<List<WeightDTO>>(data);

            return result;
        }

        public string InsertWeight(WeightDTO model)
        {
            var data = _mapper.Map<LvWeight>(model);

            return _weightRepository.Add(data);
        }

        public WeightDTO GetWeight(byte weightId)
        {
            var data = _weightRepository.Find(weightId);
            if(data == null) throw new ModelNotFoundException("Weight record does not exists.");

            var result = _mapper.Map<WeightDTO>(data);

            return result;
        }

        public string UpdateWeight(WeightDTO model)
        {
            var data = _mapper.Map<LvWeight>(model);
            return _weightRepository.Update(data);
        }


        public string RemoveWeight(byte weightId)
        {
            return _weightRepository.Remove(weightId);
        }

    }


}
